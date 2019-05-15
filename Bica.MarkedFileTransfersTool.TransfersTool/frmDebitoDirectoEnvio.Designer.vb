<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDebitoDirectoEnvio
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
        Me.dgvOrigenDestinoArchivos = New System.Windows.Forms.DataGridView()
        Me.lblFechaProceso = New System.Windows.Forms.Label()
        Me.txtFechaProceso = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnIrUbicacionDesde = New System.Windows.Forms.Button()
        Me.lblPathTo = New System.Windows.Forms.Label()
        Me.lblPathToTitulo = New System.Windows.Forms.Label()
        Me.lblPathFrom = New System.Windows.Forms.Label()
        Me.lblPathFromTitulo = New System.Windows.Forms.Label()
        Me.lblNumeroProcesoTitulo = New System.Windows.Forms.Label()
        Me.lblNumeroProceso = New System.Windows.Forms.Label()
        Me.lblNombreProcesoTitulo = New System.Windows.Forms.Label()
        Me.lblNombreProceso = New System.Windows.Forms.Label()
        Me.btnCargarDatos = New System.Windows.Forms.Button()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.btnVerRecibidos = New System.Windows.Forms.Button()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresentationDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomParaTransferirCopiado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ParaTransferir = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FechaModificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAction = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.dgvOrigenDestinoArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvOrigenDestinoArchivos
        '
        Me.dgvOrigenDestinoArchivos.AllowUserToAddRows = False
        Me.dgvOrigenDestinoArchivos.AllowUserToDeleteRows = False
        'Me.dgvOrigenDestinoArchivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        'Me.dgvOrigenDestinoArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrigenDestinoArchivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.FileName, Me.PresentationDate, Me.CustomParaTransferirCopiado, Me.ParaTransferir, Me.FechaModificacion, Me.btnAction})
        Me.dgvOrigenDestinoArchivos.Location = New System.Drawing.Point(55, 288)
        Me.dgvOrigenDestinoArchivos.Name = "dgvOrigenDestinoArchivos"
        Me.dgvOrigenDestinoArchivos.ReadOnly = True
        Me.dgvOrigenDestinoArchivos.Size = New System.Drawing.Size(785, 150)
        Me.dgvOrigenDestinoArchivos.TabIndex = 0
        '
        'lblFechaProceso
        '
        Me.lblFechaProceso.AutoSize = True
        Me.lblFechaProceso.Location = New System.Drawing.Point(55, 25)
        Me.lblFechaProceso.Name = "lblFechaProceso"
        Me.lblFechaProceso.Size = New System.Drawing.Size(86, 13)
        Me.lblFechaProceso.TabIndex = 2
        Me.lblFechaProceso.Text = "lblFechaProceso"
        '
        'txtFechaProceso
        '
        Me.txtFechaProceso.Location = New System.Drawing.Point(322, 22)
        Me.txtFechaProceso.Name = "txtFechaProceso"
        Me.txtFechaProceso.Size = New System.Drawing.Size(136, 20)
        Me.txtFechaProceso.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnIrUbicacionDesde)
        Me.GroupBox1.Controls.Add(Me.lblPathTo)
        Me.GroupBox1.Controls.Add(Me.lblPathToTitulo)
        Me.GroupBox1.Controls.Add(Me.lblPathFrom)
        Me.GroupBox1.Controls.Add(Me.lblPathFromTitulo)
        Me.GroupBox1.Controls.Add(Me.lblNumeroProcesoTitulo)
        Me.GroupBox1.Controls.Add(Me.lblNumeroProceso)
        Me.GroupBox1.Controls.Add(Me.lblNombreProcesoTitulo)
        Me.GroupBox1.Controls.Add(Me.lblNombreProceso)
        Me.GroupBox1.Location = New System.Drawing.Point(55, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(785, 170)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de proceso "
        '
        'btnIrUbicacionDesde
        '
        Me.btnIrUbicacionDesde.Location = New System.Drawing.Point(578, 77)
        Me.btnIrUbicacionDesde.Name = "btnIrUbicacionDesde"
        Me.btnIrUbicacionDesde.Size = New System.Drawing.Size(75, 23)
        Me.btnIrUbicacionDesde.TabIndex = 17
        Me.btnIrUbicacionDesde.Text = "ir"
        Me.btnIrUbicacionDesde.UseVisualStyleBackColor = True
        '
        'lblPathTo
        '
        Me.lblPathTo.AutoSize = True
        Me.lblPathTo.Location = New System.Drawing.Point(130, 115)
        Me.lblPathTo.Name = "lblPathTo"
        Me.lblPathTo.Size = New System.Drawing.Size(41, 13)
        Me.lblPathTo.TabIndex = 13
        Me.lblPathTo.Text = "pathTo"
        '
        'lblPathToTitulo
        '
        Me.lblPathToTitulo.AutoSize = True
        Me.lblPathToTitulo.Location = New System.Drawing.Point(17, 115)
        Me.lblPathToTitulo.Name = "lblPathToTitulo"
        Me.lblPathToTitulo.Size = New System.Drawing.Size(41, 13)
        Me.lblPathToTitulo.TabIndex = 12
        Me.lblPathToTitulo.Text = "pathTo"
        '
        'lblPathFrom
        '
        Me.lblPathFrom.AutoSize = True
        Me.lblPathFrom.Location = New System.Drawing.Point(130, 87)
        Me.lblPathFrom.Name = "lblPathFrom"
        Me.lblPathFrom.Size = New System.Drawing.Size(51, 13)
        Me.lblPathFrom.TabIndex = 11
        Me.lblPathFrom.Text = "pathFrom"
        '
        'lblPathFromTitulo
        '
        Me.lblPathFromTitulo.AutoSize = True
        Me.lblPathFromTitulo.Location = New System.Drawing.Point(17, 87)
        Me.lblPathFromTitulo.Name = "lblPathFromTitulo"
        Me.lblPathFromTitulo.Size = New System.Drawing.Size(51, 13)
        Me.lblPathFromTitulo.TabIndex = 10
        Me.lblPathFromTitulo.Text = "pathFrom"
        '
        'lblNumeroProcesoTitulo
        '
        Me.lblNumeroProcesoTitulo.AutoSize = True
        Me.lblNumeroProcesoTitulo.Location = New System.Drawing.Point(17, 57)
        Me.lblNumeroProcesoTitulo.Name = "lblNumeroProcesoTitulo"
        Me.lblNumeroProcesoTitulo.Size = New System.Drawing.Size(44, 13)
        Me.lblNumeroProcesoTitulo.TabIndex = 9
        Me.lblNumeroProcesoTitulo.Text = "Número"
        '
        'lblNumeroProceso
        '
        Me.lblNumeroProceso.AutoSize = True
        Me.lblNumeroProceso.Location = New System.Drawing.Point(130, 57)
        Me.lblNumeroProceso.Name = "lblNumeroProceso"
        Me.lblNumeroProceso.Size = New System.Drawing.Size(39, 13)
        Me.lblNumeroProceso.TabIndex = 8
        Me.lblNumeroProceso.Text = "Label1"
        '
        'lblNombreProcesoTitulo
        '
        Me.lblNombreProcesoTitulo.AutoSize = True
        Me.lblNombreProcesoTitulo.Location = New System.Drawing.Point(17, 25)
        Me.lblNombreProcesoTitulo.Name = "lblNombreProcesoTitulo"
        Me.lblNombreProcesoTitulo.Size = New System.Drawing.Size(47, 13)
        Me.lblNombreProcesoTitulo.TabIndex = 7
        Me.lblNombreProcesoTitulo.Text = "Nombre:"
        '
        'lblNombreProceso
        '
        Me.lblNombreProceso.AutoSize = True
        Me.lblNombreProceso.Location = New System.Drawing.Point(130, 25)
        Me.lblNombreProceso.Name = "lblNombreProceso"
        Me.lblNombreProceso.Size = New System.Drawing.Size(39, 13)
        Me.lblNombreProceso.TabIndex = 6
        Me.lblNombreProceso.Text = "Label1"
        '
        'btnCargarDatos
        '
        Me.btnCargarDatos.Location = New System.Drawing.Point(613, 25)
        Me.btnCargarDatos.Name = "btnCargarDatos"
        Me.btnCargarDatos.Size = New System.Drawing.Size(75, 23)
        Me.btnCargarDatos.TabIndex = 6
        Me.btnCargarDatos.Text = "Cargar Datos"
        Me.btnCargarDatos.UseVisualStyleBackColor = True
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.BackColor = System.Drawing.SystemColors.Control
        Me.lblMensaje.Location = New System.Drawing.Point(52, 235)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(47, 13)
        Me.lblMensaje.TabIndex = 7
        Me.lblMensaje.Text = "Mensaje"
        '
        'btnVerRecibidos
        '
        Me.btnVerRecibidos.Location = New System.Drawing.Point(712, 25)
        Me.btnVerRecibidos.Name = "btnVerRecibidos"
        Me.btnVerRecibidos.Size = New System.Drawing.Size(128, 23)
        Me.btnVerRecibidos.TabIndex = 8
        Me.btnVerRecibidos.Text = "Ver archivos recibidos"
        Me.btnVerRecibidos.UseVisualStyleBackColor = True
        '
        'ID
        '
        Me.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ID.DataPropertyName = "Id"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'FileName
        '
        Me.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.FileName.DataPropertyName = "NombreArchivo"
        Me.FileName.FillWeight = 27.63732!
        Me.FileName.HeaderText = "Nombre Archivo"
        Me.FileName.Name = "FileName"
        Me.FileName.ReadOnly = True
        'Me.FileName.Width = 99
        '
        'PresentationDate
        '
        Me.PresentationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PresentationDate.DataPropertyName = "FechaPresentacion"
        Me.PresentationDate.FillWeight = 110.3141!
        Me.PresentationDate.HeaderText = "Fecha Presentación"
        Me.PresentationDate.Name = "PresentationDate"
        Me.PresentationDate.ReadOnly = True
        'Me.PresentationDate.Width = 116
        '
        'CustomParaTransferirCopiado
        '
        Me.CustomParaTransferirCopiado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CustomParaTransferirCopiado.DataPropertyName = "CustomParaTransferirCopiado"
        Me.CustomParaTransferirCopiado.FillWeight = 1.731939!
        Me.CustomParaTransferirCopiado.HeaderText = "Por Transferir"
        Me.CustomParaTransferirCopiado.Name = "CustomParaTransferirCopiado"
        Me.CustomParaTransferirCopiado.ReadOnly = True
        Me.CustomParaTransferirCopiado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CustomParaTransferirCopiado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        'Me.CustomParaTransferirCopiado.Width = 87
        '
        'ParaTransferir
        '
        Me.ParaTransferir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ParaTransferir.DataPropertyName = "Transferido"
        Me.ParaTransferir.FillWeight = 1.731939!
        Me.ParaTransferir.HeaderText = "Transferido"
        Me.ParaTransferir.Name = "ParaTransferir"
        Me.ParaTransferir.ReadOnly = True
        Me.ParaTransferir.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ParaTransferir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        'Me.ParaTransferir.Width = 85
        '
        'FechaModificacion
        '
        Me.FechaModificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.FechaModificacion.DataPropertyName = "FechaModificacion"
        Me.FechaModificacion.FillWeight = 456.8528!
        Me.FechaModificacion.HeaderText = "Fecha Transferido"
        Me.FechaModificacion.Name = "FechaModificacion"
        Me.FechaModificacion.ReadOnly = True
        'Me.FechaModificacion.Width = 108
        '
        'btnAction
        '
        Me.btnAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.btnAction.FillWeight = 1.731939!
        Me.btnAction.HeaderText = "Acción"
        Me.btnAction.Name = "btnAction"
        Me.btnAction.ReadOnly = True
        Me.btnAction.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btnAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.btnAction.Text = "Seleccionar"
        Me.btnAction.UseColumnTextForButtonValue = True
        'Me.btnAction.Width = 65
        '
        'frmDebitoDirectoEnvio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 450)
        Me.Controls.Add(Me.btnVerRecibidos)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.btnCargarDatos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtFechaProceso)
        Me.Controls.Add(Me.lblFechaProceso)
        Me.Controls.Add(Me.dgvOrigenDestinoArchivos)
        Me.MaximizeBox = False
        Me.Name = "frmDebitoDirectoEnvio"
        Me.Text = "Form1"
        CType(Me.dgvOrigenDestinoArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvOrigenDestinoArchivos As DataGridView
    Friend WithEvents lblFechaProceso As Label
    Friend WithEvents txtFechaProceso As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblPathTo As Label
    Friend WithEvents lblPathToTitulo As Label
    Friend WithEvents lblPathFrom As Label
    Friend WithEvents lblPathFromTitulo As Label
    Friend WithEvents lblNumeroProcesoTitulo As Label
    Friend WithEvents lblNumeroProceso As Label
    Friend WithEvents lblNombreProcesoTitulo As Label
    Friend WithEvents lblNombreProceso As Label
    Friend WithEvents btnCargarDatos As Button
    Friend WithEvents lblMensaje As Label
    Friend WithEvents btnVerRecibidos As Button
    Friend WithEvents btnIrUbicacionDesde As Button
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents FileName As DataGridViewTextBoxColumn
    Friend WithEvents PresentationDate As DataGridViewTextBoxColumn
    Friend WithEvents CustomParaTransferirCopiado As DataGridViewCheckBoxColumn
    Friend WithEvents ParaTransferir As DataGridViewCheckBoxColumn
    Friend WithEvents FechaModificacion As DataGridViewTextBoxColumn
    Friend WithEvents btnAction As DataGridViewButtonColumn
End Class
