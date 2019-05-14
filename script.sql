/*
SQLyog Community v13.0.1 (64 bit)
MySQL - 10.1.37-MariaDB-0+deb9u1 : Database - remindersystem
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`remindersystem` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `remindersystem`;

/*Table structure for table `Action` */

DROP TABLE IF EXISTS `Action`;

CREATE TABLE `Action` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PhoneNumber` longtext,
  `TemplateId` int(11) DEFAULT NULL,
  `Data` longtext,
  `IsDone` bit(1) DEFAULT NULL,
  `Type` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Action_TemplateId` (`TemplateId`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

/*Data for the table `Action` */

insert  into `Action`(`Id`,`PhoneNumber`,`TemplateId`,`Data`,`IsDone`,`Type`) values 
(1,'SIP/1002',1,'{\'Name\':\'Mr Son\'}','',1),
(2,'123456',1,'{\"Name\":\"Mr Son\"}','',0),
(3,'SIP/1002',4,'{\"Name\":\"Mr Son\"}','',1);

/*Table structure for table `AspNetRoleClaims` */

DROP TABLE IF EXISTS `AspNetRoleClaims`;

CREATE TABLE `AspNetRoleClaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `AspNetRoleClaims` */

/*Table structure for table `AspNetRoles` */

DROP TABLE IF EXISTS `AspNetRoles`;

CREATE TABLE `AspNetRoles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `AspNetRoles` */

/*Table structure for table `AspNetUserClaims` */

DROP TABLE IF EXISTS `AspNetUserClaims`;

CREATE TABLE `AspNetUserClaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `AspNetUserClaims` */

/*Table structure for table `AspNetUserLogins` */

DROP TABLE IF EXISTS `AspNetUserLogins`;

CREATE TABLE `AspNetUserLogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` longtext,
  `UserId` varchar(255) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `AspNetUserLogins` */

/*Table structure for table `AspNetUserRoles` */

DROP TABLE IF EXISTS `AspNetUserRoles`;

CREATE TABLE `AspNetUserRoles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `AspNetUserRoles` */

/*Table structure for table `AspNetUserTokens` */

DROP TABLE IF EXISTS `AspNetUserTokens`;

CREATE TABLE `AspNetUserTokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `Value` longtext,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `AspNetUserTokens` */

/*Table structure for table `AspNetUsers` */

DROP TABLE IF EXISTS `AspNetUsers`;

CREATE TABLE `AspNetUsers` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `ConcurrencyStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `Discriminator` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `AspNetUsers` */

insert  into `AspNetUsers`(`Id`,`UserName`,`NormalizedUserName`,`Email`,`NormalizedEmail`,`EmailConfirmed`,`PasswordHash`,`SecurityStamp`,`ConcurrencyStamp`,`PhoneNumber`,`PhoneNumberConfirmed`,`TwoFactorEnabled`,`LockoutEnd`,`LockoutEnabled`,`AccessFailedCount`,`Discriminator`) values 
('eef33d7d-3637-4da4-a19a-3df146b773b5','vocaoson7@gmail.com','VOCAOSON7@GMAIL.COM','vocaoson7@gmail.com','VOCAOSON7@GMAIL.COM','\0','AQAAAAEAACcQAAAAEIKuHJNc0PLOQsxPsqvoQKuLU1v7OAlLYwi4X/KPa35BMVkFe2y9jlgwdlkHPrZyNA==','PPQCQCGVCM5TRXJYFSKN6LFZA4TREHMR','bfb0026d-45ef-474a-9984-9c74a6252256',NULL,'\0','\0',NULL,'',0,NULL),
('ab9ff5eb-319a-45d0-9581-25acb8a86e4e','king@gmail.com','KING@GMAIL.COM','king@gmail.com','KING@GMAIL.COM','\0','AQAAAAEAACcQAAAAEJ5l2/QSDjRdDFwMs4GJyrDrrcg85uavk6TAZt75QVjewRoI6KNEEcdg40x0iDMs8w==','QEYQF6K67EOYZX5MDPTZXQQCMGLDRHL2','cd9ca38f-eeee-4e3e-a0f8-75cc10f99a89',NULL,'\0','\0',NULL,'',0,'IdentityUser');

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
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `Data` */

insert  into `Data`(`Id`,`DataStore`,`DataType`,`Order`,`SentenceId`) values 
(3,'Name',3,3,1),
(2,'/var/www/sounds/hello',2,2,1),
(1,'Text to speech',1,1,1),
(4,'E:\\HKI6\\Reminder\\AGI\\TestAudio\\MySystem.gsm',2,1,6);

/*Table structure for table `Result` */

DROP TABLE IF EXISTS `Result`;

CREATE TABLE `Result` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ResultData` longtext,
  `IsSend` bit(1) DEFAULT NULL,
  `ActionId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Result_ActionId` (`ActionId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `Result` */

/*Table structure for table `Sentence` */

DROP TABLE IF EXISTS `Sentence`;

CREATE TABLE `Sentence` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TemplateId` int(11) DEFAULT NULL,
  `Step` int(11) DEFAULT NULL,
  `Type` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Sentence_TemplateId` (`TemplateId`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `Sentence` */

insert  into `Sentence`(`Id`,`TemplateId`,`Step`,`Type`) values 
(1,1,1,1),
(2,1,2,1),
(3,1,3,1),
(4,3,1,1),
(5,3,2,2),
(6,4,1,1),
(7,4,2,2);

/*Table structure for table `Template` */

DROP TABLE IF EXISTS `Template`;

CREATE TABLE `Template` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) DEFAULT NULL,
  `LinkBack` longtext,
  `DataBackTemplate` longtext,
  `Description` longtext,
  `Name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Template_UserId` (`UserId`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `Template` */

insert  into `Template`(`Id`,`UserId`,`LinkBack`,`DataBackTemplate`,`Description`,`Name`) values 
(1,'ab9ff5eb-319a-45d0-9581-25acb8a86e4e','test.com',NULL,'Test template','Template 1'),
(2,'ab9ff5eb-319a-45d0-9581-25acb8a86e4e','king.com',NULL,'King','Template 2'),
(3,'ab9ff5eb-319a-45d0-9581-25acb8a86e4e','demo3.com',NULL,'Tempate 3 for demo','Template 3'),
(4,'ab9ff5eb-319a-45d0-9581-25acb8a86e4e','test5.com',NULL,'Template 5 for test','Template 5');

/*Table structure for table `Type` */

DROP TABLE IF EXISTS `Type`;

CREATE TABLE `Type` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Value` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `Type` */

/*Table structure for table `User` */

DROP TABLE IF EXISTS `User`;

CREATE TABLE `User` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` longtext,
  `Password` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `User` */

/*Table structure for table `__EFMigrationsHistory` */

DROP TABLE IF EXISTS `__EFMigrationsHistory`;

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `__EFMigrationsHistory` */

/*Table structure for table `__Efmigrationshistory` */

DROP TABLE IF EXISTS `__Efmigrationshistory`;

CREATE TABLE `__Efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `__Efmigrationshistory` */

insert  into `__Efmigrationshistory`(`MigrationId`,`ProductVersion`) values 
('00000000000000_CreateIdentitySchema','2.2.3-servicing-35854'),
('20190513045657_Demo','2.2.3-servicing-35854');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
