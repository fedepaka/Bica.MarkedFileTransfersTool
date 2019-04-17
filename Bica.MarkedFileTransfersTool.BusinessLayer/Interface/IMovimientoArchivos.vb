Imports Bica.MarkedFileTransfersTool.Model

Public Interface IMovimientoArchivos
    Function ObtenerMovimientosArchivos(IdProceso As Long, fecha As Date) As List(Of Procesos_MovimientoArchivos)
End Interface
