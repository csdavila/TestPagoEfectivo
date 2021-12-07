
USE [master]
GO

CREATE DATABASE [DB_pago_efectivo]
GO

USE [DB_pago_efectivo]
GO

CREATE TABLE [dbo].[PromoCode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](500) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Code] [varchar](36) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_PromoCode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PromoCode] ADD  CONSTRAINT [DF_PromoCode_Status]  DEFAULT ((1)) FOR [Status]
GO
