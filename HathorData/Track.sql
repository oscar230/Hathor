CREATE TABLE [dbo].[Track]
(
    [InternalID] VARCHAR(50) NOT NULL, 
    [Guid] UNIQUEIDENTIFIER NOT NULL, 
    [RepositoryGuid] UNIQUEIDENTIFIER NOT NULL, 
    PRIMARY KEY ([Guid]) 
)
