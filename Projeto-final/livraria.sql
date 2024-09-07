-- MariaDB dump 10.19  Distrib 10.4.24-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: livraria
-- ------------------------------------------------------
-- Server version 10.4.24-MariaDB
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

--
-- Dumping data for table `adm`
--

INSERT INTO `adm` VALUES (1,'Davi','adm@gmail.com','123','1555554',14454545,'5556845','2','Dada');

--
-- Table structure for table `classificacao`
--

CREATE TABLE `classificacao` (
  `class_nome` varchar(255) NOT NULL,
  `class_id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`class_id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `classificacao`
--

INSERT INTO `classificacao` VALUES 
('Terror',1),
('Suspense',2),
('Drama',3),
('Comédia',4),
('Ficção Científica',5),
('Romance',6),
('Histórico',7),
('Biografia',8),
('Aventura',9),
('Justiça',12),
('Aprendizagem',13);

--
-- Table structure for table `classiflivro`
--

CREATE TABLE `classiflivro` (
  `fk_idLivro` int(11) NOT NULL,
  `fk_class_id` int(11) NOT NULL,
  KEY `fk_idLivro` (`fk_idLivro`),
  KEY `fk_class_id` (`fk_class_id`),
  CONSTRAINT `classiflivro_ibfk_1` FOREIGN KEY (`fk_idLivro`) REFERENCES `livro` (`idLivro`),
  CONSTRAINT `classiflivro_ibfk_2` FOREIGN KEY (`fk_class_id`) REFERENCES `classificacao` (`class_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `classiflivro`
--

INSERT INTO `classiflivro` VALUES 
(1,2),(1,9),(2,2),(1,3),(13,6),(8,12),(4,13),(9,7),(10,5),(12,6),
(15,5),(5,3),(7,8),(6,4),(17,1),(2,9);

--
-- Table structure for table `cliente`
--

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

--
-- Dumping data for table `cliente`
--

INSERT INTO `cliente` VALUES 
(1,'Rodrigo','rodrigo@gmail.com','1','65345735',12358,'423','1','Rod','retirado'),
(2,'Aldego','aldego@gmail.com','124','90545426',53635,'432','','Alde','ok'),
(3,'Everaldo','everaldo@gmail.com','5','23552535',63436,'56','','Everas','ok');

--
-- Table structure for table `funcionario`
--

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

--
-- Dumping data for table `funcionario`
--

INSERT INTO `funcionario` VALUES 
(1,'Matheus','matheus@gmail.com','123','2456365',50145,'64','','Matheus','retirado'),
(2,'Samuel','func@gmail.com','99','1825325',23552,'632','','Samucrel','ok');

--
-- Table structure for table `livro`
--

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

--
-- Dumping data for table `livro`
--

INSERT INTO `livro` VALUES 
(1,'Alice no País dos Carvalhos','Davi Carvalho',1,'2000-05-12',302,'18.00',1,'locado'),
(2,'Alice no País das Maravilhas','Lerow Corlli',2,'2000-05-12',400,'15.00',1,'locado'),
(3,'1984','George Orwell',3,'2000-05-12',350,'20.00',2,'disponivel');

--
-- Table structure for table `locacao`
--

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
  CONSTRAINT `fk_locacao_cliente1` FOREIGN KEY (`fk_idCliente`) REFERENCES `cliente` (`idCliente`),
  CONSTRAINT `fk_locacao_funcionario` FOREIGN KEY (`fk_idFuncionario`) REFERENCES `funcionario` (`idFuncionario`),
  CONSTRAINT `fk_locacao_livro` FOREIGN KEY (`fk_idLivro`) REFERENCES `livro` (`idLivro`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `locacao`
--

INSERT INTO `locacao` VALUES 
(1,'2022-12-07','2008-12-20',1,2553,2,2,1,1,5106),
(2,'2022-12-18','2022-12-28',1,22,2,1,2,0,5);

--
-- Indexes for dumped tables
--
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
