USE [master]
GO
/****** Object:  Database [Assignment]    Script Date: 02-03-2021 23:04:52 ******/
CREATE DATABASE [Assignment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Assignment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Assignment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Assignment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Assignment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Assignment] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Assignment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Assignment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Assignment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Assignment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Assignment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Assignment] SET ARITHABORT OFF 
GO
ALTER DATABASE [Assignment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Assignment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Assignment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Assignment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Assignment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Assignment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Assignment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Assignment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Assignment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Assignment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Assignment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Assignment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Assignment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Assignment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Assignment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Assignment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Assignment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Assignment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Assignment] SET  MULTI_USER 
GO
ALTER DATABASE [Assignment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Assignment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Assignment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Assignment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Assignment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Assignment] SET QUERY_STORE = OFF
GO
USE [Assignment]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 02-03-2021 23:04:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[DOB] [datetime] NULL,
	[Address] [varchar](200) NULL,
	[PhoneNumber] [varchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeProject]    Script Date: 02-03-2021 23:04:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeProject](
	[EmployeeProjectId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [bigint] NULL,
	[ProjectId] [bigint] NULL,
 CONSTRAINT [PK_EmployeeProject] PRIMARY KEY CLUSTERED 
(
	[EmployeeProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 02-03-2021 23:04:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectId] [bigint] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](50) NULL,
	[ProjectDescription] [varchar](max) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([EmployeeId], [Name], [DOB], [Address], [PhoneNumber]) VALUES (1, N'Ram', CAST(N'1988-09-10T00:00:00.000' AS DateTime), N'Bangalore', N'9739646857')
GO
INSERT [dbo].[Employee] ([EmployeeId], [Name], [DOB], [Address], [PhoneNumber]) VALUES (2, N'Arun', CAST(N'1992-02-10T00:00:00.000' AS DateTime), N'Hosur', N'9739646444')
GO
INSERT [dbo].[Employee] ([EmployeeId], [Name], [DOB], [Address], [PhoneNumber]) VALUES (3, N'Anish', CAST(N'2000-02-10T00:00:00.000' AS DateTime), N'Hosur', N'9778767672')
GO
INSERT [dbo].[Employee] ([EmployeeId], [Name], [DOB], [Address], [PhoneNumber]) VALUES (4, N'Amar', CAST(N'1985-04-03T00:00:00.000' AS DateTime), N'Kerala', N'9867344246')
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeProject] ON 
GO
INSERT [dbo].[EmployeeProject] ([EmployeeProjectId], [EmployeeId], [ProjectId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[EmployeeProject] ([EmployeeProjectId], [EmployeeId], [ProjectId]) VALUES (2, 1, 4)
GO
INSERT [dbo].[EmployeeProject] ([EmployeeProjectId], [EmployeeId], [ProjectId]) VALUES (3, 1, 5)
GO
INSERT [dbo].[EmployeeProject] ([EmployeeProjectId], [EmployeeId], [ProjectId]) VALUES (4, 2, 1)
GO
INSERT [dbo].[EmployeeProject] ([EmployeeProjectId], [EmployeeId], [ProjectId]) VALUES (5, 3, 1)
GO
INSERT [dbo].[EmployeeProject] ([EmployeeProjectId], [EmployeeId], [ProjectId]) VALUES (6, 4, 1)
GO
SET IDENTITY_INSERT [dbo].[EmployeeProject] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 
GO
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [ProjectDescription]) VALUES (1, N'Shawbrook', N'Shawbrook')
GO
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [ProjectDescription]) VALUES (2, N'Unum', N'Unum')
GO
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [ProjectDescription]) VALUES (3, N'Cocacola', N'Cocacola')
GO
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [ProjectDescription]) VALUES (4, N'Morgan Stanley', N'Morgan Stanley')
GO
INSERT [dbo].[Project] ([ProjectId], [ProjectName], [ProjectDescription]) VALUES (5, N'Wellsfargo', N'Wellsfargo')
GO
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
ALTER TABLE [dbo].[EmployeeProject]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeProject_EmployeeProject] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[EmployeeProject] CHECK CONSTRAINT [FK_EmployeeProject_EmployeeProject]
GO
ALTER TABLE [dbo].[EmployeeProject]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeProject_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[EmployeeProject] CHECK CONSTRAINT [FK_EmployeeProject_Project]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployeeDetails]    Script Date: 02-03-2021 23:04:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetEmployeeDetails] 
(@EmployeeId bigint=null)
as 
begin
if(@EmployeeId=0)select EmployeeId	,Name,	DOB,	Address,	PhoneNumber , 
( select  p.ProjectName +' - ' + p.ProjectDescription + ', ' from employee e1 inner join EmployeeProject ep on e1.EmployeeId = ep.employeeid
inner join project p on ep.projectid=p.projectid
            FOR XML PATH('') ) AS Projects from employee 
else 
select EmployeeId	,Name,	DOB,	Address,	PhoneNumber ,  
( select  p.ProjectName +' - ' + p.ProjectDescription + ', ' from employee e1 inner join EmployeeProject ep on e1.EmployeeId = ep.employeeid
inner join project p on ep.projectid=p.projectid
            FOR XML PATH('') ) AS Projects from employee where EmployeeId = @EmployeeId
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployeeProjectDetails]    Script Date: 02-03-2021 23:04:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_GetEmployeeProjectDetails]  
(@EmployeeId bigint=null)
as 
begin
if(@EmployeeId=0)
 select p.ProjectId,  p.ProjectName, p.ProjectDescription from project p 

else  
select e.EmployeeId,e.Name,
 ( select  p.ProjectName +' - ' + p.ProjectDescription + ', ' from employee e1 inner join EmployeeProject ep on e1.EmployeeId = ep.employeeid
inner join project p on ep.projectid=p.projectid
            FOR XML PATH('') ) AS Projects
from employee e  where e.EmployeeId = @EmployeeId
end
GO
USE [master]
GO
ALTER DATABASE [Assignment] SET  READ_WRITE 
GO
