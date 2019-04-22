Imports System.Data.Entity

Public Class Procesos_DebitoDirecto_DataModel
    Public Function ObtenerDebitosDirectos(fecha As Date) As Model.Procesos_DebitoDirecto
        Dim registro As Prov_DebitoDirecto

        Using resource As New B_GeneralEntities()
            registro = (From f In resource.Prov_DebitoDirecto
                        Where DbFunctions.TruncateTime(f.FechaPres) = fecha.Date).FirstOrDefault()

            Return Map(registro)
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
