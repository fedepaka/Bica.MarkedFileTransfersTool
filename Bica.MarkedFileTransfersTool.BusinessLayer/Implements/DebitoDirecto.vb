Imports Bica.MarkedFileTransfersTool.DALayer
Imports Bica.MarkedFileTransfersTool.Helper
Imports Bica.MarkedFileTransfersTool.Model

Public Class DebitoDirecto
    Implements IDebitoDirecto

    Private _dataDebitoDirecto As Procesos_DebitoDirecto_DataModel
    Private _blMovArchivos As MovimientoArchivos
    Private _blOrigenDestino As OrigenDestinoArchivos

    Public Function ObtenerDebitosDirectos(fecha As Date) As List(Of Procesos_DebitoDirecto) Implements IDebitoDirecto.ObtenerDebitosDirectos

        'buscamos los registros de débito directo del día
        _dataDebitoDirecto = New Procesos_DebitoDirecto_DataModel()
        Return _dataDebitoDirecto.ObtenerDebitosDirectos(fecha)
    End Function

    ''' <summary>
    ''' Busca el archivo físico de débito directo del día 
    ''' si existe se genera registro en la tabla Movimiento Archivos que luego serán transferidos
    ''' </summary>
    ''' <param name="fecha"></param>
    ''' <returns></returns>
    Public Function CargaArchivosDebitoDirecto(fecha As Date) As Boolean Implements IDebitoDirecto.CopiarArchivosDebitoDirecto
        _blMovArchivos = New MovimientoArchivos()
        _blOrigenDestino = New OrigenDestinoArchivos()

        Dim listaArchivosDD = Me.ObtenerDebitosDirectos(fecha)

        For Each archivoDD As Procesos_DebitoDirecto In listaArchivosDD

            If FileUtil.ExisteArchivo(archivoDD.NombreArchivo) Then
                Dim nombreArchivo = FileUtil.ExtraerNombreArchivo(archivoDD.NombreArchivo)

                If Not _blMovArchivos.ExisteRegistroArchivo(nombreArchivo) Then

                    Dim origeDestino = _blOrigenDestino.ObtenerOrigenDestinoArchivos(Constants.BCO_Envio_Debito_Directo_Code)

                    _blMovArchivos.InsertarRegistroMovimientoArchivo(origeDestino.Id,
                        nombreArchivo, archivoDD.FechaEnvio, archivoDD.IdArchivo, 1)
                End If
            End If

        Next
        Return True
    End Function
End Class
