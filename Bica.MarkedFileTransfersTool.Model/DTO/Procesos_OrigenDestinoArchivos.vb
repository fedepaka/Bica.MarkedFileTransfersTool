Public Class Procesos_OrigenDestinoArchivos

    Public Property Id As Long
    Public Property ProcessNr As Long
    Public Property Procesos_TipoDireccionArchivoId As Long
    Public Property PathFrom As String
    Public Property PathTo As String
    Public Property PathInport As String
    Public Property PathSend As String
    Public Property PathRecibed As String
    Public Property Created_User_Id As Long
    Public Property Modified_User_Id As Long?
    Public Property Created_Date As DateTime
    Public Property Updated_Date As DateTime?
    Public Property Deleted As Boolean?
    Public Property Created_User_Name As String
    Public Property Modified_User_Name As String
End Class
