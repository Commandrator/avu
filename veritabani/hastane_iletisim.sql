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
-- Table structure for table `iletisim`
--

DROP TABLE IF EXISTS `iletisim`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `iletisim` (
  `kimlik_numarasi` bigint NOT NULL,
  `telefon` int DEFAULT NULL,
  `eposta` varchar(60) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `adres_id` int DEFAULT NULL,
  PRIMARY KEY (`kimlik_numarasi`),
  KEY `FK_adres_01` (`adres_id`),
  CONSTRAINT `FK_adres_01` FOREIGN KEY (`adres_id`) REFERENCES `adres` (`adres_id`),
  CONSTRAINT `FK_kimlik_01` FOREIGN KEY (`kimlik_numarasi`) REFERENCES `kimlik` (`kimlik_numarasi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `iletisim`
--

LOCK TABLES `iletisim` WRITE;
/*!40000 ALTER TABLE `iletisim` DISABLE KEYS */;
INSERT INTO `iletisim` VALUES (10089036546,2129423432,'',2),(14968837028,2147483647,'',6),(16079503854,2147483647,'mail@eymenbilir.com',5),(23578313754,2147483647,'',3),(27228623170,2147483647,'',4),(30559428376,2147483647,'',3),(34334447316,2147483647,'',2),(43143394506,2147483647,'',8),(52655360596,2120994553,'nasanur96@submain.com',7),(54423167192,2147483647,'yusug54@mail.com',6),(62036068898,2147483647,'',2),(85578994678,2147483647,'mail@buguyildirim.com',6),(89680877980,2147483647,'beyza8980@no-gmail.com',7),(91448936532,2147483647,'',1);
/*!40000 ALTER TABLE `iletisim` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-09-29 23:40:17
