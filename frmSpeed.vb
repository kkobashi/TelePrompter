Imports System.ComponentModel

Public Class frmSpeed
    Private scrollSpeed As Integer
    Private smooth As Integer
    Private lspace As Double
    Private theFont As Font
    Private theFontColor As Color
    Private bgColor As Color

    Public Sub New(speed As Integer, bkColor As Color, smoothness As Integer, linespacing As Double, font As Font, fontColor As Color)
        InitializeComponent()
        scrollSpeed = speed
        smooth = smoothness
        lspace = linespacing
        theFont = font
        theFontColor = fontColor
        bgColor = bkColor
    End Sub

    Private Sub frmSpeed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        trackBarSpeed.Minimum = 10
        trackBarSpeed.Maximum = 100
        trackBarSpeed.SmallChange = 10
        trackBarSpeed.LargeChange = 25
        trackBarSpeed.TickFrequency = 10
        trackBarSpeed.Value = scrollSpeed

        trackBarSmoothness.Minimum = 10
        trackBarSmoothness.Maximum = 100
        trackBarSmoothness.SmallChange = 2
        trackBarSmoothness.LargeChange = 10
        trackBarSmoothness.TickFrequency = 10
        trackBarSmoothness.Value = smooth

        speedTimer.Interval = scrollSpeed
        speedTimer.Start()
    End Sub
    Private Sub frmMain_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel

        ' Get current speed
        ' Speed range (correlated with frmSpeed) is 10 to 100
        ' 10 is the small change
        Dim speed As Integer
        speed = My.Settings.Speed

        Dim currentDetent As Integer
        Dim minDetent As Integer
        Dim maxDetent As Integer
        currentDetent = speed / 10
        minDetent = 1
        maxDetent = 10

        Dim detentChange As Integer
        detentChange = CInt(e.Delta / SystemInformation.MouseWheelScrollDelta)

        speedTimer.Stop()

        If detentChange > 0 Then
            speedTimer.Interval = Math.Min(100, speed + detentChange * 10)
        End If

        If detentChange < 0 Then
            speedTimer.Interval = Math.Max(10, speed + detentChange * 10)
        End If

        trackBarSpeed.Value = speedTimer.Interval
        My.Settings.Speed = trackBarSpeed.Value

        speedTimer.Start()
    End Sub


    Private Sub picBox_Paint(sender As Object, e As PaintEventArgs) Handles picBox.Paint
        ' Do some line calcs
        Dim wSizeF As SizeF
        Dim lineHeight As Integer
        Dim paddingF As SizeF

        wSizeF = e.Graphics.MeasureString("W", theFont)
        paddingF = wSizeF
        lineHeight = CInt(lspace * wSizeF.Height)

        ' Create a bitmap of 5 lines of text and in-memory graphics context (GC) from it
        ' e.Graphics contains the picBox GC which is not the same thing
        ' We need to do this because we are going to scroll the bitmap and blit to the picBox GC
        ' Do some setup based on memG (not e.Graphics)
        Dim bmp = New Bitmap(picBox.Width, lineHeight * 5)
        Dim memG As Graphics = Graphics.FromImage(bmp)
        memG.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        memG.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

        ' Draw into bitmap
        Dim theBrush As New SolidBrush(theFontColor)
        memG.Clear(bgColor)
        For i = 0 To 4
            memG.DrawString("This is a sample line", theFont, theBrush, 0, lineHeight * i)
        Next

        ' Scroll upwards until offset is bigger than the lines of text, then reset
        ' How much we scroll is based on W height. The smaller the more smoother the look but higher tick rate needed.
        Static yOffset As Integer = 0
        yOffset = yOffset - Math.Ceiling(wSizeF.Height / smooth)
        If yOffset < -lineHeight * 5 Then
            yOffset = 0
            Exit Sub
        End If

        ' use picbox GC context
        e.Graphics.Clear(bgColor)
        e.Graphics.DrawImage(bmp, 0, yOffset)

        ' this wont work as it causes constant redrawing
        ' memG.DrawImage(bmp, 0, yOffset)
        ' picBox.Image = bmp
    End Sub

    Private Sub speedTimer_Tick(sender As Object, e As EventArgs) Handles speedTimer.Tick
        picBox.Invalidate()
    End Sub

    Private Sub trackBarSpeed_ValueChanged(sender As Object, e As EventArgs) Handles trackBarSpeed.ValueChanged
        speedTimer.Stop()
        speedTimer.Interval = trackBarSpeed.Value
        speedTimer.Start()
    End Sub

    Private Sub trackBarSmoothness_ValueChanged(sender As Object, e As EventArgs) Handles trackBarSmoothness.ValueChanged
        speedTimer.Stop()
        smooth = trackBarSmoothness.Value
        speedTimer.Start()
    End Sub
    Private Sub frmSpeed_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        speedTimer.Stop()
    End Sub
End Class