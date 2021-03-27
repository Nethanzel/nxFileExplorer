

Module OwnFiles

    Public ShowHide As Boolean = False
    Public RutaActual As String = ""
    Public RootUser As String

    Function calcularTamano(ByVal lTamano As Long) As String
        Dim sCadena As String

        ' Cálculo del tamaño dependiendo de ciertos límites
        If lTamano < 1024 Then ' Hasta 1KB
            sCadena = lTamano & " Bytes"
        ElseIf (lTamano < 1024 ^ eUnidades.MB) Then ' Hasta 1MB
            sCadena = Format(lTamano / 1024, "F") & " KB"
        ElseIf (lTamano < 1024 ^ eUnidades.GB) Then ' Hasta 1GB
            sCadena = Format(lTamano / (1024 ^ 2), "F") & " MB"
        Else ' A partir de 1 GB
            sCadena = Format(lTamano / (1024 ^ 3), "F") & " GB"
        End If

        Return sCadena
    End Function

    Function calcularTamanoII(ByVal lTamano As Long) As String
        Dim sCadena As String

        ' Cálculo del tamaño dependiendo de ciertos límites
        If lTamano < 1024 Then ' Hasta 1KB
            sCadena = lTamano & " Bytes"
        ElseIf (lTamano < 1024 ^ eUnidadess.MB) Then ' Hasta 1MB
            sCadena = Format(lTamano / 1024, "F") & " KB"
        Else
            sCadena = Format(lTamano / (1024 ^ 2), "F") & " MB"
        End If

        Return sCadena
    End Function

    Public Enum eUnidades
        Bytes
        KB
        MB
        GB
    End Enum

    Public Enum eUnidadess
        Bytes
        KB
        MB
    End Enum

    '---Programacion de uso de extenciones y su representacion

    Public ExtList As New List(Of String)
    Public TipoList As New List(Of String)

    Dim ExtDir As String = ".\Ext"
    Dim extCount

    Sub Load_Ext()


        For Each ImgExt As String In IO.Directory.GetFiles(ExtDir)

            Dim Img As Image = Image.FromFile(ImgExt)
            Dim ExtInfo As New IO.FileInfo(ImgExt)
            Dim ExtName As String = ExtInfo.Name
            Dim Index As Integer = ExtName.IndexOf("-")
            Dim indexp As Integer = ExtName.IndexOf(".")

            Form1.ImgExtList.Images.Add(Img)
            Form1.ImgExtListBigger.Images.Add(Img)

            ExtName = ExtName.Remove(indexp)

            ExtList.Add(ExtName.Substring(Index + 1).ToLower)
            TipoList.Add(ExtName.Remove(Index))

            extCount = Form1.ImgExtList.Images.Count

        Next

       
    End Sub


    Function _Tipo(ByVal Ext As String, ByVal Hidden As Boolean) As Integer


        Ext = Ext.Replace(".", "").ToLower

        Dim Index As Integer = ExtList.IndexOf(Ext)

        If Index = -1 And Hidden = False Then

            Return ExtList.IndexOf("archivo")

        ElseIf Index = -1 And Hidden = True Then

            Return ExtList.IndexOf("harchivo")

        ElseIf Ext = "carpeta" And Hidden = True Then

            Return ExtList.IndexOf("hcarpeta")

        ElseIf Index > -1 And Not Ext = "carpeta" And Hidden = True Then

            Return ExtList.IndexOf("h" & Ext)

        Else

            Return Index

        End If


    End Function

    Function _ConfgFile(ByVal Route As String, ByVal hidden As Boolean) As Windows.Forms.ListViewItem

        Dim LvElemt As Windows.Forms.ListViewItem

        Dim Info As New IO.FileInfo(Route)
        Dim index As Integer = Info.Name.IndexOf(".")
        Dim fNombre As String

        If Not index = -1 Then
            fNombre = Info.Name.Remove(index)
        Else
            fNombre = Info.Name
        End If

        Dim fTamano As String = calcularTamano(Info.Length)
        Dim fTipo As String = TipoList.Item(_Tipo(Info.Extension, False))
        Dim fCreacion As String = Info.LastWriteTime

        Dim Atribb As IO.FileAttributes
        Atribb = Info.Attributes

        If fTipo = "Archivo" Then
            fTipo = fTipo & " " & Info.Extension.Replace(".", "").ToUpper
        End If

        If Not (Atribb And IO.FileAttributes.Hidden) > 0 Then

            If (fTipo.ToLower = "imagen") Then
                Dim Img As Image = Image.FromFile(Route)

                Form1.ImgExtList.Images.Add(Img)
                Form1.ImgExtListBigger.Images.Add(Img)

                Dim pos = Form1.ImgExtListBigger.Images.Count - 1

                LvElemt = New Windows.Forms.ListViewItem(fNombre, pos)
                LvElemt.SubItems.Add(fTamano)
                LvElemt.SubItems.Add(fTipo)
                LvElemt.SubItems.Add(fCreacion)

                LvElemt.ToolTipText = Info.Name
                LvElemt.Tag = "Archivo"

                Return LvElemt

            ElseIf (fTipo.ToLower = "acceso directo" Or fTipo.ToLower = "ejecutable") Then

                Dim ico As Icon = Icon.ExtractAssociatedIcon(Route)

                Form1.ImgExtList.Images.Add(ico)
                Form1.ImgExtListBigger.Images.Add(ico)

                Dim pos = Form1.ImgExtListBigger.Images.Count - 1

                LvElemt = New Windows.Forms.ListViewItem(fNombre, pos)
                LvElemt.SubItems.Add(fTamano)
                LvElemt.SubItems.Add(fTipo)
                LvElemt.SubItems.Add(fCreacion)

                LvElemt.ToolTipText = Info.Name
                LvElemt.Tag = "Archivo"

                Return LvElemt

            Else

                LvElemt = New Windows.Forms.ListViewItem(fNombre, _Tipo(Info.Extension, False))
                LvElemt.SubItems.Add(fTamano)
                LvElemt.SubItems.Add(fTipo)
                LvElemt.SubItems.Add(fCreacion)

                LvElemt.ToolTipText = Info.Name
                LvElemt.Tag = "Archivo"

                Return LvElemt

            End If

        Else
            If hidden = True Then
                LvElemt = New Windows.Forms.ListViewItem(fNombre, _Tipo(Info.Extension, True))
                LvElemt.SubItems.Add(fTamano)
                LvElemt.SubItems.Add(fTipo)
                LvElemt.SubItems.Add(fCreacion)

                LvElemt.ToolTipText = Info.Name
                LvElemt.Tag = "Archivo"

                Return LvElemt

            Else

                LvElemt = New Windows.Forms.ListViewItem("")
                Return LvElemt

            End If


        End If



    End Function

    Function _ConfgDir(ByVal Route As String, ByVal hidden As Boolean) As Windows.Forms.ListViewItem


        Dim LvElemt As Windows.Forms.ListViewItem

        Dim Info As New IO.DirectoryInfo(Route)

        Dim fNombre As String = Info.Name
        Dim fTamano As String = ""
        Dim fTipo As String = "Carpeta de archivos"
        Dim fCreacion As String = Info.LastWriteTime

        Dim Atribb As IO.FileAttributes
        Atribb = Info.Attributes

        If Not (Atribb And IO.FileAttributes.Hidden) > 0 Then

            LvElemt = New Windows.Forms.ListViewItem(fNombre, _Tipo("Carpeta", False))
            LvElemt.SubItems.Add(fTamano)
            LvElemt.SubItems.Add(fTipo)
            LvElemt.SubItems.Add(fCreacion)
            LvElemt.ToolTipText = Info.Name
            LvElemt.Tag = "Carpeta"

            Return LvElemt

        Else

            If hidden = True Then
                LvElemt = New Windows.Forms.ListViewItem(fNombre, _Tipo("Carpeta", True))
                LvElemt.SubItems.Add(fTamano)
                LvElemt.SubItems.Add(fTipo)
                LvElemt.SubItems.Add(fCreacion)
                LvElemt.ToolTipText = Info.Name
                LvElemt.Tag = "Carpeta"

                Return LvElemt
            Else
                LvElemt = New Windows.Forms.ListViewItem("")
                Return LvElemt

            End If

        End If


    End Function


    Function BeforeAbrirDirectorio(ByVal Ruta As String, ByVal List As ListView, ByVal Hidden As Boolean, ByVal filter As String) As String


        Try
            For Each Carpeta As String In IO.Directory.GetDirectories(Ruta)

            Next

        Catch ex As Exception
            Return ex.Message.Replace("\", "|")
            Exit Function
        End Try



        For Each Archivo As String In IO.Directory.GetFiles(Ruta)



        Next


        Return Ruta

    End Function

    Public NavegationList As New List(Of String)

    Function AbrirDirectorio(ByVal Ruta As String, ByVal List As ListView, ByVal Hidden As Boolean, ByVal filter As String, ByVal IsBack As Boolean) As String

        Form1.Label2.Visible = False
        List.Items.Clear()

        While extCount < Form1.ImgExtList.Images.Count

            Form1.ImgExtList.Images.RemoveAt(Form1.ImgExtList.Images.Count - 1)
            Form1.ImgExtListBigger.Images.RemoveAt(Form1.ImgExtListBigger.Images.Count - 1)
        End While

        Try
            For Each Carpeta As String In IO.Directory.GetDirectories(Ruta)

                Dim lvElment As New System.Windows.Forms.ListViewItem

                If filter.Length > 0 Then

                    Dim Conditional As New IO.DirectoryInfo(Carpeta)

                    If Conditional.Name.ToLower.Contains(filter.ToLower) Then

                        lvElment = _ConfgDir(Carpeta, Hidden)

                        If Not lvElment.Text = Nothing Then

                            List.Items.Add(lvElment)
                        End If

                    End If

                Else

                    lvElment = _ConfgDir(Carpeta, Hidden)

                    If Not lvElment.Text = Nothing Then

                        List.Items.Add(lvElment)
                    End If

                End If

            Next

        Catch ex As Exception
            Return ex.Message.Replace("\", "|")
            Exit Function
        End Try



        For Each Archivo As String In IO.Directory.GetFiles(Ruta)

            Dim lvElment As New System.Windows.Forms.ListViewItem


            If filter.Length > 0 Then

                Dim Conditional As New IO.FileInfo(Archivo)

                If Conditional.Name.ToLower.Contains(filter.ToLower) Then

                    lvElment = _ConfgFile(Archivo, Hidden)

                    If Not lvElment.Text = Nothing Then

                        Try
                            List.Items.Add(lvElment)
                        Catch ex As Exception

                        End Try
                    End If
                End If

            Else
                lvElment = _ConfgFile(Archivo, Hidden)

                If Not lvElment.Text = Nothing Then

                    Try
                        List.Items.Add(lvElment)
                    Catch ex As Exception

                    End Try
                End If
            End If




        Next

        If IsBack = False Then
            NavegationList.Add(RutaActual)
        End If

        RutaActual = Ruta
        Form1.InDrivesView = False
        Return Ruta

    End Function

    'Sub SetNameOrOther(ByVal Funcion As String, ByVal N As Integer)

    '    SetAnyThing.Label1.Text = Funcion

    '    If N = 2 Then
    '        SetAnyThing.PnlCrearDir.Dock = DockStyle.Fill
    '        SetAnyThing.PnlCrearDir.Visible = True
    '        SetAnyThing.PnlSetName.Visible = False
    '        SetAnyThing.Show()
    '    ElseIf N = 0 Then

    '        SetAnyThing.PnlSetName.Dock = DockStyle.Fill
    '        SetAnyThing.PnlSetName.Visible = True
    '        SetAnyThing.PnlCrearDir.Visible = False
    '        SetAnyThing.Show()



    '    End If


    'End Sub


    Sub SpecialDirectories(ByVal Tree As TreeView, ByVal Root As String)

        'Dim rt As String = "N:\Users\" & Root & "\User"

        Dim fNode As New TreeNode(Root, 12, 12)
        'fNode.NodeFont = New Font("Microsoft Sans Serif", 7, FontStyle.Bold)
        fNode.Tag = 12
        fNode.ToolTipText = "C:\Users\" & Root & "\"
        Dim iDir As IO.DirectoryInfo
        Dim NodoHijo As TreeNode

        Dim downloads = My.Computer.FileSystem.SpecialDirectories.MyDocuments

        downloads = downloads.Remove(downloads.LastIndexOf("\")) + "\Downloads"

        Dim Directories() As String = { _
            My.Computer.FileSystem.SpecialDirectories.MyDocuments, _
            My.Computer.FileSystem.SpecialDirectories.Desktop, _
            My.Computer.FileSystem.SpecialDirectories.MyMusic, _
            My.Computer.FileSystem.SpecialDirectories.MyPictures, _
            downloads _
            }


        For Each Directorio As String In Directories
            iDir = My.Computer.FileSystem.GetDirectoryInfo(Directorio)

            If iDir.Name = "Desktop" Then

                NodoHijo = New TreeNode(iDir.Name)
                NodoHijo.Tag = 13
                NodoHijo.ImageIndex = 13
                NodoHijo.ToolTipText = Directorio

            ElseIf iDir.Name = "Images" Then

                NodoHijo = New TreeNode(iDir.Name)
                NodoHijo.Tag = 18
                NodoHijo.ImageIndex = 18
                NodoHijo.ToolTipText = Directorio

            ElseIf iDir.Name = "Documents" Then

                NodoHijo = New TreeNode(iDir.Name)
                NodoHijo.Tag = 14
                NodoHijo.ImageIndex = 14
                NodoHijo.ToolTipText = Directorio

            ElseIf iDir.Name = "Videos" Then

                NodoHijo = New TreeNode(iDir.Name)
                NodoHijo.Tag = 20
                NodoHijo.ImageIndex = 20
                NodoHijo.ToolTipText = Directorio

            ElseIf iDir.Name = "Music" Then

                NodoHijo = New TreeNode(iDir.Name)
                NodoHijo.Tag = 17
                NodoHijo.ImageIndex = 17
                NodoHijo.ToolTipText = Directorio

            ElseIf iDir.Name = "Downloads" Then

                NodoHijo = New TreeNode(iDir.Name)
                NodoHijo.Tag = 15
                NodoHijo.ImageIndex = 15
                NodoHijo.ToolTipText = Directorio

            ElseIf iDir.Name = "Pictures" Then

                NodoHijo = New TreeNode(iDir.Name)
                NodoHijo.Tag = 18
                NodoHijo.ImageIndex = 18
                NodoHijo.ToolTipText = Directorio

            Else

                NodoHijo = New TreeNode(iDir.Name)
                NodoHijo.Tag = 7
                NodoHijo.ImageIndex = 7
                NodoHijo.ToolTipText = Directorio

            End If


            fNode.Nodes.Add(NodoHijo)
            fNode.Expand()

        Next


        Tree.Nodes.Add(fNode)

    End Sub

    Sub RemoteDrives(ByVal Tree As TreeView)

        Dim fNode As New TreeNode("Unidades remotas", 21, 21)
        fNode.ToolTipText = "Unidades remotas"
        fNode.Tag = 21

        Dim NodoHijo As TreeNode

        If Not My.Computer.FileSystem.GetDirectoryInfo(RemoteRecors).Exists Then
            My.Computer.FileSystem.CreateDirectory(RemoteRecors)
        End If

        For Each Disc As String In IO.Directory.GetDirectories(RemoteRecors)

            Dim Usr As String = IO.File.ReadAllText(Disc & "/user")
            Dim Psswrd As String = IO.File.ReadAllText(Disc & "/pass")
            Dim Srvr As String = IO.File.ReadAllText(Disc & "/server")
            Dim Nm As String = IO.File.ReadAllText(Disc & "/name")

            NodoHijo = New TreeNode(Nm)
            NodoHijo.Tag = 22
            NodoHijo.ImageIndex = 22
            NodoHijo.ToolTipText = ">" & Usr & "-" & Psswrd & "+" & Srvr

            fNode.Nodes.Add(NodoHijo)
        Next

        Tree.Nodes.Add(fNode)
        

    End Sub



    Sub OpenRemote(ByVal ToolTip As String)

        Form1.ListView1.Items.Clear()
        Form1.ListView1.SmallImageList = Form1.ImgExtList
        Form1.ListView1.LargeImageList = Form1.ImgExtListBigger

        Try

            Dim UserName As String = ToolTip.Remove(ToolTip.IndexOf("-"))
            UserName = UserName.Replace(">", "")

            Dim Password As String = ToolTip.Substring(ToolTip.IndexOf("-") + 1)
            Password = Password.Remove(Password.IndexOf("+"))

            Dim ServerLink As String = ToolTip.Substring(ToolTip.IndexOf("+") + 1)


            If FTP_Conect(UserName, Password, ServerLink) = True Then

                Dim Lst As List(Of String) = FTP_ListDirectory(ServerLink, UserName, Password)

                For i = 0 To Lst.Count - 1
                    Try
                        Dim xItem As Windows.Forms.ListViewItem
                        xItem = FTP_Determine(Lst.Item(i))
                        Form1.ListView1.Items.Add(xItem)
                    Catch ex As Exception

                    End Try

                Next

                RutaActual = ServerLink

            Else
                MsgBox("loggin no valido")
            End If

        Catch ex As Exception

        End Try

    End Sub


    Function FTP_Determine(ByVal Str As String) As ListViewItem
        Dim LvElemt As ListViewItem

        If Str.StartsWith("drwxr-xr-x") Then

            Dim Dat As String = Str.Substring(36)
            Dat = Dat.Remove(12)

            LvElemt = New Windows.Forms.ListViewItem(Str.Substring(49), _Tipo("Carpeta", False))
            LvElemt.SubItems.Add("")
            LvElemt.SubItems.Add("Carpeta remota")
            LvElemt.SubItems.Add(Dat)
            LvElemt.ToolTipText = ""
            LvElemt.Tag = "Carpeta remota"
        Else

            Dim x As Integer = Str.LastIndexOf(".")
            Dim Ext As String = Str.Substring(x)
            Dim fTipo As String = TipoList.Item(_Tipo(Ext, False))

            Dim aTam As String = Str.Substring(20)
            aTam = aTam.Remove(16)
            Dim rTama As Integer = CInt(Val(aTam))

            Dim Dat As String = Str.Substring(36)
            Dat = Dat.Remove(12)

            LvElemt = New Windows.Forms.ListViewItem(Str.Substring(49), _Tipo(Ext, False))
            LvElemt.SubItems.Add(calcularTamano(rTama))
            LvElemt.SubItems.Add(fTipo)
            LvElemt.SubItems.Add(Dat)
            LvElemt.ToolTipText = ""
            LvElemt.Tag = "Carpeta remota"
        End If

        Return LvElemt

    End Function

End Module
