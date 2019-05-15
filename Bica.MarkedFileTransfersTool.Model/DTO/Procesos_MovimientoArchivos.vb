
Public Class Procesos_MovimientoArchivos
    Public Property Id As Long
    Public Property Procesos_OrigenDestinoArchivosId As Long
    Public Property NombreArchivo As String
    Public Property FechaPresentacion As DateTime
    Public Property IdArchivo As Long?
    Public Property Transferido As Boolean
    Public Property ParaTransferir As Boolean
    Public Property HacerBackup As Boolean
    Public Property Copiado As Boolean
    Public Property Procesado As Boolean
    Public Property Recibido As Boolean
    Public Property FechaCreacion As DateTime
    Public Property FechaModificacion As DateTime?
    Public Property Eliminado As Boolean?
    Public Property UsuarioCreacion As String
    Public Property UsuarioModificacion As String


    Public ReadOnly Property CustomParaTransferirCopiado() As Boolean
        Get
            Return Me.ParaTransferir Or Me.Copiado
        End Get
    End Property
End Class
