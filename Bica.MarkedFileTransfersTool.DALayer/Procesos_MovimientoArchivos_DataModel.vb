﻿Imports System.Data.Entity

Public Class Procesos_MovimientoArchivos_DataModel

    ''' <summary>
    ''' Obtiene información de los Archivos que fueron generados/enviados a COELSA para un proceso particular en una fecha particular
    ''' </summary>
    ''' <param name="IdProceso">Identificador de proceso referente a los archivos. (No es el nro de proceso)</param>
    ''' <param name="fecha">Fecha de ejecución del proceso que se está consultando</param>
    ''' <returns></returns>
    Public Function ObtenerMovimientosArchivos(IdProceso As Long, fecha As Date) As List(Of Model.Procesos_MovimientoArchivos)
        Dim registros As List(Of Procesos_MovimientoArchivos)

        Using resource As New B_BancaElecEntities()
            registros = (From f In resource.Procesos_MovimientoArchivos
                         Where f.Procesos_OrigenDestinoArchivosId = IdProceso And
                             DbFunctions.TruncateTime(f.PRESENTATION_DATE) = fecha.Date And f.DELETED <> 0).ToList()

            'cargamos lista de resultados
            Dim lista As List(Of Model.Procesos_MovimientoArchivos) = New List(Of Model.Procesos_MovimientoArchivos)
            For Each item As Procesos_MovimientoArchivos In registros
                lista.Add(Map(item))
            Next

            Return lista
        End Using
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IdProceso"></param>
    ''' <param name="fecha"></param>
    ''' <returns></returns>
    Public Function ObtenerMovimientoArchivosPendientesEnviar(IdProceso As Long, fecha As Date) As List(Of Model.Procesos_MovimientoArchivos)
        Dim registros As List(Of Procesos_MovimientoArchivos)

        Using resource As New B_BancaElecEntities()
            registros = (From f In resource.Procesos_MovimientoArchivos
                         Where f.Procesos_OrigenDestinoArchivosId = IdProceso And
                             DbFunctions.TruncateTime(f.PRESENTATION_DATE) = fecha.Date And
                             f.TO_BE_TRANSFER = True And
                             f.TRANSFERRED = 0 And
                             f.DELETED <> 0 Select f).ToList()

            'cargamos lista de resultados
            Dim lista As List(Of Model.Procesos_MovimientoArchivos) = New List(Of Model.Procesos_MovimientoArchivos)
            For Each item As Procesos_MovimientoArchivos In registros
                lista.Add(Map(item))
            Next

            Return lista
        End Using
    End Function

    ''' <summary>
    ''' Obtiene los registros de archivos que fueron recibidos 
    ''' </summary>
    ''' <param name="IdProceso"></param>
    ''' <param name="fecha"></param>
    ''' <returns></returns>
    Public Function ObtenerMovimientoArchivosPendientesRecibir(IdProceso As Long, fecha As Date) As List(Of Model.Procesos_MovimientoArchivos)
        Return ObtenerMovimientoArchivosPendientesEnviar(IdProceso, fecha)
    End Function

    Public Function ObtenerMovimientoArchivosCopiadosNTFTP(IdProceso As Long, fecha As Date) As List(Of Model.Procesos_MovimientoArchivos)
        Dim registros As List(Of Procesos_MovimientoArchivos)

        Using resource As New B_BancaElecEntities()
            registros = (From f In resource.Procesos_MovimientoArchivos
                         Where f.Procesos_OrigenDestinoArchivosId = IdProceso And
                             DbFunctions.TruncateTime(f.PRESENTATION_DATE) = fecha.Date And
                             f.TO_BE_TRANSFER = 0 And
                             f.TRANSFERRED = 0 And
                             f.COPIED = True And
                             f.DELETED <> 0).ToList()

            'cargamos lista de resultados
            Dim lista As List(Of Model.Procesos_MovimientoArchivos) = New List(Of Model.Procesos_MovimientoArchivos)
            For Each item As Procesos_MovimientoArchivos In registros
                lista.Add(Map(item))
            Next

            Return lista
        End Using
    End Function

    ''' <summary>
    ''' Obtiene datos de un registro por nombre de archivo
    ''' </summary>
    ''' <param name="nombre"></param>
    ''' <returns></returns>
    Public Function ObtenerMovimientoArchivoPorNombre(nombre As String) As Model.Procesos_MovimientoArchivos
        Dim registro As Procesos_MovimientoArchivos

        Using resource As New B_BancaElecEntities()
            registro = (From f In resource.Procesos_MovimientoArchivos
                        Where f.FILENAME.ToLower() = nombre.ToLower() And f.DELETED <> 0).FirstOrDefault()

            Return Map(registro)
        End Using
    End Function

    Public Function ObtenerMovimientoArchivoPorId(Id As Long) As Model.Procesos_MovimientoArchivos
        Dim registro As Procesos_MovimientoArchivos

        Using resource As New B_BancaElecEntities()
            registro = (From f In resource.Procesos_MovimientoArchivos
                        Where f.ID = Id And f.DELETED <> 0).FirstOrDefault()

            Return Map(registro)
        End Using
    End Function

    ''' <summary>
    ''' Guardar nuevo registro de archivo que será luego enviado al NTFTP
    ''' </summary>
    ''' <param name="IdProcesoOrigen">Id del proceso al que corresponda el archivo</param>
    ''' <param name="NombreArchivo">Nombre del archivo</param>
    ''' <param name="FechaPresentacion">Fecha en la que será presentado el archivo</param>
    ''' <param name="IdArchivo">Identificador del archivo interno a BICA</param>
    ''' <param name="IdUsuarioCreacion">Identifiador del usuario que ejecuta el evento</param>
    ''' <returns></returns>
    Public Function InsertarRegistroMovimientoArchivo(IdProcesoOrigen As Long, NombreArchivo As String, FechaPresentacion As Date, IdArchivo As Long, UserName As String) As Long
        Dim idREgistro As Long = 0
        Dim objMovArchivos As Procesos_MovimientoArchivos
        Using resource As New B_BancaElecEntities()
            objMovArchivos = New Procesos_MovimientoArchivos()
            objMovArchivos.Procesos_OrigenDestinoArchivosId = IdProcesoOrigen
            objMovArchivos.FILENAME = NombreArchivo
            objMovArchivos.PRESENTATION_DATE = FechaPresentacion
            objMovArchivos.ID_FILE = IdArchivo
            objMovArchivos.CREATED_USER_NAME = UserName
            resource.Procesos_MovimientoArchivos.Add(objMovArchivos)
            resource.SaveChanges()
            idREgistro = objMovArchivos.ID

        End Using
        Return idREgistro
    End Function

    ''' <summary>
    ''' Actualizar registro de movimiento de archivo
    ''' </summary>
    ''' <param name="IdMovimientoArchivo"></param>
    ''' <param name="Transferred"></param>
    ''' <param name="DoBackup"></param>
    ''' <param name="IdUpdatedUser"></param>
    ''' <returns></returns>
    Public Function ActualizarRegistroMovimientoArchivo(IdMovimientoArchivo As Long, Transferred As Boolean, DoBackup As Boolean, ToBeTransfer As Boolean, Copied As Boolean, UpdatedUserName As String) As Long
        Using resource = New B_BancaElecEntities()

            Dim objMovArchivos = (From f In resource.Procesos_MovimientoArchivos
                                  Where f.ID = IdMovimientoArchivo And f.DELETED <> 0 Select f).FirstOrDefault()

            If objMovArchivos IsNot Nothing Then
                objMovArchivos.MODIFIED_DATE = DateTime.Now
                objMovArchivos.DOBACKUP = DoBackup
                objMovArchivos.TRANSFERRED = Transferred
                objMovArchivos.TO_BE_TRANSFER = ToBeTransfer
                objMovArchivos.COPIED = Copied
                objMovArchivos.MODIFIED_USER_NAME = UpdatedUserName
                If resource.SaveChanges() > 0 Then
                    Return 1
                End If
            End If
        End Using

        Return 0
    End Function

