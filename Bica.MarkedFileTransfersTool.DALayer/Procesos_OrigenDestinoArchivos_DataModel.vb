
Public Class Procesos_OrigenDestinoArchivos_DataModel
    Private registro As Procesos_OrigenDestinoArchivos

    ''' <summary>
    ''' Obtener configuración de un proceso para transferencia de archivos
    ''' </summary>
    ''' <param name="IdProceso"></param>
    ''' <returns></returns>
    Public Function ObtenerOrigenDestinoArchivos(IdProceso As Long) As Model.Procesos_OrigenDestinoArchivos
        Using resource As New B_BancaElecEntities()
            registro = (From f In resource.Procesos_OrigenDestinoArchivos Where f.NumeroProceso = IdProceso And f.Eliminado = False).FirstOrDefault()
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

            Dim registros = (From f In resource.Procesos_OrigenDestinoArchivos Where f.Procesos_TipoDireccionArchivo.Nombre = TipoProcesoNombre And f.Eliminado = False Select f).ToList()

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
        retorno.FechaCreacion = registro.FechaCreacion
        retorno.Id = registro.Id
        retorno.ProcessName = registro.NombreProceso
        retorno.Procesos_TipoDireccionArchivoId = registro.Procesos_TipoDireccionArchivoId
        retorno.Updated_Date = registro.FechaModificacion
        retorno.PathFrom = registro.UbicacionDesde
        retorno.PathInport = registro.UbicacionNTFTPImportar
        retorno.PathTo = registro.UbicacionDestino
        retorno.PathSend = registro.UbicacionNTFTPEnviar
        retorno.PathRecibed = registro.UbicacionNTFTPRecibir
        retorno.PathProcessed = registro.UbicacionProcesado
        retorno.ProcessNr = registro.NumeroProceso
        retorno.UsuarioCreacion = registro.UsuarioCreacion
        retorno.UsuarioModificacion = registro.UsuarioModificacion
        Return retorno
    End Function

#End Region
End Class
