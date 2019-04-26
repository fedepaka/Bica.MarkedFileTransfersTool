Imports Bica.MarkedFileTransfersTool.BusinessLayer
Imports Bica.MarkedFileTransfersTool.DALayer
Imports Bica.MarkedFileTransfersTool.Model

Public Class OrigenDestinoArchivos
    Implements IOrigenDestinoArchivos

    Private _daOrigenDestinoArchivos As Procesos_OrigenDestinoArchivos_DataModel
    ''' <summary>
    ''' Obtiene las rutas de origen y destino para el proceso de transferencia de archivos
    ''' </summary>
    ''' <returns></returns>
    Public Function ObtenerOrigenDestinoArchivos(numeroProceso As Long) As Model.Procesos_OrigenDestinoArchivos Implements IOrigenDestinoArchivos.ObtenerOrigenDestinoArchivos

        _daOrigenDestinoArchivos = New Procesos_OrigenDestinoArchivos_DataModel()

        Return _daOrigenDestinoArchivos.ObtenerOrigenDestinoArchivos(numeroProceso)

    End Function

    Public Function CargaDatosProcesos(fecha As Date) As Boolean
        Return True
    End Function

    Public Function ObtenerOrigenDestinoArchivosPorTipo(TipoProcesoNombre As String) As List(Of Model.Procesos_OrigenDestinoArchivos) Implements IOrigenDestinoArchivos.ObtenerOrigenDestinoArchivosPorTipo
        _daOrigenDestinoArchivos = New Procesos_OrigenDestinoArchivos_DataModel()
        Return _daOrigenDestinoArchivos.ObtenerOrigenDestinoArchivosPorTipo(TipoProcesoNombre)
    End Function
    Public Function ObtenerOrigenDestinoArchivosPorEnviar() As List(Of Model.Procesos_OrigenDestinoArchivos) Implements IOrigenDestinoArchivos.ObtenerOrigenDestinoArchivosPorEnviar
        Return ObtenerOrigenDestinoArchivosPorTipo(Constants.Procesos_TipoDireccionArchivo_ENVIO)
    End Function

    Public Function ObtenerOrigenDestinoArchivosPorRecibir() As List(Of Model.Procesos_OrigenDestinoArchivos) Implements IOrigenDestinoArchivos.ObtenerOrigenDestinoArchivosPorRecibir
        Return ObtenerOrigenDestinoArchivosPorTipo(Constants.Procesos_TipoDireccionArchivo_RECEPCION)
    End Function


End Class