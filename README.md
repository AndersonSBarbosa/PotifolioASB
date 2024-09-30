# PotifolioASB

## Criar um Banco de Dados SQL Server

Ajustar a string de Conexão no arquivo  appsettings.json

    "ManagerAPISqlServer": "Data Source=MSSQL1;Password=@Aspcce86;Persist Security Info=True;User ID=sa;Initial Catalog=PotifolioASB;Data Source=DESKTOP-3IRH1LT; TrustServerCertificate=true; MultipleActiveResultSets=true"




### Script Criação da Tabela
USE [PotifolioASB]
GO


CREATE TABLE [Fluxo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NULL,
	[Entrada] [bit] DEFAULT ((1)) NULL,
	[ValorLancamento] [decimal](18, 2) NULL,
	[DataRegistro] [datetime] DEFAULT (getdate()) NULL,
	[DataAtualizacao] [datetime] NULL,
	[Ativo] [bit] DEFAULT ((1))  NULL,
 CONSTRAINT [PK_Fluxo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-----------------------------------------------------------------------------

CREATE TABLE [Ocorrencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NULL,
	[Conclusao] [varchar](500) NULL,
	[DataOcorrencia] [datetime] NULL,
	[ResponsavelAbertura] [int] NULL,
	[ResponsavelOcorrencia] [int] NULL,
	[FluxoId] [int] NULL,
	[DataRegistro] [datetime] NULL   DEFAULT (getdate()),
	[DataAtualizacao] [datetime] NULL,
	[Ativo] [bit] NULL CONSTRAINT [DF_Fluxo_DataRegistro]  DEFAULT (1),
 CONSTRAINT [PK_Ocorrencia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

----------------------------------------------------------------------------------

CREATE TABLE [Responsavel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Telefone] [varchar](12) NULL,
	[Endereco] [varchar](150) NULL,
	[CPF] [varchar](11) NULL,
	[DataRegistro] [datetime] NULL  DEFAULT (getdate()),
	[DataAtualizacao] [datetime] NULL,
	[Ativo] [bit] NULL   DEFAULT (1),
 CONSTRAINT [PK_Responsavel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO