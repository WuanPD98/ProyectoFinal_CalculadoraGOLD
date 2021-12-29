<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.rtxtOperacion = New System.Windows.Forms.RichTextBox()
        Me.btnOperar = New System.Windows.Forms.Button()
        Me.rtxtResultado = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'rtxtOperacion
        '
        Me.rtxtOperacion.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.rtxtOperacion.Location = New System.Drawing.Point(10, 15)
        Me.rtxtOperacion.Name = "rtxtOperacion"
        Me.rtxtOperacion.Size = New System.Drawing.Size(414, 35)
        Me.rtxtOperacion.TabIndex = 0
        Me.rtxtOperacion.Text = ""
        '
        'btnOperar
        '
        Me.btnOperar.Location = New System.Drawing.Point(12, 56)
        Me.btnOperar.Name = "btnOperar"
        Me.btnOperar.Size = New System.Drawing.Size(112, 40)
        Me.btnOperar.TabIndex = 1
        Me.btnOperar.Text = "Operar"
        Me.btnOperar.UseVisualStyleBackColor = True
        '
        'rtxtResultado
        '
        Me.rtxtResultado.Enabled = False
        Me.rtxtResultado.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.rtxtResultado.Location = New System.Drawing.Point(139, 56)
        Me.rtxtResultado.Name = "rtxtResultado"
        Me.rtxtResultado.Size = New System.Drawing.Size(286, 40)
        Me.rtxtResultado.TabIndex = 2
        Me.rtxtResultado.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 109)
        Me.Controls.Add(Me.rtxtResultado)
        Me.Controls.Add(Me.btnOperar)
        Me.Controls.Add(Me.rtxtOperacion)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rtxtOperacion As RichTextBox
    Friend WithEvents btnOperar As Button
    Friend WithEvents rtxtResultado As RichTextBox
End Class
