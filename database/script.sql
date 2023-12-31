USE [master]
GO
/****** Object:  Database [DB_N5_CHALLENGE]    Script Date: 11/12/2023 17:52:35 ******/
CREATE DATABASE [DB_N5_CHALLENGE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_N5_CHALLENGE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DB_N5_CHALLENGE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_N5_CHALLENGE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DB_N5_CHALLENGE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_N5_CHALLENGE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET  MULTI_USER 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_N5_CHALLENGE', N'ON'
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET QUERY_STORE = ON
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DB_N5_CHALLENGE]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 11/12/2023 17:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeForename] [varchar](100) NOT NULL,
	[EmployeeSurname] [varchar](100) NOT NULL,
	[PermissionType] [int] NOT NULL,
	[PermissionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermissionType]    Script Date: 11/12/2023 17:52:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionType](
	[Id] [int] NOT NULL,
	[Description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_PermissionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Permission]  WITH NOCHECK ADD  CONSTRAINT [FK_Permission_PermissionType] FOREIGN KEY([PermissionType])
REFERENCES [dbo].[PermissionType] ([Id])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_PermissionType]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission'
GO
USE [master]
GO
ALTER DATABASE [DB_N5_CHALLENGE] SET  READ_WRITE 
GO
