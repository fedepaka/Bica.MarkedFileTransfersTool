Imports Quartz
Imports Bica.MarkedFileTransfersTool.Model
Imports Bica.MarkedFileTransfersTool.BusinessLayer
Imports Bica.MarkedFileTransfersTool
Imports Bica.MarkedFileTransfersTool.Helper

Namespace Bica.TransferGateway.WindowsService.Service
    Public Class ReciberNTFTPJob
        Implements IJob

        Private _blMovimientoArchivos As MovimientoArchivos = New MovimientoArchivos()
        Private _blOrigenDestinoArchivos As OrigenDestinoArchivos = New OrigenDestinoArchivos()
        Private fechaProcesoActual As Date = Date.Now

        Public Function Execute(ByVal context As IJobExecutionContext) As Task Implements IJob.Execute
            Dim lastRun = If(context.PreviousFireTimeUtc?.DateTime.ToString(), String.Empty)

            If Not String.IsNullOrEmpty(lastRun) Then
                Console.ResetColor()
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine(String.Format("Ejecución previa del JOB ReciberNTFTPJob: {0}.", lastRun))
            Else
                Console.ResetColor()
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine(String.Format("Ejecución inicial del JOB ReciberNTFTPJob: {0}.", context.FireTimeUtc.DateTime.ToString()))
            End If

            IniciarProcesoRecepcion()
            Return Task.FromResult(0)
        End Function

        Private Function IniciarProcesoRecepcion() As Boolean
            'Dim objOrigenArchivosRecibir = _blOrigenDestinoArchivos.ObtenerOrigenDestinoArchivosPorRecibir()

            'For Each objOrigenArchivos As Procesos_OrigenDestinoArchivos In objOrigenArchivosRecibir
            '    Dim objMovimientoArchivos = _blMovimientoArchivos.ObtenerRegistrosMovimientosArchivosRecibidos(fechaProcesoActual, objOrigenArchivos.Id)

            '    Return MoverArchivosAsync(Tuple.Create(objOrigenArchivos, objMovimientoArchivos))
            'Next
        End Function
    End Class
End Namespace
