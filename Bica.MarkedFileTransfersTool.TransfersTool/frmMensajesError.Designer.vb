<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMensajesError
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rtbMensajeError = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'rtbMensajeError
        '
        Me.rtbMensajeError.Location = New System.Drawing.Point(12, 12)
        Me.rtbMensajeError.Name = "rtbMensajeError"
        Me.rtbMensajeError.Size = New System.Drawing.Size(751, 254)
        Me.rtbMensajeError.TabIndex = 0
        Me.rtbMensajeError.Text = ""
        '
        'frmMensajesError
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 278)
        Me.Controls.Add(Me.rtbMensajeError)
        Me.Name = "frmMensajesError"
        Me.Text = "frmMensajesError"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rtbMensajeError As RichTextBox
End Class
