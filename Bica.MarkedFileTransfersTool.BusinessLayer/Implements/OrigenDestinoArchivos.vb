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
        'Using resource As New Object

        'End Using

        'If Constants.BCO_Envio_Debito_Directo_Code = 10 Then Throw New Exception()

        'Return New List(Of Procesos_OrigenDestinoArchivos)()


    End Function
End Class