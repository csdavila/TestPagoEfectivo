CREATE TABLE [dbo].[PromoCode] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Email]  VARCHAR (500) NOT NULL,
    [Name]   VARCHAR (500) NOT NULL,
    [Code]   VARCHAR (36)  NULL,
    [Status] INT           CONSTRAINT [DF_PromoCode_Status] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_PromoCode] PRIMARY KEY CLUSTERED ([Id] ASC)
);

