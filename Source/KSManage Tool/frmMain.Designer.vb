    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmMain
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Empty"}, 2, System.Drawing.Color.Empty, System.Drawing.SystemColors.Window, Nothing)
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Customer went out", 1)
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Customer in", 3)
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Checking out", 0)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btn_Logout = New System.Windows.Forms.Button
        Me.lstRoom = New System.Windows.Forms.ListView
        Me.imgl_RoomStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_ManageUser = New System.Windows.Forms.Button
        Me.cMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnu_Checkin = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_Checkout = New System.Windows.Forms.ToolStripMenuItem
        Me.mnu_ChangeRoom = New System.Windows.Forms.ToolStripMenuItem
        Me.Room01ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Room02ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tab_Extra = New System.Windows.Forms.TabControl
        Me.tab_info = New System.Windows.Forms.TabPage
        Me.btn_RefreshInfoList = New System.Windows.Forms.Button
        Me.lst_Info = New System.Windows.Forms.ListView
        Me.colProperty = New System.Windows.Forms.ColumnHeader
        Me.colValue = New System.Windows.Forms.ColumnHeader
        Me.tab_hist = New System.Windows.Forms.TabPage
        Me.btn_PrintHist = New System.Windows.Forms.Button
        Me.btn_RefreshHist = New System.Windows.Forms.Button
        Me.lst_Hist = New System.Windows.Forms.ListView
        Me.colDate = New System.Windows.Forms.ColumnHeader
        Me.colIncome = New System.Windows.Forms.ColumnHeader
        Me.colComment = New System.Windows.Forms.ColumnHeader
        Me.tab_UpdPrice = New System.Windows.Forms.TabPage
        Me.lbl_UpdatePriceTag = New System.Windows.Forms.Label
        Me.btn_RefreshPriceUpdate = New System.Windows.Forms.Button
        Me.btn_UpdPrice = New System.Windows.Forms.Button
        Me.txtPriceUpd = New System.Windows.Forms.TextBox
        Me.lst_BangGia = New System.Windows.Forms.ListView
        Me.colPriceCD = New System.Windows.Forms.ColumnHeader
        Me.colPrice = New System.Windows.Forms.ColumnHeader
        Me.tab_UpdTemplate = New System.Windows.Forms.TabPage
        Me.btnTemplateListRefresh = New System.Windows.Forms.Button
        Me.btn_UpdTemplate = New System.Windows.Forms.Button
        Me.txtUpdTemplate = New System.Windows.Forms.TextBox
        Me.lst_Template = New System.Windows.Forms.ListBox
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.cMenu.SuspendLayout()
        Me.tab_Extra.SuspendLayout()
        Me.tab_info.SuspendLayout()
        Me.tab_hist.SuspendLayout()
        Me.tab_UpdPrice.SuspendLayout()
        Me.tab_UpdTemplate.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Logout
        '
        Me.btn_Logout.Location = New System.Drawing.Point(665, 519)
        Me.btn_Logout.Name = "btn_Logout"
        Me.btn_Logout.Size = New System.Drawing.Size(125, 46)
        Me.btn_Logout.TabIndex = 2
        Me.btn_Logout.Text = "Thoat / Doi Nguoi Dung"
        Me.btn_Logout.UseVisualStyleBackColor = True
        '
        'lstRoom
        '
        Me.lstRoom.Alignment = System.Windows.Forms.ListViewAlignment.[Default]
        Me.lstRoom.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8})
        Me.lstRoom.LargeImageList = Me.imgl_RoomStatus
        Me.lstRoom.Location = New System.Drawing.Point(3, 4)
        Me.lstRoom.MultiSelect = False
        Me.lstRoom.Name = "lstRoom"
        Me.lstRoom.ShowGroups = False
        Me.lstRoom.Size = New System.Drawing.Size(787, 357)
        Me.lstRoom.TabIndex = 3
        Me.lstRoom.UseCompatibleStateImageBehavior = False
        '
        'imgl_RoomStatus
        '
        Me.imgl_RoomStatus.ImageStream = CType(resources.GetObject("imgl_RoomStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgl_RoomStatus.TransparentColor = System.Drawing.Color.Transparent
        Me.imgl_RoomStatus.Images.SetKeyName(0, "0_default.png")
        Me.imgl_RoomStatus.Images.SetKeyName(1, "1_available.png")
        Me.imgl_RoomStatus.Images.SetKeyName(2, "2_inused.png")
        Me.imgl_RoomStatus.Images.SetKeyName(3, "3_disabled.png")
        '
        'btn_ManageUser
        '
        Me.btn_ManageUser.Location = New System.Drawing.Point(665, 389)
        Me.btn_ManageUser.Name = "btn_ManageUser"
        Me.btn_ManageUser.Size = New System.Drawing.Size(123, 46)
        Me.btn_ManageUser.TabIndex = 2
        Me.btn_ManageUser.Text = "Quan Ly Nguoi Dung"
        Me.btn_ManageUser.UseVisualStyleBackColor = True
        '
        'cMenu
        '
        Me.cMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_Checkin, Me.mnu_Checkout, Me.mnu_ChangeRoom})
        Me.cMenu.Name = "cMenu"
        Me.cMenu.Size = New System.Drawing.Size(142, 70)
        '
        'mnu_Checkin
        '
        Me.mnu_Checkin.Name = "mnu_Checkin"
        Me.mnu_Checkin.Size = New System.Drawing.Size(141, 22)
        Me.mnu_Checkin.Text = "Check In"
        Me.mnu_Checkin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnu_Checkout
        '
        Me.mnu_Checkout.Name = "mnu_Checkout"
        Me.mnu_Checkout.Size = New System.Drawing.Size(141, 22)
        Me.mnu_Checkout.Text = "Check Out"
        '
        'mnu_ChangeRoom
        '
        Me.mnu_ChangeRoom.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Room01ToolStripMenuItem, Me.Room02ToolStripMenuItem})
        Me.mnu_ChangeRoom.Name = "mnu_ChangeRoom"
        Me.mnu_ChangeRoom.Size = New System.Drawing.Size(141, 22)
        Me.mnu_ChangeRoom.Text = "Change Room"
        '
        'Room01ToolStripMenuItem
        '
        Me.Room01ToolStripMenuItem.Name = "Room01ToolStripMenuItem"
        Me.Room01ToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.Room01ToolStripMenuItem.Text = "Room 01"
        '
        'Room02ToolStripMenuItem
        '
        Me.Room02ToolStripMenuItem.Name = "Room02ToolStripMenuItem"
        Me.Room02ToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.Room02ToolStripMenuItem.Text = "Room 02"
        '
        'tab_Extra
        '
        Me.tab_Extra.Controls.Add(Me.tab_info)
        Me.tab_Extra.Controls.Add(Me.tab_hist)
        Me.tab_Extra.Controls.Add(Me.tab_UpdPrice)
        Me.tab_Extra.Controls.Add(Me.tab_UpdTemplate)
        Me.tab_Extra.Location = New System.Drawing.Point(3, 367)
        Me.tab_Extra.Name = "tab_Extra"
        Me.tab_Extra.SelectedIndex = 0
        Me.tab_Extra.Size = New System.Drawing.Size(656, 202)
        Me.tab_Extra.TabIndex = 7
        '
        'tab_info
        '
        Me.tab_info.Controls.Add(Me.btn_RefreshInfoList)
        Me.tab_info.Controls.Add(Me.lst_Info)
        Me.tab_info.Location = New System.Drawing.Point(4, 22)
        Me.tab_info.Name = "tab_info"
        Me.tab_info.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_info.Size = New System.Drawing.Size(648, 176)
        Me.tab_info.TabIndex = 0
        Me.tab_info.Text = "Thong Tin Them"
        Me.tab_info.UseVisualStyleBackColor = True
        '
        'btn_RefreshInfoList
        '
        Me.btn_RefreshInfoList.Location = New System.Drawing.Point(39, 152)
        Me.btn_RefreshInfoList.Name = "btn_RefreshInfoList"
        Me.btn_RefreshInfoList.Size = New System.Drawing.Size(75, 23)
        Me.btn_RefreshInfoList.TabIndex = 6
        Me.btn_RefreshInfoList.Text = "Cap Nhat"
        Me.btn_RefreshInfoList.UseVisualStyleBackColor = True
        '
        'lst_Info
        '
        Me.lst_Info.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lst_Info.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colProperty, Me.colValue})
        Me.lst_Info.Location = New System.Drawing.Point(3, 0)
        Me.lst_Info.Name = "lst_Info"
        Me.lst_Info.Size = New System.Drawing.Size(642, 149)
        Me.lst_Info.TabIndex = 5
        Me.lst_Info.UseCompatibleStateImageBehavior = False
        Me.lst_Info.View = System.Windows.Forms.View.Details
        '
        'colProperty
        '
        Me.colProperty.Text = "Trang Thai"
        Me.colProperty.Width = 70
        '
        'colValue
        '
        Me.colValue.Text = "Gia Tri"
        Me.colValue.Width = 165
        '
        'tab_hist
        '
        Me.tab_hist.Controls.Add(Me.btn_PrintHist)
        Me.tab_hist.Controls.Add(Me.btn_RefreshHist)
        Me.tab_hist.Controls.Add(Me.lst_Hist)
        Me.tab_hist.Location = New System.Drawing.Point(4, 22)
        Me.tab_hist.Name = "tab_hist"
        Me.tab_hist.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_hist.Size = New System.Drawing.Size(648, 176)
        Me.tab_hist.TabIndex = 1
        Me.tab_hist.Text = "Lich su phong"
        Me.tab_hist.UseVisualStyleBackColor = True
        '
        'btn_PrintHist
        '
        Me.btn_PrintHist.Location = New System.Drawing.Point(138, 153)
        Me.btn_PrintHist.Name = "btn_PrintHist"
        Me.btn_PrintHist.Size = New System.Drawing.Size(75, 23)
        Me.btn_PrintHist.TabIndex = 9
        Me.btn_PrintHist.Text = "In"
        Me.btn_PrintHist.UseVisualStyleBackColor = True
        '
        'btn_RefreshHist
        '
        Me.btn_RefreshHist.Location = New System.Drawing.Point(36, 153)
        Me.btn_RefreshHist.Name = "btn_RefreshHist"
        Me.btn_RefreshHist.Size = New System.Drawing.Size(75, 23)
        Me.btn_RefreshHist.TabIndex = 8
        Me.btn_RefreshHist.Text = "Cap Nhat"
        Me.btn_RefreshHist.UseVisualStyleBackColor = True
        '
        'lst_Hist
        '
        Me.lst_Hist.AllowColumnReorder = True
        Me.lst_Hist.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lst_Hist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colDate, Me.colIncome, Me.colComment})
        Me.lst_Hist.GridLines = True
        Me.lst_Hist.Location = New System.Drawing.Point(3, 0)
        Me.lst_Hist.MultiSelect = False
        Me.lst_Hist.Name = "lst_Hist"
        Me.lst_Hist.Size = New System.Drawing.Size(645, 151)
        Me.lst_Hist.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lst_Hist.TabIndex = 6
        Me.lst_Hist.UseCompatibleStateImageBehavior = False
        Me.lst_Hist.View = System.Windows.Forms.View.Details
        '
        'colDate
        '
        Me.colDate.Text = "Ngay Gio"
        Me.colDate.Width = 65
        '
        'colIncome
        '
        Me.colIncome.Text = "Thu Nhap"
        Me.colIncome.Width = 65
        '
        'colComment
        '
        Me.colComment.Text = "Mo ta"
        Me.colComment.Width = 110
        '
        'tab_UpdPrice
        '
        Me.tab_UpdPrice.Controls.Add(Me.lbl_UpdatePriceTag)
        Me.tab_UpdPrice.Controls.Add(Me.btn_RefreshPriceUpdate)
        Me.tab_UpdPrice.Controls.Add(Me.btn_UpdPrice)
        Me.tab_UpdPrice.Controls.Add(Me.txtPriceUpd)
        Me.tab_UpdPrice.Controls.Add(Me.lst_BangGia)
        Me.tab_UpdPrice.Location = New System.Drawing.Point(4, 22)
        Me.tab_UpdPrice.Name = "tab_UpdPrice"
        Me.tab_UpdPrice.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_UpdPrice.Size = New System.Drawing.Size(648, 176)
        Me.tab_UpdPrice.TabIndex = 2
        Me.tab_UpdPrice.Text = "Chinh Gia"
        Me.tab_UpdPrice.UseVisualStyleBackColor = True
        '
        'lbl_UpdatePriceTag
        '
        Me.lbl_UpdatePriceTag.AutoSize = True
        Me.lbl_UpdatePriceTag.Location = New System.Drawing.Point(453, 17)
        Me.lbl_UpdatePriceTag.Name = "lbl_UpdatePriceTag"
        Me.lbl_UpdatePriceTag.Size = New System.Drawing.Size(84, 13)
        Me.lbl_UpdatePriceTag.TabIndex = 4
        Me.lbl_UpdatePriceTag.Text = "Dang Cap Nhat:"
        '
        'btn_RefreshPriceUpdate
        '
        Me.btn_RefreshPriceUpdate.Location = New System.Drawing.Point(558, 147)
        Me.btn_RefreshPriceUpdate.Name = "btn_RefreshPriceUpdate"
        Me.btn_RefreshPriceUpdate.Size = New System.Drawing.Size(87, 23)
        Me.btn_RefreshPriceUpdate.TabIndex = 3
        Me.btn_RefreshPriceUpdate.Text = "Refresh"
        Me.btn_RefreshPriceUpdate.UseVisualStyleBackColor = True
        '
        'btn_UpdPrice
        '
        Me.btn_UpdPrice.Location = New System.Drawing.Point(558, 69)
        Me.btn_UpdPrice.Name = "btn_UpdPrice"
        Me.btn_UpdPrice.Size = New System.Drawing.Size(75, 56)
        Me.btn_UpdPrice.TabIndex = 2
        Me.btn_UpdPrice.Text = "Cap Nhat Gia"
        Me.btn_UpdPrice.UseVisualStyleBackColor = True
        '
        'txtPriceUpd
        '
        Me.txtPriceUpd.Location = New System.Drawing.Point(542, 43)
        Me.txtPriceUpd.Name = "txtPriceUpd"
        Me.txtPriceUpd.Size = New System.Drawing.Size(100, 20)
        Me.txtPriceUpd.TabIndex = 1
        '
        'lst_BangGia
        '
        Me.lst_BangGia.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colPriceCD, Me.colPrice})
        Me.lst_BangGia.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lst_BangGia.Location = New System.Drawing.Point(7, 7)
        Me.lst_BangGia.MultiSelect = False
        Me.lst_BangGia.Name = "lst_BangGia"
        Me.lst_BangGia.Size = New System.Drawing.Size(440, 163)
        Me.lst_BangGia.TabIndex = 0
        Me.lst_BangGia.UseCompatibleStateImageBehavior = False
        Me.lst_BangGia.View = System.Windows.Forms.View.Details
        '
        'colPriceCD
        '
        Me.colPriceCD.Text = "Ma Gia"
        '
        'colPrice
        '
        Me.colPrice.Text = "Gia"
        '
        'tab_UpdTemplate
        '
        Me.tab_UpdTemplate.Controls.Add(Me.btnTemplateListRefresh)
        Me.tab_UpdTemplate.Controls.Add(Me.btn_UpdTemplate)
        Me.tab_UpdTemplate.Controls.Add(Me.txtUpdTemplate)
        Me.tab_UpdTemplate.Controls.Add(Me.lst_Template)
        Me.tab_UpdTemplate.Location = New System.Drawing.Point(4, 22)
        Me.tab_UpdTemplate.Name = "tab_UpdTemplate"
        Me.tab_UpdTemplate.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_UpdTemplate.Size = New System.Drawing.Size(648, 176)
        Me.tab_UpdTemplate.TabIndex = 3
        Me.tab_UpdTemplate.Text = "Chinh Template"
        Me.tab_UpdTemplate.UseVisualStyleBackColor = True
        '
        'btnTemplateListRefresh
        '
        Me.btnTemplateListRefresh.Location = New System.Drawing.Point(585, 147)
        Me.btnTemplateListRefresh.Name = "btnTemplateListRefresh"
        Me.btnTemplateListRefresh.Size = New System.Drawing.Size(60, 23)
        Me.btnTemplateListRefresh.TabIndex = 3
        Me.btnTemplateListRefresh.Text = "Refresh"
        Me.btnTemplateListRefresh.UseVisualStyleBackColor = True
        '
        'btn_UpdTemplate
        '
        Me.btn_UpdTemplate.Location = New System.Drawing.Point(587, 3)
        Me.btn_UpdTemplate.Name = "btn_UpdTemplate"
        Me.btn_UpdTemplate.Size = New System.Drawing.Size(58, 136)
        Me.btn_UpdTemplate.TabIndex = 2
        Me.btn_UpdTemplate.Text = "Cap Nhat"
        Me.btn_UpdTemplate.UseVisualStyleBackColor = True
        '
        'txtUpdTemplate
        '
        Me.txtUpdTemplate.AcceptsReturn = True
        Me.txtUpdTemplate.AcceptsTab = True
        Me.txtUpdTemplate.Location = New System.Drawing.Point(133, 7)
        Me.txtUpdTemplate.Multiline = True
        Me.txtUpdTemplate.Name = "txtUpdTemplate"
        Me.txtUpdTemplate.Size = New System.Drawing.Size(448, 160)
        Me.txtUpdTemplate.TabIndex = 1
        '
        'lst_Template
        '
        Me.lst_Template.FormattingEnabled = True
        Me.lst_Template.Location = New System.Drawing.Point(7, 7)
        Me.lst_Template.Name = "lst_Template"
        Me.lst_Template.Size = New System.Drawing.Size(120, 160)
        Me.lst_Template.TabIndex = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Status"
        Me.ColumnHeader2.Width = 1
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 571)
        Me.Controls.Add(Me.tab_Extra)
        Me.Controls.Add(Me.lstRoom)
        Me.Controls.Add(Me.btn_Logout)
        Me.Controls.Add(Me.btn_ManageUser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KSManage Tool"
        Me.cMenu.ResumeLayout(False)
        Me.tab_Extra.ResumeLayout(False)
        Me.tab_info.ResumeLayout(False)
        Me.tab_hist.ResumeLayout(False)
        Me.tab_UpdPrice.ResumeLayout(False)
        Me.tab_UpdPrice.PerformLayout()
        Me.tab_UpdTemplate.ResumeLayout(False)
        Me.tab_UpdTemplate.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Logout As System.Windows.Forms.Button
    Friend WithEvents lstRoom As System.Windows.Forms.ListView
    Friend WithEvents imgl_RoomStatus As System.Windows.Forms.ImageList
    Friend WithEvents btn_ManageUser As System.Windows.Forms.Button
    Friend WithEvents cMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnu_Checkin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_Checkout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_ChangeRoom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Room01ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Room02ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tab_Extra As System.Windows.Forms.TabControl
    Friend WithEvents tab_info As System.Windows.Forms.TabPage
    Friend WithEvents lst_Info As System.Windows.Forms.ListView
    Friend WithEvents colProperty As System.Windows.Forms.ColumnHeader
    Friend WithEvents tab_hist As System.Windows.Forms.TabPage
    Friend WithEvents lst_Hist As System.Windows.Forms.ListView
    Friend WithEvents colDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_RefreshInfoList As System.Windows.Forms.Button
    Friend WithEvents btn_PrintHist As System.Windows.Forms.Button
    Friend WithEvents btn_RefreshHist As System.Windows.Forms.Button
    Friend WithEvents colValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIncome As System.Windows.Forms.ColumnHeader
    Friend WithEvents colComment As System.Windows.Forms.ColumnHeader
    Friend WithEvents tab_UpdPrice As System.Windows.Forms.TabPage
    Friend WithEvents tab_UpdTemplate As System.Windows.Forms.TabPage
    Friend WithEvents btn_UpdPrice As System.Windows.Forms.Button
    Friend WithEvents txtPriceUpd As System.Windows.Forms.TextBox
    Friend WithEvents lst_BangGia As System.Windows.Forms.ListView
    Friend WithEvents colPriceCD As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPrice As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_UpdTemplate As System.Windows.Forms.Button
    Friend WithEvents txtUpdTemplate As System.Windows.Forms.TextBox
    Friend WithEvents lst_Template As System.Windows.Forms.ListBox
    Friend WithEvents btn_RefreshPriceUpdate As System.Windows.Forms.Button
    Friend WithEvents btnTemplateListRefresh As System.Windows.Forms.Button
    Friend WithEvents lbl_UpdatePriceTag As System.Windows.Forms.Label

    End Class
