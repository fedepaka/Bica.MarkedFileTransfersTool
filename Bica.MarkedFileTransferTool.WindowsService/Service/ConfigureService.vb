Imports System.Configuration
Imports Topshelf

Namespace Bica.TransferGateway.WindowsService.Service
    Friend Module ConfigureService
        Private Const SERVICE_NAME As String = "SERVICE_NAME"
        Private Const SERVICE_DISPLAY_NAME As String = "SERVICE_DISPLAY_NAME"
        Private Const SERVICE_DESCRIPTION As String = "SERVICE_DESCRIPTION"

        Private ReadOnly Property ServiceName As String
            Get
                Return ConfigurationManager.AppSettings.[Get](SERVICE_NAME)
            End Get
        End Property

        Private ReadOnly Property ServiceDisplayName As String
            Get
                Return ConfigurationManager.AppSettings.[Get](SERVICE_DISPLAY_NAME)
            End Get
        End Property

        Private ReadOnly Property ServiceDescription As String
            Get
                Return ConfigurationManager.AppSettings.[Get](SERVICE_DESCRIPTION)
            End Get
        End Property

        Friend Sub Configure()
            HostFactory.Run(Sub(configure)
                                configure.Service(Of ScheduleService)(Sub(service)
                                                                          service.ConstructUsing(Function(s) New ScheduleService())
                                                                          service.WhenStarted(Sub(s) s.Start())
                                                                          service.WhenStopped(Sub(s) s.[Stop]())
                                                                      End Sub)
                                configure.RunAsLocalSystem()
                                configure.SetServiceName(ServiceName)
                                configure.SetDisplayName(ServiceDisplayName)
                                configure.SetDescription(ServiceDescription)
                            End Sub)
        End Sub
    End Module
End Namespace
