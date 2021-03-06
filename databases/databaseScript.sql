USE [master]
GO
/****** Object:  Database [ContactManagementDB]    Script Date: 23-11-2020 20:54:21 ******/
CREATE DATABASE [ContactManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ContactManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ContactManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ContactManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ContactManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ContactManagementDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContactManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ContactManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ContactManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ContactManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ContactManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ContactManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ContactManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ContactManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ContactManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ContactManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ContactManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ContactManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ContactManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ContactManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ContactManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ContactManagementDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ContactManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ContactManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ContactManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ContactManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ContactManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ContactManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ContactManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ContactManagementDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ContactManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [ContactManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ContactManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ContactManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ContactManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ContactManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ContactManagementDB', N'ON'
GO
ALTER DATABASE [ContactManagementDB] SET QUERY_STORE = OFF
GO
USE [ContactManagementDB]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 23-11-2020 20:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](255) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[Status] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD CHECK  (([Status]='Inactive' OR [Status]='Active'))
GO
/****** Object:  StoredProcedure [dbo].[sp_CreateContact]    Script Date: 23-11-2020 20:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CreateContact](
   @first_name VARCHAR(50),  
   @last_name VARCHAR(50),  
   @email VARCHAR(50),  
   @phone_number VARCHAR(20),  
   @status VARCHAR(20)
)
AS
BEGIN  
insert into Contacts(FirstName,LastName,Email,PhoneNumber,Status) values(@first_name, @last_name, @email, @phone_number,@status)  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteContact]    Script Date: 23-11-2020 20:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteContact](
   @id INTEGER
)
AS
BEGIN  
delete from Contacts 
where Id = @id  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllContacts]    Script Date: 23-11-2020 20:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllContacts]
AS
SELECT * FROM Contacts
GO;
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateContact]    Script Date: 23-11-2020 20:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateContact](
   @id INTEGER,
   @first_name VARCHAR(50),  
   @last_name VARCHAR(50),  
   @email VARCHAR(50),  
   @phone_number VARCHAR(20),  
   @status VARCHAR(20)
)
AS
BEGIN  
UPDATE Contacts SET  
FirstName = @first_name, LastName = @last_name, Email = @email, PhoneNumber = @phone_number, Status = @status 
where Id = @id  
END  
GO
USE [master]
GO
ALTER DATABASE [ContactManagementDB] SET  READ_WRITE 
GO
