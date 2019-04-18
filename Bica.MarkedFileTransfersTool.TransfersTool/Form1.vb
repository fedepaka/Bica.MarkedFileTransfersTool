Imports Bica.MarkedFileTransfersTool.BusinessLayer
Imports Bica.MarkedFileTransfersTool.Model

Public Class Form1
    Private bindingSource1 As BindingSource = New BindingSource()
    Private fechaActual As Date = DateTime.Now.Date
    Public Sub CargarDatosGrilla()
        Dim _datos = New OrigenDestinoArchivos()
        Dim _blMovArchivos = New MovimientoArchivos()

        dgvOrigenDestinoArchivos.DataSource = bindingSource1
        'bindingSource1.DataSource = _datos.ObtenerOrigenDestinoArchivos(Model.Constants.BCO_Envio_Debito_Directo_Code)
        bindingSource1.DataSource = _blMovArchivos.ObtenerMovimientosArchivos(1, fechaActual)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _datos = New OrigenDestinoArchivos()

        InicializarProceso()

        ConfigurarFormulario(_datos.ObtenerOrigenDestinoArchivos(Model.Constants.BCO_Envio_Debito_Directo_Code))


        Me.dgvOrigenDestinoArchivos.AutoGenerateColumns = False
        Me.dgvOrigenDestinoArchivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
        CargarDatosGrilla()

    End Sub

    Private Sub ConfigurarFormulario(objOrigenArchivo As Procesos_OrigenDestinoArchivos)

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
    End Sub

    ''' <summary>
    ''' Buscar los datos del archivo que se debe generar
    ''' </summary>
    Private Sub InicializarProceso()
        Dim _blDebitosDirectos = New DebitoDirecto()
        Dim objArchivos = _blDebitosDirectos.ObtenerDebitosDirectos(fechaActual)

        If objArchivos Is Nothing Then
            lblMensaje.Text = "No existen archivos físicos para transferir"
        End If

    End Sub
End Class


