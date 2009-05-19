Module globalModule

    Public strConn As String = ""
    Public userlogin As String = ""
    Public Sub RaiseError(ByVal errTitle As String, ByVal ex As Exception)
        MsgBox(ex.ToString(), MsgBoxStyle.Critical, errTitle)
    End Sub
End Module
