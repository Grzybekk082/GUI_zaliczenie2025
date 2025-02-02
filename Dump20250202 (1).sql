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
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `surname` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `login` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `departament` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `permissions` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `tel` double DEFAULT NULL,
  `email` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci GENERATED ALWAYS AS (lower(concat(`name`,_utf8mb4'.',`surname`,_utf8mb4'@domain.pl'))) STORED COMMENT 'lower(concat(`name`,_utf8mb4''.'',`surname`,_utf8mb4''@domain.pl''))',
  `password` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `new_password` varchar(100) COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `_user`
--

LOCK TABLES `_user` WRITE;
/*!40000 ALTER TABLE `_user` DISABLE KEYS */;
INSERT INTO `_user` (`id`, `name`, `surname`, `login`, `departament`, `permissions`, `tel`, `password`, `new_password`) VALUES (1,'Adam','Adam','Adam','3linnia','Global-admin',48777777777,'2rSg1t:)',NULL),(2,'Adam','Nowak','adam.nowak','1 linia','Technician',123456789,']N@(*7Kp',NULL),(3,'Ewa','Kowalska','ewa.kowalska','2 linia','Technician',987654321,'h%–L5!nb',NULL),(4,'Marek','Zieliński','marek.zielinski','3 linia','Technician',564738291,'@Uk6I>1b',NULL),(5,'Kasia','Wójcik','kasia.wojcik','1 linia','Technician',112233445,'13j=K}UX',NULL),(6,'Jan','Pawlak','jan.pawlak','2 linia','Technician',667788990,'yO\\W?oU4',NULL),(7,'Julia','Mazur','julia.mazur','3 linia','Technician',773344556,'I$WC<34s',NULL),(8,'Piotr','Kaczmarek','piotr.kaczmarek','1 linia','Technician',998877665,'Onomatopeja12',NULL),(9,'Karolina','Szymańska','karolina.szymanska','2 linia','Technician',334455667,'#vHSc6tA',NULL),(10,'Łukasz','Jankowski','lukasz.jankowski','3 linia','Technician',556677889,'R+d4FaN9',NULL),(11,'Michał','Kwiatkowski','michal.kwiatkowski','1 linia','Technician',223344556,'Nowenowe123',NULL),(12,'Anna','Wielka','anna.wielka','2 linia','Technician',445566778,'{o(Q6WZ/',NULL),(13,'Tomasz','Chmiel','tomasz.chmiel','3 linia','Technician',889900112,'Nowehaslo1234',NULL),(14,'Zofia','Kozłowska','zofia.kozlowska','1 linia','Technician',110233445,'JT4/L7Zs',NULL),(15,'Patryk','Mazurek','patryk.mazurek','2 linia','admin',223366778,'F7–X:rj9',NULL),(16,'Monika','Wróbel','monika.wrobel','3 linia','Technician',556677889,'.3Q0zph?',NULL),(17,'Mariusz','Dzwon','Mariusz.Dzwon','3 linia','Technican',123456789,'#h?:U]5H',NULL),(18,'Anna','Nowaaaa','Anna.Nowaaaa','1 linia','Technican',987654321,'>0rMNc~t',NULL),(19,'Filip','Kaszewiak','Filip.Kaszewiak','2 linia','Technican',11448,'Onomatopeja',NULL),(20,'Aleksandra','Bednarczyk','Aleksandra.Bednarczyk','2 linia','Technican',147852369,'&O.V1gD+',NULL),(21,'Mateusz','Gośliński','Mateusz.Gośliński','1 linia','Technican',951236547,'+s#<Mg0S',NULL),(22,'Dawid','Kaz','Dawid.Kaz','3 linia','Technican',555666999,'JsD)3E1d',NULL),(23,'Marion','Dudu','Marion.Dudu','2 linia','Technican',147852369,'%da)8qTf',NULL),(24,'','','admin','3 linia','admin',0,'admin',NULL),(25,'Filip','Kaczor','Filip.Kaczor','3 linia','Technican',95123654789,'KIJBvsdhiflvs',NULL),(26,'Piotr','Kaczmarek','piotr.kaczmarek','1 linia','Technician',978643683,' fa%71hM%',NULL),(27,'Kamil','Kowalczuk','kamil.kowalczuk','1 linia','Technician',444987654,'D\\~j=c9L',NULL),(28,'Jacek','Jankowski','jacek.jankowski','1 linia','Technician',111223344,'@Mxa7cxl',NULL),(29,'Magdalena','Sowa','magdalena.sowa','1 linia','Technician',555987654,'Yr.!>z1D',NULL),(30,'Aleksandra','Nowak','aleksandra.nowak','1 linia','Technician',777123456,'h1&}We#=',NULL),(31,'Grzegorz','Kaczmarek','grzegorz.kaczmarek','1 linia','Technician',555123987,' dn}Z31kS',NULL),(32,'Monika','Lipska','monika.lipska','1 linia','Technician',333222444,' !:Kj<v0B',NULL),(33,'Anna','Kwiatkowska','anna.kwiatkowska','1 linia','Technician',123456789,' ()G2C(v\\',NULL),(34,'Tomek','Woźniak','tomek.woźniak','1 linia','Technician',555666777,' )p]DV.48',NULL),(35,'Karolina','Duda','karolina.duda','1 linia','Technician',987654321,' u]e)8Z@<',NULL),(36,'Piotr','Woźniak','piotr.woźniak','1 linia','Technician',888555444,' T%s9phEj',NULL),(37,'Piotr','Nawrocki','piotr.nawrocki','1 linia','Technician',777123555,' Ue@w>h7P',NULL),(38,'Dawid','Nowak','dawid.nowak','1 linia','Technician',333111555,' 9zf*5O+s',NULL),(39,'Martyna','Woźniak','martyna.woźniak','1 linia','Technician',111223444,' b7AcvP2>',NULL),(40,'Katarzyna','Woźniak','katarzyna.woźniak','1 linia','Technician',666777888,' 9!Sv]S:v',NULL),(41,'Julian','Pawlak','julian.pawlak','1 linia','Technician',444555777,' }37wN*F–',NULL),(42,'Krzysztof','Kaczmarek','krzysztof.kaczmarek','1 linia','Technician',123987654,' []RlDB1(',NULL),(43,'Monika','Kwiatkowska','monika.kwiatkowska','1 linia','Technician',555666777,' UtFk$&2x',NULL),(44,'Joanna','Kowalska','joanna.kowalska','1 linia','Technician',222333444,' 16J)vAF@',NULL),(45,'Pawel','Nowak','pawel.nowak','1 linia','Technician',333444555,'\\87Cp(5>',NULL),(46,'Magdalena','Woźniak','magdalena.woźniak','1 linia','Technician',444777888,'0+\\^Cvsv',NULL),(47,'Grzegorz','Kwiatkowski','grzegorz.kwiatkowski','1 linia','Technician',777888999,' wZO}d8?k',NULL),(48,'Dorota','Nowak','dorota.nowak','1 linia','Technician',555666333,' 7^!ZKHaF',NULL),(49,'Kamil','Jaworski','Kamil.Jaworski','2 linia','Technican',445566778,'U[D00\\li',NULL),(50,'Grzegorz','Kowalczyk','Grzegorz.Kowalczyk','2 linia','Technican',556677889,'PR4z}_Tx',NULL),(51,'Tomasz','Zieliński','Tomasz.Zielinski','2 linia','Technican',667788990,'ZpdXH0,s',NULL),(52,'Rafał','Piątek','Rafal.Piatek','2 linia','Technican',778899001,'g~jc5E}.',NULL),(53,'Marek','Jasiński','Marek.Jasinski','2 linia','Technican',889900112,'1z,z_L7$',NULL),(54,'Paweł','Kwiatkowski','Pawel.Kwiatkowski','2 linia','Technican',990011223,'U]7]=9iy',NULL),(55,'Wojciech','Nowak','Wojciech.Nowak','2 linia','Technican',101112223,'q]7SW+l8',NULL),(56,'Ewa','Kowalska','Ewa.Kowalska','2 linia','Technican',112233445,'31o:OGrJ',NULL),(57,'Piotr','Szymański','Piotr.Szymanski','2 linia','Technican',223344556,'ccWNW?7n',NULL),(58,'Alicja','Nowak','Alicja.Nowak','2 linia','Technican',334455667,'~/vK3Ui{',NULL),(59,'Kamil','Piątek','Kamil.Piatek','2 linia','Technican',445566778,'QCbM)oB7',NULL),(60,'Marta','Kowalska','Marta.Kowalska','2 linia','Technican',556677889,'SF9M,5Oz',NULL),(61,'Patryk','Wójcik','Patryk.Wojcik','2 linia','Technican',667788990,'yzS:.R1r',NULL),(62,'Tomasz','Pawlak','Tomasz.Pawlak','2 linia','Technican',778899001,'R_9G}1)j',NULL),(63,'Piotr','Wiśniewski','Piotr.Wisniewski','2 linia','Technican',889900112,'}K6vjP[2',NULL),(64,'Rafał','Zieliński','Rafal.Zielinski','2 linia','Technican',990011223,'UN(0(Kkv',NULL),(65,'Piotr','Pawlak','Piotr.Pawlak','2 linia','Technican',101112223,'dgD5;U)Z',NULL),(66,'Krzysztof','Nowak','Krzysztof.Nowak','2 linia','Technican',112233445,'=0PQq]KJ',NULL),(67,'Marek','Piątek','Marek.Piatek','2 linia','Technican',223344556,'91*gXl5j',NULL),(68,'Izabela','Łęczycka','izabela.łęczycka','2 linia','Technican',123698745,'LOPJF1234d',NULL),(69,'Jalanta','Karoń','jalanta.karoń','1 linia','Technican',123456789,'Onomatopeja',NULL);
/*!40000 ALTER TABLE `_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reports`
--

DROP TABLE IF EXISTS `reports`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reports` (
  `Id` int NOT NULL,
  `_user` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `location` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Street` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `title` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  `technican` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `status` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `company_name` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `telephone_number` varchar(13) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `start_date` date DEFAULT NULL,
  `create_date` datetime DEFAULT NULL,
  `date_of_sla` datetime DEFAULT NULL,
  `priorytet` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `end_date` datetime DEFAULT NULL,
  `ID_protocol` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Protocol` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reports`
--

LOCK TABLES `reports` WRITE;
/*!40000 ALTER TABLE `reports` DISABLE KEYS */;
INSERT INTO `reports` VALUES (1,'adam.nowak','Warszawa','Trocka 18','Problemy z siecią','Mam problem z internetem. Połączenie często przerywa, a prędkość internetu jest bardzo niska. Próbowałem resetować modem i router, ale to nie pomogło. Problem występuje zarówno przy połączeniu kablowym, jak i bezprzewodowym. Urządzenia są wykrywane w sieci, ale internet działa bardzo wolno i niestabilnie. Proszę o pomoc w naprawie tego problemu, bo utrudnia mi to korzystanie z sieci. Czekam na szybką pomoc i rozwiązanie problemu.\n\n\n','Filip Kaszewiak','Open','Żabka','123456789','2024-12-15','2024-11-21 04:17:00','2024-11-21 12:17:00','low',NULL,NULL,NULL),(2,'piotr.kaczmarek','Poznań','Anielska 1','Awaria serwera bazy danych','Mam problem z serwerem bazy danych. Nie mogę połączyć się z bazą, a próby dostępu kończą się błędem. Wydaje się, że serwer jest niedostępny lub występuje jego przeciążenie. Brak dostępu do bazy uniemożliwia dalszą pracę. Proszę o pilną interwencję, aby przywrócić działanie serwera i umożliwić normalną pracę z danymi. Czekam na szybkie rozwiązanie problemu.','Marek Zieliński','Closed','Biedronka','234567890','2024-12-16','2024-11-22 12:03:00','2024-11-22 14:03:00','high','2024-12-18 00:00:00','NT_1','Po przybyciu na miejsce przeprowadziłem diagnostykę serwera bazy danych. Zidentyfikowano problem z przeciążeniem procesora spowodowany nieoptymalnymi zapytaniami do bazy. Wykonałem restart serwera, wyczyściłem pamięć podręczną oraz zoptymalizowałem najbardziej obciążające zapytania. Po zakończeniu działań przeprowadziłem testy wydajności, które potwierdziły przywrócenie normalnego działania serwera. Problem został rozwiązany, a system jest w pełni operacyjny. TEST'),(3,'kasia.wojcik','Wrocław','Miła 3','Problem z aktualizacją oprogramowania','Mam problem z aktualizacją oprogramowania. Podczas próby pobrania i zainstalowania najnowszej wersji program wyświetla błąd i nie kończy procesu aktualizacji. Próby ponownej instalacji również nie przyniosły efektu. Program działa niepoprawnie, co utrudnia jego normalne użytkowanie. Proszę o pomoc w rozwiązaniu problemu i umożliwienie prawidłowej instalacji najnowszej wersji. Czekam na szybką reakcję i pomoc.\n\n\n\n','Filip Kaszewiak','Resolved','Lidl','345678901','2024-12-17','2024-11-17 07:31:00','2024-11-17 11:31:00','medium','2024-12-18 00:00:00','NT_2','Przeprowadziłem diagnostykę problemu z aktualizacją oprogramowania. Okazało się, że błąd wynikał z uszkodzonych plików tymczasowych i konfliktów w ustawieniach systemowych. Usunąłem nieprawidłowe pliki oraz zresetowałem ustawienia aktualizacji. Następnie pobrałem i zainstalowałem najnowszą wersję oprogramowania, która zainstalowała się poprawnie. Po zakończeniu procesu przeprowadziłem test działania programu – funkcjonuje on teraz bez zarzutu. Problem został rozwiązany.'),(4,'jan.pawlak','Gdańsk','Sadowa 55','Zgłoszenie dotyczące awarii komputera','Mój komputer przestał działać poprawnie. Przy próbie uruchomienia systemu pojawia się czarny ekran, a komputer nie ładuje się do końca. Próbowałem restartować urządzenie, ale problem nadal występuje. Słychać również nietypowy dźwięk z wnętrza komputera, co może sugerować problem z hardwarem. Potrzebuję pomocy w diagnostyce i naprawie usterki. Proszę o szybką interwencję, ponieważ uniemożliwia mi to normalne korzystanie z komputera.','Filip Kaszewiak','Closed','Biedronka','456789012','2024-12-18','2024-11-16 17:39:00','2024-11-17 01:39:00','low','2024-12-19 00:00:00','NT_3','Podczas diagnostyki ustalono, że przyczyną awarii był uszkodzony zasilacz, który nie dostarczał wystarczającej mocy do podzespołów komputera. Nietypowe dźwięki pochodziły od dysku twardego, jednak po sprawdzeniu jego stanu nie wykryto uszkodzeń. Wymieniłem zasilacz na nowy o odpowiednich parametrach, co pozwoliło na przywrócenie pełnej funkcjonalności komputera. Dodatkowo przetestowałem wszystkie podzespoły, aby upewnić się, że nie występują inne problemy. Komputer działa teraz prawidłowo.'),(5,'julia.mazur','Szczecin','Przyjazna 99','Problemy z dostępem do VPN','Mam problem z dostępem do VPN. Po próbie połączenia, program wyświetla komunikat o błędzie i nie mogę uzyskać dostępu do sieci. Sprawdzałem ustawienia i hasło, ale problem nadal występuje. Próby ponownego uruchomienia komputera i aplikacji VPN nie rozwiązały problemu. Potrzebuję pomocy w rozwiązaniu tego problemu, aby móc ponownie bezpiecznie łączyć się z siecią. Czekam na szybką pomoc w tej sprawie.','Filip Kaszewiak','Closed','Stokrotka','567890123','2024-12-19','2024-11-03 12:14:00','2024-11-03 16:14:00','medium','2025-02-03 12:00:00','NT_11','Zrealizowano zlecenie. TEST'),(6,'Filip.Kaszewiak','Warszawa','Grzybowska 18','Problemy z dyskiem twardym','Mój dysk twardy zaczyna sprawiać problemy. Komputer wolno się ładuje, a podczas pracy pojawiają się komunikaty o błędach odczytu. Czasami pliki nie chcą się otworzyć, a system operacyjny wyświetla ostrzeżenia o błędach na dysku. Próbowałem uruchomić narzędzie do naprawy, ale problem nadal występuje. Obawiam się, że dysk może być uszkodzony. Proszę o pomoc w diagnostyce i ewentualnej naprawie, ponieważ problem wpływa na moją pracę. Czekam na szybką reakcję.','Anna Wróbel','Open','Żabka','678901234','2024-12-20','2024-11-18 20:11:00','2024-11-19 00:11:00','medium',NULL,NULL,NULL),(7,'piotr.kaczmarek','Kraków','Żelazna 22','Błąd w systemie operacyjnym','Mam problem z systemem operacyjnym. Podczas codziennego użytkowania komputer wyświetla błąd i często się zawiesza. Po ponownym uruchomieniu pojawia się komunikat o awarii systemu, a niektóre aplikacje przestają działać poprawnie. Próbowałem restartować komputer i uruchomić go w trybie awaryjnym, ale problem nadal występuje. Proszę o pomoc w naprawie tego błędu, ponieważ uniemożliwia mi to normalne korzystanie z komputera. Czekam na szybką pomoc w tej sprawie.','Filip Kaszewiak','In Progress','Lidl','789012345','2024-12-21','2024-11-08 01:15:00','2024-11-08 09:15:00','low',NULL,NULL,NULL),(8,'kasia.wojcik','Łódź','Złota 18','Awaria sprzętu komputerowego','Mam problem ze sprzętem komputerowym. Po włączeniu komputera urządzenie nie uruchamia się poprawnie – ekran pozostaje czarny, a komputer nie reaguje na żadne polecenia. Słychać dziwne dźwięki z wnętrza obudowy, co może sugerować problem z komponentami, jak np. zasilacz czy płyta główna. Próbowałem podłączyć komputer do innego źródła zasilania, ale problem nie zniknął. Proszę o pomoc w diagnostyce i naprawie uszkodzonego sprzętu, ponieważ uniemożliwia mi to korzystanie z komputera. Czekam na szybką reakcję.','Filip Kaszewiak','Resolved','PZU','890123456','2024-12-22','2024-11-04 22:19:00','2024-11-05 06:19:00','low','2024-12-23 00:00:00','NT_4','Po przeprowadzeniu diagnostyki stwierdzono awarię dysku twardego, który powodował problemy z uruchomieniem komputera. Dziwne dźwięki wynikały z uszkodzonego mechanizmu talerzy w dysku. Wymieniłem dysk na nowy i przeinstalowałem system operacyjny. Dodatkowo odzyskałem część danych z uszkodzonego dysku, które udało się zabezpieczyć. Po zakończeniu działań komputer działa prawidłowo, a użytkownik został poinformowany o konieczności regularnego wykonywania kopii zapasowych.'),(9,'jan.pawlak','Poznań','Jana Pawła II 3','Zgłoszenie dotyczące routera','Mam problem z routerem. Internet działa niestabilnie, często traci połączenie, a prędkość łącza jest bardzo niska. Próby resetowania urządzenia oraz zmiana ustawień nie przyniosły poprawy. Problemy występują zarówno przy połączeniu Wi-Fi, jak i przez kabel. Inne urządzenia w sieci również mają trudności z łącznością. Proszę o pomoc w diagnozie i naprawie routera, ponieważ brak stabilnego internetu utrudnia mi codzienne korzystanie z sieci. Czekam na szybką pomoc.','Filip Kaszewiak','Closed','Sony','901234567','2024-12-23','2024-11-19 21:10:00','2024-11-19 23:10:00','high','2024-12-24 00:00:00','NT_5','Po przybyciu na miejsce przeprowadziłem diagnostykę routera i łącza internetowego. Ustalono, że problem wynikał z przestarzałego oprogramowania routera oraz zakłóceń sygnału w pasmach Wi-Fi. Zaktualizowałem firmware urządzenia, zmieniłem kanał Wi-Fi na mniej obciążony oraz zoptymalizowałem ustawienia sieci. Po tych działaniach przeprowadziłem testy stabilności i prędkości, które wykazały poprawę działania łącza. Internet działa obecnie stabilnie i z pełną prędkością.'),(10,'Filip.Kaszewiak','Kraków','Poznańska 90','Awaria zasilania','Mam problem z zasilaniem w moim urządzeniu. Komputer/urządzenia nie włączają się, mimo że podłączone są do gniazdka. Próbowałem używać innych kabli i gniazdek, ale problem nadal występuje. Zasilacz wydaje się być uszkodzony, ponieważ nie ma żadnych oznak zasilania. Proszę o pomoc w diagnozie i naprawie awarii, ponieważ uniemożliwia mi to korzystanie z urządzeń. Czekam na szybką pomoc i rozwiązanie problemu.','Filip Kaszewiak','Open','HP','123456789','2024-12-24','2024-11-04 05:45:00','2024-11-04 07:45:00','high',NULL,NULL,NULL),(11,'adam.nowak','Wrocław','Krakowska 15','Zgłoszenie o problemach z aplikacją','Mam problem z aplikacją. Po jej uruchomieniu często wyświetla się komunikat o błędzie, a sama aplikacja się zawiesza lub zamyka. Próbowałem ponownie zainstalować program, ale problem nadal występuje. Aplikacja działa nieprawidłowo i uniemożliwia mi wykonywanie zaplanowanych zadań. Proszę o pomoc w naprawie błędów, ponieważ potrzebuję, aby aplikacja działała sprawnie. Czekam na szybką reakcję i rozwiązanie problemu.','Filip Kaszewiak','In Progress','Biedronka','234567890','2024-12-25','2024-11-03 04:37:00','2024-11-03 08:37:00','medium',NULL,NULL,NULL),(12,'piotr.kaczmarek','Warszawa','Myszkowska 154','Awaria laptopa','Mój laptop przestał działać poprawnie. Po włączeniu nie uruchamia się do końca – ekran pozostaje czarny, a system nie ładuje się. Słychać jedynie wentylator, ale żadne inne funkcje nie działają. Próbowałem go restartować, ale problem nadal występuje. Obawiam się, że może to być problem z podzespołami. Proszę o pomoc w diagnozie i naprawie, ponieważ nie mogę korzystać z laptopa do pracy. Czekam na szybką reakcję.','Filip Kaszewiak','Closed','Ispot','345678901','2024-12-26','2024-11-14 00:24:00','2024-11-14 02:24:00','high','2024-12-27 00:00:00','NT_6','Po otrzymaniu zgłoszenia przeprowadziłem diagnostykę laptopa. Ustalono, że problemem był uszkodzony moduł pamięci RAM, który uniemożliwiał poprawne uruchomienie systemu. Wymieniłem wadliwą pamięć na nowy moduł zgodny z parametrami urządzenia. Po wymianie laptop uruchomił się poprawnie, a wszystkie funkcje działają bez zakłóceń. Dodatkowo przeprowadziłem aktualizację systemu i sterowników, aby zapobiec dalszym problemom. Laptop jest gotowy do użytku.'),(13,NULL,'Szczecin','Warszawska 15','Problem z siecią Wi-Fi','Mam problem z połączeniem Wi-Fi. Sieć często traci sygnał lub jest bardzo wolna, co utrudnia korzystanie z internetu. Inne urządzenia w domu nie mają problemów z łącznością, więc podejrzewam, że problem dotyczy tylko mojego urządzenia. Próbowałem resetować router, ale to nie pomogło. Proszę o pomoc w rozwiązaniu problemu, aby połączenie Wi-Fi działało stabilnie. Czekam na szybką pomoc.','Filip Kaszewiak','Open','PZU','456789012','2024-12-27','2024-11-24 14:07:00','2024-11-24 18:07:00','medium',NULL,NULL,NULL),(14,'Filip.Kaszewiak','Gdańsk','Morska 1','Problem z drukarką','Mam problem z drukarką. Drukarka nie reaguje na polecenia, mimo że jest poprawnie podłączona do komputera i włączona. Próbowałem ponownie uruchomić urządzenie, ale nadal nie działa. Wydrukowane dokumenty są opóźnione lub w ogóle nie wychodzą. Sprawdziłem poziom tuszu i stan papieru, ale problem nadal występuje. Proszę o pomoc w naprawie lub diagnozie usterki, ponieważ potrzebuję drukarki do codziennej pracy. Czekam na szybką pomoc.','Filip Kaszewiak','In Progress','Ispot','567890123','2024-12-28','2024-11-19 12:17:00','2024-11-19 14:17:00','high',NULL,NULL,NULL),(15,'adam.nowak','Warszawa','Grzybowska 65','Problem z Panelem Dotykowym.','Mam problem z panelem dotykowym w moim urządzeniu. Ekran dotykowy nie reaguje prawidłowo – czasami nie rejestruje dotyków, a innym razem wykonuje akcje losowo. Próbowałem zrestartować urządzenie oraz wyczyścić ekran, ale problem nadal występuje. Panel dotykowy działa bardzo niestabilnie, co utrudnia normalne korzystanie z urządzenia. Proszę o pomoc w naprawie tego problemu. Czekam na szybką reakcję.','Filip Kaszewiak','Closed','Żabka','567646489','2024-12-28','2024-12-28 00:00:00','2024-12-28 02:00:00','high','2024-12-26 14:30:00','NT_9','Zrealizowano zlecenie.'),(16,'Filip.Kaszewiak','Warszawa','Trocka 18','Problemy z siecią','Mam problem z siecią. Internet działa bardzo niestabilnie – często traci połączenie, a prędkość jest znacznie niższa niż zazwyczaj. Próby resetowania modemu i routera nie przyniosły efektu. Połączenie działa tylko przez krótkie okresy czasu, a potem znów przerywa. Problem występuje zarówno przy połączeniu Wi-Fi, jak i przewodowym. Proszę o pomoc w rozwiązaniu tego problemu, ponieważ uniemożliwia mi to korzystanie z internetu. Czekam na szybką pomoc.','Filip Kaszewiak','Open','Żabka','123456789','2024-12-30','2024-12-30 07:00:01','2024-12-30 09:00:01','high',NULL,NULL,NULL),(19,'Filip.Kaszewiak','Gdańsk','Świętego Ducha 45','Problem z połączeniem VPN','Nie mogę połączyć się z siecią VPN. Po wpisaniu loginu i hasła, system zwraca komunikat o błędzie połączenia. Sprawdziłem ustawienia i wygląda na to, że nie ma problemów z konfiguracją, ale nadal nie mogę uzyskać dostępu do firmowej sieci. Proszę o pilną pomoc, ponieważ nie mogę pracować zdalnie.','Filip Kaszewiak','open','Lidl','789123456','2025-01-10','2025-01-10 09:00:00','2025-01-10 11:00:00','high',NULL,NULL,NULL),(20,'patryk.marciniak','Wrocław','Grabiszyńska 12','Brak dostępu do internetu','Od wczoraj nie mam dostępu do internetu w komputerze. Połączenie Wi-Fi działa na innych urządzeniach, ale na moim laptopie nie mogę się połączyć z żadną siecią. Restartowałem komputer i router, ale to nie pomogło. Proszę o pomoc w diagnozowaniu problemu.','Michał Nowak','open','Aldi','987654321','2025-01-10','2025-01-10 10:30:00','2025-01-10 14:30:00','medium',NULL,NULL,NULL),(21,'monika.wisniewska','Poznań','Pięciomorgowa 6','Awarie drukarki sieciowej','Drukarka sieciowa przestała działać. Wszystkie próby ponownego uruchomienia i podłączenia do sieci zakończyły się niepowodzeniem. Komputer nie wykrywa urządzenia w sieci, mimo że wcześniej działała poprawnie. Proszę o szybkie sprawdzenie problemu, ponieważ drukarka jest niezbędna do pracy biurowej.','Adam Kowalski','open','Żabka','654321987','2025-01-09','2025-01-09 14:00:00','2025-01-09 16:00:00','high',NULL,NULL,NULL),(22,'julia.pawlak','Katowice','Tysiąclecia 2','Problem z synchronizacją konta email','Mój klient poczty email przestał synchronizować wiadomości. Od kilku dni nie mogę pobrać nowych wiadomości ani wysłać maila. Konto zostało prawidłowo skonfigurowane, ale nadal nie działa poprawnie. Proszę o pomoc, gdyż problem utrudnia mi codzienną pracę.','Filip Kaszewiak','Closed','Biedronka','321654987','2025-01-11','2025-01-11 08:00:00','2025-01-11 12:00:00','medium','2025-02-22 14:00:00','NT_10','Tekst Teskowy TEST'),(23,'tomasz.baran','Szczecin','Jana Pawła II 30','Wolne działanie komputera','Komputer działa bardzo wolno, zarówno przy uruchamianiu, jak i podczas pracy z aplikacjami. Przeprowadziłem czyszczenie dysku, jednak nie zauważyłem poprawy. Proszę o pomoc w optymalizacji komputera.','Aleksandra Nowak','open','PZU','123987654','2025-01-09','2025-01-09 12:00:00','2025-01-09 20:00:00','low',NULL,NULL,NULL),(24,'barbara.kowalczyk','Rzeszów','Jagodowa 7','Błąd przy instalacji oprogramowania','Podczas próby instalacji nowego oprogramowania na moim komputerze pojawia się komunikat o błędzie i instalacja nie kończy się pomyślnie. Próbowałam różnych wersji programu, ale problem się powtarza. Proszę o pomoc w rozwiązaniu tej kwestii.','Janusz Michalski','open','Ispot','555123456','2025-01-08','2025-01-08 15:30:00','2025-01-08 19:30:00','medium',NULL,NULL,NULL),(25,'aneta.kubiak','Warszawa','Aleje Jerozolimskie 121','Problemy z kartą graficzną','Po uruchomieniu komputera ekran miga, a obrazy wyświetlają się niepoprawnie. Wygląda na to, że problem jest związany z kartą graficzną. Proszę o pomoc w jej diagnostyce i ewentualnej wymianie.','Ewa Sienkiewicz','open','HP','333444555','2025-01-07','2025-01-07 10:00:00','2025-01-07 12:00:00','high',NULL,NULL,NULL),(26,'adam.milczarski','Łódź','Piotrkowska 77','Przerywanie połączenia internetowego','Połączenie z internetem przerywa się co kilka minut. Próby rozwiązania problemu poprzez restart routera nie pomagają. Problem występuje zarówno na komputerze stacjonarnym, jak i na laptopie. Proszę o pomoc w ustaleniu przyczyny i naprawie.','Kamil Jaworski','open','Biedronka','111223344','2025-01-06','2025-01-06 16:30:00','2025-01-06 18:30:00','high',NULL,NULL,NULL),(27,'agnieszka.górka','Gdynia','Chwarzno 8','Zawieszający się system operacyjny','Mój system operacyjny zawiesza się regularnie podczas pracy z aplikacjami biurowymi. Nie jestem w stanie zidentyfikować, co może powodować ten problem. Proszę o pomoc w jego rozwiązaniu, ponieważ utrudnia to moją codzienną pracę.','Grzegorz Kowalczyk','open','LIdl','222333444','2025-01-05','2025-01-05 11:00:00','2025-01-05 13:00:00','high',NULL,NULL,NULL),(28,'marcin.woźniak','Białystok','Lipowa 19','Uszkodzony dysk SSD','Dysk SSD w moim laptopie przestał działać. Po uruchomieniu systemu operacyjnego pojawia się komunikat o błędzie odczytu. Próba reinstalacji systemu również kończy się niepowodzeniem. Proszę o pomoc w diagnozie i naprawie.','Filip Kaszewiak','Closed','Stokrotka','444555666','2025-01-04','2025-01-04 09:00:00','2025-01-04 11:00:00','high','2025-01-15 12:00:00','NT_7','Zgodnie z procesem TEST'),(29,'kamil.kowalczuk','Olsztyn','Wojska Polskiego 12','Problemy z aplikacją biurową','Aplikacja biurowa na moim komputerze ciągle się zawiesza. Próbowałem ponownie zainstalować oprogramowanie, ale problem nadal występuje. Proszę o pomoc w diagnozowaniu błędów w aplikacji.','Rafał Piątek','open','Stokrotka','444987654','2025-01-03','2025-01-03 13:00:00','2025-01-03 15:00:00','high',NULL,NULL,NULL),(30,'jacek.jankowski','Bydgoszcz','Armii Krajowej 7','Problem z laptopem','Mój laptop wyłącza się samoczynnie, nawet podczas pracy na mniej obciążających zadaniach. Sprawdziłem ustawienia zarządzania energią, ale problem nadal występuje. Proszę o pomoc w zdiagnozowaniu problemu.','Filip Kaszewiak','open','Stokrotka','111223344','2025-01-02','2025-01-02 09:00:00','2025-01-02 11:00:00','high',NULL,NULL,NULL),(31,'Filip.Kaszewiak','Sosnowiec','Warszawska 21','Problem z dostępem do plików','Po ostatniej aktualizacji systemu operacyjnego straciłam dostęp do wielu plików na dysku twardym. Programy pokazują, że pliki są nadal obecne, ale nie mogę ich otworzyć. Proszę o pomoc w odzyskaniu dostępu do plików.','Tomasz Chmiel','open','Lidl','555987654','2025-01-01','2025-01-01 14:00:00','2025-01-01 16:00:00','high',NULL,NULL,NULL),(32,'aleksandra.nowak','Toruń','Konstytucji 3 Maja 5','Problem z monitorami','Po podłączeniu dwóch monitorów do laptopa jeden z nich nie działa. Mimo prób w różnych portach, ekran nie wyświetla obrazu. Proszę o pomoc w diagnozie problemu z monitorem.','Wojciech Nowak','open','PZU','777123456','2024-12-31','2024-12-31 09:00:00','2024-12-31 13:00:00','medium',NULL,NULL,NULL),(33,'grzegorz.kaczmarek','Opole','Armii Krajowej 10','Problem z kartą sieciową','Nie mogę połączyć się z internetem, mimo że komputer pokazuje aktywne połączenie. Podejrzewam, że problem dotyczy karty sieciowej. Proszę o pomoc w diagnozie i naprawie.','Ewa Kowalska','open','Opole IT Solutions','555123987','2024-12-30','2024-12-30 08:30:00','2024-12-30 10:30:00','high',NULL,NULL,NULL),(34,'monika.lipska','Lublin','Andersa 23','Awaria systemu operacyjnego','Po aktualizacji systemu operacyjnego komputer nie chce się uruchomić. Wyświetla się tylko czarny ekran, a system nie ładuje się wcale. Proszę o pomoc w naprawie systemu.','Piotr Szymański','open','HP','333222444','2024-12-29','2024-12-29 10:00:00','2024-12-29 12:00:00','high',NULL,NULL,NULL),(35,'anna.kwiatkowska','Zielona Góra','Żernickiej 11','Problemy z dyskiem twardym','Po włączeniu komputera pojawia się komunikat o błędzie dysku twardego. Pliki są coraz trudniejsze do otwarcia, a komputer zwalnia. Proszę o diagnostykę i naprawę problemu z dyskiem.','Krzysztof Wiśniewski','open','HP','123456789','2024-12-28','2024-12-28 14:00:00','2024-12-28 16:00:00','high',NULL,NULL,NULL),(36,'Filip.Kaszewiak','Łódź','Polska 8','Awarie sieci Wi-Fi','Połączenie Wi-Fi ciągle się zrywa, mimo że w innych częściach mieszkania działa normalnie. Problemy występują w jednym pokoju, mimo że router znajduje się blisko. Proszę o pomoc w zdiagnozowaniu przyczyny problemu z siecią Wi-Fi.','Tomasz Pawlak','open','Lidl','555666777','2024-12-27','2024-12-27 16:00:00','2024-12-27 20:00:00','medium',NULL,NULL,NULL),(37,'karolina.duda','Opole','Kościuszki 4','Problemy z oprogramowaniem antywirusowym','Oprogramowanie antywirusowe przestało działać poprawnie i nie wykrywa zagrożeń. Po próbie aktualizacji pojawia się błąd. Proszę o pomoc w ponownej instalacji oprogramowania.','Alicja Nowak','open','Biedronka','987654321','2024-12-26','2024-12-26 09:00:00','2024-12-26 13:00:00','medium',NULL,NULL,NULL),(38,'piotr.woźniak','Katowice','Bratysławska 7','Brak dostępu do zewnętrznego dysku','Nie mogę uzyskać dostępu do zewnętrznego dysku twardego. Podłączam urządzenie, ale komputer nie widzi go. Proszę o pomoc w rozwiązaniu tego problemu.','Kamil Piątek','open','Lidl','888555444','2024-12-25','2024-12-25 10:30:00','2024-12-25 12:30:00','high',NULL,NULL,NULL),(39,'piotr.nawrocki','Sosnowiec','Kościelna 4','Problemy z pamięcią RAM','Mój komputer zaczął działać wolno, a aplikacje często się zawieszają. Podejrzewam, że może to być problem z pamięcią RAM. Proszę o pomoc w diagnostyce.','Marta Kowalska','open','Lidl','777123555','2024-12-24','2024-12-24 08:30:00','2024-12-24 12:30:00','medium',NULL,NULL,NULL),(40,'Filip.Kaszewiak','Piotrków Trybunalski','Łódzka 1','Problem z kartą dźwiękową','Po wymianie karty dźwiękowej komputer przestał wykrywać nowe urządzenie. Proszę o pomoc w zainstalowaniu i skonfigurowaniu karty dźwiękowej.','Patryk Wójcik','open','Lidl','333111555','2024-12-23','2024-12-23 11:00:00','2024-12-23 15:00:00','medium',NULL,NULL,NULL),(41,'martyna.woźniak','Bydgoszcz','Św. Trójcy 9','Problemy z aplikacją pocztową','Aplikacja pocztowa na moim komputerze nie synchronizuje wiadomości. Od kilku dni nie otrzymuję nowych wiadomości i nie mogę wysyłać maili. Proszę o pomoc w naprawie aplikacji.','Filip Kaszewiak','open','HP','111223444','2024-12-22','2024-12-22 10:00:00','2024-12-22 14:00:00','medium',NULL,NULL,NULL),(42,'katarzyna.woźniak','Łódź','Podrzeczna 10','Problem z synchronizacją kalendarza','Mój kalendarz w aplikacji biurowej nie synchronizuje się z serwerem. Wydaje się, że problem leży po stronie serwera. Proszę o pomoc w synchronizacji kalendarza.','Piotr Szymański','open','HP','666777888','2024-12-21','2024-12-21 08:30:00','2024-12-21 16:30:00','low',NULL,NULL,NULL),(43,'julian.pawlak','Wrocław','Wiatraczna 6','Problemy z systemem operacyjnym','Mój komputer nie chce uruchomić systemu operacyjnego. Pokazuje się komunikat o błędzie podczas próby załadowania systemu. Proszę o pomoc w naprawie systemu operacyjnego.','Magdalena Nowak','open','Biedronka','444555777','2024-12-20','2024-12-20 09:00:00','2024-12-20 11:00:00','high',NULL,NULL,NULL),(44,'krzysztof.kaczmarek','Radom','Krakowska 8','Awarie sprzętu','Po upadku mojego laptopa ekran nie działa prawidłowo, widać pęknięcia. Proszę o pomoc w diagnozie i ewentualnej naprawie ekranu.','Filip Kaszewiak','open','Biedronka','123987654','2024-12-19','2024-12-19 10:00:00','2024-12-19 12:00:00','high',NULL,NULL,NULL),(45,'monika.kwiatkowska','Szczecin','Pięciomorgowa 3','Problemy z kartą graficzną','Po uruchomieniu komputera na ekranie pojawiają się artefakty graficzne. Wygląda na to, że karta graficzna przestała działać prawidłowo. Proszę o pomoc w naprawie karty graficznej.','Marek Lewandowski','open','HP','555666777','2024-12-18','2024-12-18 09:30:00','2024-12-18 11:30:00','high',NULL,NULL,NULL),(46,'joanna.kowalska','Katowice','Chorzowska 4','Problemy z połączeniem VPN','Po aktualizacji systemu operacyjnego nie mogę połączyć się z siecią VPN. Aplikacja nie reaguje na próby połączenia. Proszę o pomoc w naprawie połączenia VPN.','Filip Kaszewiak','open','HP','222333444','2024-12-17','2024-12-17 08:00:00','2024-12-17 10:00:00','high',NULL,NULL,NULL),(47,'pawel.nowak','Bydgoszcz','Stare Miasto 5','Problemy z wydajnością komputera','Komputer działa bardzo wolno, nawet przy uruchomionych prostych aplikacjach. Wydaje się, że problem leży w pamięci RAM lub procesorze. Proszę o pomoc w diagnozie i poprawie wydajności komputera.','Filip Kaszewiak','open','HP','333444555','2024-12-16','2024-12-16 12:00:00','2024-12-16 16:00:00','medium',NULL,NULL,NULL),(48,'magdalena.woźniak','Sosnowiec','Polska 7','Awaria urządzenia peryferyjnego','Nie działa moja drukarka. Mimo podłączenia do komputera nie jest wykrywana przez system. Proszę o pomoc w naprawie i konfiguracji drukarki.','Filip Kaszewiak','open','Biedronka','444777888','2024-12-15','2024-12-15 10:30:00','2024-12-15 14:30:00','medium',NULL,NULL,NULL),(49,NULL,'Piła','Wojska Polskiego 3','Problemy z systemem plików','Nie mogę otworzyć niektórych folderów na dysku twardym. System operacyjny wyświetla komunikat o uszkodzeniu systemu plików. Proszę o pomoc w naprawie i odzyskaniu dostępu do danych.','Filip Kaszewiak','open','Aldi','777888999','2024-12-14','2024-12-14 09:00:00','2024-12-14 11:00:00','high',NULL,NULL,NULL),(50,'dorota.nowak','Radom','Leszczyńska 10','Problem z dostępem do sieci lokalnej','Po zmianach w konfiguracji sieci nie mogę uzyskać dostępu do drukarki w sieci lokalnej. Proszę o pomoc w ponownej konfiguracji i uzyskaniu dostępu do urządzenia.','Filip Kaszewiak','Closed','Aldi','555666333','2024-12-13','2024-12-13 08:30:00','2024-12-13 12:30:00','medium','2025-01-31 02:00:00','NT_8','Tekst Testowy auuuuu');
/*!40000 ALTER TABLE `reports` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `set_date_of_sla` BEFORE INSERT ON `reports` FOR EACH ROW BEGIN
    SET NEW.date_of_sla = CASE
        WHEN NEW.priorytet = 'high' THEN DATE_ADD(NEW.create_date, INTERVAL 2 HOUR)
        WHEN NEW.priorytet = 'medium' THEN DATE_ADD(NEW.create_date, INTERVAL 4 HOUR)
        WHEN NEW.priorytet = 'low' THEN DATE_ADD(NEW.create_date, INTERVAL 8 HOUR)
        ELSE DATE_ADD(NEW.create_date, INTERVAL 24 HOUR)
    END;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `before_insert_update_id_protocol` BEFORE INSERT ON `reports` FOR EACH ROW BEGIN
    IF NEW.end_date IS NOT NULL THEN
        SET NEW.ID_protocol = CONCAT('NT', 
            (SELECT COUNT(*) + 1 FROM REPORTS WHERE end_date IS NOT NULL));
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `set_unique_id_protocol` BEFORE UPDATE ON `reports` FOR EACH ROW BEGIN
    IF NEW.status = 'closed' AND OLD.status != 'closed' THEN
        IF NEW.ID_protocol IS NULL OR NEW.ID_protocol = '' THEN
            -- Nadanie nowego unikalnego ID
            SET NEW.ID_protocol = CONCAT(
                'NT_',
                COALESCE(
                    (SELECT MAX(CAST(SUBSTRING(ID_protocol, 4) AS UNSIGNED))
                     FROM reports
                     WHERE ID_protocol LIKE 'NT_%'),
                    0
                ) + 1
            );
        END IF;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `before_update_id_protocol` BEFORE UPDATE ON `reports` FOR EACH ROW BEGIN
    IF NEW.end_date IS NOT NULL AND NEW.ID_protocol IS NULL THEN
        SET NEW.ID_protocol = CONCAT('NT', 
            (SELECT COUNT(*) + 1 FROM REPORTS WHERE end_date IS NOT NULL));
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `resources`
--

DROP TABLE IF EXISTS `resources`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `resources` (
  `id` int NOT NULL,
  `brand` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `model` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `SerialNumber` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Registration_Number` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `category` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `assignment_technican` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci DEFAULT 'null',
  `used_for_report` varchar(100) COLLATE utf8mb4_polish_ci DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resources`
--

LOCK TABLES `resources` WRITE;
/*!40000 ALTER TABLE `resources` DISABLE KEYS */;
INSERT INTO `resources` VALUES (1,'Dell','XPS 13','SN12345678','REG123456','Laptop','Adam',NULL),(2,'HP','EliteBook 840','SN22345678','REG223456','Laptop',NULL,NULL),(3,'Apple','MacBook Pro','SN32345678','REG323456','Laptop',NULL,NULL),(4,'Lenovo','ThinkPad X1','SN42345678','REG423456','Laptop',NULL,NULL),(5,'Acer','Predator Helios','SN52345678','REG523456','Laptop',NULL,NULL),(6,'Asus','ZenBook','SN62345678','REG623456','Laptop',NULL,NULL),(7,'Samsung','Galaxy Book','SN72345678','REG723456','Laptop',NULL,NULL),(8,'Microsoft','Surface Laptop','SN82345678','REG823456','Laptop','Filip Kaszewiak',''),(9,'Lenovo','ThinkPad T14','SN92345678','REG923456','Laptop','Filip Kaszewiak',''),(10,'Dell','Latitude 7400','SN102345678','REG1023456','Laptop',NULL,NULL),(11,'Cisco','Catalyst 9300','SN112345678','REG1123456','Router',NULL,'15'),(12,'Juniper','MX960','SN122345678','REG1223456','Router','Filip Kaszewiak',NULL),(13,'Arista','7050X','SN132345678','REG1323456','Router',NULL,'15'),(14,'Huawei','NE40E','SN142345678','REG1423456','Router','Filip Kaszewiak','22'),(15,'MikroTik','CCR1009','SN152345678','REG1523456','Router','','5'),(16,'Netgear','Nighthawk X6','SN162345678','REG1623456','Router','Filip Kaszewiak',NULL),(17,'Ubiquiti','EdgeRouter 4','SN172345678','REG1723456','Router',NULL,NULL),(18,'TP-Link','Archer C7','SN182345678','REG1823456','Router',NULL,NULL),(19,'Zyxel','USG 40','SN192345678','REG1923456','Router',NULL,NULL),(20,'Linksys','WRT3200ACM','SN202345678','REG2023456','Router',NULL,NULL),(21,'HP','ProLiant DL380 Gen10','SN212345678','REG2123456','Server',NULL,NULL),(22,'Dell','PowerEdge R740','SN222345678','REG2223456','Server',NULL,NULL),(23,'Lenovo','ThinkSystem SR650','SN232345678','REG2323456','Server',NULL,NULL),(24,'Cisco','UCS C220 M5','SN242345678','REG2423456','Server',NULL,NULL),(25,'Supermicro','X11SCL-F','SN252345678','REG2523456','Server',NULL,NULL),(26,'Fujitsu','PRIMERGY RX2540 M5','SN262345678','REG2623456','Server',NULL,NULL),(27,'Huawei','FusionServer Pro 2288H V5','SN272345678','REG2723456','Server',NULL,NULL),(28,'IBM','Power System S924','SN282345678','REG2823456','Server',NULL,NULL),(29,'Oracle','SPARC T8-1','SN292345678','REG2923456','Server',NULL,NULL),(30,'Hewlett Packard','Cloudline CL3100','SN302345678','REG3023456','Server',NULL,NULL),(31,'Apple','iMac 24','SN312345678','REG3123456','Desktop','Filip Kaszewiak',''),(32,'Dell','OptiPlex 7070','SN322345678','REG3223456','Desktop',NULL,NULL),(33,'Lenovo','ThinkCentre M920','SN332345678','REG3323456','Desktop','Filip Kaszewiak',''),(34,'HP','Pavilion 24','SN342345678','REG3423456','Desktop','Filip Kaszewiak',''),(35,'Asus','ExpertCenter D7','SN352345678','REG3523456','Desktop',NULL,NULL),(36,'Acer','Veriton X','SN362345678','REG3623456','Desktop',NULL,NULL),(37,'MSI','PRO 24X 10M','SN372345678','REG3723456','Desktop',NULL,'15'),(38,'Samsung','Galaxy Book 2','SN382345678','REG3823456','Desktop','Filip Kaszewiak',''),(39,'Razer','Razer Blade 15','SN392345678','REG3923456','Desktop',NULL,'15'),(40,'Alienware','Aurora R13','SN402345678','REG4023456','Desktop',NULL,NULL),(41,'Apple','iPhone 13','SN412345678','REG4123456','Mobile',NULL,NULL),(42,'Samsung','Galaxy S21','SN422345678','REG4223456','Mobile',NULL,NULL),(43,'Google','Pixel 6','SN432345678','REG4323456','Mobile',NULL,NULL),(44,'OnePlus','9 Pro','SN442345678','REG4423456','Mobile',NULL,''),(45,'Xiaomi','Mi 11','SN452345678','REG4523456','Mobile','','28'),(46,'Motorola','Edge 20','SN462345678','REG4623456','Mobile','Filip Kaszewiak',''),(47,'Nokia','X20','SN472345678','REG4723456','Mobile','Filip Kaszewiak',''),(48,'Sony','Xperia 5 II','SN482345678','REG4823456','Mobile',NULL,''),(49,'Huawei','P40 Pro','SN492345678','REG4923456','Mobile','Filip Kaszewiak',''),(50,'LG','V60 ThinQ','SN502345678','REG5023456','Mobile',NULL,'');
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
  `Nr_tel` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_requests`
--

LOCK TABLES `user_requests` WRITE;
/*!40000 ALTER TABLE `user_requests` DISABLE KEYS */;
INSERT INTO `user_requests` (`id`, `Imie`, `Nazwisko`, `Haslo`, `kolumna_dat`, `Nr_tel`) VALUES (1,'Jan','Kowalski','Au3kjop@','2023-03-30 00:00:00','123456789'),(2,'Anna','Nowak','1Qwwwj!','2023-03-17 00:00:00','987654321'),(3,'Michał','Wiśniewski','pOkR!abC','2023-04-20 00:00:00','876543219'),(4,'Marta','Dąbrowski','fcjgkJ11#','2023-11-21 00:00:00','741852963'),(5,'Jakub','Lewandowski','BBhhhiii!!!','2023-07-18 00:00:00','369258147'),(6,'Ola','Kocoń','iopHHJ!!3#','2023-01-19 00:00:00','951236987'),(17,'Mariola','Nowak','AaAkj23 dksad','2023-11-10 00:00:00','213789432'),(18,'Wiktoira','Wit','Wksnsknocnaca','2025-01-05 17:55:35','721725272'),(20,'Ola','Amber','Haklsvhlhlkh','2025-01-05 19:05:00','123456789'),(21,'Dawid','Grzybkowski','Onomatopeja','2025-02-02 20:28:32','123456789');
/*!40000 ALTER TABLE `user_requests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'servicedeskv2'
--

--
-- Dumping routines for database 'servicedeskv2'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-02-02 21:35:25
