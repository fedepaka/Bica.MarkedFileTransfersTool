Imports Quartz
Imports Quartz.Impl
Imports System.Configuration

Namespace Bica.TransferGateway.WindowsService.Service
    Public Class ScheduleService
        Private ReadOnly scheduler As IScheduler
        Private Const INTERVAL_MINUTES_JOB_TRANSFER_NTFTP As String = "INTERVAL_MINUTES_JOB_TRANSFER_NTFTP"
        Private Const INTERVAL_MINUTES_JOB_CHECK_NTFTP As String = "INTERVAL_MINUTES_JOB_CHECK_NTFTP"
        Private Const INTERVAL_MINUTES_JOB_RECIBER_NTFTP As String = "INTERVAL_MINUTES_JOB_RECIBER_NTFTP"

        Private Const JOB_NAME_TRANSFER_NTFTP As String = "JOB_NAME_TRANSFER_NTFTP"
        Private Const JOB_NAME_CHECK_NTFTP As String = "JOB_NAME_CHECK_NTFTP"
        Private Const JOB_NAME_RECIBER_NTFTP As String = "JOB_NAME_RECIBER_NTFTP"

        Private Const GROUP_NAME As String = "GROUP_NAME"
        Private Const TRIGGER_NAME_TRANSFER_NTFTP As String = "TRIGGER_NAME_TRANSFER_NTFTP"
        Private Const TRIGGER_NAME_CHECK_NTFTP As String = "TRIGGER_NAME_CHECK_NTFTP"
        Private Const TRIGGER_NAME_RECIBER_NTFTP As String = "TRIGGER_NAME_RECIBER_NTFTP"

        Private Shared ReadOnly Property IntervalMinutesTransferNTFTP As Integer
            Get
                Return Integer.Parse(ConfigurationManager.AppSettings.[Get](INTERVAL_MINUTES_JOB_TRANSFER_NTFTP))
            End Get
        End Property

        Private Shared ReadOnly Property IntervalMinutesCheckNTFTP As Integer
            Get
                Return Integer.Parse(ConfigurationManager.AppSettings.[Get](INTERVAL_MINUTES_JOB_CHECK_NTFTP))
            End Get
        End Property

        Private Shared ReadOnly Property IntervalMinutesReciberNTFTP As Integer
            Get
                Return Integer.Parse(ConfigurationManager.AppSettings.[Get](INTERVAL_MINUTES_JOB_RECIBER_NTFTP))
            End Get
        End Property

        Private Shared ReadOnly Property JobNameTransferNTFTP As String
            Get
                Return ConfigurationManager.AppSettings.[Get](JOB_NAME_TRANSFER_NTFTP)
            End Get
        End Property

        Private Shared ReadOnly Property JobNameCheckNTFTP As String
            Get
                Return ConfigurationManager.AppSettings.[Get](JOB_NAME_CHECK_NTFTP)
            End Get
        End Property

        Private Shared ReadOnly Property JobNameReciberNTFTP As String
            Get
                Return ConfigurationManager.AppSettings.[Get](JOB_NAME_RECIBER_NTFTP)
            End Get
        End Property

        Private Shared ReadOnly Property GroupName As String
            Get
                Return ConfigurationManager.AppSettings.[Get](GROUP_NAME)
            End Get
        End Property

        Private Shared ReadOnly Property TriggerNameTransferNTFTP As String
            Get
                Return ConfigurationManager.AppSettings.[Get](TRIGGER_NAME_TRANSFER_NTFTP)
            End Get
        End Property

        Private Shared ReadOnly Property TriggerNameCheckNTFTP As String
            Get
                Return ConfigurationManager.AppSettings.[Get](TRIGGER_NAME_CHECK_NTFTP)
            End Get
        End Property

        Private Shared ReadOnly Property TriggerNameReciberNTFTP As String
            Get
                Return ConfigurationManager.AppSettings.[Get](TRIGGER_NAME_RECIBER_NTFTP)
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
            Dim transferJob As IJobDetail = JobBuilder.Create(Of TransferNTFTPJob)().WithIdentity(JobNameTransferNTFTP, GroupName).Build()
            Dim checkJob As IJobDetail = JobBuilder.Create(Of CheckTransferNTFTPJob)().WithIdentity(JobNameCheckNTFTP, GroupName).Build()
            Dim reciberJob As IJobDetail = JobBuilder.Create(Of ReciberNTFTPJob)().WithIdentity(JobNameReciberNTFTP, GroupName).Build()

            Dim triggerTransfer As ITrigger = TriggerBuilder.Create().WithIdentity(TriggerNameTransferNTFTP, GroupName).StartNow().WithSimpleSchedule(Sub(x) x.WithIntervalInMinutes(IntervalMinutesTransferNTFTP).RepeatForever()).Build()
            Dim triggerCheck As ITrigger = TriggerBuilder.Create().WithIdentity(TriggerNameCheckNTFTP, GroupName).StartNow().WithSimpleSchedule(Sub(x) x.WithIntervalInMinutes(IntervalMinutesCheckNTFTP).RepeatForever()).Build()
            Dim triggerReciber As ITrigger = TriggerBuilder.Create().WithIdentity(TriggerNameReciberNTFTP, GroupName).StartNow().WithSimpleSchedule(Sub(x) x.WithIntervalInMinutes(IntervalMinutesReciberNTFTP).RepeatForever()).Build()
            scheduler.ScheduleJob(transferJob, triggerTransfer).ConfigureAwait(False).GetAwaiter().GetResult()
            scheduler.ScheduleJob(checkJob, triggerCheck).ConfigureAwait(False).GetAwaiter().GetResult()
            scheduler.ScheduleJob(reciberJob, triggerReciber).ConfigureAwait(False).GetAwaiter().GetResult()
        End Sub
    End Class
End Namespace
