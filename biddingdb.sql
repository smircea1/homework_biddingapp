-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 01, 2018 at 09:09 PM
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
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeletePerson` (IN `IdPerson` INT)  BEGIN
	delete from person
	where person.Id = IdPerson;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchAllAuctions` ()  BEGIN
	select * from auction;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchAllCategories` ()  BEGIN
	select * from category;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchAllProducts` ()  BEGIN
	select * from product;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchAuctionBiddings` (IN `IdAuction` INT)  BEGIN
	select * from bid where bid.IdAuction = IdAuction order by bid.Value desc;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchAuctionBidds` (IN `Id` INT)  BEGIN
	select * from bid inner join auction
	on bid.IdAuction = auction.Id
	where auction.Id = Id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchAuctionById` (IN `Id` INT)  BEGIN
	select * from auction where auction.Id = Id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchAuctionHighestBid` (IN `IdAuction` INT)  BEGIN
	select * from bid
	where bid.IdAuction = IdAuction
	order by bid.Value desc limit 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchOfferorAuctions` (IN `Id` INT)  BEGIN
	select * from auction inner join person_offeror
	on auction.IdOfferor = person_offeror.Id
	where person_offeror.Id = Id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchOfferorAuctionsByCategory` (IN `IdOfferor` INT, IN `IdCategory` INT)  BEGIN
	select * from auction inner join product
	on product.Id = auction.IdProduct
	where product.IdCategory = IdCategory and auction.IdOfferor = IdOfferor;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchPersonBidderByPerson` (IN `Id` INT)  BEGIN
	select * from person_bidder
	where person_bidder.IdPerson = Id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchPersonById` (IN `Id` INT)  BEGIN
	select * from person where person.Id = Id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchPersonOfferorByPerson` (IN `Id` INT)  BEGIN
	select * from person_offeror
	where person_offeror.IdPerson = Id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchPersonOfferorMarks` (IN `Id` INT)  BEGIN
	select * from usermarks 
	where usermarks.IdReceiver = Id order by usermarks.DateOccur desc; 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchProductById` (IN `Id` INT)  BEGIN
	select * from product 
	where product.Id = Id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `FetchSubCategories` (IN `Id` INT)  BEGIN
	select * from category 
	inner join sub_category
	on category.Id = sub_category.IdSon
	where sub_category.IdParent = Id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertAuction` (IN `IdOfferor` INT, IN `IdProduct` INT, IN `IdCurrency` INT, IN `StartDate` DATETIME, IN `EndDate` DATETIME, IN `StartValue` DOUBLE)  BEGIN
	insert into auction(IdOfferor, IdProduct, IdCurrency, StartDate, EndDate, StartValue) values (IdOfferor, IdProduct, IdCurrency, StartDate, EndDate, StartValue);
	SELECT LAST_INSERT_ID(); 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertBid` (IN `IdBidder` INT, IN `IdAuction` INT, IN `IdCurrency` INT, IN `Value` DOUBLE, IN `Date` DATETIME)  BEGIN
	insert into bid(IdBidder, IdAuction, IdCurrency, Value, Date) values (IdBidder, IdAuction, IdCurrency, Value, Date);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertCategory` (IN `Name` VARCHAR(50))  BEGIN
	insert into category(Name) values (Name);
	SELECT LAST_INSERT_ID(); 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertCurrency` (IN `Name` VARCHAR(50))  BEGIN
	insert into currency(Name) values(Name);
	SELECT LAST_INSERT_ID(); 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertPerson` (IN `Name` VARCHAR(50))  BEGIN
	insert into person(Name) values(Name);
	SELECT LAST_INSERT_ID(); 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertPersonBidder` (IN `Id` INT)  BEGIN
	insert into person_bidder(IdPerson) values(Id);
	SELECT LAST_INSERT_ID(); 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertPersonOfferor` (IN `Id` INT)  BEGIN
	insert into person_offeror(IdPerson) values(Id);
	SELECT LAST_INSERT_ID(); 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertPersonOfferorMark` (IN `IdSender` INT, IN `IdReceiver` INT, IN `Mark` INT, IN `DateOccur` DATETIME)  BEGIN
	insert into personmark(IdSender, IdReceiver, Mark, DateOccur) values (IdSender, IdReceiver, Mark, DateOccur);
	SELECT LAST_INSERT_ID(); 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertProduct` (IN `IdCategory` INT, IN `Name` VARCHAR(50), IN `Description` VARCHAR(50))  BEGIN
	insert into product(IdCategory, Name, Description) values (IdCategory, Name, Description);
	SELECT LAST_INSERT_ID(); 
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertSubCategory` (IN `IdParent` INT, IN `IdSon` INT)  BEGIN
	insert into sub_category(IdParent, IdSon) values (IdParent, IdSon);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateAuction` (IN `Id` INT, IN `IdOfferor` INT, IN `IdProduct` INT, IN `IdCurrency` INT, IN `StartDate` DATETIME, IN `EndDate` DATETIME, IN `StartValue` DOUBLE)  BEGIN
	update auction set 

	auction.IdOfferor = IdOfferor,
	auction.IdProduct = IdProduct,
	auction.IdCurrency = IdCurrency,
	auction.StartDate = StartDate,
	auction.EndDate = EndDate,
	auction.StartValue = StartValue
	
	where auction.Id = Id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdatePerson` (IN `Id` INT, IN `Name` VARCHAR(50))  BEGIN
	update person set

	person.Name = Name 
	
	where person.Id = Id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdatePersonOfferor` (IN `Id` INT, IN `LastBannedDate` DATETIME)  BEGIN
	update person_offeror set

	person.LastBannedDate = LastBannedDate 
	
	where person_offeror.Id = Id;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `auction`
