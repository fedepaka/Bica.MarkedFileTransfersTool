﻿Imports Bica.MarkedFileTransfersTool.Model

Public Interface IMovimientoArchivos
    Function ObtenerMovimientosArchivos(IdProceso As Long, fecha As Date) As List(Of Procesos_MovimientoArchivos)
    Function ObtenerMovimientoArchivoPorNombre(Nombre As String) As Procesos_MovimientoArchivos
    Function ExisteRegistroArchivo(Nombre As String) As Boolean
    Function InsertarRegistroMovimientoArchivo(IdProcesoOrigen As Long, NombreArchivo As String, FechaPresentacion As Date, IdArchivo As Long, IdUsuarioCreacion As Long) As Long
    Function ActualizarRegistroMovimientoArchivo(IdMovimientoArchivo As Long, Transferred As Boolean, DoBackup As Boolean, IdUpdatedUser As Long) As Long
End Interface
