
Imports DickExplorer.OwnFiles
Imports System.Timers

Public Class Form1

    Dim LastSelectNode As String

    '______________________________________________________________________________________________________________________________________________________________

    Dim x As Integer, y As Integer, a As Integer = x, b As Integer = y
    Private XY As Point

    Sub RellenarTV(ByVal root)

        TreeView1.Nodes.Clear()

        EnviarAToolStripMenuItem.DropDownItems.Clear()

        Dim childnode As TreeNode

        Dim childnode01 As New TreeNode

        Dim childnode0 As New TreeNode

        Dim childnode1 As New TreeNode

        Dim iDir As IO.DirectoryInfo

        Dim cdrive As System.IO.DriveInfo
        Dim parentnode As TreeNode
        parentnode = New TreeNode("Unidades actuales")
        'parentnode.NodeFont = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)

        parentnode.ToolTipText = "Unidades actuales"
        SpecialDirectories(TreeView1, root)
        TreeView1.Nodes.Add(parentnode)

        For iIndice = 0 To My.Computer.FileSystem.Drives.Count - 1


            Try


                cdrive = My.Computer.FileSystem.GetDriveInfo(My.Computer.FileSystem.Drives(iIndice).RootDirectory.Name)


                If My.Computer.FileSystem.Drives(iIndice).VolumeLabel = "" Then

                    childnode = parentnode.Nodes.Add("", "Unidad " & My.Computer.FileSystem.Drives(iIndice).RootDirectory.Name, cdrive.DriveType)
                    Dim menuitemI As New ToolStripMenuItem("Unidad " & My.Computer.FileSystem.Drives(iIndice).RootDirectory.Name)
                    menuitemI.ToolTipText = My.Computer.FileSystem.Drives(iIndice).RootDirectory.Name
                    EnviarAToolStripMenuItem.DropDownItems.Add(menuitemI)


                    '----------------------------------------------------------------------------------------------------------------------------------
                    '----------------------------------------------------------------------------------------------------------------------------------
                    '----------------------------------------------------------------------------------------------------------------------------------

                    Dim NodoPadre As TreeNode

                    Try


                        For Each Dir0 As String In My.Computer.FileSystem.GetDirectories(My.Computer.FileSystem.Drives(iIndice).RootDirectory.Name)
                            iDir = My.Computer.FileSystem.GetDirectoryInfo(Dir0)
                            Dim attributeReader As System.IO.FileAttributes
                            attributeReader = iDir.Attributes

                            If (attributeReader And System.IO.FileAttributes.Hidden) > 0 Then

                            Else
                                NodoPadre = childnode.Nodes.Add("", iDir.Name, 7)
                                NodoPadre.ToolTipText = Dir0
                                NodoPadre.Tag = 7
                            End If



                        Next
                    Catch ex As Exception

                    End Try


                    '----------------------------------------------------------------------------------------------------------------------------------
                    '----------------------------------------------------------------------------------------------------------------------------------
                    '----------------------------------------------------------------------------------------------------------------------------------


                Else
                    childnode = parentnode.Nodes.Add("", My.Computer.FileSystem.Drives(iIndice).VolumeLabel & " " & "(" & My.Computer.FileSystem.Drives(iIndice).RootDirectory.Name & ")", cdrive.DriveType)

                    Dim menuitemI As New ToolStripMenuItem(My.Computer.FileSystem.Drives(iIndice).VolumeLabel & " " & "(" & My.Computer.FileSystem.Drives(iIndice).RootDirectory.Name & ")")
                    menuitemI.ToolTipText = My.Computer.FileSystem.Drives(iIndice).RootDirectory.Name
                    EnviarAToolStripMenuItem.DropDownItems.Add(menuitemI)


                    '----------------------------------------------------------------------------------------------------------------------------------
                    '----------------------------------------------------------------------------------------------------------------------------------
                    '----------------------------------------------------------------------------------------------------------------------------------

                    Dim NodoPadre As TreeNode

                    Try


                        For Each Dir0 As String In My.Computer.FileSystem.GetDirectories(My.Computer.FileSystem.Drives(iIndice).RootDirectory.Name)
                            iDir = My.Computer.FileSystem.GetDirectoryInfo(Dir0)
                            Dim attributeReader As System.IO.FileAttributes
                            attributeReader = iDir.Attributes

                            If (attributeReader And System.IO.FileAttributes.Hidden) > 0 Then


                            Else
                                NodoPadre = childnode.Nodes.Add("", iDir.Name, 7)
                                NodoPadre.ToolTipText = Dir0
                                NodoPadre.Tag = 7

                            End If



                        Next
                    Catch ex As Exception

                    End Try

                    '----------------------------------------------------------------------------------------------------------------------------------
                    '----------------------------------------------------------------------------------------------------------------------------------
                    '----------------------------------------------------------------------------------------------------------------------------------

                End If

                childnode.Tag = cdrive.DriveType
                childnode.ToolTipText = My.Computer.FileSystem.Drives(iIndice).RootDirectory.Name


            Catch ex As Exception

            End Try


        Next

        RemoteDrives(TreeView1)
        TreeView1.Nodes(1).Expand()

    End Sub


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'RootUser = IO.File.ReadAllText("N:\Nexus\AppWork\NxDisckExplorer\SDroot")
        RellenarTV(SystemInformation.UserName)
        CurrentDrives()

        'IO.File.WriteAllText("N:\Nexus\AppWork\NxDisckExplorer\IsRun", "True")

        'Load_Me("DiskExplorer", PictureBox1.Image, ListenNumber)

        Label1.BackColor = Color.FromArgb(2, Color.White)
        Load_Ext()



    End Sub

    Public InDrivesView As Boolean = False

    Sub CurrentDrives()

        InDrivesView = True

        ListView1.Items.Clear()
        ListView1.SmallImageList = ImageList1
        ListView1.LargeImageList = ImageList2

        Dim iIndice As Integer
        Dim tDrive As Integer
        Dim lviElemento As System.Windows.Forms.ListViewItem


        For iIndice = 0 To My.Computer.FileSystem.Drives.Count - 1

            Try
                tDrive = My.Computer.FileSystem.Drives(iIndice).DriveType

                If My.Computer.FileSystem.Drives(iIndice).VolumeLabel = "" Then
                    lviElemento = New System.Windows.Forms.ListViewItem("Unidad " & My.Computer.FileSystem.Drives(iIndice).RootDirectory.Name, tDrive)
                Else
                    lviElemento = New System.Windows.Forms.ListViewItem(My.Computer.FileSystem.Drives(iIndice).VolumeLabel & vbNewLine & " (" & "Unidad " & My.Computer.FileSystem.Drives(iIndice).RootDirectory.Name & ")", tDrive)

                End If

                lviElemento.SubItems.Add(" ")
                lviElemento.SubItems.Add("Unidad de almacenaje")
                lviElemento.ToolTipText = My.Computer.FileSystem.Drives(iIndice).RootDirectory.Name
                lviElemento.Tag = "Unidad"
                ListView1.Items.Add(lviElemento)

            Catch ex As Exception

                tDrive = My.Computer.FileSystem.Drives(iIndice).DriveType

                Dim Indice As Integer = 1

                If tDrive = 3 Then
                    Indice = 9 'HDD
                ElseIf tDrive = 5 Then
                    Indice = 8 'CDR
                ElseIf tDrive = 2 Then
                    Indice = 10 'USB
                Else
                    Indice = tDrive
                End If

                lviElemento = New System.Windows.Forms.ListViewItem("Unidad " & My.Computer.FileSystem.Drives(iIndice).RootDirectory.Name, Indice)
                lviElemento.SubItems.Add(" ")
                lviElemento.SubItems.Add("Unidad de almacenaje")
                lviElemento.ToolTipText = My.Computer.FileSystem.Drives(iIndice).RootDirectory.Name
                lviElemento.Tag = "Unidad"
                ListView1.Items.Add(lviElemento)

            End Try

        Next


    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect


        Panel8.Visible = False
        Label8.Visible = False
        Label1.Visible = False

        '_______________________________________________________________________________________
        Dim t As Integer
        t = e.Node.Tag()
        e.Node.SelectedImageIndex = t

        Dim Un As String
        Un = e.Node.Text

        LastSelectNode = e.Node.ToolTipText
        Label2.Visible = False

        ShowDriveInfo(e.Node.ToolTipText)

        Try

            If Un = "Unidades actuales" Then

                CurrentDrives()
                Label1.Visible = False
                RutaActual = ""
                e.Node.Expand()
                ' NavegationList.Clear()

            ElseIf Un = "Unidades remotas" Then

                ListView1.Items.Clear()
                ListView1.LargeImageList = ImageList2
                ListView1.SmallImageList = ImageList1

                For Each Nodo As TreeNode In e.Node.Nodes

                    Dim LvItem As New ListViewItem(Nodo.Text, 11)
                    LvItem.SubItems.Add("")
                    LvItem.SubItems.Add("Disco remoto")
                    LvItem.ToolTipText = Nodo.ToolTipText

                    ListView1.Items.Add(LvItem)
                Next

            ElseIf Un = RootUser Then
                RutaActual = e.Node.ToolTipText

            ElseIf e.Node.ToolTipText.StartsWith(">") Then
                'Acceso a unidad remota
                OpenRemote(e.Node.ToolTipText)
                TextBox1.Text = RutaActual
                '----------------------
            Else
                e.Node.Expand()

                RutaActual = e.Node.ToolTipText

                ListView1.SmallImageList = ImgExtList
                ListView1.LargeImageList = ImgExtListBigger

                Dim Result As String = AbrirDirectorio(RutaActual, ListView1, ShowHide, TextBox2.Text, True)


                If Result.Contains("\") Then
                    Label2.Visible = False
                    TextBox1.Text = AbrirDirectorio(RutaActual, ListView1, ShowHide, TextBox2.Text, False)
                Else
                    Label2.Visible = True
                    Label2.Text = Result
                End If

            End If

        Catch ex As Exception

        End Try

        '____________________________________________________________________________________________________________________________________________________

        Dim iDir As IO.DirectoryInfo
        Dim NodoHijo As TreeNode

        Dim TreeChild As TreeNode = e.Node

        Try
            If TreeChild.Tag = 7 Then

                TreeChild.Nodes.Clear()

                For Each Dire As String In My.Computer.FileSystem.GetDirectories(TreeChild.ToolTipText)

                    iDir = My.Computer.FileSystem.GetDirectoryInfo(Dire)
                    Dim attributeReader As System.IO.FileAttributes
                    attributeReader = iDir.Attributes

                    If (attributeReader And System.IO.FileAttributes.Hidden) > 0 Then

                    Else

                        NodoHijo = New TreeNode(iDir.Name)
                        NodoHijo.Tag = 7
                        NodoHijo.ImageIndex = 7
                        NodoHijo.ToolTipText = Dire

                        TreeChild.Nodes.Add(NodoHijo)

                    End If
                Next

                e.Node.ExpandAll()


            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

        If Mx = True Then
            'NotMaximiced()
        End If

        'Close_Me("DiskExplorer")

        'IO.File.WriteAllText("N:\Nexus\AppWork\NxDisckExplorer\IsRun", "False")



        End

    End Sub

    Dim DrivesCount As Integer = My.Computer.FileSystem.Drives.Count

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If DrivesCount < My.Computer.FileSystem.Drives.Count Then
            RellenarTV(SystemInformation.UserName)
            DrivesCount = My.Computer.FileSystem.Drives.Count
            If InDrivesView = True Then
                CurrentDrives()
            Else
                Exit Sub

            End If
        ElseIf DrivesCount > My.Computer.FileSystem.Drives.Count Then
            RellenarTV(SystemInformation.UserName)
            DrivesCount = My.Computer.FileSystem.Drives.Count

            If InDrivesView = True Then
                CurrentDrives()
            Else
                Exit Sub

            End If
        Else

            Exit Sub

        End If





    End Sub

    Dim GetDriveInfo As System.IO.DriveInfo

    Sub ShowDriveInfo(ByVal Drive As String)

        If Drive = "Unidades actuales" Or Drive = "Unidades remotas" Then
            Label1.Visible = False
            Exit Sub

        ElseIf Not Drive.Length <= 3 Then
            Label1.Visible = False
            Exit Sub

        Else
            Label1.Visible = True
            GetDriveInfo = My.Computer.FileSystem.GetDriveInfo(Drive)

        End If


        Dim Tipo As Integer = GetDriveInfo.DriveType
        Label8.Text = "Estado " & Drive

        Try

            ProgressBar1.Maximum = calcularTamanoII(GetDriveInfo.TotalSize).Remove(6)
            ProgressBar1.Value = calcularTamanoII(GetDriveInfo.TotalSize).Remove(6) - calcularTamanoII(GetDriveInfo.AvailableFreeSpace).Remove(6)
            Panel9.Width = (ProgressBar1.Value / ProgressBar1.Maximum) * Panel8.Width

            Dim PV As Integer = CInt(ProgressBar1.Value)
            Dim PMP As Integer = CInt(ProgressBar1.Maximum)

            If PV < (PMP * 0.6) Then
                Panel9.BackColor = Color.DodgerBlue
            Else
                Panel9.BackColor = Color.Yellow
            End If

            If PV > (PMP * 0.7) Then
                Panel9.BackColor = Color.Yellow
            End If

            If PV > (PMP * 0.8) Then
                Panel9.BackColor = Color.Orange
            End If

            If PV > (PMP * 0.91) Then
                Panel9.BackColor = Color.Red
            End If



            Label1.Text = calcularTamano(GetDriveInfo.TotalSize - GetDriveInfo.AvailableFreeSpace) & "/" & calcularTamano(GetDriveInfo.TotalSize)

            Label8.Visible = True
            Panel8.Visible = True
            Label1.Left = Panel8.Left + (Panel8.Width / 2) - (Label1.Width / 2)

            Label1.Visible = True

        Catch ex As Exception

            ProgressBar1.Value = 0
            Label8.Visible = True
            Panel8.Visible = True
            Panel9.Width = (ProgressBar1.Value / ProgressBar1.Maximum) * Panel8.Width

            Label1.Text = "No disponible"
            Label1.BackColor = Color.FromArgb(1, Color.White)
            Label1.Left = Panel8.Left + (Panel8.Width / 2) - (Label1.Width / 2)

            Label1.Visible = True

        End Try





    End Sub

    Dim sAuxiliar As String


    Private Sub Panel7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel7.Click

        Dim index As Integer = RutaActual.LastIndexOf("\")

        Dim Result As String = AbrirDirectorio(RutaActual, ListView1, ShowHide, TextBox2.Text, True)

        If Not RutaActual = "" Then

            RutaActual = RutaActual.Remove(index)

            If RutaActual.Length < 3 Then
                RutaActual = RutaActual & "\"
            End If


            If Result.Contains("\") Then
                Label2.Visible = False
                TextBox1.Text = AbrirDirectorio(RutaActual, ListView1, ShowHide, TextBox2.Text, False)
            Else
                Label2.Visible = True
                Label2.Text = Result

            End If

        Else
            CurrentDrives()

        End If

    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick

        TextBox2.Text = ""

        RellenarTV(SystemInformation.UserName)

        Dim lviElemento As System.Windows.Forms.ListViewItem

        Try
            If (Me.ListView1.SelectedItems.Count > 0) Then
                lviElemento = Me.ListView1.SelectedItems(0)

                If (lviElemento.SubItems(2).Text = "Carpeta de archivos") Then


                    If RutaActual = Nothing Then

                        RutaActual = lviElemento.ToolTipText

                    ElseIf RutaActual.EndsWith(":\") Then

                        RutaActual = RutaActual & lviElemento.ToolTipText

                    Else

                        RutaActual = RutaActual & "\" & lviElemento.ToolTipText

                    End If

                    ListView1.SmallImageList = ImgExtList
                    ListView1.LargeImageList = ImgExtListBigger

                    Dim Result As String = AbrirDirectorio(RutaActual, ListView1, ShowHide, TextBox2.Text, True)

                    If Result.Contains("\") Then
                        Label2.Visible = False
                        TextBox1.Text = AbrirDirectorio(RutaActual, ListView1, ShowHide, TextBox2.Text, False)
                    Else
                        Label2.Visible = True
                        Label2.Text = Result

                    End If

                    '_______________________________________________________________________________________________________________________
                ElseIf (lviElemento.SubItems(2).Text = "Unidad de almacenaje") Then
                    If RutaActual = Nothing Then

                        RutaActual = lviElemento.ToolTipText

                    ElseIf RutaActual.EndsWith(":\") Then

                        RutaActual = RutaActual & lviElemento.ToolTipText

                    Else

                        RutaActual = RutaActual & "\" & lviElemento.ToolTipText

                    End If

                    ListView1.SmallImageList = ImgExtList
                    ListView1.LargeImageList = ImgExtListBigger

                    Dim Result As String = AbrirDirectorio(RutaActual, ListView1, ShowHide, TextBox2.Text, True)

                    If Result.Contains("\") Then
                        Label2.Visible = False
                        TextBox1.Text = AbrirDirectorio(RutaActual, ListView1, ShowHide, TextBox2.Text, False)
                    Else
                        Label2.Visible = True
                        Label2.Text = Result

                    End If

                ElseIf (lviElemento.SubItems(2).Text = "Disco remoto") Then
                    'Accesder al disco remoto
                    '-----------------------
                    '-----------------------
                    '----
                    OpenRemote(lviElemento.ToolTipText)
                    TextBox1.Text = RutaActual
                    '----
                    '-----------------------
                    '-----------------------
                    'ElseIf (lviElemento.SubItems(2).Text = "Archivo de audio") Then

                    '    Dim IsRun As String = IO.File.ReadAllText("N:\Nexus\AppWork\NxReproductor/IsRun")


                    '    If IsRun = "False" Then

                    '        savePlaylist()
                    '        IO.File.WriteAllText("N:\Nexus\AppWork\NxReproductor/&bucle&", "True")
                    '        IO.File.WriteAllText("N:\Nexus\AppWork\NxReproductor/TMedia", "Audio")

                    '        IO.File.WriteAllText("N:\Nexus\AppWork/NxReproductor/&play&", RutaActual & "/" & lviElemento.ToolTipText)
                    '        Process.Start("N:\Dev App\NxPlayer\NxPlayer\bin\Debug/NxPlayer.exe")
                    '    Else
                    '        Speak("NxPlayer", "+" & RutaActual & "/" & lviElemento.ToolTipText, "C")

                    '    End If
                    '_______________________________________________________________________________________________________________________

                    'ElseIf (lviElemento.SubItems(2).Text = "Archivo de vídeo") Then
                    '    Dim IsRun As String = IO.File.ReadAllText("N:\Nexus\AppWork\NxReproductor/IsRun")

                    '    If IsRun = "False" Then

                    '        savePlaylist()
                    '        IO.File.WriteAllText("N:\Nexus\AppWork\NxReproductor/&bucle&", "True")
                    '        IO.File.WriteAllText("N:\Nexus\AppWork\NxReproductor/TMedia", "Video")

                    '        IO.File.WriteAllText("N:\Nexus\AppWork/NxReproductor/&play&", RutaActual & "/" & lviElemento.ToolTipText)
                    '        Process.Start("N:\Dev App\NxPlayer\NxPlayer\bin\Debug/NxPlayer.exe")

                    '    Else
                    '        Speak("NxPlayer", "-" & RutaActual & "/" & lviElemento.ToolTipText, "C")
                    '    End If
                    '_______________________________________________________________________________________________________________________

                    'ElseIf (lviElemento.SubItems(2).Text = "Imagen") Then
                    '    Dim IsRun As String = IO.File.ReadAllText("N:\Nexus\AppWork\NxPicViewer\IsRun")

                    '    If IsRun = "False" Then
                    '        'IO.File.WriteAllText("N:\NexusFrameWork\NxPicViewer\rFile", "False")
                    '        'IO.File.WriteAllText("N:\NexusFrameWork\NxPicViewer\nFile", RutaActual & "/" & lviElemento.ToolTipText)

                    '        Process.Start("N:\Dev App\PicViewer\PicViewer\bin\Debug\PicViewer.exe")

                    '        App_Break(1000)

                    '        Speak("PicViewer", "+" & RutaActual & "/" & lviElemento.ToolTipText, "C")

                    '    Else

                    '        Speak("PicViewer", "+" & RutaActual & "/" & lviElemento.ToolTipText, "C")

                    '    End If



                    'ElseIf (lviElemento.SubItems(2).Text = "Documento de texto") Or (lviElemento.SubItems(2).Text = "Documento de texto enriquecido") Then

                    '    Dim IsRun As String = IO.File.ReadAllText("N:\Nexus\AppWork\NxTxt\IsRun")

                    '    If IsRun = "False" Then
                    '        'IO.File.WriteAllText("N:\Nexus\AppWork\NxPicViewer\rFile", "False")
                    '        'IO.File.WriteAllText("N:\Nexus\AppWork\NxPicViewer\nFile", RutaActual & "/" & lviElemento.ToolTipText)

                    '        Process.Start("N:\Dev App\NxtxtBloc\NxtxtBloc\bin\Debug\NxtxtBloc.exe")

                    '        App_Break(1000)

                    '        Speak("TextBloc", "+" & RutaActual & "/" & lviElemento.ToolTipText, "C")

                    '    Else

                    '        Speak("TextBloc", "+" & RutaActual & "/" & lviElemento.ToolTipText, "C")

                    '    End If


                ElseIf (lviElemento.SubItems(2).Text = "Lista de reproduccion") Then

                    Dim Route As String = "N:\Nexus\AppWork\NxReproductor\AddRepList"

                    Dim toSave As String = ""

                    For Each ListItem As ListViewItem In Me.ListView1.SelectedItems

                        toSave = RutaActual & "\" & ListItem.ToolTipText

                        IO.File.Copy(toSave, Route & "\" & ListItem.ToolTipText)

                    Next

                    IO.File.WriteAllText("N:\Nexus\AppWork\NxReproductor\RepList", "True")

                    Dim eValue As String = IO.File.ReadAllText("N:\Nexus\AppWork\NxReproductor\IsRun")

                    If eValue = "False" Then
                        Process.Start("N:\Dev App\NxPlayer\NxPlayer\bin\Debug\NxPlayer.exe")
                    End If

                    'ElseIf (lviElemento.SubItems(2).Text = "Pagina Web") Then


                Else
                    ' no puede abrir el archivo o ejecutar la aplicacion, se dejara proceder a Windows para realizar la operacion.
                    Try
                        Process.Start(RutaActual & "\" & lviElemento.ToolTipText)
                    Catch ex As Exception
                        'mensaje de ex
                    End Try

                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub PictureBox3_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseDown
        XY.X = CInt(CLng(x))
        XY.Y = CInt(CLng(y))
    End Sub

    Private Sub PictureBox3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Right Or e.Button = Windows.Forms.MouseButtons.Left Then
            'redimensionamos el ancho
            If (Me.Width + (x + e.X)) > 0 Then

                Me.Width = Me.Width + (x + e.X)
            End If
            'redimensionams el alto
            If (Me.Height + (y + e.Y)) > 0 Then

                Me.Height = Me.Height + (y + e.Y)
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then

            If TextBox1.Text.Length > 2 Then
                ListView1.SmallImageList = ImgExtList
                ListView1.LargeImageList = ImgExtListBigger

                Dim Result As String = AbrirDirectorio(TextBox1.Text, ListView1, ShowHide, TextBox2.Text, True)

                If Result.Contains("/") Then
                    Label2.Visible = False
                    TextBox1.Text = AbrirDirectorio(TextBox1.Text, ListView1, ShowHide, TextBox2.Text, False)
                ElseIf Result.Contains("\") Then
                    Label2.Visible = False
                    TextBox1.Text = AbrirDirectorio(TextBox1.Text, ListView1, ShowHide, TextBox2.Text, False)
                Else
                    Label2.Visible = True
                    Label2.Text = Result

                End If

            Else
                Exit Sub
            End If

        End If
    End Sub

    Dim Msize As Point = Nothing
    Dim maximised As Boolean = False

    Dim Mx As Boolean = False

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

        'Maximiced()

        Dim lX As Integer = My.Computer.Screen.WorkingArea.Width
        Dim lY As Integer = My.Computer.Screen.WorkingArea.Height
        Msize = Me.Size
        maximised = True

        Me.Left = 0
        Me.Top = 0

        Me.Width = lX
        Me.Height = lY


        Me.MaximumSize = Me.Size

        Mx = True

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

            If maximised = True Then
                maximised = False
                Me.Size = Msize
            End If

        End If



    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            aaa = False

        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        Label2.BackColor = Color.FromArgb(0, Color.Transparent)
        Label1.BackColor = Color.FromArgb(0, Color.Transparent)
        Label2.Location = New Drawing.Point((ListView1.Left + (ListView1.Width / 2)) - (Label2.Width / 2), ListView1.Top + (ListView1.Height / 2) - 20)

        If ListView1.SelectedItems.Count > 0 Then
            AbrirToolStripMenuItem.Enabled = True

            If ListView1.SelectedItems(0).Tag = "Carpeta" Then
                CopiarToolStripMenuItem.Enabled = True
                CortarToolStripMenuItem.Enabled = True
                ToolStripMenuItem1.Enabled = True
                PropiedadesToolStripMenuItem.Enabled = True
                EnviarAToolStripMenuItem.Enabled = True
                CambiarNombreToolStripMenuItem.Enabled = True
                CopiarRutaToolStripMenuItem.Visible = True

            ElseIf ListView1.SelectedItems(0).Tag = "Archivo" Then
                CopiarToolStripMenuItem.Enabled = True
                CortarToolStripMenuItem.Enabled = True
                ToolStripMenuItem1.Enabled = True
                PropiedadesToolStripMenuItem.Enabled = True
                EnviarAToolStripMenuItem.Enabled = True
                CambiarNombreToolStripMenuItem.Enabled = True
                CopiarRutaToolStripMenuItem.Visible = True


            ElseIf ListView1.SelectedItems(0).Tag = "Unidad" Then
                CopiarToolStripMenuItem.Enabled = False
                CortarToolStripMenuItem.Enabled = False
                ToolStripMenuItem1.Enabled = False
                PropiedadesToolStripMenuItem.Enabled = True
                EnviarAToolStripMenuItem.Enabled = False
                CambiarNombreToolStripMenuItem.Enabled = False
                CopiarRutaToolStripMenuItem.Visible = False


            Else
                CopiarToolStripMenuItem.Enabled = False
                CortarToolStripMenuItem.Enabled = False
                ToolStripMenuItem1.Enabled = False
                PropiedadesToolStripMenuItem.Enabled = False
                EnviarAToolStripMenuItem.Enabled = False
                CambiarNombreToolStripMenuItem.Enabled = False
                CopiarRutaToolStripMenuItem.Visible = False


            End If

        Else
            CopiarToolStripMenuItem.Enabled = False
            CortarToolStripMenuItem.Enabled = False
            ToolStripMenuItem1.Enabled = False
            PropiedadesToolStripMenuItem.Enabled = False
            EnviarAToolStripMenuItem.Enabled = False
            AbrirToolStripMenuItem.Enabled = False
            CambiarNombreToolStripMenuItem.Enabled = False
            CopiarRutaToolStripMenuItem.Visible = False

        End If

        Try

            If ListView1.SelectedItems.Count > 0 Then
                If ListView1.SelectedItems(0).SubItems(2).Text = "Archivo de audio" Then
                    ToolStripMenuItem3.Visible = True

                ElseIf ListView1.SelectedItems(0).SubItems(2).Text = "Archivo de vídeo" Then
                    ToolStripMenuItem3.Visible = True

                ElseIf ListView1.SelectedItems(0).SubItems(2).Text = "Lista de reproduccion" Then
                    ToolStripMenuItem3.Visible = True

                Else
                    ToolStripMenuItem3.Visible = False
                End If
            Else
                ToolStripMenuItem3.Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub EnviarAToolStripMenuItem_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles EnviarAToolStripMenuItem.DropDownItemClicked

        Dim LvElemnts As ListViewItem
        Dim copyto As String

        For Each LvElemnts In ListView1.SelectedItems

            copyto = e.ClickedItem.ToolTipText

            Dim file As String = RutaActual & "\" & LvElemnts.ToolTipText

            If Not IO.File.Exists(copyto & LvElemnts.ToolTipText) Then

                IO.File.Copy(file, copyto & LvElemnts.ToolTipText)

            Else
                If MsgBox("Este archivo ya existe, ¿Quiere sustituirlo?", MsgBoxStyle.Question + vbYesNo) = MsgBoxResult.Yes Then
                    IO.File.Copy(file, copyto & LvElemnts.ToolTipText, True)
                End If
            End If

        Next


    End Sub

    Dim SelecNew As String

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

        Label1.Visible = False
        Panel8.Visible = False
        Label8.Visible = False

        Try
            If ListView1.SelectedItems(0).ToolTipText.EndsWith(":\") Then

                ShowDriveInfo(ListView1.SelectedItems(0).ToolTipText)
                SelecNew = ListView1.SelectedItems(0).Text


            Else
                Label8.Visible = False
                Panel8.Visible = False
                SelecNew = ListView1.SelectedItems(0).Text

            End If
        Catch ex As Exception

        End Try


    End Sub

    '--------------------------------------------------------------------
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click



        If InDrivesView = True Then
            CurrentDrives()
            RellenarTV(SystemInformation.UserName)
        Else
            ListView1.SmallImageList = ImgExtList
            ListView1.LargeImageList = ImgExtListBigger

            Dim Result As String = AbrirDirectorio(RutaActual, ListView1, ShowHide, TextBox2.Text, True)

            If Result.Contains("/") Then
                Label2.Visible = False
                TextBox1.Text = AbrirDirectorio(RutaActual, ListView1, ShowHide, TextBox2.Text, False)
            ElseIf Result.Contains("\") Then
                Label2.Visible = False
                TextBox1.Text = AbrirDirectorio(RutaActual, ListView1, ShowHide, TextBox2.Text, False)
            Else
                Label2.Visible = True
                Label2.Text = Result

            End If

        End If




    End Sub


    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        Configs.Show()
    End Sub

    Sub savePlaylist()

        Dim Route As String = "N:\Nexus\AppWork\NxReproductor\AddRepList"

        Dim toSave As String = ""
        Dim x As Boolean = True

        For Each ListItem As ListViewItem In Me.ListView1.SelectedItems

            If x = True Then
                toSave = RutaActual & "\" & ListItem.ToolTipText & "|" & vbNewLine
                x = False
            Else
                toSave = toSave & RutaActual & "\" & ListItem.ToolTipText & "|" & vbNewLine
            End If

        Next

        Dim dat As String = Now.Date
        Dim tim As String = TimeOfDay

        dat = dat.Replace("\", "")
        dat = dat.Replace("/", "")
        tim = tim.Replace(":", "")

        IO.File.WriteAllText(Route & "\" & dat & "_" & tim & ".nxlp", toSave)
        IO.File.WriteAllText("N:\Nexus\AppWork\NxReproductor\RepList", "True")

    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Try

            If ListView1.SelectedItems(0).SubItems(2).Text = "Lista de reproduccion" Then

                Dim Route As String = "N:\Nexus\AppWork\NxReproductor\AddRepList"

                Dim toSave As String = ""

                For Each ListItem As ListViewItem In Me.ListView1.SelectedItems

                    toSave = RutaActual & "\" & ListItem.ToolTipText

                    IO.File.Copy(toSave, Route & "\" & ListItem.ToolTipText)

                Next

                IO.File.WriteAllText("N:\Nexus\AppWork\NxReproductor\RepList", "True")

                Dim eValue As String = IO.File.ReadAllText("N:\NexusFrameWork\NxReproductor\IsRun")

                If eValue = "False" Then
                    Process.Start("N:\Dev App\NxPlayer\NxPlayer\bin\Debug\NxPlayer.exe")
                End If
            Else

                Dim eValue As String = IO.File.ReadAllText("N:\Nexus\AppWork\NxReproductor\IsRun")

                If eValue = "False" Then
                    savePlaylist()
                    Process.Start("N:\Dev App\NxPlayer\NxPlayer\bin\Debug\NxPlayer.exe")
                Else
                    savePlaylist()
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub AbrirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirToolStripMenuItem.Click

        AddHandler AbrirToolStripMenuItem.Click, AddressOf ListView1_DoubleClick

    End Sub

    Private Sub CambiarNombreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarNombreToolStripMenuItem.Click
        Me.ListView1.SelectedItems(0).BeginEdit()


        'If ListView1.SelectedItems.Count > 0 Then
        '    SetAnyThing.Here = RutaActual
        '    If ListView1.SelectedItems(0).SubItems(2).Text = "Carpeta de archivos" Then

        '        SetAnyThing.EDir = ListView1.SelectedItems(0).ToolTipText

        '        SetNameOrOther("Renombrar carpeta", 0)

        '        SetAnyThing.IsFile = False
        '    Else
        '        SetNameOrOther("Renombrar archvio", 0)
        '        SetAnyThing.EDir = RutaActual
        '        SetAnyThing.Efile = ListView1.SelectedItems(0).ToolTipText
        '        SetAnyThing.IsFile = True
        '    End If
        'End If



    End Sub

    Dim rRef As String
    Dim ListCopy As New List(Of String)

    Private Sub CopiarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarToolStripMenuItem.Click

        ListCopy.Clear()

        For Each File As ListViewItem In ListView1.SelectedItems

            ListCopy.Add(RutaActual & "/" & File.ToolTipText)
        Next

        rRef = "C"

        PegarToolStripMenuItem.Enabled = True

    End Sub


    Private Sub CortarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CortarToolStripMenuItem.Click

        PegarToolStripMenuItem.Enabled = True

    End Sub

    Private Sub PegarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PegarToolStripMenuItem.Click

        If rRef = "C" Then

            Dim cCopy As New ClassCopyFile.Copy
            cCopy.StartPosition = Windows.Forms.FormStartPosition.WindowsDefaultLocation
            cCopy.Destination = RutaActual

            cCopy.Files.AddRange(ListCopy)

            On Error GoTo 1
            cCopy.Show()
1:

            PegarToolStripMenuItem.Enabled = False

            AbrirDirectorio(RutaActual, ListView1, ShowHide, TextBox2.Text, False)

        ElseIf rRef = "X" Then


        End If

    End Sub

    Private Sub ListView1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListView1.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then

            AddHandler ListView1.KeyPress, AddressOf ListView1_DoubleClick

        ElseIf e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Back) Then

            AddHandler ListView1.KeyPress, AddressOf Panel7_Click

        ElseIf e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Delete) Then

            ' eliminar()

        End If
    End Sub

    Private Sub ListView1_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView1.AfterLabelEdit
        Dim Info As IO.FileInfo
        Try
            If ListView1.SelectedItems(0).SubItems(2).Text = "Carpeta de archivos" Then
                Info = New IO.FileInfo(RutaActual & "\" & ListView1.SelectedItems(0).ToolTipText)
                My.Computer.FileSystem.RenameDirectory(RutaActual & "\" & ListView1.SelectedItems(0).ToolTipText, e.Label & Info.Extension)

            ElseIf ListView1.SelectedItems(0).SubItems(2).Text = "Disco remoto" Then

                For Each Disc As String In IO.Directory.GetDirectories(RemoteRecors)
                    Dim Nm As String = IO.File.ReadAllText(Disc & "/name")
                    If Nm = ListView1.SelectedItems(0).SubItems(0).Text Then
                        IO.File.WriteAllText(Disc & "/name", e.Label)
                    End If
                Next

            Else
                Info = New IO.FileInfo(RutaActual & "\" & ListView1.SelectedItems(0).ToolTipText)
                My.Computer.FileSystem.RenameFile(RutaActual & "\" & ListView1.SelectedItems(0).ToolTipText, e.Label & Info.Extension)
            End If
        Catch ex As Exception

        End Try





    End Sub


    Private Sub PropiedadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesToolStripMenuItem.Click
        If ListView1.SelectedItems(0).Tag = "Unidad" Then
            SetAnyThing.JustDoIt(ListView1.SelectedItems(0).ToolTipText)
        End If
    End Sub

    'Private Sub Form1_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
    '    Panel1.BackColor = Color.DarkGray
    '    Panel2.BackColor = Color.DarkGray

    'End Sub

    'Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    '    Panel1.BackColor = SystmColor
    '    Panel2.BackColor = SystmColor

    'End Sub

    'Private Sub CaptureForm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged

    '    If Mx = True Then

    '        Mx = False
    '        NotMaximiced()

    '    End If

    'End Sub

    'Sub Maximiced()

    '    Dim Value As String

    '    Try
    '        Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")
    '    Catch ex As Exception
    '        Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")

    '    End Try

    '    Dim X As Integer = Val(Value) + 1

    '    Try
    '        IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", CStr(X))
    '    Catch ex As Exception
    '        IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", CStr(X))

    '    End Try

    'End Sub

    'Sub NotMaximiced()

    '    Dim Value As String

    '    Try
    '        Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")
    '    Catch ex As Exception
    '        Value = IO.File.ReadAllText("N:\Nexus\AppWork\Interface\Not Touch")
    '    End Try

    '    Dim X As Integer = Val(Value) - 1

    '    Try
    '        IO.File.WriteAllText("N:\Nexus\AppWork\Interface\Not Touch", CStr(X))
    '    Catch ex As Exception
    '        IO.File.WriteAllText("N:\Nexus\AppWork/Interface\Not Touch", CStr(X))
    '    End Try


    'End Sub

    'Private Sub Form1_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged

    '    If Me.Visible = True Then

    '        If Mx = True Then
    '            Maximiced()

    '        End If

    '    Else
    '        If Mx = True Then
    '            NotMaximiced()
    '        End If

    '    End If

    'End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        RemoteDsc.Show()
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

        ListView1.SmallImageList = ImgExtList
        ListView1.LargeImageList = ImgExtListBigger

        Dim Result As String = AbrirDirectorio(RutaActual, ListView1, ShowHide, TextBox2.Text, True)

        If Result.Contains("\") Then
            Label2.Visible = False
            TextBox1.Text = AbrirDirectorio(RutaActual, ListView1, ShowHide, TextBox2.Text, False)
        Else
            Label2.Visible = True
            Label2.Text = Result

        End If
    End Sub


    'Private Sub PictureBox2_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseHover, PictureBox6.MouseHover, PictureBox5.MouseHover, PictureBox4.MouseHover, PictureBox2.MouseHover
    '    CType(sender, PictureBox).BackColor = SystmColor
    'End Sub


    'Private Sub PictureBox2_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox7.MouseUp, PictureBox6.MouseUp, PictureBox5.MouseUp, PictureBox4.MouseUp, PictureBox2.MouseUp
    '    CType(sender, PictureBox).BackColor = SystmColor
    'End Sub

    Private Sub CopiarRutaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarRutaToolStripMenuItem.Click
        Try
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(RutaActual & "\" & ListView1.SelectedItems(0).ToolTipText)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim deletes As New List(Of String)

        For el = 0 To ListView1.SelectedItems.Count - 1
            deletes.Add(RutaActual & "\" & ListView1.SelectedItems(el).ToolTipText)
        Next

        Label8.Visible = True
        Label8.Text = "Eliminando archivos..."

        If (MsgBox("Confirmar antes de borrar", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Borrar") = MsgBoxResult.Ok) Then
            For i = 0 To deletes.Count - 1
                Dim directory As Boolean = My.Computer.FileSystem.DirectoryExists(deletes(i))
                Dim file As Boolean = My.Computer.FileSystem.FileExists(deletes(i))

                If (file) Then
                    My.Computer.FileSystem.DeleteFile(deletes(i))
                ElseIf (directory) Then
                    My.Computer.FileSystem.DeleteDirectory(deletes(i), FileIO.DeleteDirectoryOption.DeleteAllContents)
                End If
            Next
        End If

        Dim tmr As New System.Timers.Timer()
        tmr.Interval = 2000
        tmr.Enabled = True
        tmr.Start()
        AddHandler tmr.Elapsed, AddressOf OnTimedEvent
        CheckForIllegalCrossThreadCalls = False

    End Sub


    Private Sub OnTimedEvent(ByVal sender As Object, ByVal e As ElapsedEventArgs)
        Label8.Visible = False
        Label8.Text = "Espacio"

        AddHandler ToolStripMenuItem1.Click, AddressOf ToolStripMenuItem2_Click
    End Sub
End Class
