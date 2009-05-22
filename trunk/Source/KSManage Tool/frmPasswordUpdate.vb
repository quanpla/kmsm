Imports System.Windows.Forms

Public Class frmPasswordUpdate

    Public oldPassword As String = String.Empty
    Public newPassword As String = String.Empty

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If (txtNewPassword.Text = txtConfirmPassword.Text) Then
            oldPassword = txtOldPassword.Text
            newPassword = txtNewPassword.Text
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("Khong xac nhan password (password moi va password xac nhan khong giong nhau)")
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmPasswordUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtOldPassword.Focus()
    End Sub
End Class
