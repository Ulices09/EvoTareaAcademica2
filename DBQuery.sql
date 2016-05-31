USE MASTER
GO
CREATE DATABASE EvolucionTA2
GO
USE EvolucionTA2
CREATE TABLE Persona(
Codigo int primary key identity,
Nombre varchar(20),
Apellido varchar(30)
)