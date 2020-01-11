CREATE TABLE IF NOT EXISTS `pessoa` (
	`ID` INT(10) NOT NULL AUTO_INCREMENT,
	`Nome` VARCHAR(255)   NULL,
	`Sobrenome` VARCHAR(255)  NULL,
	`DtNasc` datetime  NULL,
	`Endereco` VARCHAR(255) NULL,
	`Complemento` VARCHAR(255)  NULL,
	`Telefone` VARCHAR(255) NULL,
	`Celular` VARCHAR(255) NULL,
	`UserId` VARCHAR (255)  NULL,
	PRIMARY KEY (`ID`)
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB;