Imports System.Data

Public Class frmMain

#Region "Private Declaration"

    Private dsRoomlist As New DataSet ' List and information of all rooms
    Private dbc As New DatabaseClass ' main database class

#End Region

#Region "Private sub"

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

        ' Update the price
        updateInfoTab_noRoom()
    End Sub

    Public Sub showHideAdminTask()
        ' hide some admin tool
        Dim isAdmin As Integer = dbc.ExeDataset("exec dbo.get_UserStatus").Tables(0).Rows(0)(0)
        Dim user As String = dbc.ExeDataset("select system_user").Tables(0).Rows(0)(0).ToString
        If isAdmin = 0 Then
            hideAdminTask()
        Else
            showAdminTask()
        End If
        tab_Extra.TabPages(0).Select()
    End Sub

    ''' <summary>
    ''' hide all the components that for admin
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub hideAdminTask()
        If (tab_Extra.TabPages.Contains(tab_hist)) Then
            tab_Extra.TabPages.Remove(tab_hist)
            tab_Extra.TabPages.Remove(tab_UpdPrice)
            tab_Extra.TabPages.Remove(tab_UpdTemplate)
        End If
    End Sub

    ''' <summary>
    ''' Show all the components for admin
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub showAdminTask()
        If (Not tab_Extra.TabPages.Contains(tab_hist)) Then
            tab_Extra.TabPages.Add(tab_hist)
            tab_Extra.TabPages.Add(tab_UpdPrice)
            tab_Extra.TabPages.Add(tab_UpdTemplate)
        End If
    End Sub

    ''' <summary>
    ''' Update all info in the info tab
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub updateInfoTab()
        'init
        lst_Info.Items.Clear()
        lst_Hist.Items.Clear()
        lst_BangGia.Items.Clear()
        lst_Template.Items.Clear()

        '   1.  Room Info
        Dim RoomInfo As New DataTable
        Dim Room_ID As String
        ' get room id
        Try
            Room_ID = lstRoom.SelectedItems(0).SubItems("ID").Text.Trim().Trim("'").Trim(" ")
        Catch ex As Exception
            RaiseError("Chua co phong nao duoc chon", ex)
            Return
        End Try
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
        If dbc.ExeDataset("exec dbo.get_UserStatus").Tables(0).Rows(0)(0) <> 0 Then
            Try
                RoomInfo = dbc.ExeDataset("exec q3admin.SelAppHist '" + Room_ID + "'").Tables(0)
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
                RaiseError("Loi khi cap nhat thong tin phong", ex)
            End Try
        End If
    End Sub

    Private Sub updateInfoTab_noRoom()
        lst_BangGia.Items.Clear()
        lst_Template.Items.Clear()

        '   1.  Room Info
        Dim RoomInfo As New DataTable
        Try
            RoomInfo = dbc.ExeDataset("exec q3admin.SelBangGia").Tables(0)
            ' loop through it
            For Each infodt As DataRow In RoomInfo.Rows
                Dim item As New ListViewItem
                Dim subitem1 As New ListViewItem.ListViewSubItem
                item.Text = infodt("BangGia_CD")
                subitem1.Name = "Gia"
                subitem1.Text = infodt("Gia")
                item.SubItems.Add(subitem1)
                lst_BangGia.Items.Add(item)
            Next
        Catch ex As Exception
            RaiseError("Loi khi cap nhat bang gia", ex)
        End Try

        Try
            RoomInfo = dbc.ExeDataset("exec q3admin.SelTemplate").Tables(0)
            ' loop through it
            For Each infodt As DataRow In RoomInfo.Rows
                lst_Template.Items.Add(infodt("Template_CD"))
            Next
        Catch ex As Exception
            RaiseError("Loi khi cap nhat danh sach Template.", ex)
        End Try
        If lst_Template.SelectedItems.Count = 1 Then
            Dim strTemplate As String = dbc.ExeDataset("exec q3admin.SelTemplate '" + lst_Template.SelectedItem.ToString + "'").Tables(0).Rows(0)(1).ToString
            txtUpdTemplate.Text = strTemplate.Replace("\", vbCrLf)
        End If
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
            If strRoomName.Trim(" ").Trim("'").Length > 0 Then
                Dim strquery As String = "exec q3admin.AddRoom '" & strRoomName & "'"
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
                dbc.ExeNonQuery("exec q3admin.delRoom '" & lstRoom.SelectedItems(0).SubItems("ID").Text + "'")
            End If
        Catch ex As Exception
            RaiseError("Loi khi xoa phong", ex)
        End Try

        Updatelist()
    End Sub

    ''' <summary>
    ''' Room action: Rename room
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub act_renRoom()
        Try
            ' Ask for it
            Dim strRoomName As String = InputBox("Xin nhap ten phong moi: ", "Sua Ten Phong")

            ' Exec to add
            If strRoomName.Trim(" ").Trim("'").Length > 0 Then
                Dim strquery As String = "exec q3admin.RenRoom '" & lstRoom.SelectedItems(0).SubItems("ID").Text + "', '" & strRoomName & "'"
                dbc.ExeNonQuery(strquery)
            End If
            ' Update the list
            Updatelist()
        Catch ex As Exception
            RaiseError("Loi khi sua ten phong", ex)
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

        If MsgBox("Ban co muon tra phong " & room_name & " hay khong?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Dim room_id As String = lstRoom.SelectedItems(0).SubItems("ID").Text.Trim().Trim("'").Trim(" ")
                ' Ask if there is additinal fee?
                Dim inputExtraFee As New frmExtraFee
                inputExtraFee.ShowDialog(Me)
                Dim sqlCommand As String
                If MsgBox("Co tinh gio qua dem khong?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If inputExtraFee.hasInput Then
                        sqlCommand = "exec dbo.Checkout '" & room_id & "', 1, '" & inputExtraFee.ExtraFee & "', '" & inputExtraFee.ExtraReason & "'"
                    Else
                        sqlCommand = "exec dbo.Checkout '" & room_id & "', 1, NULL, NULL"
                    End If
                Else
                    If inputExtraFee.hasInput Then
                        sqlCommand = "exec dbo.Checkout '" & room_id & "', 1, '" & inputExtraFee.ExtraFee & "', '" & inputExtraFee.ExtraReason & "'"
                    Else
                        sqlCommand = "exec dbo.Checkout '" & room_id & "', 0, NULL, NULL"
                    End If
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

#Region "Print Task"
    ''' <summary>
    ''' Send a string to printer
    ''' </summary>
    ''' <param name="str"></param>
    ''' <remarks></remarks>
    Private Sub printString(ByVal str As String)
        Try
            str = str.Replace("\", vbCrLf)
            Dim prt As New TextPrint(str)
            prt.Font = New Font("Tahoma", 8)
            prt.Print()
        Catch ex As Exception
            RaiseError("Loi in an.", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Print The receipt. It's a normal task
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <param name="starttime"></param>
    ''' <param name="endtime"></param>
    ''' <param name="pricerate"></param>
    ''' <remarks></remarks>
    Private Sub printReceipt(ByVal ID As String, ByVal starttime As String, ByVal endtime As String, ByVal pricerate As String)
        Dim strprint As String = String.Empty
        Try
            strprint = dbc.ExeDataset("exec dbo.get_AppPrintableBill " & ID & ",'" & starttime & "','" & endtime & "'," & pricerate).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            RaiseError("Loi truy van!", ex)
        End Try
        If (strprint <> String.Empty) Then
            printString(strprint)
        End If
    End Sub

    ''' <summary>
    ''' Print room info. It's normal task
    ''' </summary>
    ''' <param name="ID">Room ID</param>
    ''' <remarks></remarks>
    Private Sub printInfo(ByVal ID As String)
        Dim strprint As String = String.Empty
        Try
            strprint = dbc.ExeDataset("exec dbo.get_AppPrintableInfo " & ID & "'").Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            RaiseError("Loi truy van!", ex)
        End Try
        If (strprint <> String.Empty) Then
            printString(strprint)
        End If
    End Sub

    ''' <summary>
    ''' Print room history. It's admin task
    ''' </summary>
    ''' <param name="ID">Room ID</param>
    ''' <remarks></remarks>
    Private Sub printHist(ByVal ID As String, ByVal StartTime As String, ByVal EndTime As String)
        Dim strprint As String = String.Empty
        Try
            strprint = dbc.ExeDataset("exec dbo.get_AppPrintableHist " & ID & "', '" & StartTime & "', '" & EndTime & "'").Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            RaiseError("Loi truy van!", ex)
        End Try
        If (strprint <> String.Empty) Then
            printString(strprint)
        End If
    End Sub

#End Region

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
                Case "renRoom"
                    act_renRoom()
            End Select
        Catch ex As Exception
            RaiseError("Loi", ex)
        End Try

    End Sub

#End Region

    Private Sub btn_RefreshInfoList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RefreshInfoList.Click
        updateInfoTab()
        Updatelist()
    End Sub

    Private Sub btn_RefreshHist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RefreshHist.Click
        updateInfoTab()
        Updatelist()
    End Sub

    Private Sub btn_PrintHist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_PrintHist.Click
        If dbc.ExeDataset("exec dbo.get_UserStatus").Tables(0).Rows(0)(0) <> 0 Then
            Dim printDialog As New frmPrintHistory
            printDialog.ShowDialog(Me)
        Else
            MsgBox("Ban khong co quyen truy cap vao lich su he thong")
        End If
    End Sub

    Private Sub btn_RefreshPriceUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_RefreshPriceUpdate.Click
        updateInfoTab_noRoom()
    End Sub

    Private Sub btn_RefreshTemplateUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTemplateListRefresh.Click
        updateInfoTab_noRoom()
    End Sub

    Private Sub btn_UpdPrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_UpdPrice.Click
        Dim strNewPrice As String = txtPriceUpd.Text
        If isNumeric(strNewPrice) Then
            Try
                dbc.ExeNonQuery("exec q3admin.UpdBangGia '" + lst_BangGia.SelectedItems(0).Text + "', '" + strNewPrice + "'")
            Catch ex As Exception
                RaiseError("Loi khi cap nhat gia", ex)
            End Try
            updateInfoTab_noRoom()
        Else
            MsgBox("Gia tien phai la mot con so!")
            txtPriceUpd.Focus()
            txtPriceUpd.SelectAll()
        End If
    End Sub

    Private Sub lst_BangGia_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_BangGia.ItemActivate
        txtPriceUpd.Text = lst_BangGia.SelectedItems(0).SubItems(1).Text
        lbl_UpdatePriceTag.Text = "Dang Cap Nhat: " + lst_BangGia.SelectedItems(0).Text
    End Sub

    Private Sub lst_Template_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_Template.SelectedIndexChanged
        If lst_Template.SelectedItems.Count = 1 Then
            Dim strTemplate As String = dbc.ExeDataset("exec q3admin.SelTemplate '" + lst_Template.SelectedItem.ToString + "'").Tables(0).Rows(0)(1).ToString
            txtUpdTemplate.Text = strTemplate.Replace("\", vbCrLf)
        End If
    End Sub

    Private Sub btn_UpdTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_UpdTemplate.Click
        If lst_Template.SelectedItems.Count = 1 Then
            Dim Template_CD As String = lst_Template.SelectedItem.ToString
            Dim updTemplate As String = txtUpdTemplate.Text.Replace(vbCrLf, "\")
            Dim sql As String = String.Format("exec q3admin.UpdTemplate '{0}', '{1}'", Template_CD, updTemplate)
            Try
                dbc.ExeNonQuery(sql)
                updateInfoTab_noRoom()
            Catch ex As Exception
                RaiseError("Loi khi cap nhat template", ex)
            End Try
        End If
    End Sub
End Class
