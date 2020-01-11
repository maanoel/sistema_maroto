CREATE TABLE IF NOT EXISTS `Product` (
	`Id` int(10) UNSIGNED primary key AUTO_INCREMENT,
	`Descricao` VARCHAR(100) NULL DEFAULT NULL,
	`Valor` decimal(6,5) NULL DEFAULT NULL,
	`Categoria` VARCHAR(50) NULL DEFAULT NULL,
	`Peso` float NULL DEFAULT NULL,
	`Cor` VARCHAR(50) NULL DEFAULT NULL,
	`Medida` VARCHAR(40) NULL DEFAULT NULL,
	`Quantidade` int(10) NULL DEFAULT NULL

)
ENGINE=InnoDB
;