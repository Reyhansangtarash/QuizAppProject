CREATE TABLE [dbo].[Question]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Text] TEXT NULL, 
    [Option1] NCHAR(10) NULL, 
    [Option2] NCHAR(10) NULL, 
    [Option3] NCHAR(10) NULL, 
    [Option4] NCHAR(10) NULL, 
    [CorrectAnswer] NCHAR(10) NULL
)
