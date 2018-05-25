<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSpeed
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
        Me.components = New System.ComponentModel.Container()
        Me.trackBarSpeed = New System.Windows.Forms.TrackBar()
        Me.picBox = New System.Windows.Forms.PictureBox()
        Me.speedTimer = New System.Windows.Forms.Timer(Me.components)
        Me.lblSlow = New System.Windows.Forms.Label()
        Me.lblFast = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.trackBarSmoothness = New System.Windows.Forms.TrackBar()
        Me.lblSmoother = New System.Windows.Forms.Label()
        Me.lblSmooth = New System.Windows.Forms.Label()
        CType(Me.trackBarSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trackBarSmoothness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'trackBarSpeed
        '
        Me.trackBarSpeed.Location = New System.Drawing.Point(12, 48)
        Me.trackBarSpeed.Name = "trackBarSpeed"
        Me.trackBarSpeed.Size = New System.Drawing.Size(333, 45)
        Me.trackBarSpeed.TabIndex = 0
        '
        'picBox
        '
        Me.picBox.Location = New System.Drawing.Point(12, 99)
        Me.picBox.Name = "picBox"
        Me.picBox.Size = New System.Drawing.Size(779, 377)
        Me.picBox.TabIndex = 1
        Me.picBox.TabStop = False
        '
        'speedTimer
        '
        '
        'lblSlow
        '
        Me.lblSlow.AutoSize = True
        Me.lblSlow.Location = New System.Drawing.Point(304, 22)
        Me.lblSlow.Name = "lblSlow"
        Me.lblSlow.Size = New System.Drawing.Size(30, 13)
        Me.lblSlow.TabIndex = 2
        Me.lblSlow.Text = "Slow"
        '
        'lblFast
        '
        Me.lblFast.AutoSize = True
        Me.lblFast.Location = New System.Drawing.Point(12, 22)
        Me.lblFast.Name = "lblFast"
        Me.lblFast.Size = New System.Drawing.Size(27, 13)
        Me.lblFast.TabIndex = 3
        Me.lblFast.Text = "Fast"
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.Location = New System.Drawing.Point(635, 505)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(716, 505)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'trackBarSmoothness
        '
        Me.trackBarSmoothness.Location = New System.Drawing.Point(544, 48)
        Me.trackBarSmoothness.Name = "trackBarSmoothness"
        Me.trackBarSmoothness.Size = New System.Drawing.Size(247, 45)
        Me.trackBarSmoothness.TabIndex = 6
        '
        'lblSmoother
        '
        Me.lblSmoother.AutoSize = True
        Me.lblSmoother.Location = New System.Drawing.Point(739, 22)
        Me.lblSmoother.Name = "lblSmoother"
        Me.lblSmoother.Size = New System.Drawing.Size(52, 13)
        Me.lblSmoother.TabIndex = 7
        Me.lblSmoother.Text = "Smoother"
        '
        'lblSmooth
        '
        Me.lblSmooth.AutoSize = True
        Me.lblSmooth.Location = New System.Drawing.Point(551, 22)
        Me.lblSmooth.Name = "lblSmooth"
        Me.lblSmooth.Size = New System.Drawing.Size(43, 13)
        Me.lblSmooth.TabIndex = 8
        Me.lblSmooth.Text = "Smooth"
        '
        'frmSpeed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 545)
        Me.Controls.Add(Me.lblSmooth)
        Me.Controls.Add(Me.lblSmoother)
        Me.Controls.Add(Me.trackBarSmoothness)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblFast)
        Me.Controls.Add(Me.lblSlow)
        Me.Controls.Add(Me.picBox)
        Me.Controls.Add(Me.trackBarSpeed)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSpeed"
        Me.Text = "Speed"
        CType(Me.trackBarSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trackBarSmoothness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents trackBarSpeed As TrackBar
    Friend WithEvents picBox As PictureBox
    Friend WithEvents speedTimer As Timer
    Friend WithEvents lblSlow As Label
    Friend WithEvents lblFast As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents trackBarSmoothness As TrackBar
    Friend WithEvents lblSmoother As Label
    Friend WithEvents lblSmooth As Label
End Class
