Imports System.Configuration
Imports System.Threading

Module GlobalErrorHandler
    Private ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    Private Const MENSAJE_ERROR_POPUP As String = "MENSAJE_ERROR_POPUP"

    ''' <summary>
    ''' Propiedad para obtener la configuración si queremos ver error en popup
    ''' </summary>
    ''' <returns></returns>
    Private ReadOnly Property MostrarErrorPopup As Boolean
        Get
            Return Boolean.Parse(ConfigurationManager.AppSettings.[Get](MENSAJE_ERROR_POPUP))
        End Get
    End Property

    Sub Ensure()
        AddHandler Application.ThreadException, AddressOf OnApplicationUnhandledException
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf OnDomainUnhandledException
    End Sub

    Private Sub OnApplicationUnhandledException(ByVal sender As Object, ByVal e As ThreadExceptionEventArgs)
        HandleException(sender, e.Exception)
    End Sub

    Private Sub OnDomainUnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        HandleException(sender, CType(e.ExceptionObject, Exception))
    End Sub

    ''' <summary>
    ''' Cuando ocurre alguna excepción no controlada, se muestra mensaje de error por un popup
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="exp"></param>
    Private Sub HandleException(ByVal sender As Object, ByVal exp As Exception)
        log.Error("ERROR - Bica.MarkedFileTransfersTool.TransfersTool", exp)

        If MostrarErrorPopup Then
            Dim frmD As New frmMensajesError()
            frmD.MensajeError = exp.ToString()
            frmD.ShowDialog()
            frmD.Close()
        Else
            Dim lblError = Application.OpenForms.Item("frmDebitoDirectoEnvio").Controls.Item("lblMensaje")
            lblError.Text = String.Format("{0}", "Error no controlado. Verifique visor de eventos para mas detalle.")
        End If
    End Sub
End Module
