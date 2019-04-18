Imports Bica.MarkedFileTransfersTool.Model
Imports Bica.MarkedFileTransfersTool.DALayer
Imports Bica.MarkedFileTransfersTool.Helper

Public Class DebitoDirecto
    Implements IDebitoDirecto

    Private _daDebitoDirecto As Procesos_DebitoDirecto_DataModel
    Private _movimientoArchivos As IMovimientoArchivos
    Public Function ObtenerDebitosDirectos(fecha As Date) As Procesos_DebitoDirecto Implements IDebitoDirecto.ObtenerDebitosDirectos

        _daDebitoDirecto = New Procesos_DebitoDirecto_DataModel()

        'Obtenemos los datos en bd de los archivos generados
        Dim datoArchivoValidar = _daDebitoDirecto.ObtenerDebitosDirectos(fecha)

        If datoArchivoValidar IsNot Nothing Then
            'validamos que exista el archivo físco
            If FileUtil.ExisteArchivo(datoArchivoValidar.NombreArchivo) Then

                'si no existe el registro se crea
                Dim registriMovArchivo = _movimientoArchivos.ObtenerMovimientoArchivos_NombreFecha(datoArchivoValidar.NombreArchivo, fecha)

                If registriMovArchivo Is Nothing Then
                    _movimientoArchivos.InsertarRegistroMovimientoArchivo(Constants.BCO_Envio_Debito_Directo_Code, datoArchivoValidar.NombreArchivo, datoArchivoValidar.FechaEnvio, datoArchivoValidar.IdArchivo, 1)
                End If

                Return _daDebitoDirecto.ObtenerDebitosDirectos(fecha)
            Else
                'mostrar mensaje que no existe el archivo
                Return Nothing
            End If
        End If



    End Function
End Class
