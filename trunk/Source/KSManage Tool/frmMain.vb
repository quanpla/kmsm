Imports System.Data

Public Class frmMain

#Region "Private Declaration"

    Private dsRoomlist As New DataSet ' List and information of all rooms
    Private dbc As New DatabaseClass ' main database class

#End Region

#Region "Private sub"

    ''' <summary>
    ''' Update the list of all the rooms
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Updatelist()
        ' init
        dsRoomlist.Clear() ' clear data set
        lstRoom.Clear() ' clear form list control

        ' call the sproc to get the data set
        dsRoomlist = dbc.ExeDataset("exec dbo.list_Allrooms")

        ' for each of data set
        Dim dt As New DataTable
        dt = dsRoomlist.Tables(0)
        For Each dtr As DataRow In dt.Rows
            Dim item As New ListViewItem
            ' The image appear has index = TrangThai_ID
            item.ImageIndex = dtr("TrangThai_ID")
            ' Text will be room name
            item.Text = dtr("TenPhong")
            ' Add some more properties
            Dim itemID As New ListViewItem.ListViewSubItem
            itemID.Name = "ID"
            itemID.Text = dtr("phong_ID")
            item.SubItems.Add(itemID)
            lstRoom.Items.Add(item)
        Next

        ' Update the Context Menu again
        lstRoom.ContextMenuStrip = cMenu
    End Sub

    ''' <summary>
    ''' Update all info in the info tab
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub updateInfoTab()
        'init
        lst_Info.Items.Clear()
        lst_Hist.Items.Clear()

        '   1.  Room Info
        Dim RoomInfo As New DataTable
        ' get room id
        Dim Room_ID As String = lstRoom.SelectedItems(0).SubItems("ID").Text.Trim().Trim("'").Trim(" ")

        RoomInfo = dbc.ExeDataset("exec dbo.get_AppStatus '" + Room_ID + "'").Tables(0)
        ' loop through it
        For Each infodt As DataRow In RoomInfo.Rows
            Dim item As New ListViewItem
            Dim subitem As New ListViewItem.ListViewSubItem
            item.Text = infodt("property")
            subitem.Name = "value"
            subitem.Text = infodt("value")
            item.SubItems.Add(subitem)
            lst_Info.Items.Add(item)
        Next

        '   2.  Room history
        RoomInfo.Clear()
        Try
            RoomInfo = dbc.ExeDataset("exec dbo.get_AppHistInfo '" + Room_ID + "'").Tables(0)
            ' loop through it
            For Each infodt As DataRow In RoomInfo.Rows
                Dim item As New ListViewItem
                Dim subitem1 As New ListViewItem.ListViewSubItem
                Dim subitem2 As New ListViewItem.ListViewSubItem
                item.Text = infodt("gio")
                subitem1.Name = "thunhap"
                subitem1.Text = infodt("thunhap")
                subitem2.Name = "mota"
                subitem2.Text = infodt("mota")
                item.SubItems.Add(subitem1)
                item.SubItems.Add(subitem2)
                lst_Hist.Items.Add(item)
            Next
        Catch ex As Exception
            ' it's not a exception, b/c only addmin can get the grant to see data
        End Try

    End Sub

    ''' <summary>
    ''' Room action: Add a new room. This option should appear for only admin
    ''' </summary>
    ''' <remarks>All the processing is for the database to hold</remarks>
    Private Sub act_addRoom()
        Try
            ' Ask for it
            Dim strRoomName As String = InputBox("Xin nhap ten phong: ", "Them Phong")

            ' Exec to add
            If strRoomName.Trim(" ").Trim("'") Then
                Dim strquery As String = "exec dbo.admin_AddRoom '" & strRoomName & "'"
                dbc.ExeNonQuery(strquery)
            End If

            ' Update the list
            Updatelist()
        Catch ex As Exception
            RaiseError("Loi khi them phong", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Room action: Delete Room, it's an admin task
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub act_delRoom()
        Try
            If MsgBox("Ban co muon xoa phong " & lstRoom.SelectedItems(0).Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                dbc.ExeNonQuery("exec dbo.admin_DropRoom '" & lstRoom.SelectedItems(0).SubItems("ID").Text + "'")
            End If
        Catch ex As Exception
            RaiseError("Loi khi xoa phong", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Room action: Change room, it's normal task
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub act_chgRoom(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim str_From As String = lstRoom.SelectedItems(0).SubItems("ID").Text
            Dim str_To As String = CType(sender, ToolStripMenuItem).Name.Replace("phong", "")
            dbc.ExeNonQuery("exec dbo.ChangeRoom '" & str_From & "','" & str_To & "' ")
            Updatelist()
        Catch ex As Exception
            RaiseError("Loi khi doi phong", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Room action: Check in, it's a normal task
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub act_chkIn()
        Try
            dbc.ExeNonQuery("exec dbo.Checkin '" & lstRoom.SelectedItems(0).SubItems("ID").Text & "'")
            Updatelist()
        Catch ex As Exception
            RaiseError("Loi khi dang ky phong", ex)
        End Try

    End Sub

    ''' <summary>
    ''' Room action: Check out, it's a normal task
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub act_chkOut()
        ' Ask if user really need to check out
        Dim room_name As String = lstRoom.SelectedItems(0).Text

        If MsgBox("Ban co muon tra phong " & room_name & "hay khong?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Dim room_id As String = lstRoom.SelectedItems(0).SubItems("ID").Text.Trim().Trim("'").Trim(" ")
                ' Ask if there is additinal fee?
                Dim inputExtraFee As New frmExtraFee
                inputExtraFee.ShowDialog(Me)
                Dim sqlCommand As String
                If inputExtraFee.hasInput Then
                    sqlCommand = "exec dbo.Checkout '" & room_id & "', '" & inputExtraFee.ExtraFee & "', '" & inputExtraFee.ExtraReason & "'"
                Else
                    sqlCommand = "exec dbo.Checkout '" & room_id & "', NULL, NULL"
                End If

                Dim dt As DataTable = dbc.ExeDataset(sqlCommand).Tables(0)
                Dim result As String = dt.Rows(0)(0).ToString
                If dt.Rows.Count > 0 Then
                    If MsgBox("In hoa don voi don gia: " & dt.Rows(0)("Thanh Tien").ToString, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        printReceipt(lstRoom.SelectedItems(0).SubItems("ID").Text, dt.Rows(0)(0).ToString, dt.Rows(0)(1).ToString, dt.Rows(0)(2).ToString)
                    End If
                End If
            Catch ex As Exception
                RaiseError("Loi khi tra phong", ex)
            End Try
        End If
        Updatelist()
    End Sub

#End Region

#Region "Form control"

#Region "For Main Form"

    ''' <summary>
    ''' Update the list when repaint and load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Updatelist()
    End Sub


    ''' <summary>
    ''' When Close this form, open the log in form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMain_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmLogin.Show()
    End Sub


    Private Sub lstRoom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRoom.SelectedIndexChanged
        ' only update if an item is selected
        If (lstRoom.SelectedItems.Count > 0) Then
            updateInfoTab()
        Else
            lst_Info.Items.Clear()
            lst_Hist.Items.Clear()
        End If
    End Sub

#End Region

#Region "Clock control"
    Private Sub Clock1_TimeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock1.TimeChanged
        lblDate.Text = Now.Date.ToString("dddd dd-MM-yyyy")
    End Sub
#End Region

#Region "Button to go to other form"
    Private Sub btnLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Logout.Click
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
#End Region

#End Region

#Region "Menu"

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
            RaiseError("Loi khi in hoa don", ex)
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
            RaiseError("Loi", ex)
        End Try

    End Sub

#End Region

End Class
