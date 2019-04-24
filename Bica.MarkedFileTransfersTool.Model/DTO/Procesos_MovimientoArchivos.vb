
Public Class Procesos_MovimientoArchivos
    Public Property Id As Long
    Public Property Procesos_OrigenDestinoArchivosId As Long
    Public Property FileName As String
    Public Property Presentation_Date As DateTime
    Public Property Id_File As Long
    Public Property Transferred As Boolean
    Public Property ToBeTransfer As Boolean
    Public Property DoBackup As Boolean
    Public Property Copied As Boolean
    Public Property Created_User_Id As Long
    Public Property Modified_User_Id As Long?
    Public Property Created_Date As DateTime
    Public Property Modified_Date As DateTime?
    Public Property Deleted As Boolean?

    Public Property Created_User_Name As String
    Public Property Modified_User_Name As String
End Class
