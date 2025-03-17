SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[PhoneNumber] [nvarchar](9) NOT NULL,
	[Address_Country] [nvarchar](3) NOT NULL,
	[Address_Line1] [nvarchar](20) NOT NULL,
	[Address_Line2] [nvarchar](20) NULL,
	[Address_City] [nvarchar](40) NOT NULL,
	[Address_State] [nvarchar](40) NOT NULL,
	[Address_ZipCode] [nvarchar](10) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
