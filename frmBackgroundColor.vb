Public Class frmBackgroundColor
    Private bgColor As Color
    Private lspace As Double
    Private theFont As Font
    Private theFontColor As Color

    Public Sub New(bkColor As Color, linespacing As Double, font As Font, fontColor As Color)
        InitializeComponent()

        bgColor = bkColor
        lspace = linespacing
        theFont = font
        theFontColor = fontColor
    End Sub
    Public Function GetBackgroundColor() As Color
        Return bgColor
    End Function
    Private Sub btnChangeColor_Click(sender As Object, e As EventArgs) Handles btnChangeColor.Click
        colorDialog.Color = bgColor
        If (colorDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            bgColor = colorDialog.Color
            picBox.Invalidate()
        End If
    End Sub

    Private Sub picBox_Paint(sender As Object, e As PaintEventArgs) Handles picBox.Paint
        ' Do some line calcs
        Dim wSizeF As SizeF
        Dim lineHeight As Integer
        Dim paddingF As SizeF

        wSizeF = e.Graphics.MeasureString("W", theFont)
        paddingF = wSizeF
        lineHeight = CInt(lspace * wSizeF.Height)

        ' Create a bitmap same size as picBox and in-memory graphics context (GC) from it
        ' e.Graphics contains the picBox GC which is not the same thing
        ' We need to do this because we are going to scroll the bitmap and blit to the picBox GC
        Dim maxLinesToRender As Integer

        maxLinesToRender = Math.Floor(picBox.Height / lineHeight)

        ' Do some setup based on memG (not e.Graphics)
        Dim bmp = New Bitmap(picBox.Width, picBox.Height)
        Dim memG As Graphics = Graphics.FromImage(bmp)

        memG.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        memG.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

        ' Draw into bitmap
        Dim theBrush As New SolidBrush(theFontColor)

        memG.Clear(bgColor)
        For i = 0 To maxLinesToRender - 1
            memG.DrawString("This is a sample line", theFont, theBrush, 0, lineHeight * i)
        Next

        ' use picbox GC context
        e.Graphics.Clear(bgColor)
        e.Graphics.DrawImage(bmp, 0, 0)
    End Sub
End Class