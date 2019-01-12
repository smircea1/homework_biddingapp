-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 12, 2019 at 09:07 PM
-- Server version: 10.1.30-MariaDB
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `biddingdb`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchAllAuctions` ()  BEGIN
	select * from auction;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchAllCategories` ()  BEGIN
	select * from category;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchAllCurrencies` ()  BEGIN
	select * from currency;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchAllProducts` ()  BEGIN
	select * from product;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchAuctionBiddings` (IN `IdAuction` INT)  BEGIN
	select * from bid where bid.IdAuction = IdAuction order by bid.Value desc;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchAuctionByIds` (IN `IdOfferor` INT, IN `IdProduct` INT)  BEGIN
	select * from auction
	where auction.IdOfferor = IdOfferor and auction.IdProduct = IdProduct;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchAuctionHighestBid` (IN `IdAuction` INT)  BEGIN
	select * from bid
	where bid.IdAuction = IdAuction
	order by bid.Value desc limit 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchCategoryByName` (IN `Name` VARCHAR(50))  BEGIN
	select * from category where category.Name = Name;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchCurrencyByName` (IN `Name` VARCHAR(50))  BEGIN
	select * from currency
	where currency.Name = Name;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchOfferorAuctions` (IN `IdOfferor` INT)  BEGIN
	select * from auction
	where auction.IdOfferor = IdOfferor;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchOfferorAuctionsByCategory` (IN `IdOfferor` INT, IN `IdCategory` INT)  BEGIN
	select * from auction inner join product
	on product.Id = auction.IdProduct
	where product.IdCategory = IdCategory and auction.IdOfferor = IdOfferor;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchPersonBidderByIdPerson` (IN `IdPerson` INT)  BEGIN
	select * from person_bidder
	where person_bidder.IdPerson = IdPerson;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchPersonById` (IN `Id` INT)  BEGIN
	select * from person where person.Id = Id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchPersonByIdBid` (IN `IdBid` INT)  BEGIN
	select * from person_bidder inner join bid
	on person_bidder.IdBidder = bid.IdBidder
	where bid.IdBid = IdBid;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchPersonByPhone` (IN `Phone` VARCHAR(50))  BEGIN
	select * from person
	where person.Phone = Phone;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchPersonOfferorByPerson` (IN `IdPerson` INT)  BEGIN
	select * from person_offeror
	where person_offeror.IdPerson = IdPerson;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchPersonOfferorMarks` (IN `IdOfferor` INT)  BEGIN
	select * from usermarks 
	where usermarks.IdReceiver = IdOfferor order by usermarks.DateOccur desc; 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchProductByAllAttributes` (IN `IdCategory` INT, IN `Name` VARCHAR(50), IN `Description` VARCHAR(50))  BEGIN
	select * from product
	where product.IdCategory = IdCategory and product.Name = Name and product.Description = Description;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchProductById` (IN `IdProduct` INT)  BEGIN
	select * from product 
	where product.Id = IdProduct;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchSubCategories` (IN `IdCategory` INT)  BEGIN
	select * from category 
	inner join sub_category
	on category.IdCategory = sub_category.IdSon
	where sub_category.IdParent = IdCategory;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertAuction` (IN `IdOfferor` INT, IN `IdProduct` INT, IN `IdCurrency` INT, IN `StartDate` DATETIME, IN `EndDate` DATETIME, IN `StartValue` DOUBLE)  BEGIN
	insert into auction(IdOfferor, IdProduct, IdCurrency, StartDate, EndDate, StartValue) values (IdOfferor, IdProduct, IdCurrency, StartDate, EndDate, StartValue);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertBid` (IN `IdBidder` INT, IN `IdAuction` INT, IN `IdCurrency` INT, IN `Value` DOUBLE, IN `Date` DATETIME)  BEGIN
	insert into bid(IdBidder, IdAuction, IdCurrency, Value, Date) values (IdBidder, IdAuction, IdCurrency, Value, Date);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertCategory` (IN `Name` VARCHAR(50), IN `IdParent` INT)  BEGIN
	insert into category(Name) values (Name); 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertCurrency` (IN `Name` VARCHAR(50))  BEGIN
	insert into currency(Name) values(Name); 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertPerson` (IN `Name` VARCHAR(50), IN `Phone` VARCHAR(50))  BEGIN 
	insert into person(Name, Phone) values(Name, Phone); 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertPersonBidder` (IN `IdPerson` INT)  BEGIN
	insert into person_bidder(IdPerson) values(IdPerson); 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertPersonOfferor` (IN `IdPerson` INT)  BEGIN
	insert into person_offeror(IdPerson) values(IdPerson); 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertPersonOfferorMark` (IN `IdSender` INT, IN `IdReceiver` INT, IN `Mark` INT, IN `DateOccur` DATETIME)  BEGIN
	insert into personmark(IdSender, IdReceiver, Mark, DateOccur) values (IdSender, IdReceiver, Mark, DateOccur);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertProduct` (IN `IdCategory` INT, IN `Name` VARCHAR(50), IN `Description` VARCHAR(50))  BEGIN
	insert into product(IdCategory, Name, Description) values (IdCategory, Name, Description);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertSubCategory` (IN `IdParent` INT, IN `IdSon` INT)  BEGIN
	insert into sub_category(IdParent, IdSon) values (IdParent, IdSon);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateAuction` (IN `IdAuction` INT, IN `IdOfferor` INT, IN `IdProduct` INT, IN `IdCurrency` INT, IN `StartDate` DATETIME, IN `EndDate` DATETIME, IN `StartValue` DOUBLE)  BEGIN
	update auction set 

	auction.IdOfferor = IdOfferor,
	auction.IdProduct = IdProduct,
	auction.IdCurrency = IdCurrency,
	auction.StartDate = StartDate,
	auction.EndDate = EndDate,
	auction.StartValue = StartValue
	
	where auction.IdAuction = IdAuction;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdatePerson` (IN `IdPerson` INT, IN `Name` VARCHAR(50), IN `Phone` VARCHAR(50))  BEGIN
	update person set

	person.Name = Name,
	person.Phone = Phone
	
	where person.IdPerson = IdPerson;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdatePersonOfferor` (IN `IdOfferor` INT, IN `LastBannedDate` DATETIME)  BEGIN
	update person_offeror set

	person.LastBannedDate = LastBannedDate 
	
	where person_offeror.IdOfferor = IdOfferor;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `auction`
--

CREATE TABLE `auction` (
  `IdAuction` int(11) NOT NULL,
  `IdOfferor` int(11) NOT NULL,
  `IdProduct` int(11) NOT NULL,
  `IdCurrency` int(11) NOT NULL,
  `StartDate` datetime NOT NULL,
  `EndDate` datetime NOT NULL,
  `StartValue` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `bid`
--

CREATE TABLE `bid` (
  `IdBid` int(11) NOT NULL,
  `IdBidder` int(11) NOT NULL,
  `IdAuction` int(11) NOT NULL,
  `IdCurrency` int(11) NOT NULL,
  `Value` double NOT NULL,
  `Date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `IdCategory` int(11) NOT NULL,
  `Name` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`IdCategory`, `Name`) VALUES
