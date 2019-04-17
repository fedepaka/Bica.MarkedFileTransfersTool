
Public Class Procesos_OrigenDestinoArchivos_DataModel
    Private registro As Procesos_OrigenDestinoArchivos

    ''' <summary>
    ''' Obtener configuración de un proceso para transferencia de archivos
    ''' </summary>
    ''' <param name="IdProceso"></param>
    ''' <returns></returns>
    Public Function ObtenerOrigenDestinoArchivos(IdProceso As Long) As Model.Procesos_OrigenDestinoArchivos
        Dim setGeneral As List(Of Gen_Procesos)

        'Using rGeneral As New B_GeneralEntities
        '    setGeneral = (From gen In rGeneral.Gen_Procesos Where gen.Proceso = IdProceso).ToList()
        'End Using

        Using resource As New B_BancaElecEntities()
            registro = (From f In resource.Procesos_OrigenDestinoArchivos Where f.PROCESSNR = IdProceso And f.DELETED <> 0).FirstOrDefault()



            'Dim pepe = From elec In resource.Procesos_OrigenDestinoArchivos
            '           Join gen In setGeneral On elec.PROCESSNR Equals gen.Proceso
            '           Where elec.PROCESSNR = IdProceso
            '           Select New Procesos_OrigenDestinoArchivos With {.ID = elec.ID,
            '               .MODIFIED_DATE = elec.MODIFIED_DATE,
            '               .CREATED_DATE = elec.CREATED_DATE,
            '               .CREATED_USER_ID = elec.CREATED_USER_ID,
            '               .PROCESSNR = elec.PROCESSNR,
            '               .PATHFROM = elec.PATHFROM,
            '               .PATHTO = elec.PATHTO,
            '               .MODIFIED_USER_ID = elec.MODIFIED_USER_ID}
            '''Select elec.ID, elec.MODIFIED_DATE, elec.CREATED_DATE, elec.CREATED_USER_ID, elec.PROCESSNR, elec.PATHFROM, elec.PATHTO, elec.MODIFIED_USER_ID

            'Dim x = pepe.ToList()

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
