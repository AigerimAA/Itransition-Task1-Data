USE [ItransitionData]
GO

/****** Object:  Table [dbo].[RawBooks]    Script Date: 07.04.2026 11:35:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RawBooks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NULL,
	[PublicationYear] [int] NULL,
	[PriceRaw] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


