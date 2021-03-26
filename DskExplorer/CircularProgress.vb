Module CircularProgress

    Private Sub DrawProgress(ByVal g As Graphics, ByVal rect As Rectangle, ByVal percentage As Single, ByVal FontSize As Integer, ByVal colorSend As Color, ByVal BrushOne As Integer, ByVal BrushTwo As Integer)
        'work out the angles for each arc
        Dim progressAngle = CSng(360 / 100 * percentage)
        Dim remainderAngle = 360 - progressAngle

        'create pens to use for the arcs
        Using progressPen As New Pen(colorSend, BrushOne), remainderPen As New Pen(Color.LightGray, BrushTwo)
            'set the smoothing to high quality for better output
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality

            'g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            'draw the blue and white arcs
            g.DrawArc(progressPen, rect, -90, progressAngle)
            g.DrawArc(remainderPen, rect, progressAngle - 90, remainderAngle)
        End Using

        'draw the text in the centre by working out how big it is and adjusting the co-ordinates accordingly
        Using fnt As New Font("Microsoft Sans Serif", FontSize)
            Dim text As String = percentage.ToString + "%"
            Dim textSize = g.MeasureString(text, fnt)
            Dim textPoint As New Point(CInt(rect.Left + (rect.Width / 2) - (textSize.Width / 2)), CInt(rect.Top + (rect.Height / 2) - (textSize.Height / 2)))
            'now we have all the values draw the text
            g.DrawString(text, fnt, Brushes.Black, textPoint)
        End Using
    End Sub


    Private Sub DrawProgressLbl(ByVal g As Graphics, ByVal rect As Rectangle, ByVal percentage As Single, ByVal FontSize As Integer, ByVal colorSend As Color, ByVal BrushOne As Integer, ByVal BrushTwo As Integer)
        'work out the angles for each arc
        Dim progressAngle = CSng(360 / 100 * percentage)
        Dim remainderAngle = 360 - progressAngle

        'create pens to use for the arcs
        Using progressPen As New Pen(colorSend, BrushOne), remainderPen As New Pen(Color.LightGray, BrushTwo)
            'set the smoothing to high quality for better output
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality

            'g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            'draw the blue and white arcs
            g.DrawArc(progressPen, rect, -90, progressAngle)
            g.DrawArc(remainderPen, rect, progressAngle - 90, remainderAngle)
        End Using

        'draw the text in the centre by working out how big it is and adjusting the co-ordinates accordingly
        Using fnt As New Font("Microsoft Sans Serif", FontSize)
            Dim text As String = percentage.ToString + "%"
            Dim textSize = g.MeasureString(text, fnt)
            Dim textPoint As New Point(CInt(rect.Left + (rect.Width / 2) - (textSize.Width / 2)), CInt(rect.Top + (rect.Height / 2) - (textSize.Height / 2)))
            'now we have all the values draw the text

        End Using
    End Sub

    Sub CircularDraw(ByVal sender As Object, ByVal size As Drawing.Size, ByVal Graphic As System.Windows.Forms.PaintEventArgs, ByVal Percent As Single, ByVal FontSize As Integer, ByVal color As Color, ByVal b1 As Integer, ByVal b2 As Integer)

        Graphic.Graphics.Clear(CType(sender, Panel).BackColor)
        Dim nPoint As Drawing.Size = size
        Graphic.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality

        Dim HW As Integer

        If nPoint.Width > nPoint.Height Then
            HW = nPoint.Height - (nPoint.Height / 10)
        Else
            HW = nPoint.Width - (nPoint.Width / 10)
        End If

        Dim pX As Single = (nPoint.Width / 2) - (HW / 2)

        Dim pY As Single = (nPoint.Height / 2) - (HW / 2)


        DrawProgress(Graphic.Graphics, New Rectangle(pX, pY, HW, HW), Percent, FontSize, color, b1, b2)


    End Sub


    Sub CircularDrawLbl(ByVal sender As Object, ByVal size As Drawing.Size, ByVal Graphic As System.Windows.Forms.PaintEventArgs, ByVal Percent As Single, ByVal FontSize As Integer, ByVal color As Color, ByVal b1 As Integer, ByVal b2 As Integer)

        Graphic.Graphics.Clear(CType(sender, Panel).BackColor)
        Dim nPoint As Drawing.Size = size
        Graphic.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality

        Dim HW As Integer

        If nPoint.Width > nPoint.Height Then
            HW = nPoint.Height - (nPoint.Height / 10)
        Else
            HW = nPoint.Width - (nPoint.Width / 10)
        End If

        Dim pX As Single = (nPoint.Width / 2) - (HW / 2)

        Dim pY As Single = (nPoint.Height / 2) - (HW / 2)


        DrawProgressLbl(Graphic.Graphics, New Rectangle(pX, pY, HW, HW), Percent, FontSize, color, b1, b2)


    End Sub

End Module
