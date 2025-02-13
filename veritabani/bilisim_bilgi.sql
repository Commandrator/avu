-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: bilisim
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
-- Table structure for table `bilgi`
--

DROP TABLE IF EXISTS `bilgi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bilgi` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ad` varchar(25) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `soyad` varchar(25) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `yas` int DEFAULT NULL,
  `cinsiyet_id` binary(1) DEFAULT NULL,
  `sehir` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `ulke` varchar(30) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `maas` double DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_cinsiyet` (`cinsiyet_id`),
  CONSTRAINT `fk_cinsiyet` FOREIGN KEY (`cinsiyet_id`) REFERENCES `cinsiyet` (`cinsiyet_id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bilgi`
--

LOCK TABLES `bilgi` WRITE;
/*!40000 ALTER TABLE `bilgi` DISABLE KEYS */;
INSERT INTO `bilgi` VALUES (10,'Mehmet','Efe',22,_binary '1','Bolu','Türkiye',2000),(11,'Ayşe','Can',23,_binary '0','İstanbul','Türkiye',3500),(12,'Fatma','Ak',35,_binary '0','Ankara','Türkiye',3200),(13,'Jhon','Smith',40,_binary '1','New York','USA',3500),(14,'Ellen','Smith',40,_binary '0','New York','USA',3500),(15,'Hans','Müller',30,_binary '1','Berlin','Almanya',4000),(16,'Frank','Cesanne',35,_binary '1','Paris','Fransa',3700),(17,'Abbas','Demir',26,_binary '1','Adana','Türkiye',2000),(18,'Hatice','Topçu',26,_binary '0','Hatay','Türkiye ',2200);
/*!40000 ALTER TABLE `bilgi` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-01-10 12:20:25
