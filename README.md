# PotifolioASB

## Criar um Banco de Dados SQL Server

Ajustar a string de Conexão no arquivo  appsettings.json

    "ManagerAPISqlServer": "Data Source=MSSQL1;Password=@Aspcce86;Persist Security Info=True;User ID=sa;Initial Catalog=PotifolioASB;Data Source=DESKTOP-3IRH1LT; TrustServerCertificate=true; MultipleActiveResultSets=true"




### Script Criacção da Tabela
USE [PotifolioASB]
GO

/****** Object:  Table [dbo].[Fluxo]    Script Date: 05/09/2024 15:39:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Fluxo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NULL,
	[Entrada] [bit] NULL CONSTRAINT [DF_Fluxo_Entrada]  DEFAULT ((1)),
	[ValorLancamento] [decimal](18, 2) NULL,
	[DataRegistro] [datetime] NULL CONSTRAINT [DF_Fluxo_DataRegistro]  DEFAULT (getdate()),
 CONSTRAINT [PK_Fluxo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]