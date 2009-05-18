
Public Class frmLogin

#Region "private"
    Private strUserName As String
    Private strPassword As String

    Private Sub MainFormLogin()
        ' Get form inputs
        strUserName = txtUsername.Text.Trim().Trim("'").Trim(" ")
        strPassword = txtPassword.Text.Trim().Trim("'").Trim(" ")

        ' Form the connection
        strConn = strConn & "User ID=" & strUserName & ";Password=" & strPassword

        ' Try to connect
        Dim db As New DatabaseClass

        If db.checkConnection Then
            ' Remember last user name
            If chkRemember.Checked = True Then
                My.Settings.lastuser = strUserName
            End If

            ' Show main frame
            frmMain.Show()

            ' Clear password text
            txtPassword.Text = ""

            ' Hide this form
            Me.Hide()
        Else
            MsgBox("Error login.")
        End If
    End Sub
#End Region


#Region "Form Control"
    ''' <summary>
    ''' Initialized the form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Get last user setting
        txtUsername.Text = My.Settings.lastuser
        If txtUsername.Text <> "" Then
            chkRemember.Checked = True
        End If
        strConn = My.Settings.connectionStr
    End Sub

    ''' <summary>
    ''' Button clear event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtUsername.Text = ""
        txtPassword.Text = ""
    End Sub

    ''' <summary>
    ''' Button Loging event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Me.MainFormLogin()
    End Sub

    ''' <summary>
    ''' Button Exit event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If (MsgBox("Ban muon thoat khoi chuong trinh", MsgBoxStyle.YesNo, "Xac nhan thoat khoi chuong trinh") = MsgBoxResult.Yes) Then
            If chkRemember.Checked = True Then
                My.Settings.lastuser = txtUsername.Text
            End If
            Application.Exit()
        End If
    End Sub

#End Region

End Class

