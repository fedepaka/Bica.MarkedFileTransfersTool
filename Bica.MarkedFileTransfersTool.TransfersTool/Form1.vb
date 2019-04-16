Imports Bica.MarkedFileTransfersTool.BusinessLayer

Public Class Form1
    Private bindingSource1 As BindingSource = New BindingSource()
    Public Sub CargarDatosGrilla()
        Dim _datos = New OrigenDestinoArchivos()

        dgvOrigenDestinoArchivos.DataSource = bindingSource1
        bindingSource1.DataSource = _datos.ObtenerOrigenDestinoArchivos(Model.Constants.BCO_Envio_Debito_Directo_Code)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatosGrilla()
    End Sub
End Class


