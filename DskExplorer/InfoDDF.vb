Module InfoDDF


    Function DriveInfo(ByVal Drive As String) As List(Of String)
        Dim rList As New List(Of String)



        Dim GetDriveInfo As New IO.DriveInfo(Drive)
        Try
            rList.Add(GetDriveInfo.VolumeLabel)
        Catch ex As Exception
            rList.Add("No disponible")
        End Try

        Try
            rList.Add(GetDriveInfo.TotalSize)
        Catch ex As Exception
            rList.Add("No disponible")
        End Try

        Try
            rList.Add(GetDriveInfo.AvailableFreeSpace)
        Catch ex As Exception
            rList.Add("No disponible")
        End Try

        Try
            rList.Add(GetDriveInfo.Name)
        Catch ex As Exception
            rList.Add("No disponible")
        End Try

        Try
            rList.Add(GetDriveInfo.IsReady.ToString)
        Catch ex As Exception
            rList.Add("No disponible")
        End Try

        Try
            rList.Add(GetDriveInfo.DriveType)
        Catch ex As Exception
            rList.Add("No disponible")
        End Try

        Try
            rList.Add(GetDriveInfo.DriveFormat)
        Catch ex As Exception
            rList.Add("No disponible")
        End Try

        Return rList

    End Function

    Function DirectoryInfo(ByVal Path As String) As List(Of String)

        Dim rList As New List(Of String)

        If IO.Directory.Exists(Path) Then
            Dim Info As New IO.DirectoryInfo(Path)

            rList.Add(Info.Name)
            rList.Add(Info.CreationTime)
            rList.Add(Info.LastWriteTime)
            rList.Add(Info.LastAccessTime)
            rList.Add(Info.FullName)
            rList.Add(Info.Root.ToString)

        Else
            rList.Add("El directorio no existe.")
        End If
       

        Return rList
    End Function

    Function FileInfo(ByVal FilePath As String) As List(Of String)

        Dim rList As New List(Of String)

        If IO.File.Exists(FilePath) Then
            Dim Info As New IO.FileInfo(FilePath)

            rList.Add(Info.Name)
            rList.Add(Info.Length)
            rList.Add(Info.IsReadOnly.ToString)
            rList.Add(Info.FullName)
            rList.Add(Info.Extension)
            rList.Add(Info.DirectoryName)
            rList.Add(Info.CreationTime)
            rList.Add(Info.LastWriteTime)
            rList.Add(Info.LastAccessTime)
            rList.Add(Info.Attributes)

        Else
            rList.Add("Archivo no existe")
        End If


        Return rList

    End Function
End Module
