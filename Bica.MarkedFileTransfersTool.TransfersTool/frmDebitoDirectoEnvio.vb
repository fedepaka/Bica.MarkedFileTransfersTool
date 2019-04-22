Imports Bica.MarkedFileTransfersTool.BusinessLayer
Imports Bica.MarkedFileTransfersTool.Model

Public Class frmDebitoDirectoEnvio
    Private bindingSource1 As BindingSource = New BindingSource()

    Private _blDebitoDirecto As DebitoDirecto = New DebitoDirecto()
    Private fechaProcesoActual As Date = Date.Now
    Private _datos As OrigenDestinoArchivos = New OrigenDestinoArchivos()


    Private Sub CargarDatos()

        CargaDatosIniciales()
        ConfigurarFormulario(_datos.ObtenerOrigenDestinoArchivos(Model.Constants.BCO_Envio_Debito_Directo_Code))
        CargarDatosGrilla()
    End Sub

    Private Sub CargaDatosIniciales()

        _blDebitoDirecto.CargaArchivosDebitoDirecto(fechaProcesoActual)
    End Sub

    Public Sub CargarDatosGrilla()
        Dim _datos = New OrigenDestinoArchivos()
        Dim _blMovArchivos = New MovimientoArchivos()

        dgvOrigenDestinoArchivos.DataSource = bindingSource1
        'bindingSource1.DataSource = _datos.ObtenerOrigenDestinoArchivos(Model.Constants.BCO_Envio_Debito_Directo_Code)
        bindingSource1.DataSource = _blMovArchivos.ObtenerMovimientosArchivos(1, fechaProcesoActual)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatos()
    End Sub

    Private Sub ConfigurarFormulario(objOrigenArchivo As Procesos_OrigenDestinoArchivos)

        Me.dgvOrigenDestinoArchivos.AutoGenerateColumns = False
        Me.dgvOrigenDestinoArchivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvOrigenDestinoArchivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Me.lblFechaProceso.Text = "Fecha de proceso / envío"
        Me.txtFechaProceso.Text = DateTime.Now.ToString("dd/MM/yyyy")

        lblNombreProcesoTitulo.Text = "Nombre proceso:"
        lblNombreProceso.Text = "Débitos DirBCO - Envio Debito Directo"

        lblNumeroProcesoTitulo.Text = "Número proceso:"
        lblNumeroProceso.Text = objOrigenArchivo.ProcessNr

        lblPathFromTitulo.Text = "Path origen archivo:"
        lblPathFrom.Text = objOrigenArchivo.PathFrom

        lblPathToTitulo.Text = "Path destino archivo:"
        lblPathTo.Text = objOrigenArchivo.PathTo

        txtFechaProceso.ReadOnly = True

    End Sub

    Private Sub BtnCargarDatos_Click(sender As Object, e As EventArgs) Handles btnCargarDatos.Click
        Dim answer As DialogResult

        answer = MessageBox.Show("Desea efectuar carga de archivos", "hola", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            CargarDatos()
        End If

    End Sub
End Class


