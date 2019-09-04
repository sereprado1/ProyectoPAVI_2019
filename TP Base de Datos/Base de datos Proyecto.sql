USE [master]
GO
/****** Object:  Database [GrupoScoutProyecto]    Script Date: 09/04/2019 09:46:18 ******/
CREATE DATABASE [GrupoScoutProyecto] ON  PRIMARY 
( NAME = N'GrupoScoutProyecto', FILENAME = N'd:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\GrupoScoutProyecto.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GrupoScoutProyecto_log', FILENAME = N'd:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\GrupoScoutProyecto_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GrupoScoutProyecto] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GrupoScoutProyecto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GrupoScoutProyecto] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET ANSI_NULLS OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET ANSI_PADDING OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET ARITHABORT OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [GrupoScoutProyecto] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [GrupoScoutProyecto] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [GrupoScoutProyecto] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET  DISABLE_BROKER
GO
ALTER DATABASE [GrupoScoutProyecto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [GrupoScoutProyecto] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [GrupoScoutProyecto] SET  READ_WRITE
GO
ALTER DATABASE [GrupoScoutProyecto] SET RECOVERY SIMPLE
GO
ALTER DATABASE [GrupoScoutProyecto] SET  MULTI_USER
GO
ALTER DATABASE [GrupoScoutProyecto] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [GrupoScoutProyecto] SET DB_CHAINING OFF
GO
USE [GrupoScoutProyecto]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[id_perfil] [int] NULL,
	[usuario] [varchar](50) NULL,
	[contraseña] [varchar](50) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TutorXBeneficiario]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TutorXBeneficiario](
	[id_tipo_doc_tutor] [int] NOT NULL,
	[nro_doc_tutor] [numeric](18, 0) NOT NULL,
	[id_tipo_doc_benef] [int] NOT NULL,
	[nro_doc_benef] [numeric](18, 0) NOT NULL,
	[id_relacion] [int] NULL,
	[es_responsable_directo] [int] NULL,
 CONSTRAINT [PK_TutorXBeneficiario] PRIMARY KEY CLUSTERED 
(
	[id_tipo_doc_tutor] ASC,
	[nro_doc_tutor] ASC,
	[id_tipo_doc_benef] ASC,
	[nro_doc_benef] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tutor]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tutor](
	[id_tipo_doc_tutor] [int] NOT NULL,
	[nro_doc_tutor] [numeric](18, 0) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
 CONSTRAINT [PK_Tutor] PRIMARY KEY CLUSTERED 
(
	[id_tipo_doc_tutor] ASC,
	[nro_doc_tutor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tipo_Documento]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipo_Documento](
	[id_tipo_doc] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Tipo_Documento] PRIMARY KEY CLUSTERED 
(
	[id_tipo_doc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Relacion]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Relacion](
	[id_relacion] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Relacion] PRIMARY KEY CLUSTERED 
(
	[id_relacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rama]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rama](
	[id_rama] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[edad_inicial] [int] NULL,
	[edad_final] [int] NULL,
 CONSTRAINT [PK_Rama] PRIMARY KEY CLUSTERED 
(
	[id_rama] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perfil](
	[id_perfil] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[id_perfil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Funcion]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Funcion](
	[id_funcion] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Funcion] PRIMARY KEY CLUSTERED 
(
	[id_funcion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dirigente]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dirigente](
	[id_tipo_doc_diri] [int] NOT NULL,
	[nro_doc_diri] [numeric](18, 0) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
 CONSTRAINT [PK_Dirigente] PRIMARY KEY CLUSTERED 
(
	[id_tipo_doc_diri] ASC,
	[nro_doc_diri] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Descuento]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Descuento](
	[id_descuento] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[porcentaje] [float] NULL,
 CONSTRAINT [PK_Descuento] PRIMARY KEY CLUSTERED 
(
	[id_descuento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CuotaXAfiliacionXBeneficiario]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuotaXAfiliacionXBeneficiario](
	[id_tipo_doc_benef] [int] NOT NULL,
	[nro_doc_benef] [numeric](18, 0) NOT NULL,
	[id_afiliacion] [int] NOT NULL,
	[mes] [int] NOT NULL,
	[id_descuento] [int] NULL,
	[monto_total] [float] NULL,
	[esta_pagada] [int] NULL,
	[fec_pago] [date] NULL,
 CONSTRAINT [PK_CuotaXAfiliacionXBeneficiario] PRIMARY KEY CLUSTERED 
(
	[id_tipo_doc_benef] ASC,
	[nro_doc_benef] ASC,
	[id_afiliacion] ASC,
	[mes] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComunidadXDirigente]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComunidadXDirigente](
	[id_comunidad] [int] NOT NULL,
	[id_tipo_doc_diri] [int] NOT NULL,
	[nro_doc_diri] [numeric](18, 0) NOT NULL,
	[id_funcion] [int] NULL,
 CONSTRAINT [PK_ComunidadXDirigente] PRIMARY KEY CLUSTERED 
(
	[id_comunidad] ASC,
	[id_tipo_doc_diri] ASC,
	[nro_doc_diri] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComunidadXBeneficiario]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComunidadXBeneficiario](
	[id_comunidad] [int] NOT NULL,
	[id_tipo_doc_benef] [int] NOT NULL,
	[nro_doc_benef] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_ComunidadXBeneficiario] PRIMARY KEY CLUSTERED 
(
	[id_comunidad] ASC,
	[id_tipo_doc_benef] ASC,
	[nro_doc_benef] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comunidad]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comunidad](
	[id_comunidad] [int] IDENTITY(1,1) NOT NULL,
	[id_rama] [int] NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Comunidad] PRIMARY KEY CLUSTERED 
(
	[id_comunidad] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Beneficiario]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Beneficiario](
	[id_tipo_doc_benef] [int] NOT NULL,
	[nro_doc_benef] [numeric](18, 0) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[fec_nacimiento] [date] NULL,
	[direccion] [varchar](50) NULL,
	[fec_ingreso] [date] NULL,
	[esta_afiliado] [int] NULL,
 CONSTRAINT [PK_Beneficiario] PRIMARY KEY CLUSTERED 
(
	[id_tipo_doc_benef] ASC,
	[nro_doc_benef] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AfiliacionXBeneficiario]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AfiliacionXBeneficiario](
	[id_afiliacion] [int] NOT NULL,
	[id_tipo_doc_benef] [int] NOT NULL,
	[nro_doc_benef] [numeric](18, 0) NOT NULL,
	[id_descuento] [int] NULL,
	[monto_total] [float] NULL,
	[fec_pago] [date] NULL,
 CONSTRAINT [PK_AfiliacionXBeneficiario] PRIMARY KEY CLUSTERED 
(
	[id_afiliacion] ASC,
	[id_tipo_doc_benef] ASC,
	[nro_doc_benef] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Afiliacion]    Script Date: 09/04/2019 09:46:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Afiliacion](
	[id_afiliacion] [int] IDENTITY(1,1) NOT NULL,
	[año] [int] NULL,
	[monto] [float] NULL,
	[descripcion] [varchar](50) NULL,
	[monto_cuota] [float] NULL,
 CONSTRAINT [PK_Afiliacion] PRIMARY KEY CLUSTERED 
(
	[id_afiliacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
