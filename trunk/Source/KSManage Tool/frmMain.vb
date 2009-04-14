Imports System.Data

Public Class frmMain


    Dim dsRoomlist As New DataSet
    Dim dbc As New DatabaseClass

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Updatelist()
    End Sub

    Private Sub Clock1_TimeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock1.TimeChanged
        lblDate.Text = Now.Date.ToString("dddd dd-MM-yyyy")
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmLogin.Show()
    End Sub

    Private Sub UpdateConntextMenu()
        cMenu.Items.Clear()
        Try
            Dim ds As New DataSet

            If lstRoom.SelectedItems.Count > 0 Then
                Dim strQuery As String = "exec dbo.get_RoomAction " & lstRoom.SelectedItems(0).SubItems("ID").Text
                ds = dbc.ExeDataset(strQuery)
            Else
                ds = dbc.ExeDataset("exec dbo.get_RoomAction")
            End If
            For Each dtr As DataRow In ds.Tables(0).Rows
                If dtr("TacVu_ID").ToString = "3" Then
                    Dim itemwithsub As New ToolStripMenuItem(dtr("TacVu").ToString)
                    itemwithsub.Name = dtr("TacVu_CD").ToString
                    cMenu.Items.Add(itemwithsub)
                    Dim ds2 As New DataSet
                    ds2 = dbc.ExeDataset("exec dbo.get_ListRoomFree")
                    For Each dtr2 As DataRow In ds2.Tables(0).Rows
                        Dim subitem As New ToolStripMenuItem
                        subitem.Name = "phong" & dtr2("Phong_ID").ToString
                        subitem.Text = dtr2("Phong_CD").ToString
                        AddHandler subitem.Click, AddressOf act_chgRoom
                        itemwithsub.DropDownItems.Add(subitem)
                    Next
                Else
                    Dim itemwithoutsub As New ToolStripMenuItem
                    itemwithoutsub.Text = dtr("TacVu")
                    itemwithoutsub.Name = dtr("TacVu_CD")
                    cMenu.Items.Add(itemwithoutsub)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Updatelist()
        dsRoomlist.Clear()
        dsRoomlist = dbc.ExeDataset("exec dbo.list_Allrooms")
        lstRoom.Clear()
        Dim dt As New DataTable
        dt = dsRoomlist.Tables(0)
        For Each dtr As DataRow In dt.Rows
            Dim item As New ListViewItem
            item.ImageIndex = dtr("TrangThai_ID")
            item.Text = dtr("TenPhong")
            Dim itemID As New ListViewItem.ListViewSubItem
            itemID.Name = "ID"
            itemID.Text = dtr("phong_ID")
            item.SubItems.Add(itemID)
            lstRoom.Items.Add(item)
        Next
        lstRoom.ContextMenuStrip = cMenu
    End Sub


    ' Room action
    Private Sub act_addRoom()
        Try
            Dim strRoomName As String = InputBox("Ten phong: ", "Them Phong")
            If strRoomName.Trim(" ").Trim("'") Then
                Dim strquery As String = "exec dbo.admin_AddRoom '" & strRoomName & "'"
                dbc.ExeNonQuery(strquery)
            End If
            Updatelist()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub act_delRoom()
        Try
            If MsgBox("Ban co muon xoa phong " & lstRoom.SelectedItems(0).Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                dbc.ExeNonQuery("exec dbo.admin_DropRoom " & lstRoom.SelectedItems(0).SubItems("ID").Text)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub act_chgRoom(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim str_From As String = lstRoom.SelectedItems(0).SubItems("ID").Text
            Dim str_To As String = CType(sender, ToolStripMenuItem).Name.Replace("phong", "")
            dbc.ExeNonQuery("exec dbo.ChangeRoom " & str_From & "," & str_To & " ")
            Updatelist()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub act_chkIn()
        Try
            dbc.ExeNonQuery("exec dbo.Checkin '" & lstRoom.SelectedItems(0).SubItems("ID").Text & "'")
            Updatelist()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub act_chkOut()
        If MsgBox("Ban co muon CheckOut hay khong?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Dim dt As DataTable = dbc.ExeDataset("exec dbo.Checkout '" & lstRoom.SelectedItems(0).SubItems("ID").Text & "'").Tables(0)
                Dim result As String = dt.Rows(0)(0).ToString
                If dt.Rows.Count > 0 Then
                    If MsgBox("In hoa don voi don gia: " & dt.Rows(0)("Thanh Tien").ToString, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        printReceipt(lstRoom.SelectedItems(0).SubItems("ID").Text, dt.Rows(0)(0).ToString, dt.Rows(0)(1).ToString, dt.Rows(0)(2).ToString)
                    End If
                End If
            Catch ex As Exception

            End Try
        End If
        Updatelist()
    End Sub



    '----------------------------------'



    Private Sub cMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cMenu.Opening
        UpdateConntextMenu()
    End Sub

    Private Sub printReceipt(ByVal ID As String, ByVal starttime As String, ByVal endtime As String, ByVal pricerate As String)
        Try
            Dim strPrint As String = dbc.ExeDataset("exec dbo.get_AppPrintableBill " & ID & ",'" & starttime & "','" & endtime & "'," & pricerate).Tables(0).Rows(0)(0).ToString
            strPrint = strPrint.Replace("\", vbCrLf)

            Dim prt As New TextPrint(strPrint)
            prt.Font = New Font("Tahoma", 8)
            prt.Print()
        Catch ex As Exception

        End Try

    End Sub



    Private Sub cMenu_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cMenu.ItemClicked
        Try
            Select Case e.ClickedItem.Name
                Case "addRoom"
                    act_addRoom()
                Case "delRoom"
                    act_delRoom()
                Case "chkIn"
                    act_chkIn()
                Case "chkOut"
                    act_chkOut()
            End Select
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Logout.Click
        Me.Hide()
        frmLogin.Show()
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        frmLogin.Show()
    End Sub

    Private Sub btn_ManageUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ManageUser.Click
        Me.Hide()
        frmManageUser.Show()
    End Sub
End Class
