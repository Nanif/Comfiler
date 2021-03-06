USE [DBcomfiler]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 02/09/2018 21:55:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] NOT NULL,
	[Description] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_CATEGORIES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Claims]    Script Date: 02/09/2018 21:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Claims](
	[Permission] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_CLAIMS] PRIMARY KEY CLUSTERED 
(
	[Permission] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Extensions]    Script Date: 02/09/2018 21:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Extensions](
	[ID] [int] NOT NULL,
	[Extension] [nchar](4) NOT NULL,
 CONSTRAINT [PK_Extensions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 02/09/2018 21:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[ID] [nchar](32) NOT NULL,
	[Desctiption] [nvarchar](80) NULL,
	[CreatorID] [nchar](9) NOT NULL,
	[Date_Creation] [date] NOT NULL,
	[UpdateID] [nchar](9) NULL,
	[Date_Update] [date] NULL,
	[ExtensionID] [int] NOT NULL,
	[Version] [int] NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilesDetails]    Script Date: 02/09/2018 21:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilesDetails](
	[ID] [nchar](32) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Remarks] [nvarchar](100) NULL,
 CONSTRAINT [PK_FilesDetails_tbl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[History]    Script Date: 02/09/2018 21:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[ID] [nchar](32) NOT NULL,
	[VirsionNum] [int] NOT NULL,
	[UpdateID] [nchar](9) NOT NULL,
	[Date_Update] [date] NOT NULL,
	[Remarks] [nvarchar](100) NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[VirsionNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 02/09/2018 21:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descripton] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PERMISSION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 02/09/2018 21:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles_tbl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShareLevel]    Script Date: 02/09/2018 21:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShareLevel](
	[ID] [int] NOT NULL,
	[Description] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Sharelevel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sharings]    Script Date: 02/09/2018 21:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sharings](
	[FileID] [nchar](32) NOT NULL,
	[TZ] [nchar](9) NOT NULL,
	[ShareLevelID] [int] NOT NULL,
 CONSTRAINT [PK_SHARINGS] PRIMARY KEY CLUSTERED 
(
	[FileID] ASC,
	[TZ] ASC,
	[ShareLevelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Templates]    Script Date: 02/09/2018 21:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Templates](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Templates] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02/09/2018 21:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[TZ] [nchar](9) NOT NULL,
	[Password] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](25) NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[TZ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersRoles]    Script Date: 02/09/2018 21:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersRoles](
	[TZ] [nchar](9) NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_REALATIONSHIP_USERS_ROLES] PRIMARY KEY CLUSTERED 
(
	[TZ] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Claims]  WITH CHECK ADD  CONSTRAINT [FK_Claims_tbl_Permission_tbl] FOREIGN KEY([Permission])
REFERENCES [dbo].[Permissions] ([ID])
GO
ALTER TABLE [dbo].[Claims] CHECK CONSTRAINT [FK_Claims_tbl_Permission_tbl]
GO
ALTER TABLE [dbo].[Claims]  WITH CHECK ADD  CONSTRAINT [FK_Claims_tbl_Roles_tbl] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([ID])
GO
ALTER TABLE [dbo].[Claims] CHECK CONSTRAINT [FK_Claims_tbl_Roles_tbl]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Extensions] FOREIGN KEY([ExtensionID])
REFERENCES [dbo].[Extensions] ([ID])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Extensions]
GO
ALTER TABLE [dbo].[FilesDetails]  WITH CHECK ADD  CONSTRAINT [FK_FilesDetails_Files] FOREIGN KEY([ID])
REFERENCES [dbo].[Files] ([ID])
GO
ALTER TABLE [dbo].[FilesDetails] CHECK CONSTRAINT [FK_FilesDetails_Files]
GO
ALTER TABLE [dbo].[FilesDetails]  WITH CHECK ADD  CONSTRAINT [FK_FilesDetails_tbl_Categories_tbl] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[FilesDetails] CHECK CONSTRAINT [FK_FilesDetails_tbl_Categories_tbl]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_Files] FOREIGN KEY([ID])
REFERENCES [dbo].[Files] ([ID])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_Files]
GO
ALTER TABLE [dbo].[Sharings]  WITH CHECK ADD  CONSTRAINT [FK_Sharings_ShareLevel] FOREIGN KEY([ShareLevelID])
REFERENCES [dbo].[ShareLevel] ([ID])
GO
ALTER TABLE [dbo].[Sharings] CHECK CONSTRAINT [FK_Sharings_ShareLevel]
GO
ALTER TABLE [dbo].[UsersRoles]  WITH CHECK ADD  CONSTRAINT [FK_RelationshipUsersRoles_tbl_Roles_tbl] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([ID])
GO
ALTER TABLE [dbo].[UsersRoles] CHECK CONSTRAINT [FK_RelationshipUsersRoles_tbl_Roles_tbl]
GO