(26, 'Bolts'),
(21, 'CellPhones'),
(24, 'Chairs'),
(18, 'Electronics'),
(23, 'Home'),
(19, 'Laptops'),
(22, 'PC Periferics'),
(25, 'Tables'),
(20, 'TVs');

-- --------------------------------------------------------

--
-- Table structure for table `currency`
--

CREATE TABLE `currency` (
  `IdCurrency` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `currency`
--

INSERT INTO `currency` (`IdCurrency`, `Name`) VALUES
(2, 'eur'),
(3, 'ron'),
(1, 'usd');

-- --------------------------------------------------------

--
-- Table structure for table `person`
--

CREATE TABLE `person` (
  `IdPerson` int(11) NOT NULL,
  `Name` text NOT NULL,
  `Phone` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `person`
--

INSERT INTO `person` (`IdPerson`, `Name`, `Phone`) VALUES
(35, 'gigica', '07299544321');

-- --------------------------------------------------------

--
-- Table structure for table `person_bidder`
--

CREATE TABLE `person_bidder` (
  `IdBidder` int(11) NOT NULL,
  `IdPerson` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `person_bidder`
--

INSERT INTO `person_bidder` (`IdBidder`, `IdPerson`) VALUES
(5, 35);

-- --------------------------------------------------------

--
-- Table structure for table `person_offeror`
--

CREATE TABLE `person_offeror` (
  `IdOfferor` int(11) NOT NULL,
  `IdPerson` int(11) NOT NULL,
  `LastBannedDate` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `person_offeror`
--

INSERT INTO `person_offeror` (`IdOfferor`, `IdPerson`, `LastBannedDate`) VALUES
(8, 35, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `person_offeror_mark`
--

CREATE TABLE `person_offeror_mark` (
  `IdOfferorMark` int(11) NOT NULL,
  `IdSender` int(11) NOT NULL,
  `IdReceiver` int(11) NOT NULL,
  `Mark` int(11) NOT NULL,
  `DateOccur` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `IdProduct` int(11) NOT NULL,
  `IdCategory` int(11) NOT NULL,
  `Name` varchar(45) NOT NULL,
  `Description` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sub_category`
--

CREATE TABLE `sub_category` (
  `IdSubCategory` int(11) NOT NULL,
  `IdParent` int(11) DEFAULT NULL,
  `IdSon` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sub_category`
--

INSERT INTO `sub_category` (`IdSubCategory`, `IdParent`, `IdSon`) VALUES
(1, 18, 18),
(2, 18, 18),
(3, 18, 18),
(4, 18, 18),
(5, 23, 23),
(6, 23, 23),
(7, 23, 23),
(8, 18, 18),
(9, 18, 18),
(10, 18, 18),
(11, 18, 18),
(12, 23, 23),
(13, 23, 23),
(14, 23, 23);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `auction`
--
ALTER TABLE `auction`
  ADD PRIMARY KEY (`IdAuction`),
  ADD KEY `auctionofferor_link_idx` (`IdOfferor`),
  ADD KEY `auctionproduct_link_idx` (`IdProduct`),
  ADD KEY `auctioncurrency_link_idx` (`IdCurrency`);

--
-- Indexes for table `bid`
--
ALTER TABLE `bid`
  ADD PRIMARY KEY (`IdBid`),
  ADD KEY `auction_link_idx` (`IdAuction`),
  ADD KEY `bidcurrency_link_idx` (`IdCurrency`),
  ADD KEY `bidbidder_link_idx` (`IdBidder`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`IdCategory`),
  ADD UNIQUE KEY `Name_UNIQUE` (`Name`);

--
-- Indexes for table `currency`
--
ALTER TABLE `currency`
  ADD PRIMARY KEY (`IdCurrency`),
  ADD UNIQUE KEY `Name_UNIQUE` (`Name`);

--
-- Indexes for table `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`IdPerson`),
  ADD UNIQUE KEY `Phone_UNIQUE` (`Phone`);

--
-- Indexes for table `person_bidder`
--
ALTER TABLE `person_bidder`
  ADD PRIMARY KEY (`IdBidder`),
  ADD UNIQUE KEY `IdPerson_UNIQUE` (`IdPerson`),
  ADD KEY `bidder_link_idx` (`IdPerson`);

--
-- Indexes for table `person_offeror`
--
ALTER TABLE `person_offeror`
  ADD PRIMARY KEY (`IdOfferor`),
  ADD UNIQUE KEY `IdPerson_UNIQUE` (`IdPerson`),
  ADD KEY `person_link_idx` (`IdPerson`);

--
-- Indexes for table `person_offeror_mark`
--
ALTER TABLE `person_offeror_mark`
  ADD PRIMARY KEY (`IdOfferorMark`),
  ADD KEY `personreceiver_link_idx` (`IdReceiver`),
  ADD KEY `personsender_link_idx` (`IdSender`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`IdProduct`),
  ADD KEY `link_category_idx` (`IdCategory`);

--
-- Indexes for table `sub_category`
--
ALTER TABLE `sub_category`
  ADD PRIMARY KEY (`IdSubCategory`),
  ADD KEY `parent_link_idx` (`IdParent`),
  ADD KEY `son_link_idx` (`IdSon`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `auction`
--
ALTER TABLE `auction`
  MODIFY `IdAuction` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `bid`
--
ALTER TABLE `bid`
  MODIFY `IdBid` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `IdCategory` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `currency`
--
ALTER TABLE `currency`
  MODIFY `IdCurrency` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `person`
--
ALTER TABLE `person`
  MODIFY `IdPerson` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT for table `person_bidder`
--
ALTER TABLE `person_bidder`
  MODIFY `IdBidder` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `person_offeror`
--
ALTER TABLE `person_offeror`
  MODIFY `IdOfferor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `person_offeror_mark`
--
ALTER TABLE `person_offeror_mark`
  MODIFY `IdOfferorMark` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `IdProduct` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `sub_category`
--
ALTER TABLE `sub_category`
  MODIFY `IdSubCategory` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `auction`
--
ALTER TABLE `auction`
  ADD CONSTRAINT `auctioncurrency_link` FOREIGN KEY (`IdCurrency`) REFERENCES `currency` (`IdCurrency`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `auctionofferor_link` FOREIGN KEY (`IdOfferor`) REFERENCES `person_offeror` (`IdOfferor`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `auctionproduct_link` FOREIGN KEY (`IdProduct`) REFERENCES `product` (`IdProduct`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `bid`
--
ALTER TABLE `bid`
  ADD CONSTRAINT `bidauction_link` FOREIGN KEY (`IdAuction`) REFERENCES `auction` (`IdAuction`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `bidbidder_link` FOREIGN KEY (`IdBidder`) REFERENCES `person_bidder` (`IdBidder`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `bidcurrency_link` FOREIGN KEY (`IdCurrency`) REFERENCES `currency` (`IdCurrency`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `person_bidder`
--
ALTER TABLE `person_bidder`
  ADD CONSTRAINT `bidder_link` FOREIGN KEY (`IdPerson`) REFERENCES `person` (`IdPerson`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `person_offeror`
--
ALTER TABLE `person_offeror`
  ADD CONSTRAINT `offeror_link` FOREIGN KEY (`IdPerson`) REFERENCES `person` (`IdPerson`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `person_offeror_mark`
--
ALTER TABLE `person_offeror_mark`
  ADD CONSTRAINT `personreceiver_link` FOREIGN KEY (`IdReceiver`) REFERENCES `person_offeror` (`IdOfferor`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `personsender_link` FOREIGN KEY (`IdSender`) REFERENCES `person` (`IdPerson`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `link_category` FOREIGN KEY (`IdCategory`) REFERENCES `category` (`IdCategory`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `sub_category`
--
ALTER TABLE `sub_category`
  ADD CONSTRAINT `parent_link` FOREIGN KEY (`IdParent`) REFERENCES `category` (`IdCategory`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `son_link` FOREIGN KEY (`IdSon`) REFERENCES `category` (`IdCategory`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
