USE [avs]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 7/2/2018 5:03:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmpNo] [varchar](10) NOT NULL,
	[Title] [varchar](10) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NOT NULL,
	[NickName] [varchar](50) NOT NULL,
	[DateHired] [datetime] NOT NULL,
	[Birthdate] [datetime] NOT NULL,
	[Height] [varchar](20) NOT NULL,
	[Weight] [varchar](20) NOT NULL,
	[Complexion] [varchar](50) NOT NULL,
	[Image] [varbinary](max) NULL,
	[Position] [varchar](50) NOT NULL,
	[SSS] [varchar](50) NULL,
	[TIN] [varchar](50) NULL,
	[Pagibig] [varchar](50) NULL,
	[Philhealth] [varchar](50) NULL,
	[Passport] [varchar](50) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemUsers]    Script Date: 7/2/2018 5:03:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[Username] [nchar](15) NULL,
	[Password] [nchar](15) NULL,
	[AccessLevel] [int] NULL,
 CONSTRAINT [PK_SystemUsers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spEmployeeGetByID]    Script Date: 7/2/2018 5:03:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spEmployeeGetByID]
(
	@ID int
)
AS
SELECT A.*, B.Username
FROM Employees A
INNER JOIN SystemUsers B
on a.ID = b.EmployeeID WHere a.ID = @ID
GO
