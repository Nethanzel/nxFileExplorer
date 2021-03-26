
Imports System.Net
Imports System.IO

Module Ftp_Operations


    Function FTP_Conect(ByVal ServerUserName As String, ByVal ServerPassword As String, ByVal ServerURL As String) As Boolean

        Dim ListFtpDir As New List(Of String)

        Try

            Dim ftp As FtpWebRequest = CType(FtpWebRequest.Create(ServerURL), FtpWebRequest)
            Dim cred As New NetworkCredential(ServerUserName, ServerPassword)

            ftp.Credentials = cred
            ftp.KeepAlive = False

            ftp.AuthenticationLevel = Security.AuthenticationLevel.MutualAuthRequested
            ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails

            Dim ftpresp As FtpWebResponse = DirectCast(ftp.GetResponse, FtpWebResponse)

            ftpresp.Close()

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    Function Ftp_readFile(ByVal FileName As String, ByVal ServerUser As String, ByVal ServerPassword As String) As String

        Try

            Dim ftpReq As FtpWebRequest = CType(WebRequest.Create(FileName), FtpWebRequest)

            ftpReq.Method = WebRequestMethods.Ftp.DownloadFile
            ftpReq.Credentials = New NetworkCredential(ServerUser, ServerPassword)
            Dim ftpResp As FtpWebResponse = ftpReq.GetResponse
            Dim ftpRespStream As Stream = ftpResp.GetResponseStream

            Dim reader As StreamReader

            reader = New StreamReader(ftpRespStream, System.Text.Encoding.UTF8)

            Return reader.ReadToEnd

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Leer")
            Return Nothing
        End Try

    End Function

    Function FTP_WriteFile(ByVal file As String, ByVal Text As String, ByVal ServerUser As String, ByVal ServerPassword As String) As String

        Try
            Dim wc As New WebClient
            wc.Credentials = New NetworkCredential(ServerUser, ServerPassword)

            wc.Encoding = System.Text.Encoding.UTF8

            wc.UploadString(file, Text)

            Return "Exito"
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Function Ftp_GetImage(ByVal Url As String, ByVal ServerUser As String, ByVal ServerPassword As String) As Image

        Try

            Dim filename As String = Url
            Dim ftpReq As FtpWebRequest = CType(WebRequest.Create(filename), FtpWebRequest)

            ftpReq.Method = WebRequestMethods.Ftp.DownloadFile
            ftpReq.Credentials = New NetworkCredential(ServerUser, ServerPassword)
            'ftpReq.UsePassive = False
            Dim ftpResp As FtpWebResponse = ftpReq.GetResponse
            Dim ftpRespStream As Stream = ftpResp.GetResponseStream

            Dim GetedImage As Image
            GetedImage = Image.FromStream(ftpRespStream)

            Return GetedImage

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Function FTP_CreateDirectory(ByVal directory As String, ByVal ServerUser As String, ByVal ServerPassword As String) As String

        Try
            Dim ftp As FtpWebRequest = CType(FtpWebRequest.Create(directory), FtpWebRequest)
            Dim cred As New NetworkCredential(ServerUser, ServerPassword)
            ftp.Credentials = cred
            ftp.KeepAlive = False
            ftp.AuthenticationLevel = Security.AuthenticationLevel.MutualAuthRequested
            ftp.Method = WebRequestMethods.Ftp.MakeDirectory

            Dim ftpresp As FtpWebResponse = DirectCast(ftp.GetResponse, FtpWebResponse)

            Return "Exito"

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Function FTP_ListDirectory(ByVal Directory As String, ByVal ServerUser As String, ByVal ServerPassword As String) As List(Of String)

        Dim GettedList As New List(Of String)

        Try

            Dim ftp As FtpWebRequest = CType(FtpWebRequest.Create(Directory), FtpWebRequest)
            Dim cred As New NetworkCredential(ServerUser, ServerPassword)
            ftp.Credentials = cred
            ftp.KeepAlive = False
            ftp.AuthenticationLevel = Security.AuthenticationLevel.MutualAuthRequested
            ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails

            Dim ftpresp As FtpWebResponse = DirectCast(ftp.GetResponse, FtpWebResponse)

            Dim sreader As New IO.StreamReader(ftpresp.GetResponseStream)

            While Not sreader.Peek = -1

                Dim ftpList As String() = sreader.ReadLine.Split("")

                Dim ftpfile As String = ftpList(ftpList.GetUpperBound(0))

                GettedList.Add(ftpfile)

            End While
            ftpresp.Close()

        Catch ex As Exception

            Return Nothing
            Exit Function
        End Try

        Return GettedList

    End Function

    Function FTP_DeleteFile(ByVal File As String, ByVal ServerUser As String, ByVal ServerPassword As String) As String

        Try
            Dim ftp As FtpWebRequest = CType(FtpWebRequest.Create(File), FtpWebRequest)
            Dim cred As New NetworkCredential(ServerUser, ServerPassword)
            ftp.Credentials = cred
            ftp.KeepAlive = False
            ftp.AuthenticationLevel = Security.AuthenticationLevel.MutualAuthRequested
            ftp.Method = WebRequestMethods.Ftp.DeleteFile

            Dim ftpresp As FtpWebResponse = DirectCast(ftp.GetResponse, FtpWebResponse)

            Return "Exito"

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Function FTP_DeleteDirectory(ByVal Directory As String, ByVal ServerUser As String, ByVal ServerPassword As String) As String

        Try
            Dim ftp As FtpWebRequest = CType(FtpWebRequest.Create(Directory), FtpWebRequest)
            Dim cred As New NetworkCredential(ServerUser, ServerPassword)
            ftp.Credentials = cred
            ftp.KeepAlive = False
            ftp.AuthenticationLevel = Security.AuthenticationLevel.MutualAuthRequested
            ftp.Method = WebRequestMethods.Ftp.RemoveDirectory

            Dim ftpresp As FtpWebResponse = DirectCast(ftp.GetResponse, FtpWebResponse)

            Return "Exito"

        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

   
    


End Module




