GO
--Object:  Table [dbo].[members]    Script Date: 04/18/2021 11:33:08 am /
 SET ANSI_NULLS ON
 GO
 SET QUOTED_IDENTIFIER ON
 GO
 CREATE TABLE [dbo].[members](
     [Id] [int] IDENTITY(1,1) NOT NULL,
     [Name] nvarchar NULL,
     [Contact] nvarchar NULL,
     [Address] nvarchar NULL,
     [RegDate] [datetime] NULL
 ) ON [PRIMARY]
 GO