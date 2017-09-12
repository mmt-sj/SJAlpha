
CREATE TABLE `department` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(256) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `account` varchar(32) NOT NULL,
  `password` varchar(32) NOT NULL,
  `phoneNumber` varchar(32) NOT NULL DEFAULT '',
  `sex` varchar(8) NOT NULL DEFAULT '男',
  `departmentId` int(11) NOT NULL,
  `name` varchar(32) NOT NULL,
  `type` varchar(32) NOT NULL,
  `remark` varchar(1024) DEFAULT NULL,
  `createTime` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

/*!40000 ALTER TABLE `department` DISABLE KEYS */;
INSERT INTO `department` VALUES (1,'外国语学院'),(2,'文学与新闻传播学院'),(3,'法律与知识产权学院'),(4,'商学院'),(5,'计算机科学与工程学院(软件学院)'),(6,'建筑学院'),(7,'机械与电气工程学院'),(8,'土木工程学院'),(9,'电子信息工程学院'),(10,'文化产业与旅游管理学院');
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
