
Public Class SetAnyThing

    Public Efile As String
    Public EDir As String
    Public IsFile As Boolean
    Public Here As String

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

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If Not IO.Directory.Exists(EDir & "\" & TextBox1.Text) Then
    '        IO.Directory.CreateDirectory(EDir & "\" & TextBox1.Text)

    '        Form1.ListView1.SmallImageList = Form1.ImgExtList
    '        Form1.ListView1.LargeImageList = Form1.ImgExtListBigger

    '        Dim Result As String = AbrirDirectorio(RutaActual, Form1.ListView1, ShowHide)

    '        If Result.Contains("\") Then
    '            Form1.Label2.Visible = False
    '            Form1.TextBox1.Text = AbrirDirectorio(RutaActual, Form1.ListView1, ShowHide)
    '        Else
    '            Form1.Label2.Visible = True
    '            Form1.Label2.Text = Result

    '        End If

    '        Me.Close()

    '    Else

    '        MsgBox("Ya existe una carpeta con ese nombre")

    '    End If

    'End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim Info As IO.FileInfo



    '    If IsFile = True Then
    '        Info = My.Computer.FileSystem.GetFileInfo(Efile)
    '        If IO.File.Exists(Efile) Then
    '            My.Computer.FileSystem.RenameFile(Efile, TextBox2.Text & Info.Extension)

    '            Me.Close()
    '        Else
    '            MsgBox("Este archivo no existe")

    '        End If

    '    Else

    '        If IsFile = False Then
    '            If IO.Directory.Exists(EDir) Then

    '                My.Computer.FileSystem.RenameDirectory(EDir, TextBox2.Text)

    '                Form1.ListView1.SmallImageList = Form1.ImgExtList
    '                Form1.ListView1.LargeImageList = Form1.ImgExtListBigger

    '                Dim Result As String = AbrirDirectorio(RutaActual, Form1.ListView1, ShowHide)

    '                If Result.Contains("\") Then
    '                    Form1.Label2.Visible = False
    '                    Form1.TextBox1.Text = AbrirDirectorio(RutaActual, Form1.ListView1, ShowHide)
    '                Else
    '                    Form1.Label2.Visible = True
    '                    Form1.Label2.Text = Result

    '                End If

    '                Me.Close()
    '            Else
    '                MsgBox("Esta carpeta no existe")

    '            End If

    '        End If



    '    End If


    'End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Me.Close()
    End Sub

    Private Sub SetAnyThing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel4.Left = (PnlCrearDir.Width / 2) - (Panel4.Width / 2)
    End Sub

    Dim Percent As Integer

    Sub JustDoIt(ByVal Argument As String)
        Dim ProgressBar1 As New ProgressBar

        Dim wList As New List(Of String)
        wList = DriveInfo(Argument)

        If wList.Item(5) = IO.DriveType.Fixed Then
            PictureBox2.Image = Form1.ImageList2.Images(3)

            If wList.Item(0) = "No disponible" Then
                Label2.Text = "Unidad " & wList.Item(3)
            Else
                Label2.Text = wList.Item(0)
            End If

            Label3.Text = "Disco duro" & " - " & wList.Item(6)

            Try
                ProgressBar1.Maximum = calcularTamanoII(wList.Item(1)).Remove(6)
                ProgressBar1.Value = calcularTamanoII(wList.Item(1)).Remove(6) - calcularTamanoII(wList.Item(2)).Remove(6)
                Percent = (ProgressBar1.Value / ProgressBar1.Maximum) * 100

                Label8.Text = calcularTamano(wList.Item(2))
                Label9.Text = calcularTamano(wList.Item(1) - wList.Item(2))
                Label10.Text = calcularTamano(wList.Item(1))
            Catch ex As Exception
                Percent = 0
                Label8.Text = "N.D."
                Label9.Text = "N.D."
                Label10.Text = "N.D."
            End Try


        ElseIf wList.Item(5) = IO.DriveType.CDRom Then
            PictureBox2.Image = Form1.ImageList2.Images(5)

            If wList.Item(0) = "No disponible" Then
                Label2.Text = "Unidad " & wList.Item(3)
            Else
                Label2.Text = wList.Item(0)
            End If

            Label3.Text = "Unidad de CD/DVD" & " - " & wList.Item(6)

            Try
                ProgressBar1.Maximum = calcularTamanoII(wList.Item(1)).Remove(6)
                ProgressBar1.Value = calcularTamanoII(wList.Item(1)).Remove(6) - calcularTamanoII(wList.Item(2)).Remove(6)
                Percent = (ProgressBar1.Value / ProgressBar1.Maximum) * 100

                Label8.Text = calcularTamano(wList.Item(2))
                Label9.Text = calcularTamano(wList.Item(1) - wList.Item(2))
                Label10.Text = calcularTamano(wList.Item(1))
            Catch ex As Exception
                Percent = 0
                Label8.Text = "N.D."
                Label9.Text = "N.D."
                Label10.Text = "N.D."
            End Try
           

        ElseIf wList.Item(5) = IO.DriveType.Removable Then
            PictureBox2.Image = Form1.ImageList2.Images(2)

            If wList.Item(0) = "No disponible" Then
                Label2.Text = "Unidad " & wList.Item(3)
            Else
                Label2.Text = wList.Item(0) 
            End If

            Label3.Text = "Unidad extraible" & " - " & wList.Item(6)
            Try
                ProgressBar1.Maximum = calcularTamanoII(wList.Item(1)).Remove(6)
                ProgressBar1.Value = calcularTamanoII(wList.Item(1)).Remove(6) - calcularTamanoII(wList.Item(2)).Remove(6)
                Percent = (ProgressBar1.Value / ProgressBar1.Maximum) * 100

                Label8.Text = calcularTamano(wList.Item(2))
                Label9.Text = calcularTamano(wList.Item(1) - wList.Item(2))
                Label10.Text = calcularTamano(wList.Item(1))
            Catch ex As Exception
                Percent = 0
                Label8.Text = "N.D."
                Label9.Text = "N.D."
                Label10.Text = "N.D."
            End Try

        End If

        Me.ShowDialog()

    End Sub


    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel4.Paint
        e.Graphics.Clear(CType(sender, Panel).BackColor)

        If Percent >= 90 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, Percent, 20, Color.Red, 8, 6)

        ElseIf Percent > 80 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, Percent, 20, Color.Orange, 8, 6)

        ElseIf Percent > 70 Then
            CircularDraw(sender, CType(sender, Panel).Size, e, Percent, 20, Color.Yellow, 8, 6)

        Else
            CircularDraw(sender, CType(sender, Panel).Size, e, Percent, 20, Color.RoyalBlue, 8, 6)

        End If
    End Sub

    Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Panel1.BackColor = Color.DarkGray
        Panel2.BackColor = Color.DarkGray

    End Sub

    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Panel1.BackColor = Color.DimGray
        Panel2.BackColor = Color.DimGray

    End Sub
End Class