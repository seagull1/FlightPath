CREATE TABLE [dbo].[AirportFuel] (
    [AirportName]       VARCHAR (100)  NOT NULL,
    [CreateDate]        SMALLDATETIME  CONSTRAINT [DF_airport_fuel_date_added_1] DEFAULT (getdate()) NOT NULL,
    [FuelType]          VARCHAR (10)   NULL,
    [FuelPrice]         DECIMAL (6, 2) NULL,
    [FuelPriceComments] VARCHAR (60)   NULL,
    [FuelVenderName]    VARCHAR (15)   NULL,
    [FuelVenderRadio]   NCHAR (15)     NULL,
    [FuelVenderPhone]   VARCHAR (22)   NULL,
    [Designator]        VARCHAR (5)    NOT NULL,
    [Id]                INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Designator]) REFERENCES [dbo].[Airport] ([Designator])
);

