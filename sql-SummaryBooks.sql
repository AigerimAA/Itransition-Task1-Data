USE [ItransitionData]
GO

/****** Object:  Table [dbo].[SummaryBooks]    Script Date: 07.04.2026 11:36:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SummaryBooks](
	[PublicationYear] [int] NULL,
	[BookCount] [int] NULL,
	[AveragePriceUsd] [decimal](18, 2) NULL
) ON [PRIMARY]
GO


