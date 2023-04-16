-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 16, 2023 at 12:20 AM
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
-- Table structure for table `tbl_issue_detail`
--

DROP TABLE IF EXISTS `tbl_issue_detail`;
CREATE TABLE IF NOT EXISTS `tbl_issue_detail` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Issue_Category` varchar(100) DEFAULT NULL,
  `Issue_Date` date DEFAULT NULL,
  `Priority` varchar(100) DEFAULT NULL,
  `Status` varchar(100) DEFAULT NULL,
  `Solution` varchar(300) DEFAULT NULL,
  `Engin_Id` int(11) DEFAULT NULL,
  `Feedback` varchar(300) DEFAULT NULL,
  `Description` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_issue_detail`
--

INSERT INTO `tbl_issue_detail` (`ID`, `Issue_Category`, `Issue_Date`, `Priority`, `Status`, `Solution`, `Engin_Id`, `Feedback`, `Description`) VALUES
(2, 'Hardware', '2023-04-16', 'High', 'Cancle', NULL, NULL, 'Sorry', 'House Not Working'),
(4, 'Hardware', '2023-04-16', 'High', 'Resolved', 'Change Key Board', 1, 'Thanks', 'Key board n key not working');

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


/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
