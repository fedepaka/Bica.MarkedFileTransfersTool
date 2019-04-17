--[Procesos_OrigenDestinoArchivos]

CREATE TABLE [Procesos_OrigenDestinoArchivos] (
[ID] [bigint] IDENTITY(1,1) NOT NULL,
[PROCESSNR] int NULL,
[PATHFROM] nvarchar(3000) NULL,
[PATHTO] nvarchar(3000) NULL,
[CREATED_USER_ID] [bigint] NULL,
[MODIFIED_USER_ID] [bigint] NULL,
[CREATED_DATE] [datetime] NOT NULL,
[MODIFIED_DATE] [datetime] NULL,
[DELETED] [bit] NULL,
 CONSTRAINT [PK_Procesos_OrigenDestinoArchivos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] 

GO

ALTER TABLE [dbo].[Procesos_OrigenDestinoArchivos] ADD  CONSTRAINT [DF_Procesos_OrigenDestinoArchivos_CREATED_DATE]  DEFAULT (getdate()) FOR [CREATED_DATE]
GO

ALTER TABLE [dbo].[Procesos_OrigenDestinoArchivos]  ADD CONSTRAINT UK_PROCESSNR UNIQUE (PROCESSNR);   
GO  

--Insert data [Procesos_OrigenDestinoArchivos]
-- 354 - BCO - Envio Debito Directo
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (PROCESSNR, PATHFROM, PATHTO, CREATED_USER_ID) VALUES (354, '\\FILESERVER\EntExt\Provincanje\aProvincanje\Debitos', '\\BBPROCESO2\COELSA\BICA\Importado', 1);
GO
--fin [Procesos_OrigenDestinoArchivos]

-- [Procesos_MovimientoArchivos]

CREATE TABLE [dbo].[Procesos_MovimientoArchivos](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Procesos_OrigenDestinoArchivosId] [bigint] NOT NULL,
	[FILENAME] [nvarchar](255) NULL,
	[PRESENTATION_DATE] [datetime] NOT NULL,
	[ID_FILE] [bigint] NOT NULL,
	[TRANSFERRED] [bit] NULL,
	[DOBACKUP] [bit] NULL,
	[CREATED_USER_ID] [bigint] NULL,
	[MODIFIED_USER_ID] [bigint] NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[DELETED] [bit] NULL,
PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Procesos_MovimientoArchivos] ADD  DEFAULT ((0)) FOR [TRANSFERRED]
GO

ALTER TABLE [dbo].[Procesos_MovimientoArchivos] ADD  DEFAULT ((0)) FOR [DOBACKUP]
GO

ALTER TABLE [dbo].[Procesos_MovimientoArchivos] ADD  DEFAULT (getdate()) FOR [CREATED_DATE]
GO

ALTER TABLE [dbo].[Procesos_MovimientoArchivos] ADD CONSTRAINT FK_Procesos_MovimientoArchivos_OrigenDestinoArchivos FOREIGN KEY (Procesos_OrigenDestinoArchivosId) REFERENCES Procesos_OrigenDestinoArchivos (ID)    
GO  


---
INSERT INTO dbo.Procesos_MovimientoArchivos
(Procesos_OrigenDestinoArchivosId, FILENAME, PRESENTATION_DATE, ID_FILE, CREATED_USER_ID) 
VALUES (1, 'ARCHIVO1', GETDATE()-1, 1, 1);

INSERT INTO dbo.Procesos_MovimientoArchivos
(Procesos_OrigenDestinoArchivosId, FILENAME, PRESENTATION_DATE, ID_FILE, CREATED_USER_ID) 
VALUES (1, 'ARCHIVO2', GETDATE(), 2, 1);

INSERT INTO dbo.Procesos_MovimientoArchivos
(Procesos_OrigenDestinoArchivosId, FILENAME, PRESENTATION_DATE, ID_FILE, CREATED_USER_ID) 
VALUES (1, 'ARCHIVO3', GETDATE()+1, 3, 1);