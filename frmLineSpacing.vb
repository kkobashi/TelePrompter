Public Class frmLineSpacing
    Private lspaceFactor As Double
    Private theFont As Font
    Private theFontColor As Color
    Private bgColor As Color

    Public Sub New(linespacingFactor As Double, bkColor As Color, font As Font, fontColor As Color)
        InitializeComponent()
        lspaceFactor = linespacingFactor
        theFont = font
        theFontColor = fontColor
        bgColor = bkColor
    End Sub

    Private Sub frmLineSpacing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' lspaceFactor range is 0 to 5 and represents 10% increments
        ' linespacing can be:
        '   0 = 100% 1 = 110% 2 = 120% 3 = 130% 4 = 140% 5 = 150%

        trackBar.Minimum = 0
        trackBar.Maximum = 5
        trackBar.SmallChange = 1
        trackBar.LargeChange = 2
        trackBar.TickFrequency = 1
        trackBar.Value = CInt((lspaceFactor - 1.0) * 10.0)

        lblLineSpace.Text = CStr(CInt(lspaceFactor * 100.0)) + "%"
    End Sub

    Private Sub picBox_Paint(sender As Object, e As PaintEventArgs) Handles picBox.Paint
        ' Do some line calcs
        Dim wSizeF As SizeF
        Dim paddingF As SizeF

        wSizeF = e.Graphics.MeasureString("W", theFont)
        paddingF = wSizeF

        ' Create a bitmap same size as picBox and in-memory graphics context (GC) from it
        ' e.Graphics contains the picBox GC which is not the same thing
        ' We need to do this because we are going to scroll the bitmap and blit to the picBox GC
        Dim maxLinesToRender As Integer

        maxLinesToRender = Math.Floor(picBox.Height / wSizeF.Height * lspaceFactor)

        ' Do some setup based on memG (not e.Graphics)
        Dim bmp = New Bitmap(picBox.Width, picBox.Height)
        Dim memG As Graphics = Graphics.FromImage(bmp)

        memG.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        memG.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

        ' Draw into bitmap
        Dim theBrush As New SolidBrush(theFontColor)

        memG.Clear(bgColor)
        For i = 0 To maxLinesToRender - 1
            memG.DrawString("This is a sample line", theFont, theBrush, 0, wSizeF.Height * lspaceFactor * i)
        Next

        ' use picbox GC context
        e.Graphics.Clear(bgColor)
        e.Graphics.DrawImage(bmp, 0, 0)
    End Sub

    Private Sub trackBar_ValueChanged(sender As Object, e As EventArgs) Handles trackBar.ValueChanged
        lspaceFactor = trackBar.Value / 10.0 + 1.0
        lblLineSpace.Text = CStr(CInt(lspaceFactor * 100.0)) + "%"
        picBox.Invalidate()
    End Sub
End Class