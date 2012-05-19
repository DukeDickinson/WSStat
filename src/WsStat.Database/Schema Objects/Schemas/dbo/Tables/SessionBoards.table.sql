CREATE TABLE [dbo].[SessionBoards]
(
	SessionId INT NOT NULL CONSTRAINT FK_SessionBoards_SailingSession FOREIGN KEY REFERENCES SailingSession(Id),
	BoardId INT NOT NULL CONSTRAINT FK_SessionBoards_Board FOREIGN KEY REFERENCES Board(Id),
	CONSTRAINT PK_SessionBoards PRIMARY KEY
	(
		SessionId ASC,
		BoardId ASC
	)
)
