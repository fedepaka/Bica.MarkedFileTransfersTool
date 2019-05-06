Imports Bica.MarkedFileTransfersTool.BusinessLayer
Imports Bica.MarkedFileTransfersTool.Model

Public Class frmDebitoDirectoRecibidos
    Private _datos As OrigenDestinoArchivos = New OrigenDestinoArchivos()
    Private bsListaOrigenArchivos As BindingSource = New BindingSource()
    Private bsListaRecibidos As BindingSource = New BindingSource()
    Private fechaProcesoActual As Date = Date.Now
    Private _fuente As String = "Microsoft Sans Serif"


    ''' <summary>
    ''' Evento principal de la ejecución del formulario
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarVistaFormulario()
        ConfigurarGrilla()
        CargarOrigenArchivos()
        CargarDatosArchivos()
    End Sub

    Private Sub CargarOrigenArchivos()
        Dim listaOrigenArchivoProceso = _datos.ObtenerOrigenDestinoArchivosPorRecibir()
        bsListaOrigenArchivos.DataSource = listaOrigenArchivoProceso
    End Sub

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

    Private Sub ConfigurarGrilla()
        Me.dgvArchivosRecibidos.AutoGenerateColumns = False
        Me.dgvArchivosRecibidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dgvArchivosRecibidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvArchivosRecibidos.MultiSelect = False
        Me.dgvArchivosRecibidos.ReadOnly = True
        Me.dgvArchivosRecibidos.AllowUserToAddRows = False
        Me.dgvArchivosRecibidos.AllowUserToResizeRows = False
        Me.dgvArchivosRecibidos.ClearSelection()
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

    Private Sub MostrarDatosFormulario(item As Procesos_OrigenDestinoArchivos)



        LimpiarDatosFormulario()

        If item IsNot Nothing Then
            lblNombreProceso.Text = item.ProcessName
            lblNumeroProceso.Text = item.ProcessNr
            lblUbicacionDestino.Text = item.PathTo
            lblUbicacionProcesado.Text = item.PathProcessed
            lblUbicacionRecibido.Text = item.PathRecibed
        End If
    End Sub

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

    Private Sub BtnUbicacionDestinoRecepcion_Click(sender As Object, e As EventArgs) Handles btnUbicacionDestinoRecepcion.Click
        If lblUbicacionDestino.Text IsNot String.Empty Then
            Process.Start(lblUbicacionDestino.Text)
        End If
    End Sub

    Private Sub BtnUbicacionProcesado_Click(sender As Object, e As EventArgs) Handles btnUbicacionProcesado.Click
        If lblUbicacionProcesado.Text IsNot String.Empty Then
            Process.Start(lblUbicacionProcesado.Text)
        End If
    End Sub
End Class