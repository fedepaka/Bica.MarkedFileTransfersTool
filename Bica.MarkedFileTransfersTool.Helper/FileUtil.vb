Imports System.IO

Public Class FileUtil
    Public Shared Function GetValue() As String
        'My code
        Return ""
    End Function

    ''' <summary>
    ''' Determina si existe un archivo en una ruta específica
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    Public Shared Function ExisteArchivo(path As String) As Boolean

        If String.IsNullOrEmpty(path.Trim()) Then
            Return False
        End If
        Return File.Exists(path)

    End Function
End Class
