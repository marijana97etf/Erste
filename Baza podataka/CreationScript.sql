-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema erste
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema erste
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `erste` DEFAULT CHARACTER SET utf8 ;
USE `erste` ;

CREATE TABLE `osoba` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Ime` varchar(256) NOT NULL,
  `Prezime` varchar(256) NOT NULL,
  `BrojTelefona` varchar(256) NOT NULL,
  `Email` varchar(256) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5;

CREATE TABLE `polaznik` (
  `Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `OSOBA2` FOREIGN KEY (`Id`) REFERENCES `osoba` (`Id`)
) ENGINE=InnoDB;


CREATE TABLE `administrator` (
  `KorisnickoIme` varchar(256) NOT NULL,
  `LozinkaHash` varchar(256) NOT NULL,
  `Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `OSOBA1` FOREIGN KEY (`Id`) REFERENCES `osoba` (`Id`)
) ENGINE=InnoDB;

CREATE TABLE `jezik` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Naziv` varchar(256) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6;

CREATE TABLE `kurs` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nivo` varchar(256) NOT NULL,
  `JezikId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `JEZIK1_idx` (`JezikId`),
  CONSTRAINT `JEZIK1` FOREIGN KEY (`JezikId`) REFERENCES `jezik` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3;


CREATE TABLE `grupa` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `KursId` int(11) NOT NULL,
  `BrojClanova` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `KURS1_idx` (`KursId`),
  CONSTRAINT `KURS1` FOREIGN KEY (`KursId`) REFERENCES `kurs` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2;

CREATE TABLE `polaznik_grupa` (
  `PolaznikId` int(11) NOT NULL,
  `GrupaId` int(11) NOT NULL,
  PRIMARY KEY (`PolaznikId`,`GrupaId`),
  KEY `GRUPA2_idx` (`GrupaId`),
  CONSTRAINT `GRUPA2` FOREIGN KEY (`GrupaId`) REFERENCES `grupa` (`Id`),
  CONSTRAINT `POLAZNIK1` FOREIGN KEY (`PolaznikId`) REFERENCES `polaznik` (`Id`)
) ENGINE=InnoDB;

CREATE TABLE `profesor` (
  `Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `OSOBA` FOREIGN KEY (`Id`) REFERENCES `osoba` (`Id`)
) ENGINE=InnoDB;

CREATE TABLE `profesor_grupa` (
  `ProfesorId` int(11) NOT NULL,
  `GrupaId` int(11) NOT NULL,
  PRIMARY KEY (`ProfesorId`,`GrupaId`),
  KEY `GRUPA3_idx` (`GrupaId`),
  CONSTRAINT `GRUPA3` FOREIGN KEY (`GrupaId`) REFERENCES `grupa` (`Id`),
  CONSTRAINT `PROFESOR1` FOREIGN KEY (`ProfesorId`) REFERENCES `profesor` (`Id`)
) ENGINE=InnoDB;


CREATE TABLE `sluzbenik` (
  `KorisnickoIme` varchar(256) NOT NULL,
  `LozinkaHash` varchar(256) NOT NULL,
  `Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `OSOBA3` FOREIGN KEY (`Id`) REFERENCES `osoba` (`Id`)
) ENGINE=InnoDB;


CREATE TABLE `termin` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Dan` varchar(256) NOT NULL,
  `Od` time NOT NULL,
  `Do` time NOT NULL,
  `GrupaId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `GRUPA1_idx` (`GrupaId`),
  CONSTRAINT `GRUPA1` FOREIGN KEY (`GrupaId`) REFERENCES `grupa` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
