-- MySQL dump 10.13  Distrib 8.0.16, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: projektas
-- ------------------------------------------------------
-- Server version	8.0.16

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bettings`
--

DROP TABLE IF EXISTS `bettings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `bettings` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `coefficient` double(40,8) NOT NULL,
  `team_name` varchar(45) DEFAULT NULL,
  `fk_users_bets` int(11) DEFAULT NULL,
  `fk_match` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `belongs8` (`fk_users_bets`),
  KEY `has11` (`fk_match`),
  CONSTRAINT `belongs8` FOREIGN KEY (`fk_users_bets`) REFERENCES `users_bets` (`id`),
  CONSTRAINT `has11` FOREIGN KEY (`fk_match`) REFERENCES `matches` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bettings`
--

LOCK TABLES `bettings` WRITE;
/*!40000 ALTER TABLE `bettings` DISABLE KEYS */;
INSERT INTO `bettings` VALUES (6,55.00000000,'New',NULL,2),(11,87.00000000,'Gera',NULL,2);
/*!40000 ALTER TABLE `bettings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `evaluation`
--

DROP TABLE IF EXISTS `evaluation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `evaluation` (
  `id` int(11) NOT NULL,
  `score` int(11) NOT NULL,
  `description` longtext NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fk_user` int(11) NOT NULL,
  `fk_tournament` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `submits` (`fk_user`),
  KEY `has7` (`fk_tournament`),
  CONSTRAINT `has7` FOREIGN KEY (`fk_tournament`) REFERENCES `tournaments` (`id`),
  CONSTRAINT `submits` FOREIGN KEY (`fk_user`) REFERENCES `users` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `evaluation`
--

