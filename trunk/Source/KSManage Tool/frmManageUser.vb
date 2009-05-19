Public Class frmManageUser
    Dim dbc As New DatabaseClass
    Dim dt As New DataTable
    Dim bln_IsManager As Boolean = False
    Private Sub UpdateList()
        lstUsers.Items.Clear()
        If bln_IsManager = False Then
            btnNewUser.Enabled = False
            btnDeleteUser.Enabled = False
        End If
        dt = dbc.ExeDataset("exec dbo.get_ListUser").Tables(0)
        For Each dtr As DataRow In dt.Rows
            Dim item As New ListViewItem
            item.Text = dtr(0)
            Dim itemDesc As New ListViewItem.ListViewSubItem
            itemDesc.Text = dtr(1)
            item.SubItems.Add(itemDesc)
            lstUsers.Items.Add(item)
        Next
    End Sub

    Private Sub frmManageUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If dbc.ExeDataset("exec dbo.get_UserStatus").Tables(0).Rows(0)(0) = 0 Then
            ' Staff
            bln_IsManager = False
            btnChangePW.Text = "Change PW"
        Else
            ' Manager
            bln_IsManager = True
            btnChangePW.Text = "Reset PW"
        End If
        UpdateList()
    End Sub



    Private Sub btnNewUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewUser.Click
        Try
            Dim username As String = InputBox("Ten nguoi dung moi").ToString

            Dim isadmin As Boolean = MsgBox("La quan ly?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes
            Dim querystring As String = ""
            If isadmin Then
                querystring = "exec dbo.admin_Adduser '" & username & "' , 1"
            Else
                querystring = "exec dbo.admin_Adduser '" & username & "' , 0"
            End If

            dbc.ExeNonQuery(querystring)

        Catch ex As Exception

        End Try

        UpdateList()
    End Sub

    Private Sub btnChangePW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePW.Click
        Try
            If lstUsers.SelectedItems.Count > 0 Then
                If lstUsers.SelectedItems(0).Text = userlogin Then
                    Dim currentpass As String = InputBox("Password hien tai:").ToString
                    Dim newpass1 As String = InputBox("Password moi:").ToString
                    Dim newpass2 As String = InputBox("Nhap lai password moi:").ToString
                    Dim errcode As Integer = 1
                    If newpass1 = newpass2 Then
                        errcode = CInt(dbc.ExeDataset("exec dbo.upd_UpdatePassword '" & currentpass & "','" & newpass1 & "'").Tables(0).Rows(0).ToString)
                    Else
                        MsgBox("Password khong trung nhau.", MsgBoxStyle.OkOnly)
                    End If
                    If errcode = 0 Then
                        MsgBox("Doi password thanh cong.")
                    End If
                Else
                    dbc.ExeNonQuery("exec dbo.upd_ResetPassword '" & lstUsers.SelectedItems(0).Text & "'")
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmManageUser_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        frmMain.Show()
    End Sub

    Private Sub lstUsers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUsers.SelectedIndexChanged
        If lstUsers.SelectedItems.Count > 0 Then
            If lstUsers.SelectedItems(0).Text = userlogin Then
                btnChangePW.Text = "Change PW"
            Else
                btnChangePW.Text = "Reset PW"
            End If
        End If
    End Sub

    Private Sub btnDeleteUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteUser.Click
        If lstUsers.SelectedItems.Count > 0 Then
            dbc.ExeNonQuery("exec dbo.admin_DropUser '" & lstUsers.SelectedItems(0).Text & "'")
        End If
        UpdateList()
    End Sub
End Class