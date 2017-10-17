CREATE TABLE [dbo].[Runway] (
    [AirportName]   VARCHAR (100) NOT NULL,
    [CreateDate]    SMALLDATETIME CONSTRAINT [DF_runways_date_added] DEFAULT (getdate()) NOT NULL,
    [RunwayNumber]  VARCHAR (7)   NOT NULL,
    [RunwayLength]  INT           NOT NULL,
    [RunwayWidth]   INT           NOT NULL,
    [RunwaySurface] VARCHAR (70)  NULL,
    [Designator]    VARCHAR (5)   NOT NULL,
    [Id]            INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Designator]) REFERENCES [dbo].[Airport] ([Designator])
);

