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
        Private userName As String = Me.GetType().Name

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
            Dim copiado As Boolean = False
            Dim objOrigenArchivosRecibir = _blOrigenDestinoArchivos.ObtenerOrigenDestinoArchivosPorRecibir()

            For Each objOrigenArchivos As Procesos_OrigenDestinoArchivos In objOrigenArchivosRecibir

                'verificar los tipos de archivos que nos interesan en este punto: PR0DD.426 o PP0DD.426
                Select Case objOrigenArchivos.ProcessNr
                    Case 355 'BCO - Camara - Recepcion Orden Debito_VsN

                        If FileUtil.ExisteArchivo(String.Format("{0}\{1}", objOrigenArchivos.PathRecibed, FileUtil.FormatoArchivoRecepcionOrdenDebito(fechaProcesoActual))) Then
                            copiado = FileUtil.CopiarArchivo(String.Format("{0}\{1}", objOrigenArchivos.PathRecibed, FileUtil.FormatoArchivoRecepcionOrdenDebito(fechaProcesoActual)),
                                objOrigenArchivos.PathTo)
                            'si el archivo pudo copiarse, creamos registro en la tabla y lo marcamos como recibido
                            If copiado Then
                                _blMovimientoArchivos.InsertarRegistroMovimientoArchivo(objOrigenArchivos.Id, FileUtil.FormatoArchivoRecepcionOrdenDebito(fechaProcesoActual),
                                                                                fechaProcesoActual, Nothing, userName)
                            End If
                        End If

                    Case 363 'BCO - Deb. Directo - Recepcion Rechazos_VsN

                        If FileUtil.ExisteArchivo(String.Format("{0}\{1}", objOrigenArchivos.PathRecibed, FileUtil.FormatoArchivoRecepcionRechazo(fechaProcesoActual))) Then
                            copiado = FileUtil.CopiarArchivo(String.Format("{0}\{1}", objOrigenArchivos.PathRecibed, FileUtil.FormatoArchivoRecepcionRechazo(fechaProcesoActual)),
                                objOrigenArchivos.PathTo)
                            'si el archivo pudo copiarse, creamos registro en la tabla y lo marcamos como recibido
                            If copiado Then
                                _blMovimientoArchivos.InsertarRegistroMovimientoArchivo(objOrigenArchivos.Id, FileUtil.FormatoArchivoRecepcionRechazo(fechaProcesoActual),
                                                                                fechaProcesoActual, Nothing, userName)
                            End If
                        End If

                    Case 364 'BCO - Camara - Recepcion Rejects_VsN

                        If FileUtil.ExisteArchivo(String.Format("{0}\{1}", objOrigenArchivos.PathRecibed, FileUtil.FormatoArchivoRecepcionRejects(fechaProcesoActual))) Then
                            copiado = FileUtil.CopiarArchivo(String.Format("{0}\{1}", objOrigenArchivos.PathRecibed, FileUtil.FormatoArchivoRecepcionRejects(fechaProcesoActual)),
                                objOrigenArchivos.PathTo)
                            'si el archivo pudo copiarse, creamos registro en la tabla y lo marcamos como recibido
                            If copiado Then
                                _blMovimientoArchivos.InsertarRegistroMovimientoArchivo(objOrigenArchivos.Id, FileUtil.FormatoArchivoRecepcionRejects(fechaProcesoActual),
                                                                                fechaProcesoActual, Nothing, userName)
                            End If
                        End If

                End Select

            Next
            Return copiado
        End Function
    End Class
End Namespace
