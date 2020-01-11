CREATE TABLE IF NOT EXISTS `Carrinho` (
  `id` int(10) UNSIGNED  NOT NULL AUTO_INCREMENT,
  `total` FLOAT  NULL,
  `frete` FLOAT   NULL,
  `user_id` INT(10) NOT NULL,
  `end_bairro` varchar(30) NOT NULL,
  `end_rua` varchar(40) NOT NULL,
  `end_numero` INT(8) NOT NULL,
  `end_cep` varchar(15) NOT NULL,
  `end_complemento` varchar(100) NULL,
  `end_cidade` varchar(40) NOT NULL,
  `end_estado` varchar(40) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
