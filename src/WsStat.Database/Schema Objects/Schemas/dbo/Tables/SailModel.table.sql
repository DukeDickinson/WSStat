﻿CREATE TABLE [dbo].[SailModel]
(
	Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_SailModel PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	ManufacturerId INT NOT NULL CONSTRAINT FK_SailModel_Manufacturer FOREIGN KEY REFERENCES Manufacturer(Id)
)
