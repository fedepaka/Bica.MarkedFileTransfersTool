Imports System.Configuration
Imports Bica.MarkedFileTransfersTool.BusinessLayer
Imports Bica.MarkedFileTransfersTool.Model

Public Class frmDebitoDirectoEnvio

    Private bindingSource1 As BindingSource = New BindingSource()
    Private _blDebitoDirecto As DebitoDirecto = New DebitoDirecto()
    Private fechaProcesoActual As Date = Date.Now
    Private _datos As OrigenDestinoArchivos = New OrigenDestinoArchivos()

    Private _fuente As String = "Microsoft Sans Serif"
    Private userName = "aRey"

    Private Const TIEMPO_RECARGA_GRILLA_DATOS As String = "TIEMPO_RECARGA_GRILLA_DATOS"

    ''' <summary>
    ''' Propiedad para obtener el tiempo de refresco/obtención de datos de forma automática
    ''' </summary>
    ''' <returns></returns>
    Private Shared ReadOnly Property RecargaGrillaDatosTime As Integer
        Get
            Return Integer.Parse(ConfigurationManager.AppSettings.[Get](TIEMPO_RECARGA_GRILLA_DATOS))
        End Get
    End Property

    ''' <summary>
    ''' Evento principal de la ejecución del formulario
    ''' </summary>
    Private Sub CargarDatos()
        lblMensaje.Text = String.Empty
        Dim origenArchivoProceso = _datos.ObtenerOrigenDestinoArchivos(Model.Constants.BCO_Envio_Debito_Directo_Code)
        CargaDatosIniciales()
        ConfigurarFormulario(origenArchivoProceso)
        CargarDatosGrilla()
    End Sub

    ''' <summary>
    ''' Inicialización de datos de débito directo
    ''' </summary>
    Private Sub CargaDatosIniciales()

        _blDebitoDirecto.CargaArchivosDebitoDirecto(fechaProcesoActual, userName)
    End Sub

    ''' <summary>
    ''' Obtener datos de archivos de envío para la fecha actual de proceso y mostrar en grilla
    ''' </summary>
    Public Sub CargarDatosGrilla()
        Dim _datos = New OrigenDestinoArchivos()
        Dim _blMovArchivos = New MovimientoArchivos()
        Dim listaMovimientos As List(Of Procesos_MovimientoArchivos) = New List(Of Procesos_MovimientoArchivos)
        dgvOrigenDestinoArchivos.DataSource = bindingSource1

        Dim objProcesoLista = _datos.ObtenerOrigenDestinoArchivosPorEnviar()

        For Each objProceso As Procesos_OrigenDestinoArchivos In objProcesoLista
            Dim idProc = _datos.ObtenerOrigenDestinoArchivos(objProceso.NumeroProceso).Id

            Dim listaAux = _blMovArchivos.ObtenerMovimientosArchivos(idProc, fechaProcesoActual)
            listaMovimientos.AddRange(listaAux)
        Next

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
        TimerLoad()
    End Sub

    ''' <summary>
    ''' Configuración de títulos y encabezados visibles en el formulario
    ''' </summary>
    ''' <param name="objOrigenArchivo"></param>
    Private Sub ConfigurarFormulario(objOrigenArchivo As Procesos_OrigenDestinoArchivos)

        Me.dgvOrigenDestinoArchivos.AutoGenerateColumns = False
        Me.dgvOrigenDestinoArchivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvOrigenDestinoArchivos.ClearSelection()
        dgvOrigenDestinoArchivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Me.lblFechaProceso.Text = "Fecha de proceso / envío"
        Me.txtFechaProceso.Text = DateTime.Now.ToString("dd/MM/yyyy")

        lblNombreProcesoTitulo.Text = "Nombre proceso:"
        lblNombreProceso.Text = "Débitos DirBCO - Envio Debito Directo"

        lblNumeroProcesoTitulo.Text = "Número proceso:"
        lblNumeroProceso.Text = objOrigenArchivo.NumeroProceso

        lblPathFromTitulo.Text = "Path origen archivo:"
        lblPathFrom.Text = objOrigenArchivo.UbicacionDesde

        lblPathToTitulo.Text = "Path destino archivo:"
        lblPathTo.Text = objOrigenArchivo.UbicacionNTFTPEnviar

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

        Me.Text = Model.Constants.Formulario_Titulo_DebitoDirectoEnvio
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

            If Not objMovArchivo.Transferido And Not objMovArchivo.ParaTransferir Then

                answer = MessageBox.Show("¿Desea marcar el archivo: " + dgvOrigenDestinoArchivos.Item("FileName", dgvOrigenDestinoArchivos.CurrentRow.Index).Value +
                " para ser enviado?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If answer = vbYes Then
                    Dim resUpdate = _blMovArchivos.ActualizarRegistroASerTransferido(idMovimientoArchivo, userName)
                End If
                CargarDatosGrilla()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Muestra formulario donde se visualiza los archivos recibidos desde la cámara COELSA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnVerRecibidos_Click(sender As Object, e As EventArgs) Handles btnVerRecibidos.Click
        Dim frmRecibidos = New frmDebitoDirectoRecibidos()
        frmRecibidos.ShowDialog()
        frmRecibidos.Close()
    End Sub

    ''' <summary>
    ''' Abre la carpeta donde se ubican el origen de los archivos para enviar a cámara
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnIrUbicacionDesde_Click(sender As Object, e As EventArgs) Handles btnIrUbicacionDesde.Click
        If lblPathFrom.Text IsNot String.Empty Then
            Process.Start(lblPathFrom.Text)
        End If
    End Sub

    ''' <summary>
    ''' Inicialización y ejecución del timer
    ''' </summary>
    Private Sub TimerLoad()
        Dim timer As Timer = New Timer()
        timer.Interval = (RecargaGrillaDatosTime)

        AddHandler timer.Tick, AddressOf timer_Tick
        timer.Start()
    End Sub

    ''' <summary>
    ''' Evento que se ejecuta cuando vence el timer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        CargarDatos()
    End Sub
End Class


