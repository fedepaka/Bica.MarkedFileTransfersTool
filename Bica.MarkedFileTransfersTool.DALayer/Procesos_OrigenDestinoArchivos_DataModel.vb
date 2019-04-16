
Public Class Procesos_OrigenDestinoArchivos_DataModel
    Private registro As Procesos_OrigenDestinoArchivos

    ''' <summary>
    ''' Obtener configuración de un proceso para transferencia de archivos
    ''' </summary>
    ''' <param name="IdProceso"></param>
    ''' <returns></returns>
    Public Function ObtenerOrigenDestinoArchivos(IdProceso As Long) As Model.Procesos_OrigenDestinoArchivos

        Using resource As New B_BancaElecEntities()
            registro = (From f In resource.Procesos_OrigenDestinoArchivos Where f.PROCESSNR = IdProceso And f.DELETED <> 0).FirstOrDefault()
            Return Map(registro)
        End Using
    End Function

#Region "Métodos Privados"

    ''' <summary>
    ''' Mapea objeto de base de datos a una entidad de clase de negocios
    ''' </summary>
    ''' <param name="registro"></param>
    ''' <returns></returns>
    Private Shared Function Map(registro As Procesos_OrigenDestinoArchivos) As Model.Procesos_OrigenDestinoArchivos
        If registro Is Nothing Then
            Return Nothing
        End If

        Dim retorno As New Model.Procesos_OrigenDestinoArchivos()
        retorno.Created_Date = registro.CREATED_DATE
        retorno.Created_User_Id = registro.CREATED_USER_ID
        retorno.Id = registro.ID
        retorno.Updated_Date = registro.MODIFIED_DATE
        retorno.Modified_User_Id = registro.MODIFIED_USER_ID
        retorno.PathFrom = registro.PATHFROM
        retorno.PathTo = registro.PATHTO
        retorno.ProcessNr = registro.PROCESSNR

        Return retorno
    End Function

#End Region
End Class
