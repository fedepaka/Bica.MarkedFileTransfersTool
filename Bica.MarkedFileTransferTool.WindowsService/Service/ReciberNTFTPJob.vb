Imports Quartz
Imports Bica.MarkedFileTransfersTool.Model
Imports Bica.MarkedFileTransfersTool.BusinessLayer
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
                Console.ForegroundColor = ConsoleColor.Yellow
                Console.WriteLine(String.Format("Ejecución previa del JOB ReciberNTFTPJob: {0}.", lastRun))
            Else
                Console.ResetColor()
                Console.ForegroundColor = ConsoleColor.Yellow
                Console.WriteLine(String.Format("Ejecución inicial del JOB ReciberNTFTPJob: {0}.", context.FireTimeUtc.DateTime.ToString()))
            End If

            IniciarProcesoRecepcion()
            Return Task.FromResult(0)
        End Function

        Private Sub IniciarProcesoRecepcion()
            RecibirArchivosAsync()
        End Sub

        Private Function RecibirArchivosAsync() As Boolean
            Dim fatory = Task.Factory.StartNew(Function() RecibirArchivos())
            Return fatory.Result
        End Function

        Private Function RecibirArchivos() As Boolean
            Dim copiado As Boolean = False
            Dim objOrigenArchivosRecibir = _blOrigenDestinoArchivos.ObtenerOrigenDestinoArchivosPorRecibir()

            For Each objOrigenArchivos As Procesos_OrigenDestinoArchivos In objOrigenArchivosRecibir

                'verificar los tipos de archivos que nos interesan en este punto: PR0DD.426, PP0DD.426 y RJ0DD.426
                Select Case objOrigenArchivos.NumeroProceso
                    Case Constants.BCO_Camara_Recepcion_Orden_Debito_Code '355 - BCO - Camara - Recepcion Orden Debito_VsN

                        Dim patronArchivo = FileUtil.FormatoArchivoRecepcionOrdenDebito(fechaProcesoActual)
                        Dim nombreArchivo = FileUtil.ObtenerArchivoPorPatron(objOrigenArchivos.UbicacionNTFTPRecibir, patronArchivo)

                        If nombreArchivo IsNot String.Empty And nombreArchivo IsNot Nothing Then
                            Dim registroArchivo = _blMovimientoArchivos.ObtenerMovimientoArchivoPorNombre(nombreArchivo)

                            'si el registro del archivo no existe, vemos si está fisicamente e insertamos registro
                            If registroArchivo Is Nothing Then

                                copiado = FileUtil.CopiarArchivo(String.Format("{0}\{1}", objOrigenArchivos.UbicacionNTFTPRecibir, nombreArchivo), String.Format("{0}\{1}", objOrigenArchivos.UbicacionDestino, nombreArchivo))
                                'si el archivo pudo copiarse, creamos registro en la tabla y lo marcamos como recibido
                                If copiado Then
                                    Dim idMovArchivo = _blMovimientoArchivos.InsertarRegistroMovimientoArchivo(objOrigenArchivos.Id, nombreArchivo,
                                                                                    fechaProcesoActual.Date, Nothing, userName)
                                    _blMovimientoArchivos.ActualizarRegistroRecibido(idMovArchivo, userName)

                                End If
                            End If

                        End If

                    Case Constants.BCO_Debito_Directo_Recepcion_Rechazos_Code '363 - BCO - Deb. Directo - Recepcion Rechazos_VsN

                        Dim patronArchivo As String = FileUtil.FormatoArchivoRecepcionRechazo(fechaProcesoActual)
                        Dim nombreArchivo = FileUtil.ObtenerArchivoPorPatron(objOrigenArchivos.UbicacionNTFTPRecibir, patronArchivo)

                        If nombreArchivo IsNot String.Empty And nombreArchivo IsNot Nothing Then
                            Dim registroArchivo = _blMovimientoArchivos.ObtenerMovimientoArchivoPorNombre(nombreArchivo)

                            'si el registro del archivo no existe, vemos si está fisicamente e insertamos registro
                            If registroArchivo Is Nothing Then

                                copiado = FileUtil.CopiarArchivo(String.Format("{0}\{1}", objOrigenArchivos.UbicacionNTFTPRecibir, nombreArchivo), String.Format("{0}\{1}", objOrigenArchivos.UbicacionDestino, nombreArchivo))
                                'si el archivo pudo copiarse, creamos registro en la tabla y lo marcamos como recibido
                                If copiado Then
                                    Dim idMovArchivo = _blMovimientoArchivos.InsertarRegistroMovimientoArchivo(objOrigenArchivos.Id, nombreArchivo,
                                                                                    fechaProcesoActual.Date, Nothing, userName)
                                    _blMovimientoArchivos.ActualizarRegistroRecibido(idMovArchivo, userName)
                                End If

                            End If

                        End If

                    Case Constants.BCO_Camara_Recepcion_Rejects_Code 'BCO - Camara - Recepcion Rejects_VsN

                        Dim patronArchivo As String = FileUtil.FormatoArchivoRecepcionRejects(fechaProcesoActual)
                        Dim nombreArchivo = FileUtil.ObtenerArchivoPorPatron(objOrigenArchivos.UbicacionNTFTPRecibir, patronArchivo)

                        If nombreArchivo IsNot String.Empty And nombreArchivo IsNot Nothing Then

                            Dim registroArchivo = _blMovimientoArchivos.ObtenerMovimientoArchivoPorNombre(nombreArchivo)

                            If registroArchivo Is Nothing Then

                                copiado = FileUtil.CopiarArchivo(String.Format("{0}\{1}", objOrigenArchivos.UbicacionNTFTPRecibir, nombreArchivo), String.Format("{0}\{1}", objOrigenArchivos.UbicacionDestino, nombreArchivo))

                                'si el archivo pudo copiarse, creamos registro en la tabla y lo marcamos como recibido
                                If copiado Then
                                    Dim idMovArchivo = _blMovimientoArchivos.InsertarRegistroMovimientoArchivo(objOrigenArchivos.Id, nombreArchivo,
                                                                                fechaProcesoActual.Date, Nothing, userName)
                                    _blMovimientoArchivos.ActualizarRegistroRecibido(idMovArchivo, userName)
                                End If

                            End If

                        End If




                End Select

            Next
            Return copiado
        End Function

    End Class
End Namespace
