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
            btnChangePW.Text = "Change PW/Reset PW"
        End If
        UpdateList()
    End Sub



    Private Sub btnNewUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewUser.Click
        Try
            Dim username As String = InputBox("Ten nguoi dung moi").ToString

            Dim isadmin As Boolean = MsgBox("La quan ly?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes
            Dim querystring As String = ""
            If isadmin Then
                querystring = "exec q3admin.Adduser '" & username & "' , 1"
            Else
                querystring = "exec q3admin.Adduser '" & username & "' , 0"
            End If

            dbc.ExeNonQuery(querystring)

        Catch ex As Exception
            RaiseError("Loi khi tao nguoi dung", ex)
        End Try

        UpdateList()
    End Sub

    Private Sub btnChangePW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePW.Click
        Try
            If lstUsers.SelectedItems.Count > 0 Then
                If lstUsers.SelectedItems(0).Text.ToUpper = userlogin.ToUpper Then
                    Dim pwdDlg As New frmPasswordUpdate()
                    If (pwdDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK) Then
                        Try
                            dbc.ExeNonQuery(String.Format("exec dbo.upd_UpdatePassword '{0}', '{1}'", pwdDlg.oldPassword, pwdDlg.newPassword))
                        Catch ex As Exception
                            RaiseError("Loi khi cap nhat Password", ex)
                        End Try
                    End If
                Else
                    dbc.ExeNonQuery("exec dbo.upd_ResetPassword '" & lstUsers.SelectedItems(0).Text & "'")
                End If
            End If
        Catch ex As Exception
            RaiseError("Loi khi doi password", ex)
        End Try
    End Sub

    Private Sub frmManageUser_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        frmMain.Show()
    End Sub

    Private Sub lstUsers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUsers.SelectedIndexChanged
        If lstUsers.SelectedItems.Count > 0 Then
            If lstUsers.SelectedItems(0).Text.ToUpper = userlogin.ToUpper Then
                btnChangePW.Text = "Doi Password"
            Else
                btnChangePW.Text = "Reset Password"
            End If
        End If
    End Sub

    Private Sub btnDeleteUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteUser.Click
        If lstUsers.SelectedItems.Count > 0 Then
            Try
                dbc.ExeNonQuery("exec q3admin.delUser '" & lstUsers.SelectedItems(0).Text & "'")
            Catch ex As Exception
                RaiseError("Loi khi xoa nguoi dung", ex)
            End Try
        End If
        UpdateList()
    End Sub
End Class