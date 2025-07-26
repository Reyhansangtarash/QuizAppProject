CREATE TABLE [dbo].[Result]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NULL, 
    [Score] INT NULL,
	FOREIGN KEY(UserId) REFERENCES Users(Id)
)
