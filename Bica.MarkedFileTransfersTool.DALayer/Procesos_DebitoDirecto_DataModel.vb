Imports System.Data.Entity

Public Class Procesos_DebitoDirecto_DataModel

    ''' <summary>
    ''' Obtiene lista de archivos que van a ser generados por los sps (Prov_DebitoDirecto)
    ''' </summary>
    ''' <param name="fecha"></param>
    ''' <returns></returns>
    Public Function ObtenerDebitosDirectos(fecha As Date) As List(Of Model.Procesos_DebitoDirecto)
        Dim registros As List(Of Prov_DebitoDirecto)

        Dim lista As List(Of Model.Procesos_DebitoDirecto) = New List(Of Model.Procesos_DebitoDirecto)

        Using resource As New B_GeneralEntities()
            registros = (From f In resource.Prov_DebitoDirecto
                         Where DbFunctions.TruncateTime(f.FechaPres) = fecha.Date).ToList()

            For Each item As Prov_DebitoDirecto In registros
                lista.Add(Map(item))
            Next

            Return lista
        End Using
    End Function

#Region "Métodos Privados"

    ''' <summary>
    ''' Mapea objeto de base de datos a una entidad de clase de negocios
    ''' </summary>
    ''' <param name="registro"></param>
    ''' <returns></returns>
    Private Shared Function Map(registro As Prov_DebitoDirecto) As Model.Procesos_DebitoDirecto
        If registro Is Nothing Then
            Return Nothing
        End If

        Dim retorno As New Model.Procesos_DebitoDirecto()
        retorno.NombreArchivo = registro.NombreArchivo
        retorno.FechaEnvio = registro.FechaEnvio
        retorno.IdArchivo = registro.IdArchivo
        retorno.UsuarioEnvio = registro.UsuarioEnvio
        Return retorno
    End Function

#End Region
End Class