LOCK TABLES `evaluation` WRITE;
/*!40000 ALTER TABLE `evaluation` DISABLE KEYS */;
/*!40000 ALTER TABLE `evaluation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventts`
--

DROP TABLE IF EXISTS `eventts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `eventts` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `start_time` datetime NOT NULL,
  `finish_time` datetime NOT NULL,
  `name` varchar(30) NOT NULL,
  `fk_program` int(11) DEFAULT NULL,
  `fk_tournament` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `has12` (`fk_tournament`),
  KEY `has4` (`fk_program`),
  CONSTRAINT `has12` FOREIGN KEY (`fk_tournament`) REFERENCES `tournaments` (`id`),
  CONSTRAINT `has4` FOREIGN KEY (`fk_program`) REFERENCES `programs` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventts`
--

LOCK TABLES `eventts` WRITE;
/*!40000 ALTER TABLE `eventts` DISABLE KEYS */;
/*!40000 ALTER TABLE `eventts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `giveaways`
--

DROP TABLE IF EXISTS `giveaways`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `giveaways` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `description` longtext NOT NULL,
  `start_time` datetime NOT NULL,
  `end_time` datetime NOT NULL,
  `fk_skinsInGiveaway` int(11) DEFAULT NULL,
  `fk_usersInGiveaway` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `has14` (`fk_usersInGiveaway`),
  KEY `has13` (`fk_skinsInGiveaway`),
  CONSTRAINT `has13` FOREIGN KEY (`fk_skinsInGiveaway`) REFERENCES `skins_in_giveaway` (`id`),
  CONSTRAINT `has14` FOREIGN KEY (`fk_usersInGiveaway`) REFERENCES `users_in_giveaway` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `giveaways`
--

LOCK TABLES `giveaways` WRITE;
/*!40000 ALTER TABLE `giveaways` DISABLE KEYS */;
INSERT INTO `giveaways` VALUES (1,'geras','2019-05-24 15:18:00','2019-05-24 19:18:00',NULL,NULL),(2,'gerass','2019-05-24 15:18:00','2019-05-24 19:18:00',NULL,NULL);
/*!40000 ALTER TABLE `giveaways` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `matches`
--

DROP TABLE IF EXISTS `matches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `matches` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `start_time` datetime NOT NULL,
  `map` varchar(30) NOT NULL,
  `result` varchar(30) DEFAULT NULL,
  `is_broadcasted` tinyint(1) NOT NULL,
  `is_registration_open` tinyint(1) NOT NULL,
  `fk_first_team` int(11) DEFAULT NULL,
  `fk_second_team` int(11) DEFAULT NULL,
  `fk_tournament` int(11) DEFAULT NULL,
  `fk_place` int(11) DEFAULT NULL,
  `fk_betting` int(11) DEFAULT NULL,
  `fk_ticket` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `plays` (`fk_first_team`),
  KEY `plays1` (`fk_second_team`),
  KEY `belongs3` (`fk_tournament`),
  KEY `has15` (`fk_place`),
  KEY `has16` (`fk_betting`),
  KEY `has10` (`fk_ticket`),
  CONSTRAINT `belongs3` FOREIGN KEY (`fk_tournament`) REFERENCES `tournaments` (`id`),
  CONSTRAINT `has10` FOREIGN KEY (`fk_ticket`) REFERENCES `tickets` (`id`),
  CONSTRAINT `has15` FOREIGN KEY (`fk_place`) REFERENCES `place` (`id`),
  CONSTRAINT `has16` FOREIGN KEY (`fk_betting`) REFERENCES `bettings` (`id`),
  CONSTRAINT `has33` FOREIGN KEY (`fk_ticket`) REFERENCES `tickets` (`id`),
  CONSTRAINT `plays` FOREIGN KEY (`fk_first_team`) REFERENCES `teams` (`id`),
  CONSTRAINT `plays1` FOREIGN KEY (`fk_second_team`) REFERENCES `teams` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `matches`
--

LOCK TABLES `matches` WRITE;
/*!40000 ALTER TABLE `matches` DISABLE KEYS */;
INSERT INTO `matches` VALUES (2,'2019-05-28 15:18:00','Road',NULL,1,0,1,2,5,NULL,6,NULL);
/*!40000 ALTER TABLE `matches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `place`
--

DROP TABLE IF EXISTS `place`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `place` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `index` int(11) NOT NULL,
  `fk_user` int(11) NOT NULL,
  `fk_match` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `votes` (`fk_user`),
  KEY `has6` (`fk_match`),
  CONSTRAINT `has6` FOREIGN KEY (`fk_match`) REFERENCES `matches` (`id`),
  CONSTRAINT `votes` FOREIGN KEY (`fk_user`) REFERENCES `users` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `place`
--

LOCK TABLES `place` WRITE;
/*!40000 ALTER TABLE `place` DISABLE KEYS */;
/*!40000 ALTER TABLE `place` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `players`
--

DROP TABLE IF EXISTS `players`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `players` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `sex` varchar(20) NOT NULL,
  `email` varchar(50) NOT NULL,
  `rating` double(40,8) NOT NULL,
  `age` int(11) NOT NULL,
  `country` varchar(30) NOT NULL,
  `assists` int(11) NOT NULL,
  `headshots` int(11) NOT NULL,
  `damage_per_second` double(40,8) NOT NULL,
  `maps_played` int(11) NOT NULL,
  `round_number` int(11) NOT NULL,
  `total_kills` int(11) NOT NULL,
  `total_deaths` int(11) NOT NULL,
  `fk_team` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `belongs5` (`fk_team`),
  CONSTRAINT `belongs5` FOREIGN KEY (`fk_team`) REFERENCES `teams` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `players`
--

LOCK TABLES `players` WRITE;
/*!40000 ALTER TABLE `players` DISABLE KEYS */;
INSERT INTO `players` VALUES (1,'asd','asd','asd','asd',55.00000000,34,'asd',4,3,3.00000000,3,3,3,3,1),(2,'s','s','s','s',55.00000000,3,'3',3,3,3.00000000,3,3,3,3,2),(3,'w','w','w','w',3.00000000,3,'3',3,2,2.00000000,2,2,2,2,1);
/*!40000 ALTER TABLE `players` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `programs`
--

DROP TABLE IF EXISTS `programs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `programs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `description` longtext NOT NULL,
  `fk_tournament` int(11) DEFAULT NULL,
  `fk_event` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `has18` (`fk_event`),
  KEY `has17` (`fk_tournament`),
  CONSTRAINT `has17` FOREIGN KEY (`fk_tournament`) REFERENCES `tournaments` (`id`),
  CONSTRAINT `has18` FOREIGN KEY (`fk_event`) REFERENCES `eventts` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `programs`
--

LOCK TABLES `programs` WRITE;
/*!40000 ALTER TABLE `programs` DISABLE KEYS */;
INSERT INTO `programs` VALUES (1,'Gera','Labai',NULL,NULL),(2,'Geras','Labai',5,NULL);
/*!40000 ALTER TABLE `programs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `referrals`
--

DROP TABLE IF EXISTS `referrals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `referrals` (
  `referral` varchar(30) NOT NULL,
  `count` int(11) NOT NULL,
  `fk_user` int(11) NOT NULL,
  `fk_giveaway` int(11) NOT NULL,
  PRIMARY KEY (`referral`),
  KEY `has35` (`fk_user`),
  KEY `has36` (`fk_giveaway`),
  CONSTRAINT `has35` FOREIGN KEY (`fk_user`) REFERENCES `users` (`id`),
  CONSTRAINT `has36` FOREIGN KEY (`fk_giveaway`) REFERENCES `giveaways` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `referrals`
--

LOCK TABLES `referrals` WRITE;
/*!40000 ALTER TABLE `referrals` DISABLE KEYS */;
INSERT INTO `referrals` VALUES ('regular1',5,1,1),('regular2',1,1,2),('regular22',0,3,2);
/*!40000 ALTER TABLE `referrals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skins`
--

DROP TABLE IF EXISTS `skins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `skins` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `fk_skinsInGiveaway` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `has21` (`fk_skinsInGiveaway`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skins`
--

LOCK TABLES `skins` WRITE;
/*!40000 ALTER TABLE `skins` DISABLE KEYS */;
INSERT INTO `skins` VALUES (1,'AK-47',NULL),(2,'AWP',NULL),(3,'USP-S',NULL),(4,'M4A4-S',NULL),(5,'M4A4',NULL),(6,'FAMAS',NULL);
/*!40000 ALTER TABLE `skins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skins_in_giveaway`
--

DROP TABLE IF EXISTS `skins_in_giveaway`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `skins_in_giveaway` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fk_skin` int(11) NOT NULL,
  `fk_giveaway` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `has1` (`fk_skin`),
  KEY `has2` (`fk_giveaway`),
  CONSTRAINT `has1` FOREIGN KEY (`fk_skin`) REFERENCES `skins` (`id`),
  CONSTRAINT `has2` FOREIGN KEY (`fk_giveaway`) REFERENCES `giveaways` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skins_in_giveaway`
--

LOCK TABLES `skins_in_giveaway` WRITE;
/*!40000 ALTER TABLE `skins_in_giveaway` DISABLE KEYS */;
INSERT INTO `skins_in_giveaway` VALUES (1,1,1),(2,5,1),(3,6,1);
/*!40000 ALTER TABLE `skins_in_giveaway` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teams`
--

DROP TABLE IF EXISTS `teams`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `teams` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `wins` int(11) NOT NULL,
  `defeats` int(11) NOT NULL,
  `maps_played` int(11) NOT NULL,
  `round_number` int(11) NOT NULL,
  `total_kills` int(11) NOT NULL,
  `total_deaths` int(11) NOT NULL,
  `fk_match` int(11) DEFAULT NULL,
  `fk_player` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `has22` (`fk_match`),
  KEY `has23` (`fk_player`),
  CONSTRAINT `has22` FOREIGN KEY (`fk_match`) REFERENCES `matches` (`id`),
  CONSTRAINT `has23` FOREIGN KEY (`fk_player`) REFERENCES `players` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teams`
--

LOCK TABLES `teams` WRITE;
/*!40000 ALTER TABLE `teams` DISABLE KEYS */;
INSERT INTO `teams` VALUES (1,'asd',4,4,4,4,4,4,2,1),(2,'ss',4,4,4,5,5,5,2,1);
/*!40000 ALTER TABLE `teams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tickets`
--

DROP TABLE IF EXISTS `tickets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tickets` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `price` double(10,2) NOT NULL,
  `description` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tickets`
--

LOCK TABLES `tickets` WRITE;
/*!40000 ALTER TABLE `tickets` DISABLE KEYS */;
/*!40000 ALTER TABLE `tickets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tournaments`
--

DROP TABLE IF EXISTS `tournaments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tournaments` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `type` varchar(30) NOT NULL,
  `start_time` datetime NOT NULL,
  `end_time` datetime NOT NULL,
  `fk_event` int(11) DEFAULT NULL,
  `fk_match` int(11) DEFAULT NULL,
  `fk_evaluation` int(11) DEFAULT NULL,
  `fk_program` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `has5` (`fk_event`),
  KEY `has25` (`fk_match`),
  KEY `has26` (`fk_evaluation`),
  KEY `has27` (`fk_program`),
  CONSTRAINT `has25` FOREIGN KEY (`fk_match`) REFERENCES `matches` (`id`),
  CONSTRAINT `has26` FOREIGN KEY (`fk_evaluation`) REFERENCES `evaluation` (`id`),
  CONSTRAINT `has27` FOREIGN KEY (`fk_program`) REFERENCES `programs` (`id`),
  CONSTRAINT `has5` FOREIGN KEY (`fk_event`) REFERENCES `eventts` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tournaments`
--

LOCK TABLES `tournaments` WRITE;
/*!40000 ALTER TABLE `tournaments` DISABLE KEYS */;
INSERT INTO `tournaments` VALUES (2,'League','good','2019-05-27 15:18:00','2019-05-27 19:18:00',NULL,NULL,NULL,NULL),(4,'League','best','2019-05-27 15:18:00','2019-05-27 19:18:00',NULL,NULL,NULL,NULL),(5,'League','best','2019-06-27 15:18:00','2019-07-27 15:18:00',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `tournaments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(30) NOT NULL,
  `password` longtext NOT NULL,
  `userLevel` int(11) NOT NULL DEFAULT '1',
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `sex` varchar(20) NOT NULL,
  `email` varchar(50) NOT NULL,
  `fk_ticket` int(11) DEFAULT NULL,
  `fk_users_bets` int(11) DEFAULT NULL,
  `fk_giveaway` int(11) DEFAULT NULL,
  `fk_evaluation` int(11) DEFAULT NULL,
  `fk_place` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `has3` (`fk_ticket`),
  KEY `has28` (`fk_giveaway`),
  KEY `has29` (`fk_evaluation`),
  KEY `has30` (`fk_users_bets`),
  KEY `has31` (`fk_place`),
  CONSTRAINT `has28` FOREIGN KEY (`fk_giveaway`) REFERENCES `giveaways` (`id`),
  CONSTRAINT `has29` FOREIGN KEY (`fk_evaluation`) REFERENCES `evaluation` (`id`),
  CONSTRAINT `has3` FOREIGN KEY (`fk_ticket`) REFERENCES `tickets` (`id`),
  CONSTRAINT `has30` FOREIGN KEY (`fk_users_bets`) REFERENCES `users_bets` (`id`),
  CONSTRAINT `has31` FOREIGN KEY (`fk_place`) REFERENCES `place` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'regular','regular',1,'regular','regular','male','regular@gmail.com',NULL,NULL,2,NULL,NULL),(2,'admin','admin',2,'admin','admin','female','admin@gmail.com',NULL,NULL,NULL,NULL,NULL),(3,'regular2','regular2',1,'regular2','regular2','male','regular2@gmail.com',NULL,NULL,1,NULL,NULL),(4,'regular3','regular3',1,'regular3','regular3','male','regular3@gmail.com',NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users_bet_skins`
--

DROP TABLE IF EXISTS `users_bet_skins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `users_bet_skins` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `won` tinyint(1) DEFAULT '0',
  `fk_user` int(11) DEFAULT NULL,
  `fk_betting` int(11) DEFAULT NULL,
  `fk_skin` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `has39` (`fk_user`),
  KEY `has37` (`fk_skin`),
  KEY `has38` (`fk_betting`),
  CONSTRAINT `has37` FOREIGN KEY (`fk_skin`) REFERENCES `skins` (`id`),
  CONSTRAINT `has38` FOREIGN KEY (`fk_betting`) REFERENCES `bettings` (`id`),
  CONSTRAINT `has39` FOREIGN KEY (`fk_user`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users_bet_skins`
--

LOCK TABLES `users_bet_skins` WRITE;
/*!40000 ALTER TABLE `users_bet_skins` DISABLE KEYS */;
/*!40000 ALTER TABLE `users_bet_skins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users_bets`
--

DROP TABLE IF EXISTS `users_bets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `users_bets` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `bet_value` int(11) DEFAULT NULL,
  `won` tinyint(1) DEFAULT '0',
  `fk_user` int(11) DEFAULT NULL,
  `fk_betting` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `bets` (`fk_user`),
  KEY `has32` (`fk_betting`),
  CONSTRAINT `bets` FOREIGN KEY (`fk_user`) REFERENCES `users` (`id`),
  CONSTRAINT `has32` FOREIGN KEY (`fk_betting`) REFERENCES `bettings` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users_bets`
--

LOCK TABLES `users_bets` WRITE;
/*!40000 ALTER TABLE `users_bets` DISABLE KEYS */;
INSERT INTO `users_bets` VALUES (2,87,NULL,NULL,NULL),(3,888,NULL,NULL,NULL),(4,55555,NULL,NULL,NULL),(5,4444444,1,1,6),(6,333333333,NULL,1,11);
/*!40000 ALTER TABLE `users_bets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users_in_giveaway`
--

DROP TABLE IF EXISTS `users_in_giveaway`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `users_in_giveaway` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fk_user` int(11) NOT NULL,
  `fk_giveaway` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `has8` (`fk_user`),
  KEY `has9` (`fk_giveaway`),
  CONSTRAINT `has8` FOREIGN KEY (`fk_user`) REFERENCES `users` (`id`),
  CONSTRAINT `has9` FOREIGN KEY (`fk_giveaway`) REFERENCES `giveaways` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users_in_giveaway`
--

LOCK TABLES `users_in_giveaway` WRITE;
/*!40000 ALTER TABLE `users_in_giveaway` DISABLE KEYS */;
INSERT INTO `users_in_giveaway` VALUES (1,1,1),(2,3,1),(4,4,1),(5,1,2),(6,3,2);
/*!40000 ALTER TABLE `users_in_giveaway` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'projektas'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-29  1:49:26
