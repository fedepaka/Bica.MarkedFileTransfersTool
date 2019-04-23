﻿Imports Bica.MarkedFileTransfersTool.BusinessLayer
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

    Public Function ActualizarRegistroMovimientoArchivo(IdMovimientoArchivo As Long, Transferred As Boolean, DoBackup As Boolean, IdUpdatedUser As Long, ToBeTransfer As Boolean) As Boolean Implements IMovimientoArchivos.ActualizarRegistroMovimientoArchivo
        _dataMovimientoArchivos = New Procesos_MovimientoArchivos_DataModel()

        Return _dataMovimientoArchivos.ActualizarRegistroMovimientoArchivo(IdMovimientoArchivo, Transferred, DoBackup, IdUpdatedUser, ToBeTransfer) > 0

    End Function

    Public Function ObtenerMovimientoArchivoPorNombre(Nombre As String) As Model.Procesos_MovimientoArchivos Implements IMovimientoArchivos.ObtenerMovimientoArchivoPorNombre
        _dataMovimientoArchivos = New Procesos_MovimientoArchivos_DataModel()
        Return _dataMovimientoArchivos.ObtenerMovimientoArchivoPorNombre(Nombre)
    End Function

    ''' <summary>
    ''' Indica si existe registro con nombre especificado
    ''' </summary>
    ''' <param name="Nombre"></param>
    ''' <returns></returns>
    Public Function ExisteRegistroArchivo(Nombre As String) As Boolean Implements IMovimientoArchivos.ExisteRegistroArchivo
        If Me.ObtenerMovimientoArchivoPorNombre(Nombre) IsNot Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ActualizarRegistroASerTransferido(IdMovimientoArchivo As Long, IdUpdatedUser As Long) As Boolean Implements IMovimientoArchivos.ActualizarRegistroASerTransferido
        Return Me.ActualizarRegistroMovimientoArchivo(IdMovimientoArchivo, False, False, IdUpdatedUser, True) > 0
    End Function

    Public Function ObtenerMovimientoArchivoPorId(Id As Long) As Model.Procesos_MovimientoArchivos Implements IMovimientoArchivos.ObtenerMovimientoArchivoPorId
        _dataMovimientoArchivos = New Procesos_MovimientoArchivos_DataModel()
        Return _dataMovimientoArchivos.ObtenerMovimientoArchivoPorId(Id)
    End Function

    Public Function ObtenerMovimientoArchivosPendientesEnviar(IdProceso As Long, fecha As Date) As List(Of Model.Procesos_MovimientoArchivos) Implements IMovimientoArchivos.ObtenerMovimientoArchivosPendientesEnviar
        _dataMovimientoArchivos = New Procesos_MovimientoArchivos_DataModel()

        Return _dataMovimientoArchivos.ObtenerMovimientoArchivosPendientesEnviar(IdProceso, fecha)
    End Function
End Class
