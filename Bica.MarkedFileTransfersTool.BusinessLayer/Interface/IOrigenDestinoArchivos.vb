Imports Bica.MarkedFileTransfersTool.Model
Public Interface IOrigenDestinoArchivos
    Function ObtenerOrigenDestinoArchivos(numeroProceso As Long) As Procesos_OrigenDestinoArchivos
    Function ObtenerOrigenDestinoArchivosPorTipo(TipoProcesoNombre As String) As List(Of Procesos_OrigenDestinoArchivos)
    Function ObtenerOrigenDestinoArchivosPorEnviar() As List(Of Procesos_OrigenDestinoArchivos)
    Function ObtenerOrigenDestinoArchivosPorRecibir() As List(Of Procesos_OrigenDestinoArchivos)
End Interface

