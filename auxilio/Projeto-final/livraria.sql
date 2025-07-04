-- MariaDB dump 10.19  Distrib 10.4.24-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: livraria
-- ------------------------------------------------------
-- Server version	10.4.24-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `adm`
--

DROP TABLE IF EXISTS `adm`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `adm` (
  `idAdm` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) NOT NULL,
  `email` varchar(50) NOT NULL DEFAULT 'adm@gmail.com',
  `senha` varchar(50) NOT NULL DEFAULT '123',
  `cpf` varchar(255) NOT NULL,
  `cep` int(11) NOT NULL,
  `numeroCasa` varchar(255) NOT NULL,
  `complemento` varchar(255) DEFAULT NULL,
  `apelido` varchar(255) NOT NULL,
  PRIMARY KEY (`idAdm`),
  UNIQUE KEY `cpf_UNIQUE` (`cpf`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adm`
--

LOCK TABLES `adm` WRITE;
/*!40000 ALTER TABLE `adm` DISABLE KEYS */;
INSERT INTO `adm` VALUES (1,'davi','adm@gmail.com','123','1555554',14454545,'5556845','2','dada');
/*!40000 ALTER TABLE `adm` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classificacao`
--

DROP TABLE IF EXISTS `classificacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `classificacao` (
  `class_nome` varchar(255) NOT NULL,
  `class_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`class_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classificacao`
--

LOCK TABLES `classificacao` WRITE;
/*!40000 ALTER TABLE `classificacao` DISABLE KEYS */;
INSERT INTO `classificacao` VALUES ('Terror',1),('Suspense',2),('Drama',3),('Comédia',4),('Ficção Científica',5),('Romance',6),('Histórico',7),('Biografia',8),('Aventura',9),('Justiça',12),('Aprendizagem',13);
/*!40000 ALTER TABLE `classificacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classiflivro`
--

DROP TABLE IF EXISTS `classiflivro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `classiflivro` (
  `fk_idLivro` int(11) NOT NULL,
  `fk_class_id` int(11) NOT NULL,
  KEY `fk_idLivro` (`fk_idLivro`),
  KEY `fk_class_id` (`fk_class_id`),
  CONSTRAINT `classiflivro_ibfk_1` FOREIGN KEY (`fk_idLivro`) REFERENCES `livro` (`idLivro`),
  CONSTRAINT `classiflivro_ibfk_2` FOREIGN KEY (`fk_class_id`) REFERENCES `classificacao` (`class_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classiflivro`
--

LOCK TABLES `classiflivro` WRITE;
/*!40000 ALTER TABLE `classiflivro` DISABLE KEYS */;
INSERT INTO `classiflivro` VALUES (1,2),(1,9),(2,2),(1,3),(13,6),(8,12),(13,6),(8,12),(4,13),(9,7),(10,5),(12,6),(15,5),(5,3),(7,8),(6,4),(17,1),(2,9),(4,13),(9,7),(10,5),(12,6),(15,5),(5,3),(7,8),(6,4),(17,1),(2,9);
/*!40000 ALTER TABLE `classiflivro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cliente` (
  `idCliente` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) NOT NULL,
  `email` varchar(50) NOT NULL,
  `senha` varchar(50) NOT NULL,
  `cpf` varchar(255) NOT NULL,
  `cep` int(11) NOT NULL,
  `numeroCasa` varchar(255) NOT NULL,
  `complemento` varchar(255) DEFAULT NULL,
  `apelido` varchar(255) NOT NULL,
  `status` varchar(50) NOT NULL DEFAULT 'ok',
  PRIMARY KEY (`idCliente`),
  UNIQUE KEY `cpf_UNIQUE` (`cpf`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'Rodrigo','rodrigo@gmail.com','1','65345735',12358,'423','1','rod','retirado'),(2,'Aldego','aldego@gmail.com','124','90545426',53635,'432','','alde','ok'),(3,'Everaldo','everaldo@gmail.com','5','23552535',63436,'56','','everas','ok'),(4,'david','ninguem@gmail.com','4','12345344',12345,'187','','dada','ok'),(5,'martins','ninguem@gmail.com','4242','12345643',12345,'23','','mar','ok'),(6,'Vitor','ninguem@gmail.com','julia123','11234245',21174,'21','21','vitinho','ok'),(7,'David','ninguem@gmail.com','julia12332','21122155',21745,'12','12','davi','ok'),(9,'Davi','davi@gmail.com','123456','23627642',74629,'56','','davizinho','ok'),(14,'Larissa','ninguem@gmail.com','123','11153456',64577,'5','','larissel','ok'),(15,'Marcos','marcos@gmail.com','126','11115367',54632,'757','','marcão','ok');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `devolucao`
--

DROP TABLE IF EXISTS `devolucao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `devolucao` (
  `data_fim` date NOT NULL,
  `idLocacao` int(11) NOT NULL,
  PRIMARY KEY (`idLocacao`),
  CONSTRAINT `fk_devolucao_locacao1` FOREIGN KEY (`idLocacao`) REFERENCES `locacao` (`idLocacao`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `devolucao`
--

LOCK TABLES `devolucao` WRITE;
/*!40000 ALTER TABLE `devolucao` DISABLE KEYS */;
INSERT INTO `devolucao` VALUES ('2022-12-14',11),('2022-11-13',13),('2006-12-13',14),('2022-12-13',15),('2022-12-13',16),('2022-12-14',17);
/*!40000 ALTER TABLE `devolucao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `funcionario`
--

DROP TABLE IF EXISTS `funcionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `funcionario` (
  `idFuncionario` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) NOT NULL,
  `email` varchar(50) NOT NULL DEFAULT 'func@gmail.com',
  `senha` varchar(50) NOT NULL DEFAULT '123',
  `cpf` varchar(255) NOT NULL,
  `cep` int(11) NOT NULL,
  `numeroCasa` varchar(255) NOT NULL,
  `complemento` varchar(255) DEFAULT NULL,
  `apelido` varchar(255) NOT NULL,
  `estatus` varchar(50) DEFAULT 'ok',
  PRIMARY KEY (`idFuncionario`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `funcionario`
--

LOCK TABLES `funcionario` WRITE;
/*!40000 ALTER TABLE `funcionario` DISABLE KEYS */;
INSERT INTO `funcionario` VALUES (1,'Matheus','mathues@gmail.com','123','2456365',50145,'64','','Matheus','retirado'),(2,'Samuel','func@gmail.com','99','1825325',23552,'632','','Samucrel','ok'),(3,'Mario','mario@gmail.com','123455','5352366',21212,'325','ab','MMM','ok'),(4,'antonio','func@gmail.com','123788','3450523',23563,'97','','Antonio','ok'),(5,'Davi','funcDavi@gmail.com','1234','5235736',12215,'178','','Davi','ok'),(6,'Everaldo','everaldo@gmail.com','123','4674104',52356,'389','','everas','ok');
/*!40000 ALTER TABLE `funcionario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `livro`
--

DROP TABLE IF EXISTS `livro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `livro` (
  `idLivro` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(255) NOT NULL,
  `autor` varchar(255) NOT NULL,
  `editora` int(11) NOT NULL,
  `data_chegada` date NOT NULL,
  `qtd_paginas` int(11) NOT NULL,
  `valor_locacao` varchar(45) NOT NULL,
  `fk_idFuncionario` int(11) NOT NULL,
  `status` varchar(50) NOT NULL DEFAULT 'disponivel',
  PRIMARY KEY (`idLivro`),
  KEY `fk_livro_funcionario1_idx` (`fk_idFuncionario`),
  CONSTRAINT `fk_livro_funcionario1` FOREIGN KEY (`fk_idFuncionario`) REFERENCES `funcionario` (`idFuncionario`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `livro`
--

LOCK TABLES `livro` WRITE;
/*!40000 ALTER TABLE `livro` DISABLE KEYS */;
INSERT INTO `livro` VALUES (1,'Alice no País dos Carvalhos','Davi Carvalho',1,'2000-05-12',302,'18.00',1,'locado'),(2,'Alice no País das Maravilhas','Lerow Corlli',2,'2000-05-12',400,'15.00',1,'locado'),(3,'1984','George Orwell',3,'2000-05-12',350,'20.00',2,'disponivel'),(4,'C# para iniciantes','Alura',2,'2022-09-11',110,'5.50',3,'disponivel'),(5,'Memórias Póstumas de Brás Cubas','Machado de Assis',1,'2022-12-13',155,'5.00',4,'disponivel'),(6,'A vida de uma estrela','José',3,'2022-12-14',333,'17.00',2,'disponivel'),(7,'Brasil dos Humilhados','Jessé Souza',1,'2020-08-22',200,'15.00',3,'disponivel'),(8,'Elite do Atraso','Jessé Souza',1,'2020-08-22',300,'10.00',3,'disponivel'),(9,'Como o Racismo Criou o Brasil','Jessé Souza',1,'0000-00-00',279,'8.00',3,'disponivel'),(10,'Radiografia do Golpe','Jessé Souza',1,'2020-08-22',190,'7.00',3,'disponivel'),(11,'Classe Média no Espelho','Jessé Souza',1,'2020-08-22',270,'9.50',3,'disponivel'),(12,'Quincas Borba','Machado de Assis',2,'2020-10-18',150,'6.00',6,'disponivel'),(13,'O alienista','Machado de Assis',2,'2020-10-18',42,'1.00',6,'disponivel'),(14,'Dom Casmurro','Machado de Assis',2,'2020-10-18',285,'12.00',6,'disponivel'),(15,'Revolução dos Bichos','George Orwell',2,'2020-10-18',92,'4.00',6,'disponivel'),(16,'Ética para Nicômaco','Aristóteles',2,'2020-10-18',178,'8.50',6,'disponivel'),(17,'Um pouco de Ar, Por Favor!','George Orwell',2,'2020-10-18',205,'11.00',6,'disponivel');
/*!40000 ALTER TABLE `livro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `locacao`
--

DROP TABLE IF EXISTS `locacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `locacao` (
  `idLocacao` int(11) NOT NULL AUTO_INCREMENT,
  `data_inicio` date NOT NULL,
  `data_fim` date DEFAULT NULL,
  `atrasado` tinyint(1) NOT NULL,
  `taxa` double NOT NULL,
  `fk_idCliente` int(11) NOT NULL,
  `fk_idFuncionario` int(11) NOT NULL,
  `fk_idLivro` int(11) NOT NULL,
  `terminado` tinyint(4) NOT NULL DEFAULT 0,
  `dayDiff` int(11) NOT NULL,
  PRIMARY KEY (`idLocacao`),
  KEY `fk_locacao_cliente1_idx` (`fk_idCliente`),
  KEY `fk_locacao_funcionario` (`fk_idFuncionario`),
  KEY `fk_locacao_livro` (`fk_idLivro`),
  CONSTRAINT `fk_locacao_cliente1` FOREIGN KEY (`fk_idCliente`) REFERENCES `cliente` (`idCliente`),
  CONSTRAINT `fk_locacao_funcionario` FOREIGN KEY (`fk_idFuncionario`) REFERENCES `funcionario` (`idFuncionario`),
  CONSTRAINT `fk_locacao_livro` FOREIGN KEY (`fk_idLivro`) REFERENCES `livro` (`idLivro`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `locacao`
--

LOCK TABLES `locacao` WRITE;
/*!40000 ALTER TABLE `locacao` DISABLE KEYS */;
INSERT INTO `locacao` VALUES (1,'2022-12-07','2008-12-20',1,2553,2,2,1,1,5106),(2,'2022-12-18','2022-12-07',1,3,4,4,1,1,6),(3,'2002-08-07','2004-01-13',1,3454.5,1,1,1,1,6909),(4,'2022-09-17','2022-12-13',1,0,1,2,2,1,0),(5,'2009-08-08','2022-12-22',0,0,1,2,3,1,0),(6,'2022-12-13','2022-12-20',0,0,1,2,1,1,0),(7,'2022-12-13','2022-12-20',0,0,1,2,2,1,0),(8,'2022-12-13','2022-12-20',0,0,1,2,1,1,0),(9,'2022-12-13','2022-12-20',0,0,1,2,5,1,0),(10,'2022-12-13','2023-01-17',0,0,1,2,1,0,0),(11,'2022-12-13','2022-12-20',0,0,1,2,2,1,0),(12,'2022-12-13','2022-12-20',0,0,1,2,3,1,0),(13,'2022-12-13','2022-12-20',0,0,4,2,4,1,0),(14,'2022-12-13','2022-12-20',0,0,5,2,5,1,0),(15,'2022-12-13','2022-12-20',0,0,5,2,5,1,0),(16,'2022-12-13','2023-01-03',0,0,1,2,3,1,0),(17,'2022-12-13','2022-12-20',0,0,1,2,4,1,0),(18,'2022-12-09','2006-11-08',1,0,2,4,6,1,0),(19,'2022-12-14','2022-12-17',0,2,2,2,2,0,4);
/*!40000 ALTER TABLE `locacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mr_cliente`
--

DROP TABLE IF EXISTS `mr_cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mr_cliente` (
  `idCliente` int(11) NOT NULL,
  `motivo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idCliente`),
  CONSTRAINT `mr_cliente_ibfk_1` FOREIGN KEY (`idCliente`) REFERENCES `cliente` (`idCliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mr_cliente`
--

LOCK TABLES `mr_cliente` WRITE;
/*!40000 ALTER TABLE `mr_cliente` DISABLE KEYS */;
INSERT INTO `mr_cliente` VALUES (1,'capa cap cap');
/*!40000 ALTER TABLE `mr_cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mr_funcionario`
--

DROP TABLE IF EXISTS `mr_funcionario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mr_funcionario` (
  `idFuncionario` int(11) NOT NULL,
  `motivo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idFuncionario`),
  CONSTRAINT `mr_funcionario_ibfk_1` FOREIGN KEY (`idFuncionario`) REFERENCES `funcionario` (`idFuncionario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mr_funcionario`
--

LOCK TABLES `mr_funcionario` WRITE;
/*!40000 ALTER TABLE `mr_funcionario` DISABLE KEYS */;
INSERT INTO `mr_funcionario` VALUES (1,'dlghalçshdgshflghsçdfjlhl');
/*!40000 ALTER TABLE `mr_funcionario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mr_livro`
--

DROP TABLE IF EXISTS `mr_livro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mr_livro` (
  `idLivro` int(11) NOT NULL,
  `motivo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idLivro`),
  CONSTRAINT `mr_livro_ibfk_1` FOREIGN KEY (`idLivro`) REFERENCES `livro` (`idLivro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mr_livro`
--

LOCK TABLES `mr_livro` WRITE;
/*!40000 ALTER TABLE `mr_livro` DISABLE KEYS */;
INSERT INTO `mr_livro` VALUES (1,'feio');
/*!40000 ALTER TABLE `mr_livro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sistema`
--

DROP TABLE IF EXISTS `sistema`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sistema` (
  `quantidadeMaxRenovacao` int(11) NOT NULL,
  `idAdm` int(11) NOT NULL,
  PRIMARY KEY (`idAdm`),
  CONSTRAINT `fk_sistema_adm1` FOREIGN KEY (`idAdm`) REFERENCES `adm` (`idAdm`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sistema`
--

LOCK TABLES `sistema` WRITE;
/*!40000 ALTER TABLE `sistema` DISABLE KEYS */;
/*!40000 ALTER TABLE `sistema` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-14 14:38:45
