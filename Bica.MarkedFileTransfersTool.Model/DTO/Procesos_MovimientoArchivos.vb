
Public Class Procesos_MovimientoArchivos
    Public Property Id As Long
    Public Property Procesos_OrigenDestinoArchivosId As Long
    Public Property FileName As String
    Public Property Presentation_Date As DateTime
    Public Property Id_File As Long?
    Public Property Transferred As Boolean
    Public Property ToBeTransfer As Boolean
    Public Property DoBackup As Boolean
    Public Property Copied As Boolean
    Public Property Processed As Boolean
    Public Property FechaCreacion As DateTime
    Public Property FechaModificacion As DateTime?
    Public Property Deleted As Boolean?

    Public Property UsuarioCreacion As String
    Public Property UsuarioModificacion As String
End Class
