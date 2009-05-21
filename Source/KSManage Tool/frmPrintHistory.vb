Public Class frmPrintHistory

#Region "Private Declaration"

    Private dsRoomlist As New DataSet ' List and information of all rooms
    Private dbc As New DatabaseClass ' main database class

#End Region

    Private Function getStartDate() As String
        Dim strDT As String = ""

        strDT = Microsoft.VisualBasic.Right("0000" + txtStartYear.Text, 4)
        strDT = strDT + "-" + Microsoft.VisualBasic.Right("00" + txtStartMonth.Text, 2)
        strDT = strDT + "-" + Microsoft.VisualBasic.Right("00" + txtStartMonth.Text, 2)
        Try
            Dim tmp As Date = Date.Parse(strDT)
        Catch ex As Exception
            strDT = ""
            RaiseError("Ngay bat dau khong hop le", ex)
            txtStartDay.Focus()
        End Try
        Return strDT
    End Function

    Private Function getEndDate() As String
        Dim strDT As String = ""

        strDT = Microsoft.VisualBasic.Right("0000" + txtEndYear.Text, 4)
        strDT = strDT + "-" + Microsoft.VisualBasic.Right("00" + txtEndMonth.Text, 2)
        strDT = strDT + "-" + Microsoft.VisualBasic.Right("00" + txtEndMonth.Text, 2)
        Try
            Dim tmp As Date = Date.Parse(strDT)
        Catch ex As Exception
            strDT = ""
            RaiseError("Ngay ket thuc khong hop le", ex)
            txtEndDay.Focus()
        End Try
        Return strDT
    End Function

    Private Sub frmPrintHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' get all the room list, of course
        lstPrintRoom.Items.Clear()
        dsRoomlist.Clear()

        ' call the sproc to get the data set
        dsRoomlist = dbc.ExeDataset("exec dbo.list_Allrooms")

        ' for each of data set
        Dim dt As New DataTable
        dt = dsRoomlist.Tables(0)
        For Each dtr As DataRow In dt.Rows
            lstPrintRoom.Items.Add(dtr("TenPhong"))
        Next
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSelectAllRoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAllRoom.Click
        For i As Integer = 0 To lstPrintRoom.Items.Count - 1
            lstPrintRoom.SetItemChecked(i, True)
        Next i
    End Sub

    Private Sub btnDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeselectAll.Click
        For i As Integer = 0 To lstPrintRoom.Items.Count - 1
            lstPrintRoom.SetItemChecked(i, False)
        Next i
    End Sub

    Private Sub btnStartDate_GetDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartDate_GetDate.Click
        txtStartDay.Text = Date.Now.Day.ToString()
        txtStartMonth.Text = Date.Now.Month.ToString()
        txtStartYear.Text = Date.Now.Year.ToString()
    End Sub

    Private Sub btnEndDate_GetDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEndDate_GetDate.Click
        txtEndDay.Text = Date.Now.Day.ToString()
        txtEndMonth.Text = Date.Now.Month.ToString()
        txtEndYear.Text = Date.Now.Year.ToString()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        ' get begin / end date
        Dim beginDt As String = getStartDate()
        Dim endDt As String = getEndDate()

        If (beginDt.Length > 0 And endDt.Length > 0) Then
            Dim strPrint As String = ""

            Dim roomChk As Object
            For Each roomChk In lstPrintRoom.CheckedItems
                If (strPrint.Length > 0) Then
                    strPrint = strPrint + "\\\"
                End If
                Try
                    strPrint = strPrint + dbc.ExeDataset("exec q3admin.get_AppPrintableHist '" + roomChk.ToString() + "', '" + beginDt + "', '" + endDt + "';").Tables(0).Rows(0)(0).ToString()
                Catch ex As Exception
                    RaiseError("Loi truy van!", ex)
                End Try
            Next

            If strPrint.Length > 0 Then
                Try
                    strPrint = strPrint.Replace("\", vbCrLf)
                    Dim prt As New TextPrint(strPrint)
                    prt.Font = New Font("Tahoma", 8)
                    prt.Print()
                Catch ex As Exception
                    RaiseError("Loi in an.", ex)
                End Try
            End If
        End If
    End Sub
End Class