#Region "Métodos Privados"

    ''' <summary>
    ''' Mapea objeto de base de datos a una entidad de clase de negocios
    ''' </summary>
    ''' <param name="registro"></param>
    ''' <returns></returns>
    Private Shared Function Map(registro As Procesos_MovimientoArchivos) As Model.Procesos_MovimientoArchivos
        If registro Is Nothing Then
            Return Nothing
        End If

        Dim retorno As New Model.Procesos_MovimientoArchivos()
        retorno.Created_Date = registro.CREATED_DATE
        retorno.DoBackup = If(registro.DOBACKUP Is Nothing, False, registro.DOBACKUP)
        retorno.FileName = If(registro.FILENAME Is Nothing, String.Empty, registro.FILENAME)
        retorno.Id = registro.ID
        retorno.Modified_Date = registro.MODIFIED_DATE
        retorno.Modified_User_Id = registro.MODIFIED_USER_ID
        retorno.Procesos_OrigenDestinoArchivosId = registro.Procesos_OrigenDestinoArchivosId
        retorno.Transferred = If(registro.TRANSFERRED Is Nothing, False, registro.TRANSFERRED)
        retorno.ToBeTransfer = If(registro.TO_BE_TRANSFER Is Nothing, False, registro.TO_BE_TRANSFER)
        retorno.Copied = If(registro.COPIED Is Nothing, False, registro.COPIED)
        retorno.Id_File = registro.ID_FILE
        retorno.Presentation_Date = registro.PRESENTATION_DATE
        retorno.Created_User_Name = registro.CREATED_USER_NAME
        retorno.Modified_User_Name = registro.MODIFIED_USER_NAME
        Return retorno
    End Function

#End Region
End Class
