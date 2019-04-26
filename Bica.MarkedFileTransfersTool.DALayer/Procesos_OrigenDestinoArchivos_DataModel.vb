
Public Class Procesos_OrigenDestinoArchivos_DataModel
    Private registro As Procesos_OrigenDestinoArchivos

    ''' <summary>
    ''' Obtener configuración de un proceso para transferencia de archivos
    ''' </summary>
    ''' <param name="IdProceso"></param>
    ''' <returns></returns>
    Public Function ObtenerOrigenDestinoArchivos(IdProceso As Long) As Model.Procesos_OrigenDestinoArchivos
        Using resource As New B_BancaElecEntities()
            registro = (From f In resource.Procesos_OrigenDestinoArchivos Where f.PROCESSNR = IdProceso And f.DELETED <> 0).FirstOrDefault()
            Return Map(registro)
        End Using
    End Function

    ''' <summary>
    ''' Obtener información de los procesos según el típo. De envío o recepción
    ''' </summary>
    ''' <param name="TipoProcesoNombre"></param>
    ''' <returns></returns>
    Public Function ObtenerOrigenDestinoArchivosPorTipo(TipoProcesoNombre As String) As List(Of Model.Procesos_OrigenDestinoArchivos)
        Using resource As New B_BancaElecEntities()

            Dim registros = (From f In resource.Procesos_OrigenDestinoArchivos Where f.Procesos_TipoDireccionArchivo.NAME = TipoProcesoNombre And f.DELETED <> 0 Select f).ToList()

            'cargamos lista de resultados
            Dim lista As List(Of Model.Procesos_OrigenDestinoArchivos) = New List(Of Model.Procesos_OrigenDestinoArchivos)
            For Each item As Procesos_OrigenDestinoArchivos In registros
                lista.Add(Map(item))
            Next
            Return lista
        End Using
    End Function

#Region "Métodos Privados"

    ''' <summary>
    ''' Mapea objeto de base de datos a una entidad de clase de negocios
    ''' </summary>
    ''' <param name="registro"></param>
    ''' <returns></returns>
    Private Shared Function Map(registro As Procesos_OrigenDestinoArchivos) As Model.Procesos_OrigenDestinoArchivos
        If registro Is Nothing Then
            Return Nothing
        End If

        Dim retorno As New Model.Procesos_OrigenDestinoArchivos()
        retorno.Created_Date = registro.CREATED_DATE
        retorno.Id = registro.ID
        retorno.Procesos_TipoDireccionArchivoId = registro.Procesos_TipoDireccionArchivoId
        retorno.Updated_Date = registro.MODIFIED_DATE
        retorno.Modified_User_Id = registro.MODIFIED_USER_ID
        retorno.PathFrom = registro.PATH_FROM
        retorno.PathInport = registro.PATH_NTFTP_INPORT
        retorno.PathTo = registro.PATH_TO
        retorno.PathSend = registro.PATH_NTFTP_SEND
        retorno.PathRecibed = registro.PATH_NTFTP_RECIBED
        retorno.ProcessNr = registro.PROCESSNR
        retorno.Created_User_Name = registro.CREATED_USER_NAME
        retorno.Modified_User_Name = registro.MODIFIED_USER_NAME
        Return retorno
    End Function

#End Region
End Class
