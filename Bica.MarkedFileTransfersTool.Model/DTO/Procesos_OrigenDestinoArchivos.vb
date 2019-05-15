Public Class Procesos_OrigenDestinoArchivos

    Public Property Id As Long
    Public Property NumeroProceso As Long
    Public Property Procesos_TipoDireccionArchivoId As Long
    Public Property UbicacionDesde As String
    Public Property NombreProceso As String
    Public Property UbicacionDestino As String
    Public Property UbicacionNTFTPImportar As String
    Public Property UbicacionNTFTPEnviar As String
    Public Property UbicacionNTFTPRecibir As String
    Public Property UbicacionProcesado As String
    Public Property FechaCreacion As DateTime
    Public Property FechaModificacion As DateTime?
    Public Property Eliminado As Boolean?
    Public Property UsuarioCreacion As String
    Public Property UsuarioModificacion As String
End Class
