GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sku] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Manufacturer] [nvarchar](200) NOT NULL,
	[Price] [decimal](9, 2) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[Product] (Sku,[Name], Manufacturer, Price)
VALUES
('iphone12', 'iPhone 12', 'Apple', 800),
('iphone12pro', 'iPhone 12 Pro', 'Apple', 900),
('iphone13', 'iPhone 13', 'Apple', 1000),
('iphone12pro', 'iPhone 12 Pro', 'Apple', 1100)

--//////////////////////////////////////////////////

CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Barcode] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Rate] [decimal](18, 2) NOT NULL,
	[AddedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO