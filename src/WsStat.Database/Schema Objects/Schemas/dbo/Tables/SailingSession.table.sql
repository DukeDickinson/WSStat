CREATE TABLE [dbo].[SailingSession]
(
	Id INT IDENTITY(1,1) NOT NULL,
	SailorId INT NOT NULL CONSTRAINT FK_SailingSession_Sailor FOREIGN KEY REFERENCES Sailor(Id),
	StartTime [datetime] NOT NULL,
	EndTime [datetime] NOT NULL,
	LocationId INT NOT NULL CONSTRAINT FK_SailingSession_Location FOREIGN KEY REFERENCES Location(Id),
	
	CONSTRAINT PK_SailingSession PRIMARY KEY
	(
		Id ASC
	)
) 
