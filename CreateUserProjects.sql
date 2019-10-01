USE [Challenge]
GO

/****** Object:  Table [dbo].[UserProjects]    Script Date: 1/10/2019 05:26:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserProjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserProjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UserProjects]  WITH CHECK ADD  CONSTRAINT [FK_UserProjects_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO

ALTER TABLE [dbo].[UserProjects] CHECK CONSTRAINT [FK_UserProjects_Project]
GO

ALTER TABLE [dbo].[UserProjects]  WITH CHECK ADD  CONSTRAINT [FK_UserProjects_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[UserProjects] CHECK CONSTRAINT [FK_UserProjects_User]
GO


