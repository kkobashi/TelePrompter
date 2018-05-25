<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.MyContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FileOpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FontDlgToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeLineSpacingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BgColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.fontDialog = New System.Windows.Forms.FontDialog()
        Me.bgColorDialog = New System.Windows.Forms.ColorDialog()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.openFileDlg = New System.Windows.Forms.OpenFileDialog()
        Me.MyContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MyContextMenuStrip
        '
        Me.MyContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileOpenToolStripMenuItem, Me.ToolStripSeparator1, Me.FontDlgToolStripMenuItem, Me.ChangeLineSpacingToolStripMenuItem, Me.SpeedToolStripMenuItem, Me.BgColorToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MyContextMenuStrip.Name = "ContextMenuStrip"
        Me.MyContextMenuStrip.Size = New System.Drawing.Size(180, 142)
        '
        'FileOpenToolStripMenuItem
        '
        Me.FileOpenToolStripMenuItem.Name = "FileOpenToolStripMenuItem"
        Me.FileOpenToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.FileOpenToolStripMenuItem.Text = "File Open..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(176, 6)
        '
        'FontDlgToolStripMenuItem
        '
        Me.FontDlgToolStripMenuItem.Name = "FontDlgToolStripMenuItem"
        Me.FontDlgToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.FontDlgToolStripMenuItem.Text = "Font..."
        '
        'ChangeLineSpacingToolStripMenuItem
        '
        Me.ChangeLineSpacingToolStripMenuItem.Name = "ChangeLineSpacingToolStripMenuItem"
        Me.ChangeLineSpacingToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ChangeLineSpacingToolStripMenuItem.Text = "Line Spacing..."
        '
        'SpeedToolStripMenuItem
        '
        Me.SpeedToolStripMenuItem.Name = "SpeedToolStripMenuItem"
        Me.SpeedToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.SpeedToolStripMenuItem.Text = "Speed..."
        '
        'BgColorToolStripMenuItem
        '
        Me.BgColorToolStripMenuItem.Name = "BgColorToolStripMenuItem"
        Me.BgColorToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.BgColorToolStripMenuItem.Text = "Background Color..."
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'Timer
        '
        '
        'openFileDlg
        '
        Me.openFileDlg.FileName = "OpenFileDialog1"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 792)
        Me.Name = "frmMain"
        Me.RightToLeftLayout = True
        Me.Text = "Teleprompter"
        Me.MyContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MyContextMenuStrip As ContextMenuStrip
    Friend WithEvents FileOpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents fontDialog As FontDialog
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents FontDlgToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeLineSpacingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpeedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents bgColorDialog As ColorDialog
    Friend WithEvents BgColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer As Timer
    Friend WithEvents openFileDlg As OpenFileDialog
End Class
