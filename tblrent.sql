-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 12, 2023 at 03:59 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `lmsdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `tblrent`
--

CREATE TABLE `tblrent` (
  `rent_id` int(1) NOT NULL,
  `rent_invoice` int(2) DEFAULT NULL,
  `book_name` varchar(22) DEFAULT NULL,
  `borrower` varchar(255) NOT NULL,
  `tilldate` varchar(255) NOT NULL,
  `rent_price` int(3) NOT NULL DEFAULT 0,
  `total` varchar(255) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `tblrent`
--

INSERT INTO `tblrent` (`rent_id`, `rent_invoice`, `book_name`, `borrower`, `tilldate`, `rent_price`, `total`) VALUES
(5, 1, 'forty rules of love', 'testuser', '12/13/2023 7:46:02 PM', 1050, '105'),
(6, 2, 'forty rules of love', 'testuser', '12/14/2023 7:47:08 PM', 1050, '105'),
(7, 3, 'forty rules of love', 'testuser', '12/13/2023 7:52:39 PM', 1050, '105'),
(8, 4, 'forty rules of love', 'testuser', '12/13/2023 7:53:47 PM', 1050, '105'),
(9, 5, 'forty rules of love', 'testuser', '12/13/2023 7:55:39 PM', 1050, '105'),
(10, 6, 'forty rules of love', 'testuser', '12/15/2023 7:56:35 PM', 1050, '105'),
(11, 7, 'forty rules of love', 'testuser', '12/20/2023 7:57:53 PM', 1050, '1050');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tblrent`
--
ALTER TABLE `tblrent`
  ADD PRIMARY KEY (`rent_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tblrent`
--
ALTER TABLE `tblrent`
  MODIFY `rent_id` int(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
