-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 2019 m. Geg 22 d. 13:39
-- Server version: 10.1.40-MariaDB
-- PHP Version: 7.3.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `projektas`
--

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `bettings`
--

CREATE TABLE `bettings` (
  `id` int(11) NOT NULL,
  `coefficient` double(40,8) NOT NULL,
  `fk_users_bets` int(11) NOT NULL,
  `fk_match` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `evaluation`
--

CREATE TABLE `evaluation` (
  `id` int(11) NOT NULL,
  `score` int(11) NOT NULL,
  `description` longtext NOT NULL,
  `timestamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `fk_user` int(11) NOT NULL,
  `fk_tournament` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `events`
--

CREATE TABLE `eventts` (
  `id` int(11) NOT NULL,
  `start_time` datetime NOT NULL,
  `finish_time` datetime NOT NULL,
  `name` varchar(30) NOT NULL,
  `fk_program` int(11) DEFAULT NULL,
  `fk_tournament` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `giveaways`
--

CREATE TABLE `giveaways` (
  `id` int(11) NOT NULL,
  `description` longtext NOT NULL,
  `start_time` datetime NOT NULL,
  `end_time` datetime NOT NULL,
  `fk_skinsInGiveaway` int(11) DEFAULT NULL,
  `fk_usersInGiveaway` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `matches`
--

CREATE TABLE `matches` (
  `id` int(11) NOT NULL,
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
  `fk_ticket` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `place`
--

CREATE TABLE `place` (
  `id` int(11) NOT NULL,
  `index` int(11) NOT NULL,
  `fk_user` int(11) NOT NULL,
  `fk_match` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `players`
--

CREATE TABLE `players` (
  `id` int(11) NOT NULL,
  `username` varchar(30) NOT NULL,
  `password` longtext NOT NULL,
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
  `fk_team` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `programs`
--

CREATE TABLE `programs` (
  `id` int(11) NOT NULL,
  `name` varchar(30) NOT NULL,
  `description` longtext NOT NULL,
  `fk_tournament` int(11) DEFAULT NULL,
  `fk_event` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `skins`
--

CREATE TABLE `skins` (
  `id` int(11) NOT NULL,
  `name` varchar(30) NOT NULL,
  `fk_skinsInGiveaway` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `skins_in_giveaway`
--

CREATE TABLE `skins_in_giveaway` (
  `id` int(11) NOT NULL,
  `fk_skin` int(11) NOT NULL,
  `fk_giveaway` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `teams`
--

CREATE TABLE `teams` (
  `id` int(11) NOT NULL,
  `name` varchar(30) NOT NULL,
  `wins` int(11) NOT NULL,
  `defeats` int(11) NOT NULL,
  `maps_played` int(11) NOT NULL,
  `round_number` int(11) NOT NULL,
  `total_kills` int(11) NOT NULL,
  `total_deaths` int(11) NOT NULL,
  `fk_match` int(11) DEFAULT NULL,
  `fk_player` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `tickets`
--

CREATE TABLE `tickets` (
  `id` int(11) NOT NULL,
  `price` double(10,2) NOT NULL,
  `description` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `tournaments`
--

CREATE TABLE `tournaments` (
  `id` int(11) NOT NULL,
  `name` varchar(30) NOT NULL,
  `type` varchar(30) NOT NULL,
  `fk_event` int(11) DEFAULT NULL,
  `fk_match` int(11) DEFAULT NULL,
  `fk_evaluation` int(11) DEFAULT NULL,
  `fk_program` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(30) NOT NULL,
  `password` longtext NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `sex` varchar(20) NOT NULL,
  `email` varchar(50) NOT NULL,
  `fk_ticket` int(11) DEFAULT NULL,
  `fk_users_bets` int(11) DEFAULT NULL,
  `fk_giveaway` int(11) DEFAULT NULL,
  `fk_evaluation` int(11) DEFAULT NULL,
  `fk_place` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `users_bets`
--

CREATE TABLE `users_bets` (
  `id` int(11) NOT NULL,
  `bet_value` int(11) DEFAULT NULL,
  `won` tinyint(1) DEFAULT '0',
  `fk_user` int(11) DEFAULT NULL,
  `fk_betting` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `users_in_giveaway`
--

CREATE TABLE `users_in_giveaway` (
  `id` int(11) NOT NULL,
  `fk_user` int(11) NOT NULL,
  `fk_giveaway` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bettings`
--
ALTER TABLE `bettings`
  ADD PRIMARY KEY (`id`),
  ADD KEY `belongs8` (`fk_users_bets`),
  ADD KEY `has11` (`fk_match`);

--
-- Indexes for table `evaluation`
--
ALTER TABLE `evaluation`
  ADD PRIMARY KEY (`id`),
  ADD KEY `submits` (`fk_user`),
  ADD KEY `has7` (`fk_tournament`);

--
-- Indexes for table `events`
--
ALTER TABLE `eventts`
  ADD PRIMARY KEY (`id`),
  ADD KEY `has12` (`fk_tournament`),
  ADD KEY `has4` (`fk_program`);

--
-- Indexes for table `giveaways`
--
ALTER TABLE `giveaways`
  ADD PRIMARY KEY (`id`),
  ADD KEY `has14` (`fk_usersInGiveaway`),
  ADD KEY `has13` (`fk_skinsInGiveaway`);

--
-- Indexes for table `matches`
--
ALTER TABLE `matches`
  ADD PRIMARY KEY (`id`),
  ADD KEY `plays` (`fk_first_team`),
  ADD KEY `plays1` (`fk_second_team`),
  ADD KEY `belongs3` (`fk_tournament`),
  ADD KEY `has15` (`fk_place`),
  ADD KEY `has16` (`fk_betting`),
  ADD KEY `has10` (`fk_ticket`);

--
-- Indexes for table `place`
--
ALTER TABLE `place`
  ADD PRIMARY KEY (`id`),
  ADD KEY `votes` (`fk_user`),
  ADD KEY `has6` (`fk_match`);

--
-- Indexes for table `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`id`),
  ADD KEY `belongs5` (`fk_team`);

--
-- Indexes for table `programs`
--
ALTER TABLE `programs`
  ADD PRIMARY KEY (`id`),
  ADD KEY `has18` (`fk_event`),
  ADD KEY `has17` (`fk_tournament`);

--
-- Indexes for table `skins`
--
ALTER TABLE `skins`
  ADD PRIMARY KEY (`id`),
  ADD KEY `has21` (`fk_skinsInGiveaway`);

--
-- Indexes for table `skins_in_giveaway`
--
ALTER TABLE `skins_in_giveaway`
ADD PRIMARY KEY (`id`),
  ADD KEY `has1` (`fk_skin`),
  ADD KEY `has2` (`fk_giveaway`);

--
-- Indexes for table `teams`
--
ALTER TABLE `teams`
  ADD PRIMARY KEY (`id`),
  ADD KEY `has22` (`fk_match`),
  ADD KEY `has23` (`fk_player`);

--
-- Indexes for table `tickets`
--
ALTER TABLE `tickets`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tournaments`
--
ALTER TABLE `tournaments`
  ADD PRIMARY KEY (`id`),
  ADD KEY `has5` (`fk_event`),
  ADD KEY `has25` (`fk_match`),
  ADD KEY `has26` (`fk_evaluation`),
  ADD KEY `has27` (`fk_program`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD KEY `has3` (`fk_ticket`),
  ADD KEY `has28` (`fk_giveaway`),
  ADD KEY `has29` (`fk_evaluation`),
  ADD KEY `has30` (`fk_users_bets`),
  ADD KEY `has31` (`fk_place`);

--
-- Indexes for table `users_bets`
--
ALTER TABLE `users_bets`
  ADD PRIMARY KEY (`id`),
  ADD KEY `bets` (`fk_user`),
  ADD KEY `has32` (`fk_betting`);

--
-- Indexes for table `users_in_giveaway`
--
ALTER TABLE `users_in_giveaway`
  ADD PRIMARY KEY (`id`),
  ADD KEY `has8` (`fk_user`),
  ADD KEY `has9` (`fk_giveaway`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bettings`
--
ALTER TABLE `bettings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `events`
--
ALTER TABLE `eventts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `giveaways`
--
ALTER TABLE `giveaways`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `matches`
--
ALTER TABLE `matches`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `place`
--
ALTER TABLE `place`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `players`
--
ALTER TABLE `players`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `programs`
--
ALTER TABLE `programs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;


--
-- AUTO_INCREMENT for table `skins`
--
ALTER TABLE `skins`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `teams`
--
ALTER TABLE `teams`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tickets`
--
ALTER TABLE `tickets`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tournaments`
--
ALTER TABLE `tournaments`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users_bets`
--
ALTER TABLE `users_bets`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

  ALTER TABLE `users_in_giveaway`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

  ALTER TABLE `skins_in_giveaway`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Apribojimai eksportuotom lentelėm
--

--
-- Apribojimai lentelei `bettings`
--
ALTER TABLE `bettings`
  ADD CONSTRAINT `belongs8` FOREIGN KEY (`fk_users_bets`) REFERENCES `users_bets` (`id`),
  ADD CONSTRAINT `has11` FOREIGN KEY (`fk_match`) REFERENCES `matches` (`id`);

--
-- Apribojimai lentelei `evaluation`
--
ALTER TABLE `evaluation`
  ADD CONSTRAINT `has7` FOREIGN KEY (`fk_tournament`) REFERENCES `tournaments` (`id`),
  ADD CONSTRAINT `submits` FOREIGN KEY (`fk_user`) REFERENCES `users` (`id`);

--
-- Apribojimai lentelei `events`
--
ALTER TABLE `eventts`
  ADD CONSTRAINT `has4` FOREIGN KEY (`fk_program`) REFERENCES `programs` (`id`),
  ADD CONSTRAINT `has12` FOREIGN KEY (`fk_tournament`) REFERENCES `tournaments` (`id`);

  ALTER TABLE `giveaways`
  ADD CONSTRAINT `has13` FOREIGN KEY (`fk_skinsInGiveaway`) REFERENCES `skins_in_giveaway` (`id`),
  ADD CONSTRAINT `has14` FOREIGN KEY (`fk_usersInGiveaway`) REFERENCES `users_in_giveaway` (`id`);

--
-- Apribojimai lentelei `matches`
--
ALTER TABLE `matches`
  ADD CONSTRAINT `belongs3` FOREIGN KEY (`fk_tournament`) REFERENCES `tournaments` (`id`),
  ADD CONSTRAINT `has10` FOREIGN KEY (`fk_ticket`) REFERENCES `tickets` (`id`),
  ADD CONSTRAINT `plays` FOREIGN KEY (`fk_first_team`) REFERENCES `teams` (`id`),
  ADD CONSTRAINT `plays1` FOREIGN KEY (`fk_second_team`) REFERENCES `teams` (`id`),
  ADD CONSTRAINT `has15` FOREIGN KEY (`fk_place`) REFERENCES `place` (`id`),
  ADD CONSTRAINT `has16` FOREIGN KEY (`fk_betting`) REFERENCES `bettings` (`id`),
  ADD CONSTRAINT `has33` FOREIGN KEY (`fk_ticket`) REFERENCES `tickets` (`id`);

--
-- Apribojimai lentelei `place`
--
ALTER TABLE `place`
  ADD CONSTRAINT `has6` FOREIGN KEY (`fk_match`) REFERENCES `matches` (`id`),
  ADD CONSTRAINT `votes` FOREIGN KEY (`fk_user`) REFERENCES `users` (`id`);

--
-- Apribojimai lentelei `players`
--
ALTER TABLE `players`
  ADD CONSTRAINT `belongs5` FOREIGN KEY (`fk_team`) REFERENCES `teams` (`id`);


ALTER table `programs`
ADD CONSTRAINT `has18` FOREIGN KEY (`fk_event`) REFERENCES `eventts` (`id`),
ADD CONSTRAINT `has17` FOREIGN KEY (`fk_tournament`) REFERENCES `tournaments` (`id`);
--
-- Apribojimai lentelei `skins_in_giveaway`
--
ALTER TABLE `skins_in_giveaway`
  ADD CONSTRAINT `has1` FOREIGN KEY (`fk_skin`) REFERENCES `skins` (`id`),
  ADD CONSTRAINT `has2` FOREIGN KEY (`fk_giveaway`) REFERENCES `giveaways` (`id`);


ALTER table `teams`
ADD CONSTRAINT `has22` FOREIGN KEY (`fk_match`) REFERENCES `matches` (`id`),
ADD CONSTRAINT `has23` FOREIGN KEY (`fk_player`) REFERENCES `players` (`id`);
--
-- Apribojimai lentelei `tournaments`
--
ALTER TABLE `tournaments`
  ADD CONSTRAINT `has5` FOREIGN KEY (`fk_event`) REFERENCES `eventts` (`id`),
  ADD CONSTRAINT `has25` FOREIGN KEY (`fk_match`) REFERENCES `matches` (`id`),
  ADD CONSTRAINT `has26` FOREIGN KEY (`fk_evaluation`) REFERENCES `evaluation` (`id`),
  ADD CONSTRAINT `has27` FOREIGN KEY (`fk_program`) REFERENCES `programs` (`id`);

--
-- Apribojimai lentelei `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `has3` FOREIGN KEY (`fk_ticket`) REFERENCES `tickets` (`id`),
  ADD CONSTRAINT `has28` FOREIGN KEY (`fk_giveaway`) REFERENCES `giveaways` (`id`),
  ADD CONSTRAINT `has29` FOREIGN KEY (`fk_evaluation`) REFERENCES `evaluation` (`id`),
  ADD CONSTRAINT `has30` FOREIGN KEY (`fk_users_bets`) REFERENCES `users_bets` (`id`),
  ADD CONSTRAINT `has31` FOREIGN KEY (`fk_place`) REFERENCES `place` (`id`);

--
-- Apribojimai lentelei `users_bets`
--
ALTER TABLE `users_bets`
  ADD CONSTRAINT `bets` FOREIGN KEY (`fk_user`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `has32` FOREIGN KEY (`fk_betting`) REFERENCES `bettings` (`id`);

--
-- Apribojimai lentelei `users_in_giveaway`
--
ALTER TABLE `users_in_giveaway`
  ADD CONSTRAINT `has8` FOREIGN KEY (`fk_user`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `has9` FOREIGN KEY (`fk_giveaway`) REFERENCES `giveaways` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
