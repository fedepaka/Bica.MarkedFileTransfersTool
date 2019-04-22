Imports Bica.TransferGateway.WindowsService.ServiceReference
Imports Quartz
Imports System
Imports System.Configuration
Imports System.Threading.Tasks

Namespace Bica.TransferGateway.WindowsService.Service
    Public Class TransferJob
        Implements IJob

        'Private endpointUrl As String = ConfigurationSettings.AppSettings.[Get]("BASE_URL")

        Public Function Execute(ByVal context As IJobExecutionContext) As Task Implements IJob.Execute
            Dim lastRun = If(context.PreviousFireTimeUtc?.DateTime.ToString(), String.Empty)

            If Not String.IsNullOrEmpty(lastRun) Then
                Console.WriteLine(String.Format("Ejecución previa del JOB: {0}.", lastRun))
            End If

            'Dim gatewayWS As TransferGatewayWSClient = New TransferGatewayWSClient("webHttpBinding_ITransferGatewayWS", endpointUrl)
            'gatewayWS.CheckTransactionDelayed()
            Return Task.FromResult(0)
        End Function
    End Class
End Namespace
