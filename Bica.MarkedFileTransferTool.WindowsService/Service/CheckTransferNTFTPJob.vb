Imports Quartz
Imports Bica.MarkedFileTransfersTool.Model
Imports Bica.MarkedFileTransfersTool.BusinessLayer
Imports Bica.MarkedFileTransfersTool
Imports Bica.MarkedFileTransfersTool.Helper

Namespace Bica.TransferGateway.WindowsService.Service
    ''' <summary>
    ''' Métodos y clases necesarias para verificación de archivos transferidos por procesos de Envíos
    ''' </summary>
    Public Class CheckTransferNTFTPJob
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
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine(String.Format("Ejecución previa del JOB CheckTransferNTFTPJob: {0}.", lastRun))
            Else
                Console.ResetColor()
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine(String.Format("Ejecución inicial del JOB CheckTransferNTFTPJob: {0}.", context.FireTimeUtc.DateTime.ToString()))
            End If

            IniciarProcesoVerificarCopiaArchivos()

            Return Task.FromResult(0)
        End Function

        ''' <summary>
        ''' Principal que ejecuta la verificación de las transferencias de archivos
        ''' </summary>
        ''' <returns></returns>
        Private Function IniciarProcesoVerificarCopiaArchivos() As Boolean
            Dim objOrigenArchivosAEnviar = _blOrigenDestinoArchivos.ObtenerOrigenDestinoArchivosPorEnviar()

            For Each objOrigenArchivos As Procesos_OrigenDestinoArchivos In objOrigenArchivosAEnviar
                Dim objMovimientoArchivos = _blMovimientoArchivos.ObtenerRegistrosMovimientosArchivosCopiados(fechaProcesoActual, objOrigenArchivos.Id)

                VerificarArchivosAsync(Tuple.Create(objOrigenArchivos, objMovimientoArchivos))
            Next

        End Function

        ''' <summary>
        ''' Taréa asíncrona en nuevo thread para verificación 
        ''' </summary>
        ''' <param name="procesoArchivo"></param>
        ''' <returns></returns>
        Private Function VerificarArchivosAsync(ByVal procesoArchivo As Tuple(Of Procesos_OrigenDestinoArchivos, List(Of Model.Procesos_MovimientoArchivos))) As Boolean
            Dim fatory = Task.Factory.StartNew(Function() VerificarCopiaArchivos(procesoArchivo))
            Return fatory.Result
        End Function

        ''' <summary>
        ''' Verifica que el archivo en estado Copiado, se haya copiado en la carpeta correspondiente de NTFTP
        ''' </summary>
        ''' <param name="procesoArchivo"></param>
        ''' <returns></returns>
        Private Function VerificarCopiaArchivos(procesoArchivo As Tuple(Of Procesos_OrigenDestinoArchivos, List(Of Model.Procesos_MovimientoArchivos))) As Boolean
            Dim retorno As Boolean = True
            Dim origenDestinoArchivos = procesoArchivo.Item1
            Dim listaArchivos = procesoArchivo.Item2

            'verificar en el directorio de NTFTP - \\BBPROCESO2\Coelsa\Bica\Importado, que existan los archivos físicos
            'si existen, marcarlos como transferido

            For Each archivo As Procesos_MovimientoArchivos In listaArchivos
                If FileUtil.ExisteArchivo(String.Format("{0}\{1}", origenDestinoArchivos.UbicacionNTFTPEnviar, archivo.NombreArchivo)) Then
                    _blMovimientoArchivos.ActualizarRegistroTransferido(archivo.Id, userName)
                Else
                    retorno = False
                End If

            Next

            Return retorno
        End Function
    End Class


End Namespace
