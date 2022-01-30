CREATE TABLE [dbo].[SliderTrack]
(
	[SliderID] VARCHAR(20) NOT NULL PRIMARY KEY, 
    [Duration] INT NOT NULL, 
    [FullTitle] VARCHAR(200) NOT NULL, 
    [Url] VARCHAR(250) NOT NULL, 
    [ExtraInformation] BIT NULL DEFAULT 0
)
