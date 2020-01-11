CREATE TABLE IF NOT EXISTS `comments` (
  `com_id` int(10)  NOT  NULL AUTO_INCREMENT,
  `com_user_id`  int(10)  NOT  NULL,
  `com_dt_reg` DATETIME NULL,
  `com_texto` BLOB  NOT NULL,
  FOREIGN KEY(com_user_id) references users(ID),
  PRIMARY KEY (com_id)

) ENGINE=InnoDB DEFAULT CHARSET=latin1; 
