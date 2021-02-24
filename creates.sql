CREATE TABLE `propertyvisits` (
  `propertyId` int(12) NOT NULL DEFAULT 0,
  `type` varchar(128) NOT NULL,
  `datetime` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `customer` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`propertyId`,`type`,`datetime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8

CREATE TABLE `apartment` (
  `id` int(12) NOT NULL AUTO_INCREMENT,
  `bedrooms` int(12) NOT NULL DEFAULT 0,
  `suites` int(12) NOT NULL DEFAULT 0,
  `livingRooms` int(12) NOT NULL DEFAULT 0,
  `dinningRooms` int(12) NOT NULL DEFAULT 0,
  `parkingSpaces` int(12) NOT NULL DEFAULT 0,
  `area` int(12) NOT NULL DEFAULT 0,
  `imbuedCloset` varchar(12) NOT NULL DEFAULT 'False',
  `description` varchar(128) DEFAULT NULL,
  `floor` int(12) NOT NULL DEFAULT 0,
  `condominiumValue` int(12) NOT NULL DEFAULT 0,
  `conciergeService` varchar(12) NOT NULL DEFAULT 'False',
  `rentValue` int(24) NOT NULL DEFAULT 0,
  `district` varchar(128) NOT NULL DEFAULT '',
  `address` varchar(128) NOT NULL DEFAULT '',
  `owner` varchar(128) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8

CREATE TABLE `house` (
  `id` int(12) NOT NULL AUTO_INCREMENT,
  `bedrooms` int(12) NOT NULL DEFAULT 0,
  `suites` int(12) NOT NULL DEFAULT 0,
  `livingRooms` int(12) NOT NULL DEFAULT 0,
  `parkingSpaces` int(12) NOT NULL DEFAULT 0,
  `area` int(12) NOT NULL DEFAULT 0,
  `imbuedCloset` varchar(12) NOT NULL DEFAULT 'False',
  `description` varchar(128) DEFAULT NULL,
  `rentValue` int(24) NOT NULL DEFAULT 0,
  `district` varchar(128) NOT NULL DEFAULT '',
  `address` varchar(128) NOT NULL DEFAULT '',
  `owner` varchar(128) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8