CREATE TABLE IF NOT EXISTS `reparo` (
	`ID` INT(10) NOT NULL AUTO_INCREMENT,
	`Titulo` VARCHAR(255)   NULL,
	`Descricao` VARCHAR(255)  NULL,
	`DiaIncidente` VARCHAR(255)  NULL,
	`DiaConserto` VARCHAR(255) NULL,
	`PossuiDebito` VARCHAR(255)   NULL,
	`IdImovel` INT  NULL,

	PRIMARY KEY (`ID`)
)
COLLATE='latin1_swedish_ci'
ENGINE=InnoDB;