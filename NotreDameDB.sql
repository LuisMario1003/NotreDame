CREATE DATABASE  IF NOT EXISTS `notredamedb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `notredamedb`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: notredamedb
-- ------------------------------------------------------
-- Server version	8.0.37

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categoria` (
  `CategoriaID` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Precio` decimal(10,2) NOT NULL,
  PRIMARY KEY (`CategoriaID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (1,'Economica',10000.00),(2,'Estandar',20000.00),(3,'Suite',30000.00),(4,'Premium',50000.00);
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `ClienteID` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Telefono` varchar(20) DEFAULT NULL,
  `Genero` varchar(10) DEFAULT NULL,
  `Cedula` varchar(20) NOT NULL,
  PRIMARY KEY (`ClienteID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'Luis Mario','3135473633','Masculino','1006680868'),(2,'Ivan Rene','315669875','Masculino','1005547896'),(3,'Laura','3168972255','Femenino','112236547'),(4,'Maria','3215648798','Femenino','550653214'),(5,'Pedro','31754649988','Masculino','57689425'),(6,'Andres','321547986','Masculino','560754236'),(7,'Pablo','3115642231','Masculino','11225544');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura`
--

DROP TABLE IF EXISTS `factura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `factura` (
  `FacturaID` int NOT NULL AUTO_INCREMENT,
  `ReservaID` int DEFAULT NULL,
  `Fecha` date DEFAULT NULL,
  `MontoTotal` decimal(10,2) DEFAULT NULL,
  `CodigoFactura` varchar(50) NOT NULL,
  PRIMARY KEY (`FacturaID`),
  KEY `ReservaID` (`ReservaID`),
  CONSTRAINT `factura_ibfk_1` FOREIGN KEY (`ReservaID`) REFERENCES `reserva` (`ReservaID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura`
--

LOCK TABLES `factura` WRITE;
/*!40000 ALTER TABLE `factura` DISABLE KEYS */;
INSERT INTO `factura` VALUES (1,1,'2024-11-21',35000.00,'1001'),(2,2,'2024-11-21',55000.00,'1002'),(3,3,'2024-11-21',80000.00,'1003'),(4,5,'2024-11-21',80000.00,'1004'),(5,6,'2024-11-21',45000.00,'1005');
/*!40000 ALTER TABLE `factura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `facturaservicioadicional`
--

DROP TABLE IF EXISTS `facturaservicioadicional`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `facturaservicioadicional` (
  `FacturaServicioAdicionalID` int NOT NULL AUTO_INCREMENT,
  `FacturaID` int DEFAULT NULL,
  `ServicioID` int DEFAULT NULL,
  PRIMARY KEY (`FacturaServicioAdicionalID`),
  KEY `FacturaID` (`FacturaID`),
  KEY `ServicioID` (`ServicioID`),
  CONSTRAINT `facturaservicioadicional_ibfk_1` FOREIGN KEY (`FacturaID`) REFERENCES `factura` (`FacturaID`),
  CONSTRAINT `facturaservicioadicional_ibfk_2` FOREIGN KEY (`ServicioID`) REFERENCES `servicioadicional` (`ServicioID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `facturaservicioadicional`
--

LOCK TABLES `facturaservicioadicional` WRITE;
/*!40000 ALTER TABLE `facturaservicioadicional` DISABLE KEYS */;
INSERT INTO `facturaservicioadicional` VALUES (1,1,1),(2,1,2),(3,2,1),(4,2,2),(5,2,3),(6,3,1),(7,3,2),(8,3,3),(9,3,4),(10,4,1),(11,4,2),(12,4,3),(13,5,1),(14,5,3);
/*!40000 ALTER TABLE `facturaservicioadicional` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `habitacion`
--

DROP TABLE IF EXISTS `habitacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `habitacion` (
  `HabitacionID` int NOT NULL AUTO_INCREMENT,
  `Numero` varchar(10) NOT NULL,
  `CategoriaID` int DEFAULT NULL,
  `CodigoHabitacion` varchar(50) NOT NULL,
  `Estado` varchar(50) NOT NULL,
  PRIMARY KEY (`HabitacionID`),
  KEY `CategoriaID` (`CategoriaID`),
  CONSTRAINT `habitacion_ibfk_1` FOREIGN KEY (`CategoriaID`) REFERENCES `categoria` (`CategoriaID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `habitacion`
--

LOCK TABLES `habitacion` WRITE;
/*!40000 ALTER TABLE `habitacion` DISABLE KEYS */;
INSERT INTO `habitacion` VALUES (1,'01',1,'101','Ocupado'),(2,'02',1,'102','Disponible'),(3,'03',2,'103','Disponible'),(4,'04',2,'104','Ocupado'),(5,'05',3,'105','Disponible'),(6,'06',3,'106','Mantenimiento'),(7,'07',2,'107','Ocupado');
/*!40000 ALTER TABLE `habitacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reserva`
--

DROP TABLE IF EXISTS `reserva`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reserva` (
  `ReservaID` int NOT NULL AUTO_INCREMENT,
  `ClienteID` int DEFAULT NULL,
  `HabitacionID` int DEFAULT NULL,
  `FechaInicio` date DEFAULT NULL,
  `FechaFin` date DEFAULT NULL,
  `MontoTotal` decimal(10,2) DEFAULT NULL,
  `CodigoReserva` varchar(50) NOT NULL,
  PRIMARY KEY (`ReservaID`),
  KEY `ClienteID` (`ClienteID`),
  KEY `HabitacionID` (`HabitacionID`),
  CONSTRAINT `reserva_ibfk_1` FOREIGN KEY (`ClienteID`) REFERENCES `cliente` (`ClienteID`),
  CONSTRAINT `reserva_ibfk_2` FOREIGN KEY (`HabitacionID`) REFERENCES `habitacion` (`HabitacionID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reserva`
--

LOCK TABLES `reserva` WRITE;
/*!40000 ALTER TABLE `reserva` DISABLE KEYS */;
INSERT INTO `reserva` VALUES (1,1,1,'2024-11-22','2024-11-23',15000.00,'01'),(2,3,2,'2024-11-24','2024-11-25',15000.00,'02'),(3,5,4,'2024-11-21','2024-11-22',20000.00,'03'),(4,6,1,'2024-11-27','2024-11-28',15000.00,'04'),(5,4,4,'2024-11-22','2024-11-24',40000.00,'05'),(6,7,7,'2024-11-21','2024-11-23',20000.00,'06');
/*!40000 ALTER TABLE `reserva` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `servicioadicional`
--

DROP TABLE IF EXISTS `servicioadicional`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `servicioadicional` (
  `ServicioID` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) DEFAULT NULL,
  `Precio` decimal(10,2) DEFAULT NULL,
  `CodigoServicio` varchar(50) NOT NULL,
  PRIMARY KEY (`ServicioID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servicioadicional`
--

LOCK TABLES `servicioadicional` WRITE;
/*!40000 ALTER TABLE `servicioadicional` DISABLE KEYS */;
INSERT INTO `servicioadicional` VALUES (1,'Limpieza',5000.00,'01'),(2,'Desayuno',15000.00,'02'),(3,'Almuerzo',20000.00,'03'),(4,'Cena',20000.00,'04'),(5,'Pepsi',1500.00,'05');
/*!40000 ALTER TABLE `servicioadicional` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'notredamedb'
--

--
-- Dumping routines for database 'notredamedb'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-26 17:27:24
