CREATE DATABASE IF NOT EXISTS news_app_db;
USE news_app_db;

CREATE TABLE IF NOT EXISTS role (
    role_id INT PRIMARY KEY AUTO_INCREMENT,
    role_name NVARCHAR(20)
);

CREATE TABLE IF NOT EXISTS author_contact(
    contact_id INT PRIMARY KEY AUTO_INCREMENT,
    contact_name NVARCHAR(50),
    contact_email NVARCHAR(50),
    contact_tel NVARCHAR(20)
);

CREATE TABLE IF NOT EXISTS authors (
    author_id INT PRIMARY KEY AUTO_INCREMENT,
    author_role_id INT NOT NULL,
    author_name VARCHAR(255) NOT NULL,
    author_contact_id INT NOT NULL,
    FOREIGN KEY (author_contact_id) REFERENCES author_contact(contact_id),
    FOREIGN KEY (author_role_id) REFERENCES role(role_id)
);

CREATE TABLE IF NOT EXISTS author_roles (
    author_role_id INT PRIMARY KEY AUTO_INCREMENT,
    author_id INT,
    role_id INT,
    FOREIGN KEY (author_id) REFERENCES authors(author_id),
    FOREIGN KEY (role_id) REFERENCES role(role_id)
);

DELIMITER //

CREATE PROCEDURE `add_authors`(
    IN name NVARCHAR(25),
    IN role NVARCHAR(25),
    IN contact_name NVARCHAR(50),
    IN telefon NVARCHAR(20),
    IN email NVARCHAR(50)
)
BEGIN
    -- Önce iletişim bilgilerini ekleyelim
    CALL add_contact(contact_name, telefon, email);

    -- Ardından yazarı ve iletişim bilgilerini ekleyelim
    INSERT IGNORE INTO authors (author_name, author_contact_id, author_role_id)
    VALUES (
        name, 
        (SELECT contact_id FROM author_contact WHERE contact_name = contact_name AND contact_email = email),
        (SELECT role_id FROM role WHERE role_name = role)
    );

    -- Eğer rol varsa ve yazar eklendiyse, rol ataması yapalım
    IF role IS NOT NULL THEN
        INSERT IGNORE INTO author_roles (author_id, role_id)
        VALUES (
            (SELECT author_id FROM authors WHERE author_name = name),
            (SELECT role_id FROM role WHERE role_name = role)
        );
    END IF;
END //

DELIMITER ;
