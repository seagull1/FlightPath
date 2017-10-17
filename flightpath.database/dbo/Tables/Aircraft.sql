CREATE TABLE [dbo].[Aircraft] (
    [Make]              VARCHAR (40) NOT NULL,
    [Model]             VARCHAR (60) NOT NULL,
    [Horsepower]        INT          NULL,
    [WeightEmpty]       INT          NULL,
    [FuelCapacity]      INT          NOT NULL,
    [WeightGross]       INT          NULL,
    [SpeedTop]          INT          NULL,
    [SpeedCruise]       INT          NOT NULL,
    [SpeedStall]        INT          NULL,
    [Range]             INT          NOT NULL,
    [TakeoffGroundRoll] INT          NULL,
    [LandingGroundRoll] INT          NULL,
    [Takeoff50ftObst]   INT          NULL,
    [Landing50ftObst]   INT          NULL,
    [RateOfClimb]       INT          NULL,
    [RateOfClimbSingle] INT          NULL,
    [Ceiling]           INT          NOT NULL,
    [CeilingSingle]     INT          NULL,
    [FuelBurn]          INT          NULL,
    [Id]                INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

