CREATE DATABASE IF NOT EXISTS db_auth_management;
USE db_auth_management;
CREATE TABLE IF NOT EXISTS users (
    user_id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(255) NOT NULL,
    password_hash VARCHAR(255) NOT NULL
);
CREATE TABLE IF NOT EXISTS user_sessions (
    session_id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT NOT NULL,
    session_token VARCHAR(255) NOT NULL,
    expiration_time TIMESTAMP NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

DELIMITER //

CREATE PROCEDURE `login`(
    IN p_username VARCHAR(255),
    IN p_password VARCHAR(255)
)
BEGIN
    DECLARE user_id INT;

    -- Kullanıcı adı ve şifreyi kontrol et
    SELECT user_id INTO user_id
    FROM users
    WHERE username = p_username AND password_hash = SHA2(p_password, 256);

    -- Eğer kullanıcı bulunursa, başarılı giriş
    IF user_id IS NOT NULL THEN
        -- Random session_token oluştur
        SET @random_token = MD5(RAND());

        -- Oturumu user_sessions tablosuna ekle
        INSERT INTO user_sessions (user_id, session_token, expiration_time)
        VALUES (user_id, @random_token, NOW() + INTERVAL 1 HOUR);  -- 1 saatlik oturum süresi örneği

        -- Oluşturulan session_token'i döndür
        SELECT @random_token AS result;
    ELSE
        SELECT 'Hatalı kullanıcı adı veya şifre' AS result;
    END IF;
END //

DELIMITER ;
DELIMITER //
CREATE PROCEDURE `add_user`(
    IN p_username VARCHAR(255),
    IN p_password VARCHAR(255)
)
BEGIN
    -- Kullanıcı adının benzersiz olup olmadığını kontrol et
    IF (SELECT COUNT(*) FROM users WHERE username = p_username) = 0 THEN
        -- Yeni kullanıcıyı ekleyin
        INSERT INTO users (username, password_hash)
        VALUES (p_username, SHA2(p_password, 256));

        SELECT 'Kullanıcı başarıyla eklendi' AS result;
    ELSE
        SELECT 'Bu kullanıcı adı zaten kullanımda' AS result;
    END IF;
END //

DELIMITER ;
