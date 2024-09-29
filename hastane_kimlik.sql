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
-- Table structure for table `kimlik`
--

DROP TABLE IF EXISTS `kimlik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kimlik` (
  `ad` varchar(25) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `soyad` varchar(25) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `kimlik_numarasi` bigint NOT NULL,
  `seri_no` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `aile_sira_no` int DEFAULT NULL,
  `dogum_tarihi` datetime DEFAULT NULL,
  `anne_adi` varchar(25) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `baba_adi` varchar(25) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  PRIMARY KEY (`kimlik_numarasi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kimlik`
--

LOCK TABLES `kimlik` WRITE;
/*!40000 ALTER TABLE `kimlik` DISABLE KEYS */;
INSERT INTO `kimlik` VALUES ('talha','yaşar',10089036546,'D32DW03EIKDQ03E',123,'2003-02-09 00:00:00','MİNE','MEHMET'),('Nefise','Dere',14968837028,'43DIGUGUIUHUGUG7',127,'2001-06-23 00:00:00','Mine','Mehmet'),('Eymen','Bilir',16079503854,'FK0I5GIKOLSR04IFP',433,'1975-09-30 00:00:00','Sultan','Osman'),('Ahmet','Velioğlu',20057463963,'ST7TKKKKJDI4',188,'1967-09-19 00:00:00','Hafize','Eyyüp'),('Zehra','Çelik',23578313754,'5K07KHR0I59TU9R48HF',14,'1979-11-23 00:00:00','Elmas','Mehmet'),('Mehmet','Tanrıverdi',27228623170,'RW3RW3RHY5EIS3E434R',134,'1955-04-13 00:00:00','Meryem','İbrahim'),('Muhammed','Dağ',30559428376,'4EDY46RGW87GRRYFGF7',154,'1953-11-23 00:00:00','Şerife','İsmail'),('Buğu','Yıldırım',34334447316,'Y7Y7I8UU8U8Y8IYYI8',964,'1977-11-14 00:00:00','Mine','Alper'),('Elmas','Dere',43143394506,'JCIWOU94UUFHNHF940W',12,'1984-07-15 00:00:00','Makbule','Mehmet'),('Nisanur','Şahin',52655360596,'E2ET5Y78JSD0OFER0RT',27,'1966-04-19 00:00:00','Naz','Taha'),('Yusuf','Kılıç',54423167192,'AAD7S84UFS04RIS4RFJ',154,'1987-11-05 00:00:00','Fatma','Mehmet'),('Emirhan','Özdemir',62036068898,'R43FW4R4W3RF5E4RA4',645,'1968-06-19 00:00:00','Zehra','Murat'),('Elif','Öztürk',85578994678,'R4RHJU8IKU8KUKH8H',875,'1954-12-05 00:00:00','Emine','Mustafa'),('Beyza','Aydin',89680877980,'F45RSAKOKE03KR4RR',54,'1989-03-18 00:00:00','Ayfer','Muhammet'),('Yağmur','İnan',91448936532,'K9DFJ9FJSR0934RKFW',974,'1973-06-06 00:00:00','Nezaket','Mehmet');
/*!40000 ALTER TABLE `kimlik` ENABLE KEYS */;
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
