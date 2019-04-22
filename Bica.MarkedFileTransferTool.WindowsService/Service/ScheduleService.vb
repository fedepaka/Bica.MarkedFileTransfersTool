Imports Quartz
Imports Quartz.Impl
Imports System.Configuration

Namespace Bica.TransferGateway.WindowsService.Service
    Public Class ScheduleService
        Private ReadOnly scheduler As IScheduler
        Private Const INTERVAL_MINUTES As String = "INTERVAL_MINUTES"
        Private Const JOB_NAME As String = "JOB_NAME"
        Private Const GROUP_NAME As String = "GROUP_NAME"
        Private Const TRIGGER_NAME As String = "TRIGGER_NAME"

        Private Shared ReadOnly Property IntervalMinutes As Integer
            Get
                Return Integer.Parse(ConfigurationManager.AppSettings.[Get](INTERVAL_MINUTES))
            End Get
        End Property

        Private Shared ReadOnly Property JobName As String
            Get
                Return ConfigurationManager.AppSettings.[Get](JOB_NAME)
            End Get
        End Property

        Private Shared ReadOnly Property GroupName As String
            Get
                Return ConfigurationManager.AppSettings.[Get](GROUP_NAME)
            End Get
        End Property

        Private Shared ReadOnly Property TriggerName As String
            Get
                Return ConfigurationManager.AppSettings.[Get](TRIGGER_NAME)
            End Get
        End Property

        Public Sub New()
            Dim factory As StdSchedulerFactory = New StdSchedulerFactory()
            scheduler = factory.GetScheduler().ConfigureAwait(False).GetAwaiter().GetResult()
        End Sub

        Public Sub Start()
            scheduler.Start().ConfigureAwait(False).GetAwaiter().GetResult()
            ScheduleJobs()
        End Sub

        Public Sub [Stop]()
            scheduler.Shutdown().ConfigureAwait(False).GetAwaiter().GetResult()
        End Sub

        Public Sub ScheduleJobs()
            Dim job As IJobDetail = JobBuilder.Create(Of TransferNTFTPJob)().WithIdentity(JobName, GroupName).Build()
            Dim trigger As ITrigger = TriggerBuilder.Create().WithIdentity(TriggerName, GroupName).StartNow().WithSimpleSchedule(Sub(x) x.WithIntervalInMinutes(IntervalMinutes).RepeatForever()).Build()
            scheduler.ScheduleJob(job, trigger).ConfigureAwait(False).GetAwaiter().GetResult()
        End Sub
    End Class
End Namespace
