CREATE TABLE [dbo].[BoardModel]
(
	[Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT [PK_BoardModel] PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[ManufacturerId] INT NOT NULL CONSTRAINT FK_BoardModel_Manufacturer FOREIGN KEY REFERENCES Manufacturer(Id),
)
