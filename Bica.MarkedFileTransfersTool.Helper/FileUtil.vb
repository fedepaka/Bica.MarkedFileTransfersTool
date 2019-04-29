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

    ''' <summary>
    ''' Copia un archivo de una ruta a otra
    ''' </summary>
    ''' <param name="rutaOrigen"></param>
    ''' <param name="rutaDestino"></param>
    ''' <returns></returns>
    Public Shared Function CopiarArchivo(rutaOrigen As String, rutaDestino As String) As Boolean
        If String.IsNullOrEmpty(rutaOrigen) Or String.IsNullOrEmpty(rutaDestino) Then
            Return False
        Else
            File.Copy(rutaOrigen, rutaDestino, True)
        End If
        Return True
    End Function

    ''' <summary>
    ''' Indica si existe un directorio físico
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    Public Shared Function ExisteDirectorio(path As String) As Boolean
        If String.IsNullOrEmpty(path) Then
            Return False
        Else
            Return Directory.Exists(path)
        End If
    End Function

    Public Shared Function FormatoArchivoRecepcionOrdenDebito(fecha As Date) As String
        Return String.Format("{0}{1}.{2}", "PP0", fecha.Day, ".426")
    End Function

    Public Shared Function FormatoArchivoRecepcionRechazo(fecha As Date) As String
        Return String.Format("{0}{1}.{2}", "PR0", fecha.Day, ".426")
    End Function

    Public Shared Function FormatoArchivoRecepcionRejects(fecha As Date) As String
        Return String.Format("{0}{1}.{2}", "PJ0", fecha.Day, ".426")
    End Function
End Class
