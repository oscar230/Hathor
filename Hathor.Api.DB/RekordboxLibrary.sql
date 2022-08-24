CREATE TABLE [dbo].[RekordboxLibrary]
(
	[Id] INT NOT NULL, 
    [Guid] UNIQUEIDENTIFIER NOT NULL, 
    [Xml] XML NOT NULL, 
    [Created] DATETIME2 NOT NULL, 
    [HashCode] INT NOT NULL, 
    CONSTRAINT [PK_RekordboxLibrary] PRIMARY KEY ([Id]) 
)

GO
