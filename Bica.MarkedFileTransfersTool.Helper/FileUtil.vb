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

    ''' <summary>
    ''' Extrae el nombre de un archivo desde el fullpath
    ''' </summary>
    ''' <param name="fullPath"></param>
    ''' <returns></returns>
    Public Shared Function ExtraerNombreArchivo(fullPath As String) As String
        If String.IsNullOrEmpty(fullPath.Trim()) Then
            Return String.Empty
        End If

        Dim arrString = fullPath.Split("\")
        If arrString.Length > 0 Then
            Return arrString.GetValue(arrString.Length - 1)
        Else
            Return String.Empty
        End If
    End Function
End Class
