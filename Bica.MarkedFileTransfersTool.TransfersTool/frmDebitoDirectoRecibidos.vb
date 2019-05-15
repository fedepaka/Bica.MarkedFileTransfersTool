Imports System.Configuration
Imports Bica.MarkedFileTransfersTool.BusinessLayer
Imports Bica.MarkedFileTransfersTool.Model

Public Class frmDebitoDirectoRecibidos
    Private _datos As OrigenDestinoArchivos = New OrigenDestinoArchivos()
    Private bsListaOrigenArchivos As BindingSource = New BindingSource()
    Private bsListaRecibidos As BindingSource = New BindingSource()
    Private fechaProcesoActual As Date = Date.Now
    Private _fuente As String = "Microsoft Sans Serif"

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
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatos()
        TimerLoad()
    End Sub

    ''' <summary>
    ''' Método principal de carga de datos
    ''' </summary>
    Private Sub CargarDatos()
        ConfigurarVistaFormulario()
        ConfigurarGrilla()
        CargarOrigenArchivos()
        CargarDatosArchivos()
    End Sub

    ''' <summary>
    ''' Obtiene datos de orígenes de archivos
    ''' </summary>
    Private Sub CargarOrigenArchivos()
        Dim listaOrigenArchivoProceso = _datos.ObtenerOrigenDestinoArchivosPorRecibir()
        bsListaOrigenArchivos.DataSource = listaOrigenArchivoProceso
    End Sub

    ''' <summary>
    ''' Obtener datos de archivos recibidos
    ''' </summary>
    Private Sub CargarDatosArchivos()
        Dim listaOrigenArchivoProceso As List(Of Procesos_OrigenDestinoArchivos)
        dgvArchivosRecibidos.DataSource = bsListaRecibidos

        If bsListaOrigenArchivos.Count <= 0 Then
            listaOrigenArchivoProceso = _datos.ObtenerOrigenDestinoArchivosPorRecibir()
        Else
            listaOrigenArchivoProceso = bsListaOrigenArchivos.DataSource
        End If


        Dim Ids = New List(Of Long)

        For Each objODA As Procesos_OrigenDestinoArchivos In listaOrigenArchivoProceso

            Ids.Add(objODA.Id)
        Next

        Dim _blMovArchivos = New MovimientoArchivos()
        Dim listaArchivo = _blMovArchivos.ObtenerArchivosRecibidos(fechaProcesoActual, Ids.ToArray())

        If listaArchivo.Count <= 0 Then
            lblMensaje.Text = Constants.Formulario_Msg_SinDatosRecepcion
        End If

        bsListaRecibidos.DataSource = listaArchivo

    End Sub

    ''' <summary>
    ''' Configuración de aspecto de la grilla
    ''' </summary>
    Private Sub ConfigurarGrilla()
        Me.dgvArchivosRecibidos.AutoGenerateColumns = False
        Me.dgvArchivosRecibidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvArchivosRecibidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvArchivosRecibidos.MultiSelect = False
        Me.dgvArchivosRecibidos.ReadOnly = True
        Me.dgvArchivosRecibidos.AllowUserToAddRows = False
        Me.dgvArchivosRecibidos.AllowUserToResizeRows = False
        Me.dgvArchivosRecibidos.ClearSelection()
        dgvArchivosRecibidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        'mensaje de error
        lblMensaje.Font = New Font(_fuente, 10.0!, FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblMensaje.ForeColor = Color.Red
        lblMensaje.Text = String.Empty

        LimpiarDatosFormulario()
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

        Me.Text = Model.Constants.Formulario_Titulo_DebitoDirectoRecepcion
    End Sub

    ''' <summary>
    ''' Al seleccionar un archivo en la grilla, se muestra información relevante del mismo por pantalla
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DgvArchivosRecibidos_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArchivosRecibidos.RowEnter
        If e.RowIndex >= 0 Then
            Dim idOrigenArchivo = dgvArchivosRecibidos.Rows(e.RowIndex).Cells(1).Value

            If bsListaOrigenArchivos.Count > 0 Then
                Dim origenDestinoArchivos = bsListaOrigenArchivos.DataSource

                If origenDestinoArchivos IsNot Nothing Then
                    Dim lista = DirectCast(origenDestinoArchivos, List(Of Procesos_OrigenDestinoArchivos))
                    Dim item = (From i In lista Where i.Id = idOrigenArchivo Select i).FirstOrDefault()

                    MostrarDatosFormulario(item)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Mustra datos en pantalla de Origen / Destino de archivos
    ''' </summary>
    ''' <param name="item"></param>
    Private Sub MostrarDatosFormulario(item As Procesos_OrigenDestinoArchivos)

        LimpiarDatosFormulario()

        If item IsNot Nothing Then
            lblNombreProceso.Text = item.NombreProceso
            lblNumeroProceso.Text = item.NumeroProceso
            lblUbicacionDestino.Text = item.UbicacionDestino
            lblUbicacionProcesado.Text = item.UbicacionProcesado
            lblUbicacionRecibido.Text = item.UbicacionNTFTPRecibir
        End If
    End Sub

    ''' <summary>
    ''' Limpia datos del formulario
    ''' </summary>
    Private Sub LimpiarDatosFormulario()
        lblNombreProcesoTitulo.Text = "Nombre Proceso:"
        lblNumeroProcesoTitulo.Text = "Número Proceso:"
        lblUbicacionDestinoTitulo.Text = "Destino Archivo:"
        lblUbicacionProcesadoTitulo.Text = "Ubicación Procesado:"
        lblUbicacionRecibidoTitulo.Text = "Ubicación Recibido:"

        lblNombreProceso.Text = ""
        lblNumeroProceso.Text = ""
        lblUbicacionDestino.Text = ""
        lblUbicacionProcesado.Text = ""
        lblUbicacionRecibido.Text = ""
    End Sub

    ''' <summary>
    ''' Abrir carpeta donde se encuentran los archivos recibidos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnUbicacionDestinoRecepcion_Click(sender As Object, e As EventArgs) Handles btnUbicacionDestinoRecepcion.Click
        If lblUbicacionDestino.Text IsNot String.Empty Then
            Process.Start(lblUbicacionDestino.Text)
        End If
    End Sub

    ''' <summary>
    ''' Abrir la carpeta donde se encuentran los archivos procesados
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BtnUbicacionProcesado_Click(sender As Object, e As EventArgs) Handles btnUbicacionProcesado.Click
        If lblUbicacionProcesado.Text IsNot String.Empty Then
            Process.Start(lblUbicacionProcesado.Text)
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