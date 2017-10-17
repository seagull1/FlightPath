CREATE TABLE [dbo].[Airport] (
    [AirportName] VARCHAR (100) NOT NULL,
    [ICAO]        BIT           NOT NULL,
    [Designator]  VARCHAR (5)   NOT NULL,
    [Category]    VARCHAR (40)  NULL,
    [City]        VARCHAR (50)  NULL,
    [Province]    VARCHAR (45)  NULL,
    [Country]     VARCHAR (45)  CONSTRAINT [DF_airportData_country] DEFAULT ('Canada') NOT NULL,
    [Latitude]    FLOAT (53)    NOT NULL,
    [Longitude]   FLOAT (53)    NOT NULL,
    [Elevation]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Designator] ASC)
);