--

CREATE TABLE `auction` (
  `Id` int(11) NOT NULL,
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
  `Id` int(11) NOT NULL,
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
  `Id` int(11) NOT NULL,
  `Name` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`Id`, `Name`) VALUES
(1, 'animal');

-- --------------------------------------------------------

--
-- Table structure for table `currency`
--

CREATE TABLE `currency` (
  `Id` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `person`
--

CREATE TABLE `person` (
  `Id` int(11) NOT NULL,
  `Name` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `person`
--

INSERT INTO `person` (`Id`, `Name`) VALUES
(16, 'gigi'),
(17, 'gigica'),
(18, 'gigica'),
(19, 'gigica'),
(20, 'gigica');

-- --------------------------------------------------------

--
-- Table structure for table `person_bidder`
--

CREATE TABLE `person_bidder` (
  `Id` int(11) NOT NULL,
  `IdPerson` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `person_offeror`
--

CREATE TABLE `person_offeror` (
  `Id` int(11) NOT NULL,
  `IdPerson` int(11) NOT NULL,
  `LastBannedDate` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `person_offeror_mark`
--

CREATE TABLE `person_offeror_mark` (
  `Id` int(11) NOT NULL,
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
  `Id` int(11) NOT NULL,
  `IdCategory` int(11) NOT NULL,
  `Name` varchar(45) NOT NULL,
  `Description` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`Id`, `IdCategory`, `Name`, `Description`) VALUES
(1, 1, 'Caine', 'Husky');

-- --------------------------------------------------------

--
-- Table structure for table `sub_category`
--

CREATE TABLE `sub_category` (
  `Id` int(11) NOT NULL,
  `IdParent` int(11) NOT NULL,
  `IdSon` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `auction`
--
ALTER TABLE `auction`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `auctionofferor_link_idx` (`IdOfferor`),
  ADD KEY `auctionproduct_link_idx` (`IdProduct`),
  ADD KEY `auctioncurrency_link_idx` (`IdCurrency`);

--
-- Indexes for table `bid`
--
ALTER TABLE `bid`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `auction_link_idx` (`IdAuction`),
  ADD KEY `bidcurrency_link_idx` (`IdCurrency`),
  ADD KEY `bidbidder_link_idx` (`IdBidder`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Name_UNIQUE` (`Name`);

--
-- Indexes for table `currency`
--
ALTER TABLE `currency`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Name_UNIQUE` (`Name`);

--
-- Indexes for table `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `person_bidder`
--
ALTER TABLE `person_bidder`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `bidder_link_idx` (`IdPerson`);

--
-- Indexes for table `person_offeror`
--
ALTER TABLE `person_offeror`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `person_link_idx` (`IdPerson`);

--
-- Indexes for table `person_offeror_mark`
--
ALTER TABLE `person_offeror_mark`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `personreceiver_link_idx` (`IdReceiver`),
  ADD KEY `personsender_link_idx` (`IdSender`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `link_category_idx` (`IdCategory`);

--
-- Indexes for table `sub_category`
--
ALTER TABLE `sub_category`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `parent_link_idx` (`IdParent`),
  ADD KEY `son_link_idx` (`IdSon`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `auction`
--
ALTER TABLE `auction`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `bid`
--
ALTER TABLE `bid`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `currency`
--
ALTER TABLE `currency`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `person`
--
ALTER TABLE `person`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `person_bidder`
--
ALTER TABLE `person_bidder`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `person_offeror`
--
ALTER TABLE `person_offeror`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `person_offeror_mark`
--
ALTER TABLE `person_offeror_mark`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `sub_category`
--
ALTER TABLE `sub_category`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `auction`
--
ALTER TABLE `auction`
  ADD CONSTRAINT `auctioncurrency_link` FOREIGN KEY (`IdCurrency`) REFERENCES `currency` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `auctionofferor_link` FOREIGN KEY (`IdOfferor`) REFERENCES `person_offeror` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `auctionproduct_link` FOREIGN KEY (`IdProduct`) REFERENCES `product` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `bid`
--
ALTER TABLE `bid`
  ADD CONSTRAINT `bidauction_link` FOREIGN KEY (`IdAuction`) REFERENCES `auction` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `bidbidder_link` FOREIGN KEY (`IdBidder`) REFERENCES `person_bidder` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `bidcurrency_link` FOREIGN KEY (`IdCurrency`) REFERENCES `currency` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `person_bidder`
--
ALTER TABLE `person_bidder`
  ADD CONSTRAINT `bidder_link` FOREIGN KEY (`IdPerson`) REFERENCES `person` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `person_offeror`
--
ALTER TABLE `person_offeror`
  ADD CONSTRAINT `offeror_link` FOREIGN KEY (`IdPerson`) REFERENCES `person` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `person_offeror_mark`
--
ALTER TABLE `person_offeror_mark`
  ADD CONSTRAINT `personreceiver_link` FOREIGN KEY (`IdReceiver`) REFERENCES `person_offeror` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `personsender_link` FOREIGN KEY (`IdSender`) REFERENCES `person` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `link_category` FOREIGN KEY (`IdCategory`) REFERENCES `category` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `sub_category`
--
ALTER TABLE `sub_category`
  ADD CONSTRAINT `parent_link` FOREIGN KEY (`IdParent`) REFERENCES `category` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `son_link` FOREIGN KEY (`IdSon`) REFERENCES `category` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
