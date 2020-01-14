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

-- -----------------------------------------------------
-- Table `erste`.`OSOBA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`OSOBA` (
  `Id` INT NOT NULL,
  `Ime` VARCHAR(256) NOT NULL,
  `Prezime` VARCHAR(256) NOT NULL,
  `BrojTelefona` VARCHAR(256) NOT NULL,
  `Email` VARCHAR(256) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `erste`.`PROFESOR`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`PROFESOR` (
  `Id` INT NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `OSOBA`
    FOREIGN KEY (`Id`)
    REFERENCES `erste`.`OSOBA` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `erste`.`ADMINISTRATOR`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`ADMINISTRATOR` (
  `KorisnickoIme` VARCHAR(256) NOT NULL,
  `LozinkaHash` VARCHAR(256) NOT NULL,
  `Id` INT NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `OSOBA1`
    FOREIGN KEY (`Id`)
    REFERENCES `erste`.`OSOBA` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `erste`.`POLAZNIK`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`POLAZNIK` (
  `Id` INT NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `OSOBA2`
    FOREIGN KEY (`Id`)
    REFERENCES `erste`.`OSOBA` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `erste`.`SLUZBENIK`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`SLUZBENIK` (
  `KorisnickoIme` VARCHAR(256) NOT NULL,
  `LozinkaHash` VARCHAR(256) NOT NULL,
  `Id` INT NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `OSOBA3`
    FOREIGN KEY (`Id`)
    REFERENCES `erste`.`OSOBA` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `erste`.`JEZIK`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`JEZIK` (
  `Id` INT NOT NULL,
  `Naziv` VARCHAR(256) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `erste`.`KURS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`KURS` (
  `Id` INT NOT NULL,
  `Nivo` VARCHAR(256) NOT NULL,
  `JezikId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `JEZIK1_idx` (`JezikId` ASC) VISIBLE,
  CONSTRAINT `JEZIK1`
    FOREIGN KEY (`JezikId`)
    REFERENCES `erste`.`JEZIK` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `erste`.`GRUPA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`GRUPA` (
  `Id` INT NOT NULL,
  `KursId` INT NOT NULL,
  `BrojClanova` INT NULL,
  PRIMARY KEY (`Id`),
  INDEX `KURS1_idx` (`KursId` ASC) VISIBLE,
  CONSTRAINT `KURS1`
    FOREIGN KEY (`KursId`)
    REFERENCES `erste`.`KURS` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `erste`.`TERMIN`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`TERMIN` (
  `Id` INT NOT NULL,
  `Dan` VARCHAR(256) NOT NULL,
  `Od` TIME NOT NULL,
  `Do` TIME NOT NULL,
  `GrupaId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `GRUPA1_idx` (`GrupaId` ASC) VISIBLE,
  CONSTRAINT `GRUPA1`
    FOREIGN KEY (`GrupaId`)
    REFERENCES `erste`.`GRUPA` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `erste`.`POLAZNIK_GRUPA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`POLAZNIK_GRUPA` (
  `PolaznikId` INT NOT NULL,
  `GrupaId` INT NOT NULL,
  PRIMARY KEY (`PolaznikId`, `GrupaId`),
  INDEX `GRUPA2_idx` (`GrupaId` ASC) VISIBLE,
  CONSTRAINT `POLAZNIK1`
    FOREIGN KEY (`PolaznikId`)
    REFERENCES `erste`.`POLAZNIK` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `GRUPA2`
    FOREIGN KEY (`GrupaId`)
    REFERENCES `erste`.`GRUPA` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `erste`.`PROFESOR_GRUPA`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`PROFESOR_GRUPA` (
  `ProfesorId` INT NOT NULL,
  `GrupaId` INT NOT NULL,
  PRIMARY KEY (`ProfesorId`, `GrupaId`),
  INDEX `GRUPA3_idx` (`GrupaId` ASC) VISIBLE,
  CONSTRAINT `PROFESOR1`
    FOREIGN KEY (`ProfesorId`)
    REFERENCES `erste`.`PROFESOR` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `GRUPA3`
    FOREIGN KEY (`GrupaId`)
    REFERENCES `erste`.`GRUPA` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
