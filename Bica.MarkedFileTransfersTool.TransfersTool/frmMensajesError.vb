Public Class frmMensajesError

    Private _error As String = ""

    Public Property MensajeError() As String
        Get
            Return Me._error
        End Get
        Set(ByVal Value As String)
            Me._error = Value
            rtbMensajeError.Text = Me._error
        End Set
    End Property

    Private Sub ConfigurarVistaFormulario()
        ' Define the border style of the form to a dialog box.
        Me.FormBorderStyle = FormBorderStyle.FixedDialog

        ' Set the MaximizeBox to false to remove the maximize box.
        Me.MaximizeBox = False

        'Set the MinimizeBox to false to remove the minimize box.
        Me.MinimizeBox = False

        ' Set the start position of the form to the center of the screen.
        Me.StartPosition = FormStartPosition.CenterScreen

        Me.Text = Model.Constants.Formulario_Error_Titulo
    End Sub

    Private Sub frmMensajesError_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarVistaFormulario()
    End Sub
End Class