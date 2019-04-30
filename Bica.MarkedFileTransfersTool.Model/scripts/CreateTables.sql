--Tipo Dirección Archivo
CREATE TABLE [dbo].[Procesos_TipoDireccionArchivo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](255) NULL,
	[Descripcion] [nvarchar](255) NULL,
	[UsuarioCreacion] nvarchar(25) NULL,
    [FechaCreacion] [datetime] NOT NULL,
	[UsuarioModificacion] nvarchar(25) NULL,
	[FechaModificacion] [datetime] NULL,
	[Eliminado] [bit] NULL,
PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Procesos_TipoDireccionArchivo] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Procesos_TipoDireccionArchivo] ADD  DEFAULT ((0)) FOR [Eliminado]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_TipoDireccionArchivo', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre dirección del archivo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_TipoDireccionArchivo', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Descripción de dirección del archivo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_TipoDireccionArchivo', @level2type=N'COLUMN',@level2name=N'Descripcion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del usuario que lo creó' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_TipoDireccionArchivo', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del usuario que modificó' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_TipoDireccionArchivo', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_TipoDireccionArchivo', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de modificación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_TipoDireccionArchivo', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Marca eliminado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_TipoDireccionArchivo', @level2type=N'COLUMN',@level2name=N'Eliminado'
GO

INSERT INTO [dbo].[Procesos_TipoDireccionArchivo] (Nombre, Descripcion, UsuarioCreacion) VALUES ('Entidad-Coelsa', 'Indica la dirección del archivo desde Bica a COELSA', 'aRey');
INSERT INTO [dbo].[Procesos_TipoDireccionArchivo] (Nombre, Descripcion, UsuarioCreacion) VALUES ('Coelsa-Entidad', 'Indica la dirección del archivo desde COELSA a la Entidad', 'aRey');
-- fin Tipo Dirección archivo

--[Procesos_OrigenDestinoArchivos]

CREATE TABLE [Procesos_OrigenDestinoArchivos] (
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NumeroProceso] int NULL,
	[Procesos_TipoDireccionArchivoId] [bigint] NOT NULL,
	[UbicacionDesde]  nvarchar(3000) NULL, --[PATH_FROM]
	[UbicacionNTFTPImportar] nvarchar(3000) NULL,--[PATH_NTFTP_INPORT] nvarchar(3000) NULL,
	[UbicacionNTFTPEnviar] nvarchar(3000) NULL,--[PATH_NTFTP_SEND] nvarchar(3000) NULL,
	[UbicacionNTFTPRecibir] nvarchar(3000) NULL,--[PATH_NTFTP_RECIBED] nvarchar(3000) NULL,
	[UbicacionDestino] nvarchar(3000) NULL,--[PATH_TO] nvarchar(3000) NULL,
	[UbicacionProcesado] nvarchar(3000) NULL,
	[UsuarioCreacion] nvarchar(25) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioModificacion] nvarchar(25) NULL,
	[FechaModificacion] [datetime] NULL,
	[Eliminado] [bit] NULL,
 CONSTRAINT [PK_Procesos_OrigenDestinoArchivos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] 

GO

ALTER TABLE [dbo].[Procesos_OrigenDestinoArchivos] ADD  CONSTRAINT [DF_Procesos_OrigenDestinoArchivos_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Procesos_OrigenDestinoArchivos] ADD  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [dbo].[Procesos_OrigenDestinoArchivos]  ADD CONSTRAINT UK_NumeroProceso UNIQUE (NumeroProceso);   
GO  
ALTER TABLE [dbo].[Procesos_OrigenDestinoArchivos] ADD CONSTRAINT FK_Procesos_OrigenDestinoArchivos_TipoDireccionArchivo FOREIGN KEY (Procesos_TipoDireccionArchivoId) REFERENCES Procesos_TipoDireccionArchivo (Id)    
GO  

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador unico del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_OrigenDestinoArchivos', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Numero de proceso. Hace referencia al campo Proceso de la tabla B_General.dbo.Gen_Procesos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_OrigenDestinoArchivos', @level2type=N'COLUMN',@level2name=N'NumeroProceso'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ubicacion desde donde se toma el archivo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_OrigenDestinoArchivos', @level2type=N'COLUMN',@level2name=N'UbicacionDesde'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ubicación NTFTP Importar. Lugar donde dejamos el archivo desde Bica, para que lo procese la central.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_OrigenDestinoArchivos', @level2type=N'COLUMN',@level2name=N'UbicacionNTFTPImportar'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ubicación NTFTP Enviar. Lugar de destino final del archivo. Ubicación de control para Bica.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_OrigenDestinoArchivos', @level2type=N'COLUMN',@level2name=N'UbicacionNTFTPEnviar'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ubicacion NTFTP Recibir. Ubicación desde donde tomar archivos desde la central para Bica.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_OrigenDestinoArchivos', @level2type=N'COLUMN',@level2name=N'UbicacionNTFTPRecibir'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ubicacion donde se dejarán los archivos que se reciben para BICA' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_OrigenDestinoArchivos', @level2type=N'COLUMN',@level2name=N'UbicacionDestino'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ubicacion donde se dejarán los archivos procesados por BICA una vez recibido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_OrigenDestinoArchivos', @level2type=N'COLUMN',@level2name=N'UbicacionProcesado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del usuario que lo creó' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_OrigenDestinoArchivos', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del usuario que modificó' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_OrigenDestinoArchivos', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_OrigenDestinoArchivos', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de modificación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_OrigenDestinoArchivos', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Marca eliminado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_OrigenDestinoArchivos', @level2type=N'COLUMN',@level2name=N'Eliminado'
GO


