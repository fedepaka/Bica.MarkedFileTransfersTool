Imports Quartz
Imports Bica.MarkedFileTransfersTool.Model
Imports Bica.MarkedFileTransfersTool.BusinessLayer
Imports Bica.MarkedFileTransfersTool
Imports Bica.MarkedFileTransfersTool.Helper

Namespace Bica.TransferGateway.WindowsService.Service
    Public Class TransferNTFTPJob
        Implements IJob

        Private _blMovimientoArchivos As MovimientoArchivos = New MovimientoArchivos()
        Private _blOrigenDestinoArchivos As OrigenDestinoArchivos = New OrigenDestinoArchivos()
        Private fechaProcesoActual As Date = Date.Now

        Public Function Execute(ByVal context As IJobExecutionContext) As Task Implements IJob.Execute
            Dim lastRun = If(context.PreviousFireTimeUtc?.DateTime.ToString(), String.Empty)

            If Not String.IsNullOrEmpty(lastRun) Then
                Console.ResetColor()
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine(String.Format("Ejecución previa del JOB TransferNTFTPJob: {0}.", lastRun))
            End If

            Return Task.FromResult(0)
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Fecha"></param>
        ''' <param name="IdProceso"></param>
        Private Function ObtenerRegistrosMovimientosArchivosPendientesEnviar(Fecha As Date, IdProceso As Long) As Tuple(Of Procesos_OrigenDestinoArchivos, List(Of Model.Procesos_MovimientoArchivos))

            Dim objProceso = _blOrigenDestinoArchivos.ObtenerOrigenDestinoArchivos(Constants.BCO_Envio_Debito_Directo_Code)
            Return Tuple.Create(objProceso, _blMovimientoArchivos.ObtenerMovimientoArchivosPendientesEnviar(objProceso.Id, fechaProcesoActual))
        End Function

        ''' <summary>
        ''' Se encarga de mover los archivos a la carpeta de NTFTP
        ''' </summary>
        ''' <param name="procesoArchivo">Tupla con el id</param>
        ''' <returns></returns>
        Private Function MoverArchivos(procesoArchivo As Tuple(Of Procesos_OrigenDestinoArchivos, List(Of Model.Procesos_MovimientoArchivos))) As Boolean
            Dim resultado As Boolean = False
            Dim datosProceso As Procesos_OrigenDestinoArchivos = procesoArchivo.Item1
            Dim listaArchivos As List(Of Model.Procesos_MovimientoArchivos) = procesoArchivo.Item2

            Dim rutaOrigen = datosProceso.PathFrom
            Dim rutaDestino = datosProceso.PathTo

            For Each archivo As Model.Procesos_MovimientoArchivos In listaArchivos
                'armamos la ruta del archivo
                Dim rutaArchivoDesdeCompleta = String.Format("{0}\{1}", rutaOrigen, archivo.FileName)
                'verificamos que exista
                'si existe el archivo en el origen
                'y existe la ruta destino de NTFTP, copiamos el archivo
                If Not FileUtil.ExisteArchivo(rutaArchivoDesdeCompleta) And
                    Not FileUtil.ExisteDirectorio(rutaDestino) Then
                    Return resultado
                Else
                    FileUtil.CopiarArchivo(rutaArchivoDesdeCompleta, rutaDestino)
                End If
            Next
            Return True
        End Function


    End Class
End Namespace
