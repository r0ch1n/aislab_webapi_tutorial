--
-- Database: `Worshop`
--

CREATE DATABASE IF NOT EXISTS `Worshop` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `Worshop`;

-- --------------------------------------------------------

--
-- Table structure for table `members`
--

DROP TABLE IF EXISTS `members`;
CREATE TABLE `members` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `sName` varchar(45) DEFAULT NULL,
  `sMail` varchar(150) DEFAULT NULL,
  `sDepartment` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cat_servicetype`
--

INSERT INTO `Workshop`.`members` (`Id`, `sName`, `sMail`, `sDepartment`) VALUES (null, 'Frank', 'frank@aislab.com', 'Research');

