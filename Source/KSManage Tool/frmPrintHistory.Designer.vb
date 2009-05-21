<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintHistory
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtStartMonth = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtStartYear = New System.Windows.Forms.TextBox
        Me.txtStartDay = New System.Windows.Forms.TextBox
        Me.btnStartDate_GetDate = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnEndDate_GetDate = New System.Windows.Forms.Button
        Me.txtEndMonth = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtEndYear = New System.Windows.Forms.TextBox
        Me.txtEndDay = New System.Windows.Forms.TextBox
        Me.btnSelectAllRoom = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lstPrintRoom = New System.Windows.Forms.CheckedListBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnDeselectAll = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Controls.Add(Me.btnStartDate_GetDate)
        Me.GroupBox1.Controls.Add(Me.txtStartMonth)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtStartYear)
        Me.GroupBox1.Controls.Add(Me.txtStartDay)
        Me.GroupBox1.Location = New System.Drawing.Point(180, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(149, 100)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ngay Bat Dau"
        '
        'txtStartMonth
        '
        Me.txtStartMonth.Location = New System.Drawing.Point(58, 32)
        Me.txtStartMonth.Name = "txtStartMonth"
        Me.txtStartMonth.Size = New System.Drawing.Size(33, 20)
        Me.txtStartMonth.TabIndex = 10
        Me.txtStartMonth.Text = "01"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(97, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Nam"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(53, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Thang"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Ngay"
        '
        'txtStartYear
        '
        Me.txtStartYear.Location = New System.Drawing.Point(100, 32)
        Me.txtStartYear.Name = "txtStartYear"
        Me.txtStartYear.Size = New System.Drawing.Size(43, 20)
        Me.txtStartYear.TabIndex = 6
        Me.txtStartYear.Text = "2001"
        '
        'txtStartDay
        '
        Me.txtStartDay.Location = New System.Drawing.Point(13, 32)
        Me.txtStartDay.Name = "txtStartDay"
        Me.txtStartDay.Size = New System.Drawing.Size(34, 20)
        Me.txtStartDay.TabIndex = 5
        Me.txtStartDay.Text = "01"
        '
        'btnStartDate_GetDate
        '
        Me.btnStartDate_GetDate.Location = New System.Drawing.Point(31, 58)
        Me.btnStartDate_GetDate.Name = "btnStartDate_GetDate"
        Me.btnStartDate_GetDate.Size = New System.Drawing.Size(75, 23)
        Me.btnStartDate_GetDate.TabIndex = 11
        Me.btnStartDate_GetDate.Text = "Hom Nay"
        Me.btnStartDate_GetDate.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.AutoSize = True
        Me.GroupBox2.Controls.Add(Me.btnEndDate_GetDate)
        Me.GroupBox2.Controls.Add(Me.txtEndMonth)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtEndYear)
        Me.GroupBox2.Controls.Add(Me.txtEndDay)
        Me.GroupBox2.Location = New System.Drawing.Point(180, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(149, 100)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ngay Ket Thuc"
        '
        'btnEndDate_GetDate
        '
        Me.btnEndDate_GetDate.Location = New System.Drawing.Point(31, 58)
        Me.btnEndDate_GetDate.Name = "btnEndDate_GetDate"
        Me.btnEndDate_GetDate.Size = New System.Drawing.Size(75, 23)
        Me.btnEndDate_GetDate.TabIndex = 11
        Me.btnEndDate_GetDate.Text = "Hom Nay"
        Me.btnEndDate_GetDate.UseVisualStyleBackColor = True
        '
        'txtEndMonth
        '
        Me.txtEndMonth.Location = New System.Drawing.Point(58, 32)
        Me.txtEndMonth.Name = "txtEndMonth"
        Me.txtEndMonth.Size = New System.Drawing.Size(33, 20)
        Me.txtEndMonth.TabIndex = 10
        Me.txtEndMonth.Text = "10"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(97, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Nam"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(53, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Thang"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Ngay"
        '
        'txtEndYear
        '
        Me.txtEndYear.Location = New System.Drawing.Point(100, 32)
        Me.txtEndYear.Name = "txtEndYear"
        Me.txtEndYear.Size = New System.Drawing.Size(43, 20)
        Me.txtEndYear.TabIndex = 6
        Me.txtEndYear.Text = "2010"
        '
        'txtEndDay
        '
        Me.txtEndDay.Location = New System.Drawing.Point(13, 32)
        Me.txtEndDay.Name = "txtEndDay"
        Me.txtEndDay.Size = New System.Drawing.Size(34, 20)
        Me.txtEndDay.TabIndex = 5
        Me.txtEndDay.Text = "10"
        '
        'btnSelectAllRoom
        '
        Me.btnSelectAllRoom.Location = New System.Drawing.Point(13, 225)
        Me.btnSelectAllRoom.Name = "btnSelectAllRoom"
        Me.btnSelectAllRoom.Size = New System.Drawing.Size(57, 39)
        Me.btnSelectAllRoom.TabIndex = 8
        Me.btnSelectAllRoom.Text = "Chon Tat Ca"
        Me.btnSelectAllRoom.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox3.Controls.Add(Me.btnDeselectAll)
        Me.GroupBox3.Controls.Add(Me.lstPrintRoom)
        Me.GroupBox3.Controls.Add(Me.btnSelectAllRoom)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(152, 270)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Chon Danh Sach Phong"
        '
        'lstPrintRoom
        '
        Me.lstPrintRoom.CheckOnClick = True
        Me.lstPrintRoom.FormattingEnabled = True
        Me.lstPrintRoom.Location = New System.Drawing.Point(13, 20)
        Me.lstPrintRoom.Name = "lstPrintRoom"
        Me.lstPrintRoom.Size = New System.Drawing.Size(130, 199)
        Me.lstPrintRoom.TabIndex = 9
        Me.lstPrintRoom.ThreeDCheckBoxes = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(180, 237)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(60, 39)
        Me.btnPrint.TabIndex = 10
        Me.btnPrint.Text = "In"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(248, 237)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 39)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Thoat"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Location = New System.Drawing.Point(76, 225)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(67, 39)
        Me.btnDeselectAll.TabIndex = 10
        Me.btnDeselectAll.Text = "Bo Tat Ca"
        Me.btnDeselectAll.UseVisualStyleBackColor = True
        '
        'frmPrintHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(344, 293)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrintHistory"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "In Lich Su Thu Nhap"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStartDate_GetDate As System.Windows.Forms.Button
    Friend WithEvents txtStartMonth As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStartYear As System.Windows.Forms.TextBox
    Friend WithEvents txtStartDay As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEndDate_GetDate As System.Windows.Forms.Button
    Friend WithEvents txtEndMonth As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEndYear As System.Windows.Forms.TextBox
    Friend WithEvents txtEndDay As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectAllRoom As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lstPrintRoom As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnDeselectAll As System.Windows.Forms.Button
End Class
