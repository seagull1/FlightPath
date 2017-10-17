CREATE TABLE [dbo].[Radio] (
    [AirportName]    VARCHAR (100) NOT NULL,
    [RadioId]        INT           NULL,
    [RadioName]      VARCHAR (20)  NULL,
    [RadioFrequency] VARCHAR (50)  NULL,
    [Designator]     VARCHAR (5)   NOT NULL,
    [Id]             INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Designator]) REFERENCES [dbo].[Airport] ([Designator])
);

