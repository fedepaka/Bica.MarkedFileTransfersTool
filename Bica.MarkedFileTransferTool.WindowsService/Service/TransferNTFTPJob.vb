Imports Quartz
Imports System
Imports System.Configuration
Imports System.Threading.Tasks
Imports Bica.MarkedFileTransfersTool.Model
Imports Bica.MarkedFileTransfersTool.BusinessLayer
Imports Bica.MarkedFileTransfersTool

Namespace Bica.TransferGateway.WindowsService.Service
    Public Class TransferNTFTPJob
        Implements IJob

        'Private endpointUrl As String = ConfigurationSettings.AppSettings.[Get]("BASE_URL")
        Private _blMovimientoArchivos As MovimientoArchivos = New MovimientoArchivos()
        Private _blOrigenDestinoArchivos As OrigenDestinoArchivos = New OrigenDestinoArchivos()
        Private fechaProcesoActual As Date = Date.Now

        Public Function Execute(ByVal context As IJobExecutionContext) As Task Implements IJob.Execute
            Dim lastRun = If(context.PreviousFireTimeUtc?.DateTime.ToString(), String.Empty)

            If Not String.IsNullOrEmpty(lastRun) Then
                Console.WriteLine(String.Format("Ejecución previa del JOB: {0}.", lastRun))
            End If

            'Dim gatewayWS As TransferGatewayWSClient = New TransferGatewayWSClient("webHttpBinding_ITransferGatewayWS", endpointUrl)
            'gatewayWS.CheckTransactionDelayed()
            Return Task.FromResult(0)
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="Fecha"></param>
        ''' <param name="IdProceso"></param>
        Private Function ObtenerRegistrosMovimientosArchivosPendientesEnviar(Fecha As Date, IdProceso As Long) As List(Of Model.Procesos_MovimientoArchivos)

            Dim objProceso = _blOrigenDestinoArchivos.ObtenerOrigenDestinoArchivos(Constants.BCO_Envio_Debito_Directo_Code)
            Return _blMovimientoArchivos.ObtenerMovimientoArchivosPendientesEnviar(objProceso.Id, fechaProcesoActual)
        End Function

        ''' <summary>
        ''' Se encarga de mover los archivos a la carpeta de NTFTP
        ''' </summary>
        ''' <param name="ListaArchivos"></param>
        ''' <returns></returns>
        Private Function MoverArchivos(ListaArchivos As List(Of Model.Procesos_MovimientoArchivos)) As Boolean

            For Each item As Model.Procesos_MovimientoArchivos In ListaArchivos
                'item.FileName
            Next
            Return True
        End Function

    End Class
End Namespace