--Insert data [Procesos_OrigenDestinoArchivos]
--PROD
/*
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (NumeroProceso, Procesos_TipoDireccionArchivoId, UbicacionDesde, UbicacionNTFTPImportar, UbicacionNTFTPEnviar, UbicacionNTFTPRecibir, UbicacionDestino, UbicacionProcesado, UsuarioCreacion) VALUES (354, 1, '\\FILESERVER\EntExt\Provincanje\aProvincanje1\Debitos', '\\BBPROCESO2\Coelsa\Bica\Importado', '\\BBPROCESO2\Coelsa\Bica\Enviado', null, null, null, 'arey');
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (NumeroProceso, Procesos_TipoDireccionArchivoId, UbicacionDesde, UbicacionNTFTPImportar, UbicacionNTFTPEnviar, UbicacionNTFTPRecibir, UbicacionDestino, UbicacionProcesado, UsuarioCreacion) VALUES (359, 1, '\\FILESERVER\EntExt\Provincanje\aProvincanje1\Debitos', '\\BBPROCESO2\Coelsa\Bica\Importado', '\\BBPROCESO2\Coelsa\Bica\Enviado', null, null, null, 'arey');
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (NumeroProceso, Procesos_TipoDireccionArchivoId, UbicacionDesde, UbicacionNTFTPImportar, UbicacionNTFTPEnviar, UbicacionNTFTPRecibir, UbicacionDestino, UbicacionProcesado, UsuarioCreacion) VALUES (355, 2, null, null, null, '\\BBPROCESO2\Coelsa\Bica\Recibido', '\\FILESERVER\EntExt\Provincanje\alBanco\Debitos', '\\FILESERVER\EntExt\Provincanje\alBanco\Debitos\Procesados', 'arey');
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (NumeroProceso, Procesos_TipoDireccionArchivoId, UbicacionDesde, UbicacionNTFTPImportar, UbicacionNTFTPEnviar, UbicacionNTFTPRecibir, UbicacionDestino, UbicacionProcesado, UsuarioCreacion) VALUES (363, 2, null, null, null, '\\BBPROCESO2\Coelsa\Bica\Recibido', '\\FILESERVER\EntExt\Provincanje\alBanco\Debitos', '\\FILESERVER\EntExt\Provincanje\alBanco\Debitos\Procesados', 'arey');
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (NumeroProceso, Procesos_TipoDireccionArchivoId, UbicacionDesde, UbicacionNTFTPImportar, UbicacionNTFTPEnviar, UbicacionNTFTPRecibir, UbicacionDestino, UbicacionProcesado, UsuarioCreacion) VALUES (364, 2, null, null, null, '\\BBPROCESO2\Coelsa\Bica\Recibido', '\\FILESERVER\EntExt\Provincanje\alBanco\Debitos', '\\FILESERVER\EntExt\Provincanje\alBanco\Debitos\Procesados', 'arey');
*/
--DEV
/*
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (NumeroProceso, Procesos_TipoDireccionArchivoId, UbicacionDesde, UbicacionNTFTPImportar, UbicacionNTFTPEnviar, UbicacionNTFTPRecibir, UbicacionDestino, UbicacionProcesado, UsuarioCreacion) VALUES (354, 1, '\\HP\FILESERVER\EntExt\Provincanje\aProvincanje1\Debitos', '\\HP\BBPROCESO2\Coelsa\Bica\Importado', '\\HP\BBPROCESO2\Coelsa\Bica\Enviado', null, null, null, 'arey');
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (NumeroProceso, Procesos_TipoDireccionArchivoId, UbicacionDesde, UbicacionNTFTPImportar, UbicacionNTFTPEnviar, UbicacionNTFTPRecibir, UbicacionDestino, UbicacionProcesado, UsuarioCreacion) VALUES (359, 1, '\\HP\FILESERVER\EntExt\Provincanje\aProvincanje1\Debitos', '\\HP\BBPROCESO2\Coelsa\Bica\Importado', '\\HP\BBPROCESO2\Coelsa\Bica\Enviado', null, null, null, 'arey');
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (NumeroProceso, Procesos_TipoDireccionArchivoId, UbicacionDesde, UbicacionNTFTPImportar, UbicacionNTFTPEnviar, UbicacionNTFTPRecibir, UbicacionDestino, UbicacionProcesado, UsuarioCreacion) VALUES (355, 2, null, null, null, '\\HP\BBPROCESO2\Coelsa\Bica\Recibido', '\\HP\FILESERVER\EntExt\Provincanje\alBanco\Debitos', '\\HP\FILESERVER\EntExt\Provincanje\alBanco\Debitos\Procesados', 'arey');
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (NumeroProceso, Procesos_TipoDireccionArchivoId, UbicacionDesde, UbicacionNTFTPImportar, UbicacionNTFTPEnviar, UbicacionNTFTPRecibir, UbicacionDestino, UbicacionProcesado, UsuarioCreacion) VALUES (363, 2, null, null, null, '\\HP\BBPROCESO2\Coelsa\Bica\Recibido', '\\HP\FILESERVER\EntExt\Provincanje\alBanco\Debitos', '\\HP\FILESERVER\EntExt\Provincanje\alBanco\Debitos\Procesados', 'arey');
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (NumeroProceso, Procesos_TipoDireccionArchivoId, UbicacionDesde, UbicacionNTFTPImportar, UbicacionNTFTPEnviar, UbicacionNTFTPRecibir, UbicacionDestino, UbicacionProcesado, UsuarioCreacion) VALUES (364, 2, null, null, null, '\\HP\BBPROCESO2\Coelsa\Bica\Recibido', '\\HP\FILESERVER\EntExt\Provincanje\alBanco\Debitos', '\\HP\FILESERVER\EntExt\Provincanje\alBanco\Debitos\Procesados', 'arey');
*/
--TESTING
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (NumeroProceso, Procesos_TipoDireccionArchivoId, UbicacionDesde, UbicacionNTFTPImportar, UbicacionNTFTPEnviar, UbicacionNTFTPRecibir, UbicacionDestino, UbicacionProcesado, UsuarioCreacion) VALUES (354, 1, '\\FILESERVER\EntExt\Provincanje\aProvincanje1\Debitos', '\\cctecn32\BBPROCESOS2_TEST\Coelsa\Bica\Importado', '\\cctecn32\BBPROCESOS2_TEST\Coelsa\Bica\Enviado', null, null, null, 'arey');
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (NumeroProceso, Procesos_TipoDireccionArchivoId, UbicacionDesde, UbicacionNTFTPImportar, UbicacionNTFTPEnviar, UbicacionNTFTPRecibir, UbicacionDestino, UbicacionProcesado, UsuarioCreacion) VALUES (359, 1, '\\FILESERVER\EntExt\Provincanje\aProvincanje1\Debitos', '\\cctecn32\BBPROCESOS2_TEST\Coelsa\Bica\Importado', '\\cctecn32\BBPROCESOS2_TEST\Coelsa\Bica\Enviado', null, null, null, 'arey');
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (NumeroProceso, Procesos_TipoDireccionArchivoId, UbicacionDesde, UbicacionNTFTPImportar, UbicacionNTFTPEnviar, UbicacionNTFTPRecibir, UbicacionDestino, UbicacionProcesado, UsuarioCreacion) VALUES (355, 2, null, null, null, '\\BBPROCESO2\Coelsa\Bica\Recibido', '\\FILESERVER\EntExt\Provincanje\alBanco\Debitos', '\\FILESERVER\EntExt\Provincanje\alBanco\Debitos\Procesados','arey');
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (NumeroProceso, Procesos_TipoDireccionArchivoId, UbicacionDesde, UbicacionNTFTPImportar, UbicacionNTFTPEnviar, UbicacionNTFTPRecibir, UbicacionDestino, UbicacionProcesado, UsuarioCreacion) VALUES (363, 2, null, null, null, '\\BBPROCESO2\Coelsa\Bica\Recibido', '\\FILESERVER\EntExt\Provincanje\alBanco\Debitos', '\\FILESERVER\EntExt\Provincanje\alBanco\Debitos\Procesados', 'arey');
INSERT INTO dbo.Procesos_OrigenDestinoArchivos (NumeroProceso, Procesos_TipoDireccionArchivoId, UbicacionDesde, UbicacionNTFTPImportar, UbicacionNTFTPEnviar, UbicacionNTFTPRecibir, UbicacionDestino, UbicacionProcesado, UsuarioCreacion) VALUES (364, 2, null, null, null, '\\BBPROCESO2\Coelsa\Bica\Recibido', '\\FILESERVER\EntExt\Provincanje\alBanco\Debitos', '\\FILESERVER\EntExt\Provincanje\alBanco\Debitos\Procesados', 'arey');

