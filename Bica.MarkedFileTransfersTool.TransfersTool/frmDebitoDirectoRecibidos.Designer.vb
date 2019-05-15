<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDebitoDirectoRecibidos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgvArchivosRecibidos = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnUbicacionProcesado = New System.Windows.Forms.Button()
        Me.btnUbicacionDestinoRecepcion = New System.Windows.Forms.Button()
        Me.lblUbicacionProcesado = New System.Windows.Forms.Label()
        Me.lblUbicacionProcesadoTitulo = New System.Windows.Forms.Label()
        Me.lblUbicacionDestino = New System.Windows.Forms.Label()
        Me.lblUbicacionDestinoTitulo = New System.Windows.Forms.Label()
        Me.lblUbicacionRecibido = New System.Windows.Forms.Label()
        Me.lblUbicacionRecibidoTitulo = New System.Windows.Forms.Label()
        Me.lblNumeroProcesoTitulo = New System.Windows.Forms.Label()
        Me.lblNumeroProceso = New System.Windows.Forms.Label()
        Me.lblNombreProcesoTitulo = New System.Windows.Forms.Label()
        Me.lblNombreProceso = New System.Windows.Forms.Label()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Procesos_OrigenDestinoArchivosId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaPresentacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recibido = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Procesado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dgvArchivosRecibidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvArchivosRecibidos
        '
        Me.dgvArchivosRecibidos.AllowUserToAddRows = False
        Me.dgvArchivosRecibidos.AllowUserToDeleteRows = False
        Me.dgvArchivosRecibidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArchivosRecibidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Procesos_OrigenDestinoArchivosId, Me.NombreArchivo, Me.FechaPresentacion, Me.Recibido, Me.Procesado})
        Me.dgvArchivosRecibidos.Location = New System.Drawing.Point(36, 277)
        Me.dgvArchivosRecibidos.Name = "dgvArchivosRecibidos"
        Me.dgvArchivosRecibidos.ReadOnly = True
        Me.dgvArchivosRecibidos.Size = New System.Drawing.Size(675, 150)
        Me.dgvArchivosRecibidos.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnUbicacionProcesado)
        Me.GroupBox1.Controls.Add(Me.btnUbicacionDestinoRecepcion)
        Me.GroupBox1.Controls.Add(Me.lblUbicacionProcesado)
        Me.GroupBox1.Controls.Add(Me.lblUbicacionProcesadoTitulo)
        Me.GroupBox1.Controls.Add(Me.lblUbicacionDestino)
        Me.GroupBox1.Controls.Add(Me.lblUbicacionDestinoTitulo)
        Me.GroupBox1.Controls.Add(Me.lblUbicacionRecibido)
        Me.GroupBox1.Controls.Add(Me.lblUbicacionRecibidoTitulo)
        Me.GroupBox1.Controls.Add(Me.lblNumeroProcesoTitulo)
        Me.GroupBox1.Controls.Add(Me.lblNumeroProceso)
        Me.GroupBox1.Controls.Add(Me.lblNombreProcesoTitulo)
        Me.GroupBox1.Controls.Add(Me.lblNombreProceso)
        Me.GroupBox1.Location = New System.Drawing.Point(36, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(675, 170)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de proceso "
        '
        'btnUbicacionProcesado
        '
        Me.btnUbicacionProcesado.Location = New System.Drawing.Point(578, 134)
        Me.btnUbicacionProcesado.Name = "btnUbicacionProcesado"
        Me.btnUbicacionProcesado.Size = New System.Drawing.Size(75, 23)
        Me.btnUbicacionProcesado.TabIndex = 18
        Me.btnUbicacionProcesado.Text = "ir"
        Me.btnUbicacionProcesado.UseVisualStyleBackColor = True
        '
        'btnUbicacionDestinoRecepcion
        '
        Me.btnUbicacionDestinoRecepcion.Location = New System.Drawing.Point(578, 105)
        Me.btnUbicacionDestinoRecepcion.Name = "btnUbicacionDestinoRecepcion"
        Me.btnUbicacionDestinoRecepcion.Size = New System.Drawing.Size(75, 23)
        Me.btnUbicacionDestinoRecepcion.TabIndex = 17
        Me.btnUbicacionDestinoRecepcion.Text = "ir"
        Me.btnUbicacionDestinoRecepcion.UseVisualStyleBackColor = True
        '
        'lblUbicacionProcesado
        '
        Me.lblUbicacionProcesado.AutoSize = True
        Me.lblUbicacionProcesado.Location = New System.Drawing.Point(212, 145)
        Me.lblUbicacionProcesado.Name = "lblUbicacionProcesado"
        Me.lblUbicacionProcesado.Size = New System.Drawing.Size(116, 13)
        Me.lblUbicacionProcesado.TabIndex = 15
        Me.lblUbicacionProcesado.Text = "lblUbicacionProcesado"
        '
        'lblUbicacionProcesadoTitulo
        '
        Me.lblUbicacionProcesadoTitulo.AutoSize = True
        Me.lblUbicacionProcesadoTitulo.Location = New System.Drawing.Point(17, 145)
        Me.lblUbicacionProcesadoTitulo.Name = "lblUbicacionProcesadoTitulo"
        Me.lblUbicacionProcesadoTitulo.Size = New System.Drawing.Size(142, 13)
        Me.lblUbicacionProcesadoTitulo.TabIndex = 14
        Me.lblUbicacionProcesadoTitulo.Text = "lblUbicacionProcesadoTitulo"
        '
        'lblUbicacionDestino
        '
        Me.lblUbicacionDestino.AutoSize = True
        Me.lblUbicacionDestino.Location = New System.Drawing.Point(212, 115)
        Me.lblUbicacionDestino.Name = "lblUbicacionDestino"
        Me.lblUbicacionDestino.Size = New System.Drawing.Size(101, 13)
        Me.lblUbicacionDestino.TabIndex = 13
        Me.lblUbicacionDestino.Text = "lblUbicacionDestino"
        '
        'lblUbicacionDestinoTitulo
        '
        Me.lblUbicacionDestinoTitulo.AutoSize = True
        Me.lblUbicacionDestinoTitulo.Location = New System.Drawing.Point(17, 115)
        Me.lblUbicacionDestinoTitulo.Name = "lblUbicacionDestinoTitulo"
        Me.lblUbicacionDestinoTitulo.Size = New System.Drawing.Size(127, 13)
        Me.lblUbicacionDestinoTitulo.TabIndex = 12
        Me.lblUbicacionDestinoTitulo.Text = "lblUbicacionDestinoTitulo"
        '
        'lblUbicacionRecibido
        '
        Me.lblUbicacionRecibido.AutoSize = True
        Me.lblUbicacionRecibido.Location = New System.Drawing.Point(212, 87)
        Me.lblUbicacionRecibido.Name = "lblUbicacionRecibido"
        Me.lblUbicacionRecibido.Size = New System.Drawing.Size(107, 13)
        Me.lblUbicacionRecibido.TabIndex = 11
        Me.lblUbicacionRecibido.Text = "lblUbicacionRecibido"
        '
        'lblUbicacionRecibidoTitulo
        '
        Me.lblUbicacionRecibidoTitulo.AutoSize = True
        Me.lblUbicacionRecibidoTitulo.Location = New System.Drawing.Point(17, 87)
        Me.lblUbicacionRecibidoTitulo.Name = "lblUbicacionRecibidoTitulo"
        Me.lblUbicacionRecibidoTitulo.Size = New System.Drawing.Size(133, 13)
        Me.lblUbicacionRecibidoTitulo.TabIndex = 10
        Me.lblUbicacionRecibidoTitulo.Text = "lblUbicacionRecibidoTitulo"
        '
        'lblNumeroProcesoTitulo
        '
        Me.lblNumeroProcesoTitulo.AutoSize = True
        Me.lblNumeroProcesoTitulo.Location = New System.Drawing.Point(17, 57)
        Me.lblNumeroProcesoTitulo.Name = "lblNumeroProcesoTitulo"
        Me.lblNumeroProcesoTitulo.Size = New System.Drawing.Size(119, 13)
        Me.lblNumeroProcesoTitulo.TabIndex = 9
        Me.lblNumeroProcesoTitulo.Text = "lblNumeroProcesoTitulo"
        '
        'lblNumeroProceso
        '
        Me.lblNumeroProceso.AutoSize = True
        Me.lblNumeroProceso.Location = New System.Drawing.Point(212, 57)
        Me.lblNumeroProceso.Name = "lblNumeroProceso"
        Me.lblNumeroProceso.Size = New System.Drawing.Size(93, 13)
        Me.lblNumeroProceso.TabIndex = 8
        Me.lblNumeroProceso.Text = "lblNumeroProceso"
        '
        'lblNombreProcesoTitulo
        '
        Me.lblNombreProcesoTitulo.AutoSize = True
        Me.lblNombreProcesoTitulo.Location = New System.Drawing.Point(17, 25)
        Me.lblNombreProcesoTitulo.Name = "lblNombreProcesoTitulo"
        Me.lblNombreProcesoTitulo.Size = New System.Drawing.Size(119, 13)
        Me.lblNombreProcesoTitulo.TabIndex = 7
        Me.lblNombreProcesoTitulo.Text = "lblNombreProcesoTitulo"
        '
        'lblNombreProceso
        '
        Me.lblNombreProceso.AutoSize = True
        Me.lblNombreProceso.Location = New System.Drawing.Point(212, 25)
        Me.lblNombreProceso.Name = "lblNombreProceso"
        Me.lblNombreProceso.Size = New System.Drawing.Size(93, 13)
        Me.lblNombreProceso.TabIndex = 6
        Me.lblNombreProceso.Text = "lblNombreProceso"
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.BackColor = System.Drawing.SystemColors.Control
        Me.lblMensaje.Location = New System.Drawing.Point(33, 243)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(47, 13)
        Me.lblMensaje.TabIndex = 8
        Me.lblMensaje.Text = "Mensaje"
        '
        'Id
        '
        Me.Id.DataPropertyName = "Id"
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        '
        'Procesos_OrigenDestinoArchivosId
        '
        Me.Procesos_OrigenDestinoArchivosId.DataPropertyName = "Procesos_OrigenDestinoArchivosId"
        Me.Procesos_OrigenDestinoArchivosId.HeaderText = "Procesos_OrigenDestinoArchivosId"
        Me.Procesos_OrigenDestinoArchivosId.Name = "Procesos_OrigenDestinoArchivosId"
        Me.Procesos_OrigenDestinoArchivosId.ReadOnly = True
        Me.Procesos_OrigenDestinoArchivosId.Visible = False
        '
        'NombreArchivo
        '
        Me.NombreArchivo.DataPropertyName = "NombreArchivo"
        Me.NombreArchivo.HeaderText = "Nombre Archivo"
        Me.NombreArchivo.Name = "NombreArchivo"
        Me.NombreArchivo.ReadOnly = True
        '
        'FechaPresentacion
        '
        Me.FechaPresentacion.DataPropertyName = "FechaPresentacion"
        Me.FechaPresentacion.HeaderText = "Fecha"
        Me.FechaPresentacion.Name = "FechaPresentacion"
        Me.FechaPresentacion.ReadOnly = True
        '
        'Recibido
        '
        Me.Recibido.DataPropertyName = "Recibido"
        Me.Recibido.HeaderText = "Recibido"
        Me.Recibido.Name = "Recibido"
        Me.Recibido.ReadOnly = True
        Me.Recibido.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Recibido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Procesado
        '
        Me.Procesado.DataPropertyName = "Procesado"
        Me.Procesado.HeaderText = "Procesado"
        Me.Procesado.Name = "Procesado"
        Me.Procesado.ReadOnly = True
        '
        'frmDebitoDirectoRecibidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 450)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvArchivosRecibidos)
        Me.Name = "frmDebitoDirectoRecibidos"
        Me.Text = "frmDebitoDirectoRecibidos"
        CType(Me.dgvArchivosRecibidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvArchivosRecibidos As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblUbicacionProcesado As Label
    Friend WithEvents lblUbicacionProcesadoTitulo As Label
    Friend WithEvents lblUbicacionDestino As Label
    Friend WithEvents lblUbicacionDestinoTitulo As Label
    Friend WithEvents lblUbicacionRecibido As Label
    Friend WithEvents lblUbicacionRecibidoTitulo As Label
    Friend WithEvents lblNumeroProcesoTitulo As Label
    Friend WithEvents lblNumeroProceso As Label
    Friend WithEvents lblNombreProcesoTitulo As Label
    Friend WithEvents lblNombreProceso As Label
    Friend WithEvents lblMensaje As Label
    Friend WithEvents btnUbicacionProcesado As Button
    Friend WithEvents btnUbicacionDestinoRecepcion As Button
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents Procesos_OrigenDestinoArchivosId As DataGridViewTextBoxColumn
    Friend WithEvents NombreArchivo As DataGridViewTextBoxColumn
    Friend WithEvents FechaPresentacion As DataGridViewTextBoxColumn
    Friend WithEvents Recibido As DataGridViewCheckBoxColumn
    Friend WithEvents Procesado As DataGridViewCheckBoxColumn
End Class
