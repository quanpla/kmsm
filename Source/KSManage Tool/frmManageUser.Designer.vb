<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageUser
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
        Me.lstUsers = New System.Windows.Forms.ListView
        Me.colUsername = New System.Windows.Forms.ColumnHeader
        Me.colRole = New System.Windows.Forms.ColumnHeader
        Me.btnNewUser = New System.Windows.Forms.Button
        Me.btnChangePW = New System.Windows.Forms.Button
        Me.btnDeleteUser = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lstUsers
        '
        Me.lstUsers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colUsername, Me.colRole})
        Me.lstUsers.Location = New System.Drawing.Point(2, 1)
        Me.lstUsers.Name = "lstUsers"
        Me.lstUsers.Size = New System.Drawing.Size(258, 215)
        Me.lstUsers.TabIndex = 0
        Me.lstUsers.UseCompatibleStateImageBehavior = False
        Me.lstUsers.View = System.Windows.Forms.View.Details
        '
        'colUsername
        '
        Me.colUsername.Text = "Username"
        '
        'colRole
        '
        Me.colRole.Text = "Role"
        Me.colRole.Width = 180
        '
        'btnNewUser
        '
        Me.btnNewUser.Location = New System.Drawing.Point(1, 222)
        Me.btnNewUser.Name = "btnNewUser"
        Me.btnNewUser.Size = New System.Drawing.Size(82, 49)
        Me.btnNewUser.TabIndex = 1
        Me.btnNewUser.Text = "Them Nguoi Dung Moi"
        Me.btnNewUser.UseVisualStyleBackColor = True
        '
        'btnChangePW
        '
        Me.btnChangePW.Location = New System.Drawing.Point(90, 222)
        Me.btnChangePW.Name = "btnChangePW"
        Me.btnChangePW.Size = New System.Drawing.Size(82, 49)
        Me.btnChangePW.TabIndex = 2
        Me.btnChangePW.Text = "Doi/Reset Mat Ma"
        Me.btnChangePW.UseVisualStyleBackColor = True
        '
        'btnDeleteUser
        '
        Me.btnDeleteUser.Location = New System.Drawing.Point(178, 222)
        Me.btnDeleteUser.Name = "btnDeleteUser"
        Me.btnDeleteUser.Size = New System.Drawing.Size(82, 49)
        Me.btnDeleteUser.TabIndex = 3
        Me.btnDeleteUser.Text = "Xoa Nguoi Dung"
        Me.btnDeleteUser.UseVisualStyleBackColor = True
        '
        'frmManageUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(262, 273)
        Me.Controls.Add(Me.btnDeleteUser)
        Me.Controls.Add(Me.btnChangePW)
        Me.Controls.Add(Me.btnNewUser)
        Me.Controls.Add(Me.lstUsers)
        Me.Name = "frmManageUser"
        Me.Text = "ManageUser"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstUsers As System.Windows.Forms.ListView
    Friend WithEvents btnNewUser As System.Windows.Forms.Button
    Friend WithEvents btnChangePW As System.Windows.Forms.Button
    Friend WithEvents btnDeleteUser As System.Windows.Forms.Button
    Friend WithEvents colUsername As System.Windows.Forms.ColumnHeader
    Friend WithEvents colRole As System.Windows.Forms.ColumnHeader
End Class
