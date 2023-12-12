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
-- Table structure for table `tblpurchase`
--

CREATE TABLE `tblpurchase` (
  `pur_id` int(2) NOT NULL,
  `invoice` int(2) DEFAULT NULL,
  `book_name` varchar(22) DEFAULT NULL,
  `author` varchar(255) NOT NULL,
  `batch_no` varchar(6) DEFAULT NULL,
  `quantity` int(3) NOT NULL DEFAULT 0,
  `tradeprice` int(3) DEFAULT 0,
  `rentprice` int(3) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `tblpurchase`
--

INSERT INTO `tblpurchase` (`pur_id`, `invoice`, `book_name`, `author`, `batch_no`, `quantity`, `tradeprice`, `rentprice`) VALUES
(20, 1, 'forty rules of love', 'elif sherik', 'abc', 100, 900, 1050),
(21, 2, 'forty rules of love', 'elif sherik', 'abc', 100, 700, 1050),
(22, 3, 'forty rules of love', 'elif sherik', 'abc', 100, 700, 1050),
(23, 4, 'forty rules of love', 'elif sherik', 'batch', 100, 700, 1050),
(24, 5, 'forty rules of love', 'elif sherik', 'abc', 100, 700, 1050),
(25, 6, 'forty rules of love', 'elif sherik', 'abc', 100, 700, 1050),
(26, 7, 'forty rules of love', 'elif sherik', 'abc', 100, 700, 1050);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tblpurchase`
--
ALTER TABLE `tblpurchase`
  ADD PRIMARY KEY (`pur_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tblpurchase`
--
ALTER TABLE `tblpurchase`
  MODIFY `pur_id` int(2) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
