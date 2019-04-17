Imports Bica.MarkedFileTransfersTool.DALayer
Imports Bica.MarkedFileTransfersTool.Model

Public Class MovimientoArchivos
    Implements IMovimientoArchivos

    Private _dataMovimientoArchivos As Procesos_MovimientoArchivos_DataModel
    Public Function ObtenerMovimientosArchivos(IdProceso As Long, fecha As Date) As List(Of Model.Procesos_MovimientoArchivos) Implements IMovimientoArchivos.ObtenerMovimientosArchivos
        _dataMovimientoArchivos = New Procesos_MovimientoArchivos_DataModel()

        Return _dataMovimientoArchivos.ObtenerMovimientosArchivos(IdProceso, fecha)
    End Function

    Public Function InsertarRegistroMovimientoArchivo(IdProcesoOrigen As Long, NombreArchivo As String, FechaPresentacion As Date, IdArchivo As Long, IdUsuarioCreacion As Long) As Long Implements IMovimientoArchivos.InsertarRegistroMovimientoArchivo
        _dataMovimientoArchivos = New Procesos_MovimientoArchivos_DataModel()



        Return _dataMovimientoArchivos.InsertarRegistroMovimientoArchivo(IdProcesoOrigen, NombreArchivo, FechaPresentacion, IdArchivo, IdUsuarioCreacion)
    End Function

    Public Function ActualizarRegistroMovimientoArchivo(IdMovimientoArchivo As Long, Transferred As Boolean, DoBackup As Boolean, IdUpdatedUser As Long) As Long Implements IMovimientoArchivos.ActualizarRegistroMovimientoArchivo
        Throw New NotImplementedException()
    End Function

End Class
