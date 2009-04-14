Public Class frmManageUser
    Dim dbc As DatabaseClass
    Dim bln_IsManager As Boolean = False
    Private Sub UpdateList()
        lstUsers.Items.Clear()

    End Sub

    Private Sub frmManageUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If dbc.ExeDataset("get_UserStatus").Tables(0).Rows(0)(0) = 0 Then
            ' Staff
            bln_IsManager = False
        Else
            ' Manager
            bln_IsManager = True
        End If
    End Sub
End Class