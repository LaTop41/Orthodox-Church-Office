USE [master]
GO
/****** Object:  Database [CrkvenaKancelarija]    Script Date: 27.05.2020. 09:38:58 ******/
CREATE DATABASE [CrkvenaKancelarija]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CrkvenaKancelarija', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CrkvenaKancelarija.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CrkvenaKancelarija_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CrkvenaKancelarija_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CrkvenaKancelarija] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CrkvenaKancelarija].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CrkvenaKancelarija] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET ARITHABORT OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CrkvenaKancelarija] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CrkvenaKancelarija] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CrkvenaKancelarija] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CrkvenaKancelarija] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CrkvenaKancelarija] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CrkvenaKancelarija] SET  MULTI_USER 
GO
ALTER DATABASE [CrkvenaKancelarija] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CrkvenaKancelarija] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CrkvenaKancelarija] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CrkvenaKancelarija] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CrkvenaKancelarija] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CrkvenaKancelarija] SET QUERY_STORE = OFF
GO
USE [CrkvenaKancelarija]
GO
/****** Object:  Table [dbo].[Arhiva1]    Script Date: 27.05.2020. 09:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arhiva1](
	[IDDokumenta] [int] NOT NULL,
	[RedniBroj] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[ImeAdmin] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Arhiva1] PRIMARY KEY CLUSTERED 
(
	[IDDokumenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dokument]    Script Date: 27.05.2020. 09:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dokument](
	[SifraDokumenta] [int] NOT NULL,
	[VrstaDokumenta] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Dokument] PRIMARY KEY CLUSTERED 
(
	[SifraDokumenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Krstenica]    Script Date: 27.05.2020. 09:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Krstenica](
	[SifraDokumenta] [int] NOT NULL,
	[SifraKrstenice] [int] NOT NULL,
	[ImeVernika] [nvarchar](20) NOT NULL,
	[PrezimeVernika] [nvarchar](20) NOT NULL,
	[Pol] [nvarchar](10) NOT NULL,
	[DatumRodjenja] [date] NOT NULL,
	[Eparhija] [nvarchar](50) NOT NULL,
	[Hram] [nvarchar](50) NOT NULL,
	[TekucaGodina] [int] NOT NULL,
	[ZanimanjeVernika] [nvarchar](50) NULL,
	[MestoRodjenja] [nvarchar](50) NOT NULL,
	[DatumKrstenja] [date] NOT NULL,
	[ImeOca] [nvarchar](20) NOT NULL,
	[PrezimeOca] [nvarchar](20) NOT NULL,
	[ImeMajke] [nvarchar](20) NOT NULL,
	[PrezimeMajke] [nvarchar](20) NOT NULL,
	[ZanimanjeOca] [nvarchar](50) NOT NULL,
	[ZanimanjeMajke] [nvarchar](50) NOT NULL,
	[MestoStanovanjaRoditelja] [nvarchar](50) NOT NULL,
	[NarodnostOca] [nvarchar](20) NOT NULL,
	[NarodnostMajke] [nvarchar](20) NOT NULL,
	[DetePoRedu] [nvarchar](25) NOT NULL,
	[DeteBlizanac] [nvarchar](10) NOT NULL,
	[TelesniNedostaci] [nvarchar](150) NULL,
	[ImeKuma] [nvarchar](20) NOT NULL,
	[PrezimeKuma] [nvarchar](20) NOT NULL,
	[MestoStanovanjaKuma] [nvarchar](50) NOT NULL,
	[ImeSvestenika] [nvarchar](20) NOT NULL,
	[PrezimeSvestenika] [nvarchar](20) NOT NULL,
	[Primedba] [nvarchar](500) NULL,
 CONSTRAINT [PK_Krstenica] PRIMARY KEY CLUSTERED 
(
	[SifraDokumenta] ASC,
	[SifraKrstenice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 27.05.2020. 09:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[ID] [int] NOT NULL,
	[Korisnik] [nvarchar](50) NOT NULL,
	[Sifra] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Umrlica]    Script Date: 27.05.2020. 09:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Umrlica](
	[SifraDokumenta] [int] NOT NULL,
	[SifraUmrlice] [int] NOT NULL,
	[ImePreminulog] [nvarchar](20) NOT NULL,
	[PrezimePreminulog] [nvarchar](20) NOT NULL,
	[Pol] [nvarchar](10) NOT NULL,
	[DatumRodjenja] [date] NOT NULL,
	[MestoRodjenja] [nvarchar](50) NOT NULL,
	[Eparhija] [nvarchar](50) NOT NULL,
	[Hram] [nvarchar](50) NOT NULL,
	[TekucaGodina] [int] NOT NULL,
	[ZanimanjePreminulog] [nvarchar](50) NOT NULL,
	[MestoRodjenjaPreminulog] [nvarchar](50) NOT NULL,
	[BracnoStanje] [nvarchar](20) NOT NULL,
	[ImeBracnogPartnera] [nvarchar](20) NULL,
	[PrezimeBracnogPartnera] [nvarchar](20) NULL,
	[ZanimanjeBracnogPartnera] [nvarchar](50) NULL,
	[MestoStanovanjaBracnogPartnera] [nvarchar](50) NULL,
	[BrojDece] [int] NULL,
	[PodaciODeci] [nvarchar](800) NULL,
	[MestoPreminuca] [nvarchar](50) NOT NULL,
	[DatumSmrti] [datetime] NOT NULL,
	[DatumSahrane] [date] NOT NULL,
	[MestoIGrobljeSahrane] [nvarchar](80) NOT NULL,
	[UzrokSmrti] [nvarchar](50) NOT NULL,
	[ImeSvestenika] [nvarchar](20) NOT NULL,
	[PrezimeSvestenika] [nvarchar](20) NOT NULL,
	[IspovedjenIPricescen] [nvarchar](50) NOT NULL,
	[Primedba] [nvarchar](500) NULL,
 CONSTRAINT [PK_Umrlica] PRIMARY KEY CLUSTERED 
(
	[SifraDokumenta] ASC,
	[SifraUmrlice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VencaniList]    Script Date: 27.05.2020. 09:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VencaniList](
	[SifraDokumenta] [int] NOT NULL,
	[SifraVencanogLista] [int] NOT NULL,
	[ImeMladozenje] [nvarchar](20) NOT NULL,
	[PrezimeMladozenje] [nvarchar](20) NOT NULL,
	[ImeMlade] [nvarchar](20) NOT NULL,
	[PrezimeMlade] [nvarchar](20) NOT NULL,
	[DatumRodjenjaMladozenje] [date] NOT NULL,
	[DatumRodjenjaMlade] [date] NOT NULL,
	[MestoStanovanjaMladenaca] [nvarchar](50) NOT NULL,
	[VeroispovestMladozenje] [nvarchar](30) NOT NULL,
	[VeroispovestMlade] [nvarchar](30) NOT NULL,
	[NarodnostMladozenje] [nvarchar](20) NOT NULL,
	[NarodnostMlade] [nvarchar](20) NOT NULL,
	[Eparhija] [nvarchar](50) NOT NULL,
	[Hram] [nvarchar](50) NOT NULL,
	[TekucaGodina] [int] NOT NULL,
	[ImeOcaMladozenje] [nvarchar](20) NOT NULL,
	[PrezimeOcaMladozenje] [nvarchar](20) NOT NULL,
	[ImeMajkeMladozenje] [nvarchar](20) NOT NULL,
	[PrezimeMajkeMladozenje] [nvarchar](20) NOT NULL,
	[ImeOcaMlade] [nvarchar](20) NOT NULL,
	[PrezimeOcaMlade] [nvarchar](20) NOT NULL,
	[ImeMajkeMlade] [nvarchar](20) NOT NULL,
	[PrezimeMajkeMlade] [nvarchar](20) NOT NULL,
	[BrakPoReduMladozenja] [nvarchar](20) NOT NULL,
	[BrakPoReduMlada] [nvarchar](20) NOT NULL,
	[IspitaniIOglaseni] [date] NOT NULL,
	[DatumVencanja] [date] NOT NULL,
	[MestoVencanja] [nvarchar](50) NOT NULL,
	[HramVencanja] [nvarchar](50) NOT NULL,
	[ImeIPrezimeKuma] [nvarchar](60) NOT NULL,
	[ZanimanjeKuma] [nvarchar](40) NOT NULL,
	[MestoStanovanjaKuma] [nvarchar](50) NOT NULL,
	[ImeIPrezimeStarogSvata] [nvarchar](60) NOT NULL,
	[ZanimanjeStarogSvata] [nvarchar](40) NOT NULL,
	[VeroispovestStarogSvata] [nvarchar](40) NOT NULL,
	[MestoStanovanjaStarogSvata] [nvarchar](40) NOT NULL,
	[Smetnje] [nvarchar](60) NOT NULL,
	[Primedba] [nvarchar](500) NULL,
 CONSTRAINT [PK_VencaniList] PRIMARY KEY CLUSTERED 
(
	[SifraDokumenta] ASC,
	[SifraVencanogLista] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Krstenica]  WITH NOCHECK ADD  CONSTRAINT [FK_Krstenica_Arhiva1] FOREIGN KEY([SifraKrstenice])
REFERENCES [dbo].[Arhiva1] ([IDDokumenta])
GO
ALTER TABLE [dbo].[Krstenica] CHECK CONSTRAINT [FK_Krstenica_Arhiva1]
GO
ALTER TABLE [dbo].[Krstenica]  WITH CHECK ADD  CONSTRAINT [FK_Krstenica_Dokument] FOREIGN KEY([SifraDokumenta])
REFERENCES [dbo].[Dokument] ([SifraDokumenta])
GO
ALTER TABLE [dbo].[Krstenica] CHECK CONSTRAINT [FK_Krstenica_Dokument]
GO
ALTER TABLE [dbo].[Umrlica]  WITH NOCHECK ADD  CONSTRAINT [FK_Umrlica_Arhiva1] FOREIGN KEY([SifraUmrlice])
REFERENCES [dbo].[Arhiva1] ([IDDokumenta])
GO
ALTER TABLE [dbo].[Umrlica] CHECK CONSTRAINT [FK_Umrlica_Arhiva1]
GO
ALTER TABLE [dbo].[Umrlica]  WITH CHECK ADD  CONSTRAINT [FK_Umrlica_Dokument] FOREIGN KEY([SifraDokumenta])
REFERENCES [dbo].[Dokument] ([SifraDokumenta])
GO
ALTER TABLE [dbo].[Umrlica] CHECK CONSTRAINT [FK_Umrlica_Dokument]
GO
ALTER TABLE [dbo].[VencaniList]  WITH NOCHECK ADD  CONSTRAINT [FK_VencaniList_Arhiva1] FOREIGN KEY([SifraVencanogLista])
REFERENCES [dbo].[Arhiva1] ([IDDokumenta])
GO
ALTER TABLE [dbo].[VencaniList] CHECK CONSTRAINT [FK_VencaniList_Arhiva1]
GO
ALTER TABLE [dbo].[VencaniList]  WITH CHECK ADD  CONSTRAINT [FK_VencaniList_Dokument] FOREIGN KEY([SifraDokumenta])
REFERENCES [dbo].[Dokument] ([SifraDokumenta])
GO
ALTER TABLE [dbo].[VencaniList] CHECK CONSTRAINT [FK_VencaniList_Dokument]
GO
USE [master]
GO
ALTER DATABASE [CrkvenaKancelarija] SET  READ_WRITE 
GO
