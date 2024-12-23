-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: servicedeskv2
-- ------------------------------------------------------
-- Server version	8.0.40

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
-- Table structure for table `_user`
--

DROP TABLE IF EXISTS `_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `_user` (
  `id` int NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `surname` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `login` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `email` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `departament` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `permissions` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `tel` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Ban` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `_user`
--

LOCK TABLES `_user` WRITE;
/*!40000 ALTER TABLE `_user` DISABLE KEYS */;
INSERT INTO `_user` VALUES (1,'Adam','Adam','Adam','adam@domena.com','3linnia','Global-admin','+48777777777',0),(2,'Adam','Nowak','adam.nowak','adam.nowak@example.com','1 linia','Technician','123456789',0),(3,'Ewa','Kowalska','ewa.kowalska','ewa.kowalska@example.com','2 linia','Technician','987654321',0),(4,'Marek','Zieliński','marek.zielinski','marek.zielinski@example.com','3 linia','Technician','564738291',1),(5,'Kasia','Wójcik','kasia.wojcik','kasia.wojcik@example.com','1 linia','Technician','112233445',0),(6,'Jan','Pawlak','jan.pawlak','jan.pawlak@example.com','2 linia','Technician','667788990',0),(7,'Julia','Mazur','julia.mazur','julia.mazur@example.com','3 linia','Technician','773344556',0),(8,'Piotr','Kaczmarek','piotr.kaczmarek','piotr.kaczmarek@example.com','1 linia','Technician','998877665',1),(9,'Karolina','Szymańska','karolina.szymanska','karolina.szymanska@example.com','2 linia','Technician','334455667',0),(10,'Łukasz','Jankowski','lukasz.jankowski','lukasz.jankowski@example.com','3 linia','Technician','556677889',0),(11,'Michał','Kwiatkowski','michal.kwiatkowski','michal.kwiatkowski@example.com','1 linia','Technician','223344556',1),(12,'Anna','Wielka','anna.wielka','anna.wielka@example.com','2 linia','Technician','445566778',0),(13,'Tomasz','Chmiel','tomasz.chmiel','tomasz.chmiel@example.com','3 linia','Technician','889900112',0),(14,'Zofia','Kozłowska','zofia.kozlowska','zofia.kozlowska@example.com','1 linia','Technician','110233445',0),(15,'Patryk','Mazurek','patryk.mazurek','patryk.mazurek@example.com','2 linia','admin','223366778',0),(16,'Monika','Wróbel','monika.wrobel','monika.wrobel@example.com','3 linia','Technician','556677889',0);
/*!40000 ALTER TABLE `_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reports`
--

DROP TABLE IF EXISTS `reports`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reports` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `_user` text COLLATE utf8mb4_general_ci,
  `location` text COLLATE utf8mb4_general_ci,
  `title` text COLLATE utf8mb4_general_ci,
  `description` text COLLATE utf8mb4_general_ci,
  `technican` text COLLATE utf8mb4_general_ci,
  `status` text COLLATE utf8mb4_general_ci,
  `date_of_sla` date DEFAULT NULL,
  `company_name` text COLLATE utf8mb4_general_ci,
  `telephone_number` varchar(13) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `start_date` date DEFAULT NULL,
  `end_date` date DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reports`
--

LOCK TABLES `reports` WRITE;
/*!40000 ALTER TABLE `reports` DISABLE KEYS */;
INSERT INTO `reports` VALUES (1,'adam.nowak','Warszawa','Problemy z siecią','Nie możemy połączyć się z siecią. Proszę o natychmiastową interwencję','Jan Kowalski','Open','2024-12-15','Firma A','123456789','2024-12-15','2024-12-16'),(2,'piotr.kaczmarek','Poznań','Awaria serwera bazy danych','Serwer bazy danych przestał odpowiadać. Wymagana naprawa','Marek Zieliński','In Progress','2024-12-16','Firma B','234567890','2024-12-16','2024-12-17'),(3,'kasia.wojcik','Wrocław','Problem z aktualizacją oprogramowania','Po zainstalowaniu najnowszej wersji oprogramowania wystąpiły problemy','Julia Mazur','Resolved','2024-12-17','Firma C','345678901','2024-12-17','2024-12-18'),(4,'jan.pawlak','Gdańsk','Zgłoszenie dotyczące awarii komputera','Komputer nie uruchamia się, potrzebna pomoc przy diagnozowaniu problemu','Piotr Kaczmarek','Closed','2024-12-18','Firma D','456789012','2024-12-18','2024-12-19'),(5,'julia.mazur','Szczecin','Problemy z dostępem do VPN','Użytkownik nie może się połączyć przez VPN. Proszę o pomoc','Tomasz Chmiel','In Progress','2024-12-19','Firma E','567890123','2024-12-19','2024-12-20'),(6,'adam.nowak','Warszawa','Problemy z dyskiem twardym','Dysk twardy przestał działać, potrzebna jest naprawa','Anna Wróbel','Open','2024-12-20','Firma F','678901234','2024-12-20','2024-12-21'),(7,'piotr.kaczmarek','Kraków','Błąd w systemie operacyjnym','Po aktualizacji systemu pojawił się błąd krytyczny','Patryk Mazurek','In Progress','2024-12-21','Firma G','789012345','2024-12-21','2024-12-22'),(8,'kasia.wojcik','Łódź','Awaria sprzętu komputerowego','Zepsuty laptop, nie włącza się. Potrzebna diagnoza','Marek Zieliński','Resolved','2024-12-22','Firma H','890123456','2024-12-22','2024-12-23'),(9,'jan.pawlak','Poznań','Zgłoszenie dotyczące routera','Router nie działa prawidłowo. Konieczna jest wymiana lub konfiguracja','Julia Mazur','Closed','2024-12-23','Firma I','901234567','2024-12-23','2024-12-24'),(10,'julia.mazur','Kraków','Awaria zasilania','Komputer nie włącza się po zaniku prądu, proszę o pomoc','Piotr Kaczmarek','Open','2024-12-24','Firma J','123456789','2024-12-24','2024-12-25'),(11,'adam.nowak','Wrocław','Zgłoszenie o problemach z aplikacją','Aplikacja przestała działać, wymaga restartu lub naprawy','Tomasz Chmiel','In Progress','2024-12-25','Firma K','234567890','2024-12-25','2024-12-26'),(12,'piotr.kaczmarek','Warszawa','Awaria laptopa','Laptop nie uruchamia się po włączeniu, potrzebna diagnoza','Anna Wróbel','Closed','2024-12-26','Firma L','345678901','2024-12-26','2024-12-27'),(13,'kasia.wojcik','Szczecin','Problem z siecią Wi-Fi','Brak sygnału Wi-Fi w biurze, wymagana konfiguracja routera','Patryk Mazurek','Open','2024-12-27','Firma M','456789012','2024-12-27','2024-12-28'),(14,'jan.pawlak','Gdańsk','Problem z drukarką','Drukarka nie drukuje, potrzeba naprawy lub ponownej konfiguracji','Marek Zieliński','In Progress','2024-12-28','Firma N','567890123','2024-12-28','2024-12-29');
/*!40000 ALTER TABLE `reports` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resources`
--

DROP TABLE IF EXISTS `resources`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `resources` (
  `id` int DEFAULT NULL,
  `brand` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `model` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `SerialNumber` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Registration_Number` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `assignment` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `category` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resources`
--

LOCK TABLES `resources` WRITE;
/*!40000 ALTER TABLE `resources` DISABLE KEYS */;
INSERT INTO `resources` VALUES (1,'Dell','XPS 13','SN12345678','REG123456','Company A','Laptop'),(2,'HP','EliteBook 840','SN22345678','REG223456','Company B','Laptop'),(3,'Apple','MacBook Pro','SN32345678','REG323456','Company C','Laptop'),(4,'Lenovo','ThinkPad X1','SN42345678','REG423456','Company D','Laptop'),(5,'Acer','Predator Helios','SN52345678','REG523456','Company E','Laptop'),(6,'Asus','ZenBook','SN62345678','REG623456','Company F','Laptop'),(7,'Samsung','Galaxy Book','SN72345678','REG723456','Company G','Laptop'),(8,'Microsoft','Surface Laptop','SN82345678','REG823456','Company H','Laptop'),(9,'Lenovo','ThinkPad T14','SN92345678','REG923456','Company I','Laptop'),(10,'Dell','Latitude 7400','SN102345678','REG1023456','Company J','Laptop'),(11,'Cisco','Catalyst 9300','SN112345678','REG1123456','Company K','Router'),(12,'Juniper','MX960','SN122345678','REG1223456','Company L','Router'),(13,'Arista','7050X','SN132345678','REG1323456','Company M','Router'),(14,'Huawei','NE40E','SN142345678','REG1423456','Company N','Router'),(15,'MikroTik','CCR1009','SN152345678','REG1523456','Company O','Router'),(16,'Netgear','Nighthawk X6','SN162345678','REG1623456','Company P','Router'),(17,'Ubiquiti','EdgeRouter 4','SN172345678','REG1723456','Company Q','Router'),(18,'TP-Link','Archer C7','SN182345678','REG1823456','Company R','Router'),(19,'Zyxel','USG 40','SN192345678','REG1923456','Company S','Router'),(20,'Linksys','WRT3200ACM','SN202345678','REG2023456','Company T','Router'),(21,'HP','ProLiant DL380 Gen10','SN212345678','REG2123456','Company U','Server'),(22,'Dell','PowerEdge R740','SN222345678','REG2223456','Company V','Server'),(23,'Lenovo','ThinkSystem SR650','SN232345678','REG2323456','Company W','Server'),(24,'Cisco','UCS C220 M5','SN242345678','REG2423456','Company X','Server'),(25,'Supermicro','X11SCL-F','SN252345678','REG2523456','Company Y','Server'),(26,'Fujitsu','PRIMERGY RX2540 M5','SN262345678','REG2623456','Company Z','Server'),(27,'Huawei','FusionServer Pro 2288H V5','SN272345678','REG2723456','Company AA','Server'),(28,'IBM','Power System S924','SN282345678','REG2823456','Company AB','Server'),(29,'Oracle','SPARC T8-1','SN292345678','REG2923456','Company AC','Server'),(30,'Hewlett Packard','Cloudline CL3100','SN302345678','REG3023456','Company AD','Server'),(31,'Apple','iMac 24','SN312345678','REG3123456','Company AE','Desktop'),(32,'Dell','OptiPlex 7070','SN322345678','REG3223456','Company AF','Desktop'),(33,'Lenovo','ThinkCentre M920','SN332345678','REG3323456','Company AG','Desktop'),(34,'HP','Pavilion 24','SN342345678','REG3423456','Company AH','Desktop'),(35,'Asus','ExpertCenter D7','SN352345678','REG3523456','Company AI','Desktop'),(36,'Acer','Veriton X','SN362345678','REG3623456','Company AJ','Desktop'),(37,'MSI','PRO 24X 10M','SN372345678','REG3723456','Company AK','Desktop'),(38,'Samsung','Galaxy Book 2','SN382345678','REG3823456','Company AL','Desktop'),(39,'Razer','Razer Blade 15','SN392345678','REG3923456','Company AM','Desktop'),(40,'Alienware','Aurora R13','SN402345678','REG4023456','Company AN','Desktop'),(41,'Apple','iPhone 13','SN412345678','REG4123456','Company AO','Mobile'),(42,'Samsung','Galaxy S21','SN422345678','REG4223456','Company AP','Mobile'),(43,'Google','Pixel 6','SN432345678','REG4323456','Company AQ','Mobile'),(44,'OnePlus','9 Pro','SN442345678','REG4423456','Company AR','Mobile'),(45,'Xiaomi','Mi 11','SN452345678','REG4523456','Company AS','Mobile'),(46,'Motorola','Edge 20','SN462345678','REG4623456','Company AT','Mobile'),(47,'Nokia','X20','SN472345678','REG4723456','Company AU','Mobile'),(48,'Sony','Xperia 5 II','SN482345678','REG4823456','Company AV','Mobile'),(49,'Huawei','P40 Pro','SN492345678','REG4923456','Company AW','Mobile'),(50,'LG','V60 ThinQ','SN502345678','REG5023456','Company AX','Mobile');
/*!40000 ALTER TABLE `resources` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_requests`
--

DROP TABLE IF EXISTS `user_requests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_requests` (
  `id` int NOT NULL AUTO_INCREMENT,
  `Imie` varchar(50) DEFAULT NULL,
  `Nazwisko` varchar(50) DEFAULT NULL,
  `Login` varchar(100) GENERATED ALWAYS AS (concat(`Imie`,_utf8mb4'.',`Nazwisko`)) VIRTUAL,
  `Haslo` varchar(100) DEFAULT NULL,
  `kolumna_dat` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_requests`
--

LOCK TABLES `user_requests` WRITE;
/*!40000 ALTER TABLE `user_requests` DISABLE KEYS */;
INSERT INTO `user_requests` (`id`, `Imie`, `Nazwisko`, `Haslo`, `kolumna_dat`) VALUES (1,'Jan','Kowalski',NULL,'2023-03-30 00:00:00'),(2,'Anna','Nowak',NULL,'2023-03-17 00:00:00'),(3,'Michał','Wiśniewski',NULL,'2023-04-20 00:00:00'),(4,'Marta','Dąbrowski',NULL,'2023-11-21 00:00:00'),(5,'Jakub','Lewandowski',NULL,'2023-07-18 00:00:00'),(6,'Ola','Kocoń',NULL,'2023-01-19 00:00:00'),(7,'Filip','Kaszewiak',NULL,'2023-08-14 00:00:00'),(8,'Mariusz','Dzwon',NULL,'2023-12-10 00:00:00'),(9,'Izabela','Łęczycka',NULL,'2023-11-10 00:00:00'),(10,'Aleksandra','Bednarczyk',NULL,'2023-06-22 00:00:00'),(11,'Marion','Dudu',NULL,'2023-10-11 00:00:00'),(12,'Anna','Nowaaaa',NULL,'2023-06-20 00:00:00'),(13,'Ola','Jola',NULL,'2023-01-05 00:00:00'),(14,'Dawid','Kaz','LALALALALALALA','2023-08-27 00:00:00'),(15,'Mateusz','Gośliński','Aaskdjban cauy',NULL),(16,NULL,NULL,NULL,'2024-11-13 22:00:00');
/*!40000 ALTER TABLE `user_requests` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-12-23 23:11:31
