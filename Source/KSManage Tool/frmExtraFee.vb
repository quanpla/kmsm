Public Class frmExtraFee

#Region "Public"
    Public ExtraFee As String = 0 ' The fee returns
    Public ExtraReason As String ' The reason for fee
    Public hasInput As Boolean = False ' whether user input or not
#End Region

#Region "Private"
#Region "Data Validation"
    Private Function isNumeric(ByVal str As String) As Boolean
        Dim chk As Boolean = True

        Try
            Dim numTest As Double = Double.Parse(str.Trim().Trim("'").Trim(" "))
        Catch ex As Exception
            chk = False
        End Try
        Return chk
    End Function
#End Region
#End Region

#Region "Form control"

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        ExtraFee = txtExtraFee.Text.Trim()
        ExtraReason = txtReason.Text.Trim()
        If (ExtraFee.Length > 0 And ExtraFee.Trim("0").Trim("'").Trim(" ").Length > 0) Then
            hasInput = True
        End If
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ExtraFee = ""
        ExtraReason = ""
        hasInput = False
        Me.Close()
    End Sub


    Private Sub txtExtraFee_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExtraFee.Leave
        If (isNumeric(txtExtraFee.Text) = False) Then
            MsgBox("Phai nhap vao mot con so!")
            txtExtraFee.Focus()
            txtExtraFee.SelectAll()
        Else
            ExtraFee = txtExtraFee.Text.Trim().Trim("'").Trim(" ")
        End If
    End Sub

    Private Sub txtReason_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReason.Leave
        ExtraReason = txtReason.Text.Trim().Trim("'").Trim(" ")
    End Sub
#End Region
End Class