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
-- -----------------------------------------------------
-- Schema erste
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema erste
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `erste` DEFAULT CHARACTER SET utf8 ;
USE `erste` ;

-- -----------------------------------------------------
-- Table `erste`.`osoba`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`osoba` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Ime` VARCHAR(256) NOT NULL,
  `Prezime` VARCHAR(256) NOT NULL,
  `BrojTelefona` VARCHAR(256) NOT NULL,
  `Email` VARCHAR(256) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `erste`.`polaznik`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`polaznik` (
  `Id` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `OSOBA2`
    FOREIGN KEY (`Id`)
    REFERENCES `erste`.`osoba` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `erste`.`polaznik_na_cekanju`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`polaznik_na_cekanju` (
  `Id` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `fk_polaznik_na_cekanju_polaznik`
    FOREIGN KEY (`Id`)
    REFERENCES `erste`.`polaznik` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `erste` ;

-- -----------------------------------------------------
-- Table `erste`.`administrator`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`administrator` (
  `KorisnickoIme` VARCHAR(256) NOT NULL,
  `LozinkaHash` VARCHAR(256) NOT NULL,
  `Id` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `OSOBA1`
    FOREIGN KEY (`Id`)
    REFERENCES `erste`.`osoba` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `erste`.`jezik`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`jezik` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Naziv` VARCHAR(256) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 6
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `erste`.`kurs`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`kurs` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Nivo` VARCHAR(256) NOT NULL,
  `JezikId` INT(11) NOT NULL,
  `DatumOd` DATE NOT NULL,
  `DatumDo` DATE NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `JEZIK1_idx` (`JezikId` ASC) VISIBLE,
  CONSTRAINT `JEZIK1`
    FOREIGN KEY (`JezikId`)
    REFERENCES `erste`.`jezik` (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `erste`.`grupa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`grupa` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `KursId` INT(11) NOT NULL,
  `BrojClanova` INT(11) NOT NULL,
  `Naziv` VARCHAR(256) NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `KURS1_idx` (`KursId` ASC) VISIBLE,
  CONSTRAINT `KURS1`
    FOREIGN KEY (`KursId`)
    REFERENCES `erste`.`kurs` (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `erste`.`polaznik_grupa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`polaznik_grupa` (
  `PolaznikId` INT(11) NOT NULL,
  `GrupaId` INT(11) NOT NULL,
  PRIMARY KEY (`PolaznikId`, `GrupaId`),
  INDEX `GRUPA2_idx` (`GrupaId` ASC) VISIBLE,
  CONSTRAINT `GRUPA2`
    FOREIGN KEY (`GrupaId`)
    REFERENCES `erste`.`grupa` (`Id`),
  CONSTRAINT `POLAZNIK1`
    FOREIGN KEY (`PolaznikId`)
    REFERENCES `erste`.`polaznik` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `erste`.`profesor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`profesor` (
  `Id` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `OSOBA`
    FOREIGN KEY (`Id`)
    REFERENCES `erste`.`osoba` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `erste`.`profesor_grupa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`profesor_grupa` (
  `ProfesorId` INT(11) NOT NULL,
  `GrupaId` INT(11) NOT NULL,
  PRIMARY KEY (`ProfesorId`, `GrupaId`),
  INDEX `GRUPA3_idx` (`GrupaId` ASC) VISIBLE,
  CONSTRAINT `GRUPA3`
    FOREIGN KEY (`GrupaId`)
    REFERENCES `erste`.`grupa` (`Id`),
  CONSTRAINT `PROFESOR1`
    FOREIGN KEY (`ProfesorId`)
    REFERENCES `erste`.`profesor` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `erste`.`sluzbenik`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`sluzbenik` (
  `KorisnickoIme` VARCHAR(256) NOT NULL,
  `LozinkaHash` VARCHAR(256) NOT NULL,
  `Id` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `OSOBA3`
    FOREIGN KEY (`Id`)
    REFERENCES `erste`.`osoba` (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `erste`.`termin`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`termin` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Dan` VARCHAR(256) NOT NULL,
  `Od` TIME NOT NULL,
  `Do` TIME NOT NULL,
  `GrupaId` INT(11) NULL,
  PRIMARY KEY (`Id`),
  INDEX `GRUPA1_idx` (`GrupaId` ASC) VISIBLE,
  CONSTRAINT `GRUPA1`
    FOREIGN KEY (`GrupaId`)
    REFERENCES `erste`.`grupa` (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `erste`.`kurs_polaznik_na_cekanju`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `erste`.`kurs_polaznik_na_cekanju` (
  `PolaznikNaCekanjuId` INT(11) NOT NULL,
  `KursId` INT(11) NOT NULL,
  PRIMARY KEY (`PolaznikNaCekanjuId`, `KursId`),
  INDEX `fk_grupa_has_polaznik_na_cekanju_polaznik_na_cekanju1_idx` (`PolaznikNaCekanjuId` ASC) VISIBLE,
  INDEX `fk_grupa_polaznik_na_cekanju_kurs1_idx` (`KursId` ASC) VISIBLE,
  CONSTRAINT `fk_grupa_has_polaznik_na_cekanju_polaznik_na_cekanju1`
    FOREIGN KEY (`PolaznikNaCekanjuId`)
    REFERENCES `erste`.`polaznik_na_cekanju` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_grupa_polaznik_na_cekanju_kurs1`
    FOREIGN KEY (`KursId`)
    REFERENCES `erste`.`kurs` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

use erste;

delimiter %%
create trigger povecaj_broj_clanova after insert
on polaznik_grupa
for each row
begin
     update grupa
     set BrojClanova = BrojClanova+1
     where new.GrupaId=Id;
end%%
delimiter ;
