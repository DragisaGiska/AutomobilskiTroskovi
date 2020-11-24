-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 14, 2015 at 09:02 PM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `ispit`
--

-- --------------------------------------------------------

--
-- Table structure for table `potrosnja`
--

CREATE TABLE IF NOT EXISTS `potrosnja` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `potroseno_litara` double NOT NULL,
  `predjeno_km` double NOT NULL,
  `cijena_po_litru` double NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `servisi`
--

CREATE TABLE IF NOT EXISTS `servisi` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Lokacija` varchar(64) NOT NULL,
  `Opis` varchar(128) NOT NULL,
  `Cijena` double NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `troskovi`
--

CREATE TABLE IF NOT EXISTS `troskovi` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Naziv` varchar(64) NOT NULL,
  `Opis` varchar(128) NOT NULL,
  `Cijena` double NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
