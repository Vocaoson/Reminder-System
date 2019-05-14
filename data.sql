/*
SQLyog Community v13.0.1 (64 bit)
MySQL - 10.1.37-MariaDB-0+deb9u1 : Database - remindersystem1
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`remindersystem1` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `remindersystem1`;

/*Table structure for table `Action` */

DROP TABLE IF EXISTS `Action`;

CREATE TABLE `Action` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PhoneNumber` longtext,
  `TemplateId` int(11) DEFAULT NULL,
  `Data` longtext,
  `IsDone` bit(1) DEFAULT NULL,
  `Type` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Action_TemplateId` (`TemplateId`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `Action` */

insert  into `Action`(`Id`,`PhoneNumber`,`TemplateId`,`Data`,`IsDone`,`Type`) values 
(1,'SIP/1002',1,'{\'Name\':\'Mr Son\'}','',1),
(2,'123456',1,'{\"Name\":\"Mr Son\"}','\0',0);

/*Table structure for table `Data` */

DROP TABLE IF EXISTS `Data`;

CREATE TABLE `Data` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DataStore` longtext,
  `DataType` int(11) DEFAULT NULL,
  `Order` int(11) DEFAULT NULL,
  `SentenceId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Data_SentenceId` (`SentenceId`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `Data` */

insert  into `Data`(`Id`,`DataStore`,`DataType`,`Order`,`SentenceId`) values 
(1,'Text to speech',1,1,1),
(2,'/var/www/sounds/hello',2,2,1),
(3,'Name',3,3,1);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
