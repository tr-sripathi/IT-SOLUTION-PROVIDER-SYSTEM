-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 02, 2023 at 12:43 PM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_it_solution_provider`
--
CREATE DATABASE IF NOT EXISTS `db_it_solution_provider` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `db_it_solution_provider`;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user_registration`
--

DROP TABLE IF EXISTS `tbl_user_registration`;
CREATE TABLE IF NOT EXISTS `tbl_user_registration` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(100) DEFAULT NULL,
  `FirstName` varchar(100) DEFAULT NULL,
  `LastName` varchar(100) DEFAULT NULL,
  `Email` varchar(200) DEFAULT NULL,
  `PhoneNO` varchar(100) DEFAULT NULL,
  `Password` varchar(100) DEFAULT NULL,
  `UserRoles` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_user_registration`
--

INSERT INTO `tbl_user_registration` (`UserID`, `UserName`, `FirstName`, `LastName`, `Email`, `PhoneNO`, `Password`, `UserRoles`) VALUES
(1, NULL, 'Azaruddin', 'Bhadgavkar', 'azaruddinbhadgavkar1111@gmail.com', '08408098804', '8408098804', 'Engineers');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
