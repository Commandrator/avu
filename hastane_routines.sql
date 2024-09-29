-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: hastane
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping events for database 'hastane'
--

--
-- Dumping routines for database 'hastane'
--
/*!50003 DROP PROCEDURE IF EXISTS `Hasta Kayıt test#1` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Hasta Kayıt test#1`(
	-- kimlik
	in Ad nvarchar(25),
    in Soyad nvarchar(25),
    in kimlik_numarasi BIGINT,
    in Seri_no nvarchar(255),
    in Aile_Sira_no int,
    in Dogum_Tarihi datetime,
    in Anne_Adi nvarchar(25),
    in Baba_Adi nvarchar(25),
    -- iletişim
    in telefon BIGINT,
    in eposta nvarchar(60),
    in ulke nvarchar(25),
    in sehir nvarchar(25),
    in ilce nvarchar(25),
    in acik_Adres TEXT,
    in posta_kodu int,
    in adres_id int
)
BEGIN
/*select kimlik.ad, kimlik.soyad, iletisim.telefon from kimlik, iletisim
	where kimlik.ad=Ad and kimlik.soyad=Soyad OR kimlik.kimlik_numarasi=kimlik_numarasi
    ;*/	
    insert ignore into `kimlik` (`ad`, `soyad`, `kimlik_numarasi`, `seri_no`, `aile_sira_no`, `dogum_tarihi`, `anne_adi`, `baba_adi`)
		VALUES (Ad,Soyad,kimlik_numarasi,Seri_no,Aile_Sira_no,Dogum_Tarihi,Anne_Adi,Baba_Adi);

    insert ignore into `adres` (`adres_id`,`ulke`,`sehir`,`ilce`,`acik_adres`,`posta_kodu`) VALUES (
    (select adres.adres_id from adres
	where adres.adres_id=adres_id OR 
		  adres.ulke=ulke and
          adres.sehir=sehir and
          adres.ilce=ilce and
          adres.acik_adres=acik_Adres and
          adres.posta_kodu=posta_kodu), ulke, sehir, ilce, acik_Adres, posta_kodu);
    insert ignore into `iletisim` (`kimlik_numarasi`, `telefon`, `eposta`, `adres_id`) 
		VALUES (kimlik_numarasi,telefon,eposta, 
			(select adres.adres_id from adres
				where adres.adres_id=adres_id OR 
					  adres.ulke=ulke and
						adres.sehir=sehir and
						adres.ilce=ilce and
						adres.acik_adres=acik_Adres and
						adres.posta_kodu=posta_kodu)
            );
	END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `kan_grubu_bul` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `kan_grubu_bul`(
	in kan_grubu char(4)
)
begin
select kimlik.ad, kimlik.soyad, kan_grubu.kan_grubu, iletisim.telefon
	from kimlik, kan_grubu, genel, iletisim
    where iletisim.kimlik_numarasi=kimlik.kimlik_numarasi
		and genel.kimlik_numarasi=kimlik.kimlik_numarasi
		and kan_grubu.kan_grubu_id=genel.kan_grubu_id
		and kan_grubu.kan_grubu=kan_grubu;
end ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-01-10 12:20:31
