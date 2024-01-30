USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='Carhalla')
DROP DATABASE Carhalla
GO

CREATE DATABASE Carhalla
GO