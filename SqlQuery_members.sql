GO
--Object:  Table [dbo].[members]    Script Date: 04/18/2021 11:33:08 am /
 SET ANSI_NULLS ON
 GO
 SET QUOTED_IDENTIFIER ON
 GO
 CREATE TABLE [dbo].[members](
     [Id] [int] IDENTITY(1,1) NOT NULL,
     [Name] [nvarchar](100) NULL,
     [Contact] [nvarchar](100) NULL,
     [Address] [nvarchar](200) NULL,
     [RegDate] [datetime] NULL
 ) ON [PRIMARY]
 GO

 GO
 SET ANSI_NULLS ON
 GO
 SET QUOTED_IDENTIFIER ON
 GO
 CREATE TABLE [dbo].[tbl_users](
     [userid] [int] IDENTITY(1,1) NOT NULL,
     [username] [nvarchar](100) NULL,
     [password] [nvarchar](100) NULL,
     [email] [nvarchar](100) NULL,
     [role] [nvarchar](50) NULL,
     [reg_date] [datetime] NULL
 ) ON [PRIMARY]
 GO