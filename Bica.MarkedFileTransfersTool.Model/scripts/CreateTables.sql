--[Procesos_OrigenDestinoArchivos]

CREATE TABLE [Procesos_OrigenDestinoArchivos] (
[ID] [bigint] IDENTITY(1,1) NOT NULL,
[PROCESSNR] int NULL,
[PATH_FROM] nvarchar(3000) NULL,
[PATH_NTFTP_INPORT] nvarchar(3000) NULL,
[PATH_NTFTP_SEND] nvarchar(3000) NULL,
[PATH_NTFTP_RECIBED] nvarchar(3000) NULL,
[PATH_TO] nvarchar(3000) NULL,
[CREATED_USER_ID] [bigint] NULL,
[CREATED_USER_NAME] nvarchar(50) NULL,
[MODIFIED_USER_ID] [bigint] NULL,
[MODIFIED_USER_NAME] nvarchar(50) NULL,
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
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (PROCESSNR, PATH_FROM, PATH_NTFTP_INPORT, PATH_NTFTP_SEND, PATH_NTFTP_RECIBED, PATH_TO, CREATED_USER_NAME) VALUES (354, '\\FILESERVER\EntExt\Provincanje\aProvincanje\Debitos', '\\BBPROCESO2\Coelsa\Bica\Importado', '\\BBPROCESO2\Coelsa\Bica\Enviado', '\\BBPROCESO2\Coelsa\Bica\Recibido', '\\FILESERVER\EntExt\Provincanje\alBanco\Debitos', 'arey');
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (PROCESSNR, PATH_FROM, PATH_NTFTP_INPORT, PATH_NTFTP_SEND, PATH_NTFTP_RECIBED, PATH_TO, CREATED_USER_NAME) VALUES (354, '\\HP\fileserver\EntExt\Provincanje\aProvincanje1\Debitos', '\\HP\BBPROCESO2\Coelsa\Bica\Importado', '\\HP\BBPROCESO2\Coelsa\Bica\Enviado', '\\HP\BBPROCESO2\Coelsa\Bica\Recibido', '\\HP\FILESERVER\EntExt\Provincanje\alBanco\Debitos', 'arey');
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
	[TO_BE_TRANSFER] [bit] NULL,
	[COPIED] [bit] NULL,
	[CREATED_USER_ID] [bigint] NULL,
	[CREATED_USER_NAME] nvarchar(50) NULL,
	[MODIFIED_USER_ID] [bigint] NULL,
	[MODIFIED_USER_NAME] nvarchar(50) NULL,
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

ALTER TABLE [dbo].[Procesos_MovimientoArchivos] ADD  DEFAULT ((0)) FOR [TO_BE_TRANSFER]
GO

ALTER TABLE [dbo].[Procesos_MovimientoArchivos] ADD  DEFAULT ((0)) FOR [COPIED]
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