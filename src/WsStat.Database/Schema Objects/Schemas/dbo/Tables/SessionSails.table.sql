CREATE TABLE [dbo].[SessionSails]
(
	SessionId INT NOT NULL CONSTRAINT FK_SessionSails_SailingSession FOREIGN KEY REFERENCES SailingSession(Id),
	SailId INT NOT NULL CONSTRAINT FK_SessionSails_Sail FOREIGN KEY REFERENCES Sail(Id),
	
	CONSTRAINT PK_SessionSails PRIMARY KEY 
	(
		SessionId ASC,
		SailId ASC
	)
) 