GO
--fin [Procesos_OrigenDestinoArchivos]


-- [Procesos_MovimientoArchivos]

CREATE TABLE [dbo].[Procesos_MovimientoArchivos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Procesos_OrigenDestinoArchivosId] [bigint] NOT NULL,
	[NombreArchivo] [nvarchar](255) NULL,
	[FechaPresentacion] [datetime] NOT NULL,
	[IdArchivo] [bigint] NULL,
	[Transferido] [bit] NOT NULL,
	[HacerBackup] [bit] NOT NULL,
	[ParaTransferir] [bit] NOT NULL,
	[Copiado] [bit] NOT NULL,
	[Recibido] [bit] NOT NULL, --INDICA SI EL ARCHIVO FUE RECIBIDO EN LAS CARPETAS DE LA ENTIDAD
	[Procesado] [bit] NOT NULL, --INDICA SI EL ARCHIVO FUE procesado por la grilla
	[UsuarioCreacion] nvarchar(25) NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[UsuarioModificacion] nvarchar(25) NULL,
	[FechaModificacion] [datetime] NULL,
	[Eliminado] [bit] NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Procesos_MovimientoArchivos] ADD  DEFAULT ((0)) FOR [Transferido]
GO
ALTER TABLE [dbo].[Procesos_MovimientoArchivos] ADD  DEFAULT ((0)) FOR [HacerBackup]
GO
ALTER TABLE [dbo].[Procesos_MovimientoArchivos] ADD  DEFAULT ((0)) FOR [ParaTransferir]
GO
ALTER TABLE [dbo].[Procesos_MovimientoArchivos] ADD  DEFAULT ((0)) FOR [Copiado]
GO
ALTER TABLE [dbo].[Procesos_MovimientoArchivos] ADD  DEFAULT ((0)) FOR [Recibido]
GO
ALTER TABLE [dbo].[Procesos_MovimientoArchivos] ADD  DEFAULT ((0)) FOR [Procesado]
GO
ALTER TABLE [dbo].[Procesos_MovimientoArchivos] ADD  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [dbo].[Procesos_MovimientoArchivos] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Procesos_MovimientoArchivos] ADD CONSTRAINT FK_Procesos_MovimientoArchivos_OrigenDestinoArchivos FOREIGN KEY (Procesos_OrigenDestinoArchivosId) REFERENCES Procesos_OrigenDestinoArchivos (Id)    
GO  

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador del archivo.  FK al campo Id de la tabla Procesos_OrigenDestinoArchivos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'Procesos_OrigenDestinoArchivosId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de archivo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'NombreArchivo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de presentación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'FechaPresentacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id de archivo. Numero interno. Corresponde al campo IdArchivo de la tabla B_general.dbo.Prov_DebitoDirecto' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'IdArchivo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Marca Transferido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'Transferido'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Marca hacer backup' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'HacerBackup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Marca para transferir' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'ParaTransferir'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Marca copiado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'Copiado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Marca recibido. Desde Coelsa a BICA' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'Recibido'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Marca procesado. Desde Bica a BICA' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'Procesado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del usuario que lo creó' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'UsuarioCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del usuario que modificó' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'UsuarioModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de modificación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'FechaModificacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Marca eliminado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Procesos_MovimientoArchivos', @level2type=N'COLUMN',@level2name=N'Eliminado'
GO