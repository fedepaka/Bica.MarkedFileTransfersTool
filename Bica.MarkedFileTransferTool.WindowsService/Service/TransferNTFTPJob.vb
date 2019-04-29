Imports Quartz
Imports Bica.MarkedFileTransfersTool.Model
Imports Bica.MarkedFileTransfersTool.BusinessLayer
Imports Bica.MarkedFileTransfersTool
Imports Bica.MarkedFileTransfersTool.Helper

Namespace Bica.TransferGateway.WindowsService.Service
    ''' <summary>
    ''' Métodos y clases necesarias para transferencia de archivos al NTFTP
    ''' </summary>
    Public Class TransferNTFTPJob
        Implements IJob

        Private _blMovimientoArchivos As MovimientoArchivos = New MovimientoArchivos()
        Private _blOrigenDestinoArchivos As OrigenDestinoArchivos = New OrigenDestinoArchivos()
        Private fechaProcesoActual As Date = Date.Now
        Private userName As String = Me.GetType().Name

        ''' <summary>
        ''' Método principal del Job
        ''' </summary>
        ''' <param name="context"></param>
        ''' <returns></returns>
        Public Function Execute(ByVal context As IJobExecutionContext) As Task Implements IJob.Execute
            Dim lastRun = If(context.PreviousFireTimeUtc?.DateTime.ToString(), String.Empty)

            If Not String.IsNullOrEmpty(lastRun) Then
                Console.ResetColor()
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine(String.Format("Ejecución previa del JOB TransferNTFTPJob: {0}.", lastRun))
            Else
                Console.ResetColor()
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine(String.Format("Ejecución inicial del JOB TransferNTFTPJob: {0}.", context.FireTimeUtc.DateTime.ToString()))
            End If

            IniciarProcesoTransferencia()

            Return Task.FromResult(0)
        End Function

        ''' <summary>
        ''' Principal que ejecuta la transferencia de archivos
        ''' </summary>
        ''' <returns></returns>
        Private Function IniciarProcesoTransferencia() As Boolean
            Dim objOrigenArchivosAEnviar = _blOrigenDestinoArchivos.ObtenerOrigenDestinoArchivosPorEnviar()

            For Each objOrigenArchivos As Procesos_OrigenDestinoArchivos In objOrigenArchivosAEnviar
                Dim objMovimientoArchivos = _blMovimientoArchivos.ObtenerRegistrosMovimientosArchivosPendientesEnviar(fechaProcesoActual, objOrigenArchivos.Id)

                MoverArchivosAsync(Tuple.Create(objOrigenArchivos, objMovimientoArchivos))
            Next
        End Function

        ''' <summary>
        '''  Taréa asíncrona en nuevo thread para transferencia de archivo
        ''' </summary>
        ''' <param name="procesoArchivo"></param>
        ''' <returns></returns>
        Private Function MoverArchivosAsync(ByVal procesoArchivo As Tuple(Of Procesos_OrigenDestinoArchivos, List(Of Model.Procesos_MovimientoArchivos))) As Boolean
            Dim fatory = Task.Factory.StartNew(Function() MoverArchivos(procesoArchivo))
            Return fatory.Result
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
            Dim rutaDestino = datosProceso.PathInport

            For Each archivo As Model.Procesos_MovimientoArchivos In listaArchivos
                'armamos la ruta del archivo
                Dim rutaArchivoDesdeCompleta = String.Format("{0}\{1}", rutaOrigen, archivo.FileName)
                'verificamos que exista el archivo
                'si existe el archivo en el origen
                'y existe la ruta destino de NTFTP, copiamos el archivo
                If Not FileUtil.ExisteArchivo(rutaArchivoDesdeCompleta) And
                    Not FileUtil.ExisteDirectorio(rutaDestino) Then
                    Return resultado
                Else
                    FileUtil.CopiarArchivo(rutaArchivoDesdeCompleta, String.Format("{0}\{1}", rutaDestino, archivo.FileName))
                    'marcar como copiado
                    _blMovimientoArchivos.ActualizarRegistroCopiado(archivo.Id, userName)
                End If
            Next
            Return True
        End Function

    End Class
End Namespace
