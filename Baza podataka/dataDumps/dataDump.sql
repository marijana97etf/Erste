-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: erste
-- ------------------------------------------------------
-- Server version	8.0.17

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
-- Dumping data for table `administrator`
--

LOCK TABLES `administrator` WRITE;
/*!40000 ALTER TABLE `administrator` DISABLE KEYS */;
INSERT INTO `administrator` VALUES ('marko','0851f9cb7ed5c951298d9387b06985bf8fd15f98b4e700c81cc4adeddcd8c2cd',1),('mirko','0851f9cb7ed5c951298d9387b06985bf8fd15f98b4e700c81cc4adeddcd8c2cd',2);
/*!40000 ALTER TABLE `administrator` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `grupa`
--

LOCK TABLES `grupa` WRITE;
/*!40000 ALTER TABLE `grupa` DISABLE KEYS */;
INSERT INTO `grupa` VALUES (2,16,3,'NjemackiB1.2');
/*!40000 ALTER TABLE `grupa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `jezik`
--

LOCK TABLES `jezik` WRITE;
/*!40000 ALTER TABLE `jezik` DISABLE KEYS */;
INSERT INTO `jezik` VALUES (1,'Engleski'),(2,'Njemacki'),(3,'Francuski');
/*!40000 ALTER TABLE `jezik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `kurs`
--

LOCK TABLES `kurs` WRITE;
/*!40000 ALTER TABLE `kurs` DISABLE KEYS */;
INSERT INTO `kurs` VALUES (1,'A1.1',1,'2020-01-20','2020-03-20'),(2,'A1.2',1,'2020-01-20','2020-03-20'),(3,'A2.1',1,'2020-01-20','2020-03-20'),(4,'A2.2',1,'2020-01-20','2020-03-20'),(5,'B1.1',1,'2020-01-20','2020-03-20'),(6,'B1.2',1,'2020-01-20','2020-03-20'),(7,'B2.1',1,'2020-01-20','2020-03-20'),(8,'B2.2',1,'2020-01-20','2020-03-20'),(11,'A1.1',2,'2020-01-20','2020-03-20'),(12,'A1.2',2,'2020-01-20','2020-03-20'),(13,'A2.1',2,'2020-01-20','2020-03-20'),(14,'A2.2',2,'2020-01-20','2020-03-20'),(15,'B1.1',2,'2020-01-20','2020-03-20'),(16,'B1.2',2,'2020-01-20','2020-03-20'),(17,'B2.1',2,'2020-01-20','2020-03-20'),(18,'B2.2',2,'2020-01-20','2020-03-20'),(19,'C1.1',2,'2020-01-20','2020-03-20'),(20,'C1.2',2,'2020-01-20','2020-03-20'),(21,'A1.1',3,'2020-01-20','2020-03-20'),(22,'A1.2',3,'2020-01-20','2020-03-20'),(23,'A2.1',3,'2020-01-20','2020-03-20'),(24,'A2.2',3,'2020-01-20','2020-03-20');
/*!40000 ALTER TABLE `kurs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `kurs_polaznik_na_cekanju`
--

LOCK TABLES `kurs_polaznik_na_cekanju` WRITE;
/*!40000 ALTER TABLE `kurs_polaznik_na_cekanju` DISABLE KEYS */;
INSERT INTO `kurs_polaznik_na_cekanju` VALUES (7,3),(8,3);
/*!40000 ALTER TABLE `kurs_polaznik_na_cekanju` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `osoba`
--

LOCK TABLES `osoba` WRITE;
/*!40000 ALTER TABLE `osoba` DISABLE KEYS */;
INSERT INTO `osoba` VALUES (1,'Marko','Markovic','065/000-000','marko.markovic@mail.com'),(2,'Mirko','Mirkovic','065/000-000','mirko.mirkovic@mail.com'),(3,'Nikola','Nikolic','065/000-000','nikola.nikolic@mail.com'),(4,'Jovan','Jovanovic','065/000-000','jovan.jovanovic@mail.com'),(5,'Jovana','Jovanovic','065/000-000','jovana.jovanovic'),(6,'Mira','Mirkovic','065/000-000','mira.mirkovic'),(7,'Marko','Maric','065/123-456','marko.maric@gmail.com'),(8,'Nedjeljko','Milinkovic','065/123-665','nedjeljko.milinkovic@gmail.com'),(9,'Milica','Ilic','051/243-666','milica.ilic@gmail.com'),(10,'Ranko','Stanic','064/222-432','ranko.stanic@gmail.com'),(11,'Milorad','Radic','064/123-222','milorad.radic@gmail.com');
/*!40000 ALTER TABLE `osoba` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `polaznik`
--

LOCK TABLES `polaznik` WRITE;
/*!40000 ALTER TABLE `polaznik` DISABLE KEYS */;
INSERT INTO `polaznik` VALUES (7),(8),(9),(10),(11);
/*!40000 ALTER TABLE `polaznik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `polaznik_grupa`
--

LOCK TABLES `polaznik_grupa` WRITE;
/*!40000 ALTER TABLE `polaznik_grupa` DISABLE KEYS */;
INSERT INTO `polaznik_grupa` VALUES (9,2),(10,2),(11,2);
/*!40000 ALTER TABLE `polaznik_grupa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `polaznik_na_cekanju`
--

LOCK TABLES `polaznik_na_cekanju` WRITE;
/*!40000 ALTER TABLE `polaznik_na_cekanju` DISABLE KEYS */;
INSERT INTO `polaznik_na_cekanju` VALUES (7),(8);
/*!40000 ALTER TABLE `polaznik_na_cekanju` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `profesor`
--

LOCK TABLES `profesor` WRITE;
/*!40000 ALTER TABLE `profesor` DISABLE KEYS */;
INSERT INTO `profesor` VALUES (5),(6);
/*!40000 ALTER TABLE `profesor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `profesor_grupa`
--

LOCK TABLES `profesor_grupa` WRITE;
/*!40000 ALTER TABLE `profesor_grupa` DISABLE KEYS */;
INSERT INTO `profesor_grupa` VALUES (6,2);
/*!40000 ALTER TABLE `profesor_grupa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `sluzbenik`
--

LOCK TABLES `sluzbenik` WRITE;
/*!40000 ALTER TABLE `sluzbenik` DISABLE KEYS */;
INSERT INTO `sluzbenik` VALUES ('nikola','0851f9cb7ed5c951298d9387b06985bf8fd15f98b4e700c81cc4adeddcd8c2cd',3),('jovan','0851f9cb7ed5c951298d9387b06985bf8fd15f98b4e700c81cc4adeddcd8c2cd',4);
/*!40000 ALTER TABLE `sluzbenik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `termin`
--

LOCK TABLES `termin` WRITE;
/*!40000 ALTER TABLE `termin` DISABLE KEYS */;
INSERT INTO `termin` VALUES (2,'Utorak','20:00:00','21:00:00',2);
/*!40000 ALTER TABLE `termin` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-02-21  4:30:34
