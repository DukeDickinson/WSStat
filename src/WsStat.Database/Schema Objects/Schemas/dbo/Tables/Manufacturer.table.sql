﻿CREATE TABLE [dbo].[Manufacturer]
(
	[Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_Manufacturer] PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
)
