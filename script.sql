USE [master]
GO
/****** Object:  Database [Blog]    Script Date: 18/04/2019 15:40:21 ******/
CREATE DATABASE [Blog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Blog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Blog.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Blog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Blog_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Blog] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Blog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Blog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Blog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Blog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Blog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Blog] SET ARITHABORT OFF 
GO
ALTER DATABASE [Blog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Blog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Blog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Blog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Blog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Blog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Blog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Blog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Blog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Blog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Blog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Blog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Blog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Blog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Blog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Blog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Blog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Blog] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Blog] SET  MULTI_USER 
GO
ALTER DATABASE [Blog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Blog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Blog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Blog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Blog] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Blog] SET QUERY_STORE = OFF
GO
USE [Blog]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 18/04/2019 15:40:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[IdArticle] [int] IDENTITY(1,1) NOT NULL,
	[TitreArticle] [varchar](max) NOT NULL,
	[DescriptionArticle] [varchar](max) NOT NULL,
	[TexteArticle] [varchar](max) NOT NULL,
	[DatePublication] [date] NOT NULL,
	[DateModif] [date] NOT NULL,
	[Popularite] [int] NULL,
	[IdAuteur] [int] NOT NULL,
	[IdStatut] [int] NOT NULL,
	[IdRubrique] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdArticle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Commentaire]    Script Date: 18/04/2019 15:40:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commentaire](
	[IdCommentaire] [int] IDENTITY(1,1) NOT NULL,
	[TitreCommentaire] [varchar](max) NULL,
	[TexteCommentaire] [varchar](max) NOT NULL,
	[DatePublication] [date] NULL,
	[DateModification] [date] NULL,
	[Popularite] [int] NULL,
	[IdArticle] [int] NOT NULL,
	[IdStatut] [int] NOT NULL,
	[IdAuteur] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCommentaire] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 18/04/2019 15:40:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[IdImage] [int] IDENTITY(1,1) NOT NULL,
	[UrlImage] [varchar](max) NOT NULL,
	[DatePublication] [date] NOT NULL,
	[DescriptionImage] [varchar](max) NULL,
	[IdArticle] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdImage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Like]    Script Date: 18/04/2019 15:40:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Like](
	[IdLike] [int] IDENTITY(1,1) NOT NULL,
	[IdUtilisateur] [int] NOT NULL,
	[IdCommentaire] [int] NOT NULL,
	[IdArticle] [int] NOT NULL,
	[DatePop] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLike] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rubrique]    Script Date: 18/04/2019 15:40:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rubrique](
	[IdRubrique] [int] IDENTITY(1,1) NOT NULL,
	[IntituleRubrique] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRubrique] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statut]    Script Date: 18/04/2019 15:40:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statut](
	[IdStatut] [int] IDENTITY(1,1) NOT NULL,
	[LibelleStatut] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdStatut] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table]    Script Date: 18/04/2019 15:40:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[IdRubrique] [int] IDENTITY(1,1) NOT NULL,
	[IntituleRubrique] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRubrique] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeUtilisateur]    Script Date: 18/04/2019 15:40:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeUtilisateur](
	[IdTypeUtilisateur] [int] IDENTITY(1,1) NOT NULL,
	[Profil] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTypeUtilisateur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilisateur]    Script Date: 18/04/2019 15:40:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilisateur](
	[IdUtilisateur] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](max) NOT NULL,
	[Prenom] [varchar](max) NOT NULL,
	[email] [varchar](max) NOT NULL,
	[MotDePasse] [varchar](max) NOT NULL,
	[Blacklist] [tinyint] NULL,
	[IdTypeUtilisateur] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUtilisateur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Article]  WITH CHECK ADD FOREIGN KEY([IdAuteur])
REFERENCES [dbo].[Utilisateur] ([IdUtilisateur])
GO
ALTER TABLE [dbo].[Article]  WITH CHECK ADD FOREIGN KEY([IdRubrique])
REFERENCES [dbo].[Rubrique] ([IdRubrique])
GO
ALTER TABLE [dbo].[Article]  WITH CHECK ADD FOREIGN KEY([IdStatut])
REFERENCES [dbo].[Statut] ([IdStatut])
GO
ALTER TABLE [dbo].[Commentaire]  WITH CHECK ADD FOREIGN KEY([IdArticle])
REFERENCES [dbo].[Article] ([IdArticle])
GO
ALTER TABLE [dbo].[Commentaire]  WITH CHECK ADD FOREIGN KEY([IdAuteur])
REFERENCES [dbo].[Utilisateur] ([IdUtilisateur])
GO
ALTER TABLE [dbo].[Commentaire]  WITH CHECK ADD FOREIGN KEY([IdStatut])
REFERENCES [dbo].[Statut] ([IdStatut])
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD FOREIGN KEY([IdArticle])
REFERENCES [dbo].[Article] ([IdArticle])
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD FOREIGN KEY([IdArticle])
REFERENCES [dbo].[Article] ([IdArticle])
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD FOREIGN KEY([IdCommentaire])
REFERENCES [dbo].[Commentaire] ([IdCommentaire])
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD FOREIGN KEY([IdUtilisateur])
REFERENCES [dbo].[Utilisateur] ([IdUtilisateur])
GO
ALTER TABLE [dbo].[Utilisateur]  WITH CHECK ADD FOREIGN KEY([IdTypeUtilisateur])
REFERENCES [dbo].[TypeUtilisateur] ([IdTypeUtilisateur])
GO
USE [master]
GO
ALTER DATABASE [Blog] SET  READ_WRITE 
GO
