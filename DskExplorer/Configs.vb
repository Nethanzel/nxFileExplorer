Public Class Configs

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Me.Close()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        If CheckBox1.CheckState = CheckState.Checked Then
            ShowHide = True

        Else
            ShowHide = False
        End If
       


        If ComboBox1.Text = "Lista y detalles" Then

            Form1.ListView1.View = View.Details

        ElseIf ComboBox1.Text = "Iconos grandes" Then
            Form1.ListView1.View = View.LargeIcon

        Else

            Exit Sub
        End If

        If Not RutaActual.Length < 3 Then


            Form1.ListView1.SmallImageList = Form1.ImgExtList
            Form1.ListView1.LargeImageList = Form1.ImgExtListBigger

            Dim Result As String = AbrirDirectorio(RutaActual, Form1.ListView1, ShowHide, Form1.TextBox2.Text, True)

            If Result.Contains("\") Then
                Form1.Label2.Visible = False
                Form1.TextBox1.Text = AbrirDirectorio(RutaActual, Form1.ListView1, ShowHide, Form1.TextBox2.Text, False)
            Else
                Form1.Label2.Visible = True
                Form1.Label2.Text = Result

            End If
        End If
        Me.Close()


    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Me.Close()
    End Sub

    '________________________________________________
    Private aaa As Boolean = False
    Private MouseX As Integer
    Private MouseY As Integer
    '_________________________________________________


    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = True
            MouseX = e.X
            MouseY = e.Y

        End If
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If aaa = True Then
            Dim tmp As Point = New Point

            tmp.X = Me.Location.X + (e.X - MouseX)
            tmp.Y = Me.Location.Y + (e.Y - MouseY)
            Me.Location = tmp
            tmp = Nothing

        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = False

        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then

            PictureBox2.Image = My.Resources.view
        Else
            PictureBox2.Image = My.Resources.notview
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        If ComboBox1.Text = "Lista y detalles" Then

            PictureBox3.Image = My.Resources.listicon

        Else
            PictureBox3.Image = My.Resources.listicon1


        End If

    End Sub

    Private Sub Configs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Form1.ListView1.View = View.Details Then

            ComboBox1.Text = "Lista y detalles"
            PictureBox3.Image = My.Resources.listicon

        ElseIf Form1.ListView1.View = View.LargeIcon Then

            ComboBox1.Text = "Iconos grandes"
            PictureBox3.Image = My.Resources.listicon1

        Else

            Exit Sub
        End If


        If ShowHide = True Then
            CheckBox1.CheckState = CheckState.Checked
            PictureBox2.Image = My.Resources.view
        Else
            CheckBox1.CheckState = CheckState.Unchecked
            PictureBox2.Image = My.Resources.notview
        End If

    End Sub
End Class