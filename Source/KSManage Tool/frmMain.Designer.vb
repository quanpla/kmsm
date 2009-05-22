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
        Me.Clock1 = New AnalogClock.Clock
        Me.lblDate = New System.Windows.Forms.Label
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
        Me.btn_ManageUser.Location = New System.Drawing.Point(532, 519)
        Me.btn_ManageUser.Name = "btn_ManageUser"
        Me.btn_ManageUser.Size = New System.Drawing.Size(123, 46)
        Me.btn_ManageUser.TabIndex = 2
        Me.btn_ManageUser.Text = "Quan Ly Nguoi Dung"
        Me.btn_ManageUser.UseVisualStyleBackColor = True
        '
        'Clock1
        '
        Me.Clock1.BigMarkers = New AnalogClock.Marker() {New AnalogClock.Marker("BigMarker90", 90.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker60", 60.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker30", 30.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker0", 0.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker330", 330.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker300", 300.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker270", 270.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker240", 240.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker210", 210.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker180", 180.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker150", 150.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker120", 120.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias)}
        Me.Clock1.CenterPoint.PaintAttributes = New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!)
        Me.Clock1.CenterPoint.RelativeRadius = 0.03!
        Me.Clock1.HourHand.PaintAttributes = New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!)
        Me.Clock1.HourHand.RelativeRadius = 0.65!
        Me.Clock1.HourHand.Width = 5.0!
        Me.Clock1.Location = New System.Drawing.Point(676, 382)
        Me.Clock1.MinuteHand.PaintAttributes = New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!)
        Me.Clock1.MinuteHand.RelativeRadius = 0.8!
        Me.Clock1.MinuteHand.Width = 5.0!
        Me.Clock1.Name = "Clock1"
        Me.Clock1.SecondHand.PaintAttributes = New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!)
        Me.Clock1.SecondHand.RelativeRadius = 0.9!
        Me.Clock1.SecondHand.Width = 1.0!
        Me.Clock1.Size = New System.Drawing.Size(104, 100)
        Me.Clock1.SmallMarkers = New AnalogClock.Marker() {New AnalogClock.Marker("SmallMarker90", 90.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker84", 84.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker78", 78.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker72", 72.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker66", 66.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker60", 60.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker54", 54.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker48", 48.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker42", 42.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker36", 36.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker30", 30.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker24", 24.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker18", 18.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker12", 12.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker6", 6.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker0", 0.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker354", 354.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker348", 348.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker342", 342.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker336", 336.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker330", 330.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker324", 324.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker318", 318.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker312", 312.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker306", 306.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker300", 300.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker294", 294.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker288", 288.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker282", 282.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker276", 276.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker270", 270.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker264", 264.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker258", 258.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker252", 252.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker246", 246.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker240", 240.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker234", 234.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker228", 228.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker222", 222.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker216", 216.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker210", 210.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker204", 204.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker198", 198.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker192", 192.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker186", 186.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker180", 180.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker174", 174.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker168", 168.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker162", 162.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker156", 156.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker150", 150.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker144", 144.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker138", 138.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker132", 132.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker126", 126.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker120", 120.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker114", 114.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker108", 108.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker102", 102.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker96", 96.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 50.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias)}
        Me.Clock1.Symbols = New AnalogClock.Symbol() {New AnalogClock.Symbol("Symbol90", 90.0!, "12", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 0, True, True, AnalogClock.SymbolStyle.Numeric, 50.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol60", 60.0!, "1", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 1, True, True, AnalogClock.SymbolStyle.Numeric, 50.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol30", 30.0!, "2", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 2, True, True, AnalogClock.SymbolStyle.Numeric, 50.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol0", 0.0!, "3", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 3, True, True, AnalogClock.SymbolStyle.Numeric, 50.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol330", 330.0!, "4", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 4, True, True, AnalogClock.SymbolStyle.Numeric, 50.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol300", 300.0!, "5", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 5, True, True, AnalogClock.SymbolStyle.Numeric, 50.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol270", 270.0!, "6", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 6, True, True, AnalogClock.SymbolStyle.Numeric, 50.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol240", 240.0!, "7", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 7, True, True, AnalogClock.SymbolStyle.Numeric, 50.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol210", 210.0!, "8", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 8, True, True, AnalogClock.SymbolStyle.Numeric, 50.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol180", 180.0!, "9", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 9, True, True, AnalogClock.SymbolStyle.Numeric, 50.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol150", 150.0!, "10", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 10, True, True, AnalogClock.SymbolStyle.Numeric, 50.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol120", 120.0!, "11", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 11, True, True, AnalogClock.SymbolStyle.Numeric, 50.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault)}
        Me.Clock1.TabIndex = 5
        Me.Clock1.UtcOffset = System.TimeSpan.Parse("07:00:00")
        '
        'lblDate
        '
        Me.lblDate.Location = New System.Drawing.Point(653, 485)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(137, 13)
        Me.lblDate.TabIndex = 6
        Me.lblDate.Text = "Label2"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.tab_Extra.Size = New System.Drawing.Size(527, 202)
        Me.tab_Extra.TabIndex = 7
        '
        'tab_info
        '
        Me.tab_info.Controls.Add(Me.btn_RefreshInfoList)
        Me.tab_info.Controls.Add(Me.lst_Info)
        Me.tab_info.Location = New System.Drawing.Point(4, 22)
        Me.tab_info.Name = "tab_info"
        Me.tab_info.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_info.Size = New System.Drawing.Size(519, 176)
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
        Me.lst_Info.Size = New System.Drawing.Size(513, 149)
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
        Me.tab_hist.Size = New System.Drawing.Size(519, 176)
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
        Me.lst_Hist.Size = New System.Drawing.Size(516, 151)
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
        Me.tab_UpdPrice.Size = New System.Drawing.Size(519, 176)
        Me.tab_UpdPrice.TabIndex = 2
        Me.tab_UpdPrice.Text = "Chinh Gia"
        Me.tab_UpdPrice.UseVisualStyleBackColor = True
        '
        'lbl_UpdatePriceTag
        '
        Me.lbl_UpdatePriceTag.AutoSize = True
        Me.lbl_UpdatePriceTag.Location = New System.Drawing.Point(231, 22)
        Me.lbl_UpdatePriceTag.Name = "lbl_UpdatePriceTag"
        Me.lbl_UpdatePriceTag.Size = New System.Drawing.Size(84, 13)
        Me.lbl_UpdatePriceTag.TabIndex = 4
        Me.lbl_UpdatePriceTag.Text = "Dang Cap Nhat:"
        '
        'btn_RefreshPriceUpdate
        '
        Me.btn_RefreshPriceUpdate.Location = New System.Drawing.Point(426, 147)
        Me.btn_RefreshPriceUpdate.Name = "btn_RefreshPriceUpdate"
        Me.btn_RefreshPriceUpdate.Size = New System.Drawing.Size(87, 23)
        Me.btn_RefreshPriceUpdate.TabIndex = 3
        Me.btn_RefreshPriceUpdate.Text = "Refresh"
        Me.btn_RefreshPriceUpdate.UseVisualStyleBackColor = True
        '
        'btn_UpdPrice
        '
        Me.btn_UpdPrice.Location = New System.Drawing.Point(272, 87)
        Me.btn_UpdPrice.Name = "btn_UpdPrice"
        Me.btn_UpdPrice.Size = New System.Drawing.Size(75, 56)
        Me.btn_UpdPrice.TabIndex = 2
        Me.btn_UpdPrice.Text = "Cap Nhat Gia"
        Me.btn_UpdPrice.UseVisualStyleBackColor = True
        '
        'txtPriceUpd
        '
        Me.txtPriceUpd.Location = New System.Drawing.Point(272, 48)
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
        Me.lst_BangGia.Size = New System.Drawing.Size(198, 163)
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
        Me.tab_UpdTemplate.Size = New System.Drawing.Size(519, 176)
        Me.tab_UpdTemplate.TabIndex = 3
        Me.tab_UpdTemplate.Text = "Chinh Template"
        Me.tab_UpdTemplate.UseVisualStyleBackColor = True
        '
        'btnTemplateListRefresh
        '
        Me.btnTemplateListRefresh.Location = New System.Drawing.Point(456, 147)
        Me.btnTemplateListRefresh.Name = "btnTemplateListRefresh"
        Me.btnTemplateListRefresh.Size = New System.Drawing.Size(60, 23)
        Me.btnTemplateListRefresh.TabIndex = 3
        Me.btnTemplateListRefresh.Text = "Refresh"
        Me.btnTemplateListRefresh.UseVisualStyleBackColor = True
        '
        'btn_UpdTemplate
        '
        Me.btn_UpdTemplate.Location = New System.Drawing.Point(458, 5)
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
        Me.txtUpdTemplate.Size = New System.Drawing.Size(319, 160)
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
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.btn_ManageUser)
        Me.Controls.Add(Me.Clock1)
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
    Friend WithEvents Clock1 As AnalogClock.Clock
    Friend WithEvents lblDate As System.Windows.Forms.Label
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
