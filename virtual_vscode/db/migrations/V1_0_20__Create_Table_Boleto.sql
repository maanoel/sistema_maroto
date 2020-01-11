CREATE TABLE IF NOT EXISTS `boleto` (
	`ID` INT(10) NOT NULL AUTO_INCREMENT,
	`Matricula` VARCHAR(255) UNIQUE  NULL,
	`Local` VARCHAR(255)  NULL,
	`DtRef` DATETIME  NULL,
	`DtVenc` DATETIME NULL,
	`Servico1` float  NULL,
	`Servico2` float  NULL,
	`Servico3` float  NULL,
	`Total` float  NULL,
	`ImovelId` INT NULL,
	PRIMARY KEY (`ID`)
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB;