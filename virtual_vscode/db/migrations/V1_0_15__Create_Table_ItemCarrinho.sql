CREATE TABLE IF NOT EXISTS `ItemCarrinho` (
  `id` int(10) UNSIGNED NOT  NULL AUTO_INCREMENT PRIMARY KEY,
  `product_id` INT NOT NULL,
  `quantidade` INT NOT NULL,
  `carrinho_id` INT(10) UNSIGNED NOT NULL,
  FOREIGN KEY(`carrinho_id`) references Carrinho(`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
