Imports System.ComponentModel
Imports System.IO

Public Class frmMain
    Private lineSpacingFactor As Double
    Private speed As Integer
    Private smooth As Integer
    Private theFont As Font
    Private theFontColor As Color
    Private bkColor As Color
    Private fileLines As String()
    Private renderLines As New List(Of String)
    Private streamReader As StreamReader
    Private filename As String

    Private theLine As String
    Private bAnimate As Boolean
    Private bFetchNextLine As Boolean
    Private bResetAnim As Boolean
    Private bBeginOrEnd As Boolean

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ContextMenuStrip = MyContextMenuStrip
        Me.DoubleBuffered = True

        theFont = My.Settings.Font
        theFontColor = My.Settings.FontColor
        lineSpacingFactor = My.Settings.LineSpacingFactor
        speed = My.Settings.Speed
        smooth = My.Settings.Smoothness
        bkColor = My.Settings.BackgroundColor

        bAnimate = False
        bResetAnim = False
        bFetchNextLine = True
        bBeginOrEnd = True
        streamReader = Nothing

        theLine = ""

        CenterToScreen()
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.StartPosition = FormStartPosition.CenterParent
        AboutBox.ShowDialog()
    End Sub
    Private Sub FileOpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileOpenToolStripMenuItem.Click
        Try
            openFileDlg.Filter = "Text (*.txt) |*.txt|All Files (*.*) |*.*"
            openFileDlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            openFileDlg.FileName = ""
            openFileDlg.FilterIndex = 1
            If (openFileDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
                streamReader = My.Computer.FileSystem.OpenTextFileReader(openFileDlg.FileName)
                filename = openFileDlg.FileName
                bFetchNextLine = True
                bAnimate = False
                bBeginOrEnd = False
                Timer.Interval = My.Settings.Speed
                Timer.Start()
            End If
        Catch ex As Exception
            MessageBox.Show("Could not open file." & vbCrLf & "Only text files of type TXT are supported.", "Teleprompter Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Invalidate()
    End Sub

    Private Sub frmMain_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If (e.Button = MouseButtons.Right) Then
            Me.MyContextMenuStrip.Show()
        End If
    End Sub

    Private Sub FontDlgToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontDlgToolStripMenuItem.Click
        fontDialog.ShowColor = True
        fontDialog.MinSize = 36
        fontDialog.MaxSize = 100
        fontDialog.Font = theFont
        fontDialog.Color = theFontColor
        If (fontDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            theFont = fontDialog.Font
            theFontColor = fontDialog.Color
            My.Settings.Font = theFont
            My.Settings.FontColor = theFontColor

            Invalidate()
        End If
    End Sub

    Private Sub ChangeLineSpacingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeLineSpacingToolStripMenuItem.Click
        Dim frm As New frmLineSpacing(My.Settings.LineSpacingFactor, My.Settings.BackgroundColor, My.Settings.Font, My.Settings.FontColor)

        frm.StartPosition = FormStartPosition.CenterParent
        If (frm.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            lineSpacingFactor = 1.0 + frm.trackBar.Value / 10.0
            My.Settings.LineSpacingFactor = lineSpacingFactor
            Invalidate()
        End If
    End Sub

    Private Sub SpeedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeedToolStripMenuItem.Click
        Dim frm As New frmSpeed(My.Settings.Speed, My.Settings.BackgroundColor, My.Settings.Smoothness, My.Settings.LineSpacingFactor, My.Settings.Font, My.Settings.FontColor)

        frm.StartPosition = FormStartPosition.CenterParent
        If (frm.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            My.Settings.Speed = frm.trackBarSpeed.Value
            My.Settings.Smoothness = frm.trackBarSmoothness.Value

            ' If we are already animating with on open text file
            ' stop the timer, reset the speed and startup again where we left off
            If bAnimate = True Then
                Timer.Stop()
                Timer.Interval = My.Settings.Speed
                Timer.Start()
            End If

            Invalidate()
        End If
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            ' Start/Resume/Stop
            Case Keys.Space
                If streamReader Is Nothing Then
                    MessageBox.Show("Must load a teleprompter file first.", "Error: Start or Pause", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                If bAnimate = False Then
                    bAnimate = True
                    Me.FormBorderStyle = FormBorderStyle.FixedDialog ' prevent resizing
                    Timer.Interval = My.Settings.Speed
                    Timer.Start()
                Else
                    bAnimate = False
                    Me.FormBorderStyle = FormBorderStyle.Sizable ' allow resizing
                    Timer.Stop()
                End If
            ' Beginning of teleprompter file
            Case Keys.B
                If streamReader Is Nothing Then
                    MessageBox.Show("Must load a teleprompter file first.", "Error: Go to next line", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    streamReader.Close()
                    streamReader = My.Computer.FileSystem.OpenTextFileReader(filename)

                    bAnimate = False
                    bBeginOrEnd = False
                    bResetAnim = True
                    bFetchNextLine = True

                    Timer.Stop()
                    Timer.Interval = My.Settings.Speed
                    Timer.Start()

                End If
            ' Get next line
            Case Keys.N
                If streamReader Is Nothing Then
                    MessageBox.Show("Must load a teleprompter file first.", "Error: Go to Next Line", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                ' Can't force the read of a new line here file object wise
                ' Must be handled in tick event so we stop, request a fetch, and restart timerrrrrrrr
                Timer.Stop()
                bResetAnim = True
                bFetchNextLine = True
                Timer.Start()
           ' Open teleprompter file
            Case Keys.O
                FileOpenToolStripMenuItem_Click(sender, e)
        End Select

    End Sub

    Private Sub BgColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BgColorToolStripMenuItem.Click
        Dim frm As New frmBackgroundColor(My.Settings.BackgroundColor, My.Settings.LineSpacingFactor, My.Settings.Font, My.Settings.FontColor)

        frm.StartPosition = FormStartPosition.CenterParent
        If (frm.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            My.Settings.BackgroundColor = frm.GetBackgroundColor()
            Invalidate()
        End If
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        ' This timer works on a line by line basis and is in sync with the paint
        ' which sets a flag to read a new line out of the file or not
        ' A new line is not read in if its still scrolling

        If bFetchNextLine = True Then
            If streamReader.EndOfStream = False Then
                theLine = streamReader.ReadLine()
            Else
                ' we're at end of file so stop animating and stop ticking
                bAnimate = False
                bBeginOrEnd = True
                Timer.Stop()
            End If
        End If

        Invalidate()
    End Sub

    Private Sub frmMain_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Static yOffset As Integer = 0

        ' Always paint form background color
        e.Graphics.Clear(bkColor)

        ' Information or end of teleprompt
        If (bBeginOrEnd = True) Then
            Dim font As New Font("Arial", 16.0F, FontStyle.Regular)
            Dim br As New SolidBrush(Color.White)
            Dim bm = New Bitmap(AppDomain.CurrentDomain.BaseDirectory + "Intro.png")
            e.Graphics.DrawImage(bm, 32, 32)
            e.Graphics.DrawString("Right mouse click to bring up menu", font, br, 32, 380)
            e.Graphics.DrawString("Hotkeys:", font, br, 32, 420)
            e.Graphics.DrawString("  B beginning", font, br, 32, 440)
            e.Graphics.DrawString("  N next line", font, br, 32, 460)
            e.Graphics.DrawString("  O open a new Teleprompter file", font, br, 32, 480)
            e.Graphics.DrawString("  Spacebar start or pause", font, br, 32, 500)
            e.Graphics.DrawString("  Mouse wheel for speed", font, br, 32, 520)
            Exit Sub
        End If

        If (bResetAnim = True) Then
            yOffset = 0
            bResetAnim = False
        End If

        Dim renderingLines As New List(Of String)
        Dim wSizeF As SizeF
        Dim paddingF As SizeF
        wSizeF = e.Graphics.MeasureString("W", theFont)
        paddingF = wSizeF

        Dim parse = Function()
                        ' Parse the current line into words
                        Dim words As String()
                        Dim separators As String() = {" "}
                        words = theLine.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                        If words Is Nothing Or words.Count <= 0 Then
                            Return False
                        End If

                        ' Create a list of word wrapped rendering line strings
                        ' The dialog is not resizeable while in animation mode

                        Dim measureLine As String
                        Dim lineSizeF As SizeF
                        Dim wordSizeF As SizeF
                        measureLine = ""

                        For j = 0 To words.Length - 1
                            lineSizeF = e.Graphics.MeasureString(measureLine, theFont)
                            wordSizeF = e.Graphics.MeasureString(words(j) & " ", theFont)
                            If (lineSizeF.Width + wordSizeF.Width < Me.Width - 2 * paddingF.Width) Then
                                measureLine = measureLine & words(j) & " "
                            Else
                                renderingLines.Add(measureLine)
                                measureLine = words(j) & " "
                            End If
                        Next

                        'Add remaining words
                        If measureLine.Length > 0 Then
                            renderingLines.Add(measureLine)
                        End If

                        Return (True)
                    End Function

        ' Parse the current line
        If (parse() = False) Then
            Exit Sub
        End If

        ' At this point we have all the word wrapped lines in a rendering line list
        ' All the work above was to get to the next step of calculating
        ' a height based on the number of rendering lines for the bitmap we will scroll
        Dim lineHeight As Integer
        Dim bitmapHeight As Integer
        wSizeF = e.Graphics.MeasureString("W", theFont)
        lineHeight = CInt(lineSpacingFactor * wSizeF.Height)
        bitmapHeight = lineHeight * renderingLines.Count + paddingF.Height

        ' Create bitmap and in-memory GC
        Dim bmp = New Bitmap(Me.Width, bitmapHeight)
        Dim memG As Graphics = Graphics.FromImage(bmp)
        Dim brush As New SolidBrush(theFontColor)
        memG.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        memG.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

        ' Draw rendering lines into an in memory bitmap
        memG.Clear(bkColor)
        Dim renderLineCount As Integer = 0
        For Each renderLine In renderingLines
            memG.DrawString(renderLine, theFont, brush, paddingF.Width, lineHeight * renderLineCount + paddingF.Height)
            renderLineCount += 1
        Next

        ' Always show the first line when file is loaded but don't scroll upward
        ' until user hits space tro start animation (i.e. bAnimate set)

        If bAnimate = False Then
            e.Graphics.DrawImage(bmp, 0, yOffset)
            bFetchNextLine = False
            Exit Sub
        End If

        yOffset = yOffset - Math.Ceiling(lineHeight / My.Settings.Smoothness)
        e.Graphics.DrawImage(bmp, 0, yOffset)

        ' Eye factor controls where the line stops scrolling
        ' and the next location. It ranges from 0 to 10.
        If yOffset < -bitmapHeight Then     ' scrolling done reset and get next line in file
            yOffset = 0
            bFetchNextLine = True
        Else
            bFetchNextLine = False          ' scrolling not done dont fetch another line yet
        End If
    End Sub

    Private Sub frmMain_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        ' Must check to avoid creating Timer Tick event that ends up in Exception
        If streamReader Is Nothing Then
            Exit Sub
        End If

        ' Speed range (correlated with frmSpeed) is 10 to 100
        ' 10 is the small change

        Dim currentDetent As Integer
        Dim minDetent As Integer
        Dim maxDetent As Integer
        currentDetent = speed / 10
        minDetent = 1
        maxDetent = 10

        Dim detentChange As Integer
        detentChange = CInt(e.Delta / SystemInformation.MouseWheelScrollDelta)

        Timer.Stop()

        If detentChange > 0 Then
            Timer.Interval = Math.Min(100, My.Settings.Speed + detentChange * 10)
        End If

        If detentChange < 0 Then
            Timer.Interval = Math.Max(10, My.Settings.Speed + detentChange * 10)
        End If

        My.Settings.Speed = Timer.Interval

        Timer.Start()
    End Sub
End Class
