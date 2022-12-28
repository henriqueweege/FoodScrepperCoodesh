
CREATE SCHEMA IF NOT EXISTS `foodscrapper` DEFAULT CHARACTER SET utf8mb4 ;
USE `foodscrapper` ;


CREATE TABLE IF NOT EXISTS `foodscrapper`.`Product` (
  `Id` varchar(1000) NOT NULL,
  `Code` varchar(2000) DEFAULT NULL,
  `Barcode` varchar(2000) DEFAULT NULL,
  `Status` int DEFAULT NULL,
  `Imported` datetime DEFAULT NULL,
  `Url` varchar(2000) DEFAULT NULL,
  `ProductName` varchar(2000) DEFAULT NULL,
  `Quantity` varchar(45) DEFAULT NULL,
  `Categories` varchar(2000) DEFAULT NULL,
  `Packaging` varchar(2000) DEFAULT NULL,
  `Brands` varchar(2000) DEFAULT NULL,
  `ImageUrl` varchar(2000) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


