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
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresentationDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Transferred = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Modified_Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblFechaProceso = New System.Windows.Forms.Label()
        Me.txtFechaProceso = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblPathTo = New System.Windows.Forms.Label()
        Me.lblPathToTitulo = New System.Windows.Forms.Label()
        Me.lblPathFrom = New System.Windows.Forms.Label()
        Me.lblPathFromTitulo = New System.Windows.Forms.Label()
        Me.lblNumeroProcesoTitulo = New System.Windows.Forms.Label()
        Me.lblNumeroProceso = New System.Windows.Forms.Label()
        Me.lblNombreProcesoTitulo = New System.Windows.Forms.Label()
        Me.lblNombreProceso = New System.Windows.Forms.Label()
        Me.btnCargarDatos = New System.Windows.Forms.Button()
        CType(Me.dgvOrigenDestinoArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvOrigenDestinoArchivos
        '
        Me.dgvOrigenDestinoArchivos.AllowUserToAddRows = False
        Me.dgvOrigenDestinoArchivos.AllowUserToDeleteRows = False
        Me.dgvOrigenDestinoArchivos.AllowUserToOrderColumns = True
        Me.dgvOrigenDestinoArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOrigenDestinoArchivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.FileName, Me.PresentationDate, Me.Transferred, Me.Modified_Date})
        Me.dgvOrigenDestinoArchivos.Location = New System.Drawing.Point(55, 288)
        Me.dgvOrigenDestinoArchivos.Name = "dgvOrigenDestinoArchivos"
        Me.dgvOrigenDestinoArchivos.ReadOnly = True
        Me.dgvOrigenDestinoArchivos.Size = New System.Drawing.Size(675, 150)
        Me.dgvOrigenDestinoArchivos.TabIndex = 0
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
        Me.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FileName.DataPropertyName = "FileName"
        Me.FileName.HeaderText = "Nombre Archivo"
        Me.FileName.Name = "FileName"
        Me.FileName.ReadOnly = True
        '
        'PresentationDate
        '
        Me.PresentationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.PresentationDate.DataPropertyName = "Presentation_Date"
        Me.PresentationDate.HeaderText = "Fecha Presentación"
        Me.PresentationDate.Name = "PresentationDate"
        Me.PresentationDate.ReadOnly = True
        '
        'Transferred
        '
        Me.Transferred.DataPropertyName = "Transferred"
        Me.Transferred.HeaderText = "Transferido"
        Me.Transferred.Name = "Transferred"
        Me.Transferred.ReadOnly = True
        Me.Transferred.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Transferred.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Modified_Date
        '
        Me.Modified_Date.DataPropertyName = "Modified_Date"
        Me.Modified_Date.HeaderText = "Fecha Transferido"
        Me.Modified_Date.Name = "Modified_Date"
        Me.Modified_Date.ReadOnly = True
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
        Me.GroupBox1.Size = New System.Drawing.Size(621, 170)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de proceso "
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
        'frmDebitoDirectoEnvio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnCargarDatos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtFechaProceso)
        Me.Controls.Add(Me.lblFechaProceso)
        Me.Controls.Add(Me.dgvOrigenDestinoArchivos)
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
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents FileName As DataGridViewTextBoxColumn
    Friend WithEvents PresentationDate As DataGridViewTextBoxColumn
    Friend WithEvents Transferred As DataGridViewCheckBoxColumn
    Friend WithEvents Modified_Date As DataGridViewTextBoxColumn
End Class
