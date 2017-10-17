CREATE TABLE [dbo].[AirportFee] (
    [AirportName] VARCHAR (100)  NOT NULL,
    [CreateDate]  SMALLDATETIME  CONSTRAINT [DF_airport_fees_date_added] DEFAULT (getdate()) NOT NULL,
    [FeeLanding]  DECIMAL (5, 2) NULL,
    [FeeTerminal] DECIMAL (5, 2) NULL,
    [FeeParking]  DECIMAL (5, 2) NULL,
    [FeeFuelTax]  DECIMAL (5, 2) NULL,
    [FeeComments] VARCHAR (50)   NULL,
    [Designator]  VARCHAR (5)    NOT NULL,
    [Id]          INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([Designator]) REFERENCES [dbo].[Airport] ([Designator])
);

