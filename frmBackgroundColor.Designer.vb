<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackgroundColor
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
        Me.btnChangeColor = New System.Windows.Forms.Button()
        Me.picBox = New System.Windows.Forms.PictureBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCanel = New System.Windows.Forms.Button()
        Me.colorDialog = New System.Windows.Forms.ColorDialog()
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnChangeColor
        '
        Me.btnChangeColor.Location = New System.Drawing.Point(23, 31)
        Me.btnChangeColor.Name = "btnChangeColor"
        Me.btnChangeColor.Size = New System.Drawing.Size(126, 27)
        Me.btnChangeColor.TabIndex = 0
        Me.btnChangeColor.Text = "Change Color..."
        Me.btnChangeColor.UseVisualStyleBackColor = True
        '
        'picBox
        '
        Me.picBox.Location = New System.Drawing.Point(23, 79)
        Me.picBox.Name = "picBox"
        Me.picBox.Size = New System.Drawing.Size(782, 387)
        Me.picBox.TabIndex = 1
        Me.picBox.TabStop = False
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(648, 488)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCanel
        '
        Me.btnCanel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCanel.Location = New System.Drawing.Point(730, 488)
        Me.btnCanel.Name = "btnCanel"
        Me.btnCanel.Size = New System.Drawing.Size(75, 23)
        Me.btnCanel.TabIndex = 3
        Me.btnCanel.Text = "Cancel"
        Me.btnCanel.UseVisualStyleBackColor = True
        '
        'frmBackgroundColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 523)
        Me.Controls.Add(Me.btnCanel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.picBox)
        Me.Controls.Add(Me.btnChangeColor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBackgroundColor"
        Me.Text = "Background Color"
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnChangeColor As Button
    Friend WithEvents picBox As PictureBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCanel As Button
    Friend WithEvents colorDialog As ColorDialog
End Class
