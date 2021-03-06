USE [Calidad]
GO
/****** Object:  Table [dbo].[CalidadSaludEPS]    Script Date: 03/11/2017 5:26:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CalidadSaludEPS](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Codigo_Categoria] [varchar](50) NULL,
	[Codigo_eps] [varchar](10) NULL,
	[nomservicio] [varchar](200) NULL,
	[nomespecifique] [varchar](200) NULL,
	[nomidentificador] [varchar](500) NULL,
	[numerador] [int] NULL,
	[demoninador] [int] NULL,
	[resultado] [int] NULL,
	[nomunidad] [varchar](100) NULL,
	[nomfuente] [varchar](300) NULL,
	[linkfuente] [varchar](300) NULL,
 CONSTRAINT [PK_CalidadSaludEPS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cargue_CalidadSaludEPS]    Script Date: 03/11/2017 5:26:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cargue_CalidadSaludEPS](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Codigo_eps] [varchar](50) NULL,
	[eps] [varchar](300) NULL,
	[nomcategorias] [varchar](200) NULL,
	[nomservicio] [varchar](200) NULL,
	[nomespecifique] [varchar](200) NULL,
	[nomidentificador] [varchar](500) NULL,
	[numerador] [int] NULL,
	[demoninador] [int] NULL,
	[resultado] [int] NULL,
	[nomunidad] [varchar](100) NULL,
	[nomfuente] [varchar](300) NULL,
	[linkfuente] [varchar](300) NULL,
 CONSTRAINT [PK_Cargue_CalidadSaludEPS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 03/11/2017 5:26:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categorias](
	[Id_categoria] [bigint] IDENTITY(1,1) NOT NULL,
	[Codigo_categoria] [varchar](50) NOT NULL,
	[Nombre_Categoria] [varchar](300) NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[Codigo_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Datos_Encuestas]    Script Date: 03/11/2017 5:26:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Datos_Encuestas](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Id_Encuesta] [int] NOT NULL,
	[Codigo_EPS] [varchar](10) NOT NULL,
	[Valor] [int] NOT NULL,
	[FechaCreacion] [date] NOT NULL,
 CONSTRAINT [PK_Datos_Encuestas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Encuesta]    Script Date: 03/11/2017 5:26:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Encuesta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](250) NULL,
	[Numero] [int] NULL,
 CONSTRAINT [PK_Encuesta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EPS]    Script Date: 03/11/2017 5:26:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EPS](
	[Codigo_EPS] [varchar](10) NOT NULL,
	[Nombre_EPS] [varchar](200) NULL,
 CONSTRAINT [PK_EPS] PRIMARY KEY CLUSTERED 
(
	[Codigo_EPS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[Calidad]    Script Date: 03/11/2017 5:26:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[Calidad]
as
select a.codigo_categoria, b.nombre_categoria, a.codigo_eps, e.nombre_EPS, a.nomservicio, a.nomespecifique, a.nomidentificador, a.numerador, a.demoninador, a.resultado, nomunidad, a.nomfuente, a.linkfuente 
from [dbo].[CalidadSaludEPS] a inner join categorias b on a.codigo_categoria= b.codigo_categoria 
inner join  eps E on e.codigo_eps = a.codigo_eps


GO
ALTER TABLE [dbo].[CalidadSaludEPS]  WITH CHECK ADD  CONSTRAINT [FK_CalidadSaludEPS_Categorias] FOREIGN KEY([Codigo_Categoria])
REFERENCES [dbo].[Categorias] ([Codigo_categoria])
GO
ALTER TABLE [dbo].[CalidadSaludEPS] CHECK CONSTRAINT [FK_CalidadSaludEPS_Categorias]
GO
ALTER TABLE [dbo].[CalidadSaludEPS]  WITH CHECK ADD  CONSTRAINT [FK_CalidadSaludEPS_EPS] FOREIGN KEY([Codigo_eps])
REFERENCES [dbo].[EPS] ([Codigo_EPS])
GO
ALTER TABLE [dbo].[CalidadSaludEPS] CHECK CONSTRAINT [FK_CalidadSaludEPS_EPS]
GO
ALTER TABLE [dbo].[Datos_Encuestas]  WITH CHECK ADD  CONSTRAINT [FK_Datos_Encuestas_Encuesta] FOREIGN KEY([Id_Encuesta])
REFERENCES [dbo].[Encuesta] ([id])
GO
ALTER TABLE [dbo].[Datos_Encuestas] CHECK CONSTRAINT [FK_Datos_Encuestas_Encuesta]
GO
/****** Object:  StoredProcedure [dbo].[Cargar_Barra]    Script Date: 03/11/2017 5:26:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Cargar_Barra] @EPS varchar(10)
as 

select nombre_categoria as Nomservicio, nombre_categoria, sum(resultado)/count(0) as resultado from [dbo].[CalidadSaludEPS] a inner join categorias b on a.codigo_categoria = b.codigo_categoria  where codigo_eps = @EPS group by  nombre_categoria
GO
/****** Object:  StoredProcedure [dbo].[Cargar_combos]    Script Date: 03/11/2017 5:26:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Cargar_combos] @opcion int
AS
IF @opcion= 1
BEGIN
	SELECT codigo_eps as Codigo, nombre_EPS as Descripcion from eps
END
GO
/****** Object:  StoredProcedure [dbo].[Cargar_Torta]    Script Date: 03/11/2017 5:26:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Cargar_Torta] @EPS varchar(10)
as 

select nombre_categoria + '-' + Nomservicio as Nomservicio, nombre_categoria, sum(resultado)/count(0) as resultado 
from [dbo].[CalidadSaludEPS] a inner join categorias b on a.codigo_categoria = b.codigo_categoria  
where codigo_eps = @EPS group by  nombre_categoria, Nomservicio  
GO
/****** Object:  StoredProcedure [dbo].[Inserta_Encuesta]    Script Date: 03/11/2017 5:26:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Inserta_Encuesta] @pregunta int, @respuesta int, @EPS varchar(10)
as
insert into Datos_Encuestas(id_encuesta, codigo_EPS, valor, FechaCreacion) 
values(@pregunta, @EPS, @respuesta, getdate())

GO
