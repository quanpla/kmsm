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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.imgl_RoomStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.Button2 = New System.Windows.Forms.Button
        Me.Clock1 = New AnalogClock.Clock
        Me.Button3 = New System.Windows.Forms.Button
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ListView3 = New System.Windows.Forms.ListView
        Me.lblDate = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(536, 275)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Current Login as"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(536, 315)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 46)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Logout/ Switch User"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Alignment = System.Windows.Forms.ListViewAlignment.[Default]
        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8})
        Me.ListView1.LargeImageList = Me.imgl_RoomStatus
        Me.ListView1.Location = New System.Drawing.Point(3, 4)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowGroups = False
        Me.ListView1.Size = New System.Drawing.Size(527, 565)
        Me.ListView1.TabIndex = 3
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'imgl_RoomStatus
        '
        Me.imgl_RoomStatus.ImageStream = CType(resources.GetObject("imgl_RoomStatus.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgl_RoomStatus.TransparentColor = System.Drawing.Color.Transparent
        Me.imgl_RoomStatus.Images.SetKeyName(0, "checkout.png")
        Me.imgl_RoomStatus.Images.SetKeyName(1, "customerout.png")
        Me.imgl_RoomStatus.Images.SetKeyName(2, "empty.png")
        Me.imgl_RoomStatus.Images.SetKeyName(3, "withcustomer.png")
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(626, 315)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 46)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Manage User"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Clock1
        '
        Me.Clock1.BigMarkers = New AnalogClock.Marker() {New AnalogClock.Marker("BigMarker90", 90.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker60", 60.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker30", 30.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker0", 0.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker330", 330.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker300", 300.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker270", 270.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker240", 240.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker210", 210.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker180", 180.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker150", 150.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("BigMarker120", 120.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.06!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias)}
        Me.Clock1.CenterPoint.PaintAttributes = New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!)
        Me.Clock1.CenterPoint.RelativeRadius = 0.03!
        Me.Clock1.HourHand.PaintAttributes = New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!)
        Me.Clock1.HourHand.RelativeRadius = 0.65!
        Me.Clock1.HourHand.Width = 5.0!
        Me.Clock1.Location = New System.Drawing.Point(536, 4)
        Me.Clock1.MinuteHand.PaintAttributes = New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!)
        Me.Clock1.MinuteHand.RelativeRadius = 0.8!
        Me.Clock1.MinuteHand.Width = 5.0!
        Me.Clock1.Name = "Clock1"
        Me.Clock1.SecondHand.PaintAttributes = New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!)
        Me.Clock1.SecondHand.RelativeRadius = 0.9!
        Me.Clock1.SecondHand.Width = 1.0!
        Me.Clock1.Size = New System.Drawing.Size(254, 252)
        Me.Clock1.SmallMarkers = New AnalogClock.Marker() {New AnalogClock.Marker("SmallMarker90", 90.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker84", 84.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker78", 78.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker72", 72.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker66", 66.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker60", 60.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker54", 54.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker48", 48.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker42", 42.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker36", 36.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker30", 30.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker24", 24.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker18", 18.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker12", 12.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker6", 6.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker0", 0.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker354", 354.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker348", 348.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker342", 342.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker336", 336.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker330", 330.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker324", 324.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker318", 318.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker312", 312.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker306", 306.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker300", 300.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker294", 294.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker288", 288.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker282", 282.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker276", 276.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker270", 270.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker264", 264.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker258", 258.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker252", 252.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker246", 246.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker240", 240.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker234", 234.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker228", 228.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker222", 222.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker216", 216.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker210", 210.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker204", 204.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker198", 198.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker192", 192.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker186", 186.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker180", 180.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker174", 174.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker168", 168.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker162", 162.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker156", 156.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker150", 150.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker144", 144.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker138", 138.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker132", 132.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker126", 126.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker120", 120.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker114", 114.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker108", 108.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker102", 102.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias), New AnalogClock.Marker("SmallMarker96", 96.0!, System.Drawing.Color.Black, AnalogClock.MarkerStyle.Regular, True, 126.0!, 1.0!, 0.03!, 1.0!, New AnalogClock.PaintAttributes(AnalogClock.PaintObject.Brush, 1.0!), AnalogClock.SmoothMode.AntiAlias)}
        Me.Clock1.Symbols = New AnalogClock.Symbol() {New AnalogClock.Symbol("Symbol90", 90.0!, "12", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 0, True, True, AnalogClock.SymbolStyle.Numeric, 126.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol60", 60.0!, "1", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 1, True, True, AnalogClock.SymbolStyle.Numeric, 126.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol30", 30.0!, "2", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 2, True, True, AnalogClock.SymbolStyle.Numeric, 126.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol0", 0.0!, "3", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 3, True, True, AnalogClock.SymbolStyle.Numeric, 126.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol330", 330.0!, "4", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 4, True, True, AnalogClock.SymbolStyle.Numeric, 126.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol300", 300.0!, "5", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 5, True, True, AnalogClock.SymbolStyle.Numeric, 126.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol270", 270.0!, "6", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 6, True, True, AnalogClock.SymbolStyle.Numeric, 126.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol240", 240.0!, "7", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 7, True, True, AnalogClock.SymbolStyle.Numeric, 126.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol210", 210.0!, "8", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 8, True, True, AnalogClock.SymbolStyle.Numeric, 126.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol180", 180.0!, "9", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 9, True, True, AnalogClock.SymbolStyle.Numeric, 126.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol150", 150.0!, "10", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 10, True, True, AnalogClock.SymbolStyle.Numeric, 126.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault), New AnalogClock.Symbol("Symbol120", 120.0!, "11", New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold), System.Drawing.Color.Black, New System.Drawing.Point(1, 1), 11, True, True, AnalogClock.SymbolStyle.Numeric, 126.0!, 0.82!, System.Drawing.Text.TextRenderingHint.SystemDefault)}
        Me.Clock1.TabIndex = 5
        Me.Clock1.UtcOffset = System.TimeSpan.Parse("07:00:00")
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(707, 315)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(83, 46)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Logout/ Switch User"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Status"
        Me.ColumnHeader1.Width = 1
        '
        'ListView3
        '
        Me.ListView3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListView3.Location = New System.Drawing.Point(536, 367)
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(254, 202)
        Me.ListView3.TabIndex = 4
        Me.ListView3.UseCompatibleStateImageBehavior = False
        '
        'lblDate
        '
        Me.lblDate.Location = New System.Drawing.Point(597, 85)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(137, 13)
        Me.lblDate.TabIndex = 6
        Me.lblDate.Text = "Label2"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 571)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.Clock1)
        Me.Controls.Add(Me.ListView3)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KSManage Tool"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents imgl_RoomStatus As System.Windows.Forms.ImageList
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Clock1 As AnalogClock.Clock
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListView3 As System.Windows.Forms.ListView
    Friend WithEvents lblDate As System.Windows.Forms.Label

End Class
