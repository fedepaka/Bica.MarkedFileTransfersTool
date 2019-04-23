﻿Imports Quartz
Imports System
Imports System.Configuration
Imports System.Threading.Tasks
Imports Bica.MarkedFileTransfersTool.Model
Imports Bica.MarkedFileTransfersTool.BusinessLayer
Imports Bica.MarkedFileTransfersTool
Imports Bica.MarkedFileTransfersTool.Helper

Namespace Bica.TransferGateway.WindowsService.Service
    Public Class CheckTransferNTFTPJob
        Implements IJob

        Private _blMovimientoArchivos As MovimientoArchivos = New MovimientoArchivos()
        'Private _blOrigenDestinoArchivos As OrigenDestinoArchivos = New OrigenDestinoArchivos()
        Private fechaProcesoActual As Date = Date.Now

        Public Function Execute(ByVal context As IJobExecutionContext) As Task Implements IJob.Execute
            Dim lastRun = If(context.PreviousFireTimeUtc?.DateTime.ToString(), String.Empty)

            If Not String.IsNullOrEmpty(lastRun) Then
                Console.ResetColor()
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine(String.Format("Ejecución previa del JOB CheckTransferNTFTPJob: {0}.", lastRun))
            End If


            Return Task.FromResult(0)
        End Function

        Private Function VerificarCopiaArchivos()
            Dim par = _blMovimientoArchivos.ObtenerRegistrosMovimientosArchivosCopiados(fechaProcesoActual, Nothing)
            Dim origenDestinoArchivos = par.Item1
            Dim listaArchivos = par.Item2

            'verificar en el directorio de NTFTP - \\BBPROCESO2\Coelsa\Bica\Importado, que existan los archivos físicos
            'si existen, marcarlos como transferido

        End Function

        'Private Function VerificarDestinoFinalArchivo()

        'End Function

    End Class


End Namespace