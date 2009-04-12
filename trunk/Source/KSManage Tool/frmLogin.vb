Public Class frmLogin

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUsername.Text = My.Settings.lastuser
        If txtUsername.Text <> "" Then
            chkRemember.Checked = True
        End If
        strConn = My.Settings.connectionStr
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtUsername.Text = ""
        txtPassword.Text = ""
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        strConn = strConn & "User ID=" & txtUsername.Text.Trim("'").Trim(" ") & ";Password=" & txtPassword.Text.Trim("'").Trim(" ")
        Dim db As New DatabaseClass
        If db.checkConnection Then
            If chkRemember.Checked = True Then
                My.Settings.lastuser = txtUsername.Text
            End If
            frmMain.Show()
            txtPassword.Text = ""
            Me.Hide()
        Else
            MsgBox("Error login.")
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If chkRemember.Checked = True Then
            My.Settings.lastuser = txtUsername.Text
        End If
        Application.Exit()
    End Sub
End Class