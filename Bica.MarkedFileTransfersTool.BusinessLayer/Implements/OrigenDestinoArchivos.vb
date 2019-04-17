Imports Bica.MarkedFileTransfersTool.DALayer

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

End Class