Imports Bica.MarkedFileTransfersTool.BusinessLayer
Imports Bica.MarkedFileTransfersTool.Model

Public Class frmDebitoDirectoEnvio
    Private bindingSource1 As BindingSource = New BindingSource()

    Private _blDebitoDirecto As DebitoDirecto = New DebitoDirecto()
    Private fechaProcesoActual As Date = Date.Now
    Private _datos As OrigenDestinoArchivos = New OrigenDestinoArchivos()

    Private _fuente As String = "Microsoft Sans Serif"
    Private userName = "aRey"

    Private Sub CargarDatos()
        lblMensaje.Text = String.Empty
        Dim origenArchivoProceso = _datos.ObtenerOrigenDestinoArchivos(Model.Constants.BCO_Envio_Debito_Directo_Code)
        CargaDatosIniciales()
        ConfigurarFormulario(origenArchivoProceso)
        CargarDatosGrilla(origenArchivoProceso.Id)
    End Sub

    Private Sub CargaDatosIniciales()

        _blDebitoDirecto.CargaArchivosDebitoDirecto(fechaProcesoActual, userName)
    End Sub

    ''' <summary>
    ''' Obtiene los registros de archivos generados para el Proceso dado
    ''' </summary>
    ''' <param name="IdProceso">Es el Id de la tabla Procesos_OrigenDestinoArchivos. Referencia al identificador de la configuración del proceso</param>
    Public Sub CargarDatosGrilla(IdProceso As Long)
        Dim _datos = New OrigenDestinoArchivos()
        Dim _blMovArchivos = New MovimientoArchivos()

        dgvOrigenDestinoArchivos.DataSource = bindingSource1

        Dim listaMovimientos = _blMovArchivos.ObtenerMovimientosArchivos(IdProceso, fechaProcesoActual)

        If listaMovimientos.Count <= 0 Then
            lblMensaje.Text = Constants.Formulario_Msg_SinDatos
        End If

        bindingSource1.DataSource = listaMovimientos

    End Sub

    ''' <summary>
    ''' Evento principal de la ejecución del formulario
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatos()
    End Sub

    ''' <summary>
    ''' Configuración de títulos y encabezados visibles en el formulario
    ''' </summary>
    ''' <param name="objOrigenArchivo"></param>
    Private Sub ConfigurarFormulario(objOrigenArchivo As Procesos_OrigenDestinoArchivos)

        Me.dgvOrigenDestinoArchivos.AutoGenerateColumns = False
        Me.dgvOrigenDestinoArchivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvOrigenDestinoArchivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvOrigenDestinoArchivos.ClearSelection()

        Me.lblFechaProceso.Text = "Fecha de proceso / envío"
        Me.txtFechaProceso.Text = DateTime.Now.ToString("dd/MM/yyyy")

        lblNombreProcesoTitulo.Text = "Nombre proceso:"
        lblNombreProceso.Text = "Débitos DirBCO - Envio Debito Directo"

        lblNumeroProcesoTitulo.Text = "Número proceso:"
        lblNumeroProceso.Text = objOrigenArchivo.ProcessNr

        lblPathFromTitulo.Text = "Path origen archivo:"
        lblPathFrom.Text = objOrigenArchivo.PathFrom

        lblPathToTitulo.Text = "Path destino archivo:"
        lblPathTo.Text = objOrigenArchivo.PathSend

        txtFechaProceso.ReadOnly = True

        'mensaje de error
        lblMensaje.Font = New Font(_fuente, 10.0!, FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblMensaje.ForeColor = Color.Red
        lblMensaje.Text = String.Empty

        ConfigurarVistaFormulario()

    End Sub

    ''' <summary>
    ''' Configuración respecto al marco del formulario
    ''' </summary>
    Private Sub ConfigurarVistaFormulario()
        ' Define the border style of the form to a dialog box.
        Me.FormBorderStyle = FormBorderStyle.FixedDialog

        ' Set the MaximizeBox to false to remove the maximize box.
        Me.MaximizeBox = False

        'Set the MinimizeBox to false to remove the minimize box.
        Me.MinimizeBox = False

        ' Set the start position of the form to the center of the screen.
        Me.StartPosition = FormStartPosition.CenterScreen

        Me.Text = Model.Constants.Formulario_Titulo
    End Sub

    ''' <summary>
    ''' Recargar datos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnCargarDatos_Click(sender As Object, e As EventArgs) Handles btnCargarDatos.Click
        Dim answer As DialogResult

        answer = MessageBox.Show(Model.Constants.Dialogo_SiNo_Pregunta, Model.Constants.Dialogo_SiNo_Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If answer = vbYes Then
            CargarDatos()
        End If

    End Sub

    ''' <summary>
    ''' Marcar archivo para ser enviado 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DgvOrigenDestinoArchivos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrigenDestinoArchivos.CellClick

        Dim answer As DialogResult

        If e.ColumnIndex = 6 Then

            'si está marcada, no hacer nada
            Dim idMovimientoArchivo As Long = dgvOrigenDestinoArchivos.Item("Id", dgvOrigenDestinoArchivos.CurrentRow.Index).Value
            Dim _blMovArchivos = New MovimientoArchivos()
            Dim objMovArchivo = _blMovArchivos.ObtenerMovimientoArchivoPorId(idMovimientoArchivo)

            If Not objMovArchivo.Transferred And Not objMovArchivo.ToBeTransfer Then

                answer = MessageBox.Show("¿Desea marcar el archivo: " + dgvOrigenDestinoArchivos.Item("FileName", dgvOrigenDestinoArchivos.CurrentRow.Index).Value +
                " para ser enviado?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If answer = vbYes Then
                    Dim resUpdate = _blMovArchivos.ActualizarRegistroASerTransferido(idMovimientoArchivo, userName)
                End If
                CargarDatosGrilla(objMovArchivo.Procesos_OrigenDestinoArchivosId)
            End If
        End If




    End Sub
End Class


