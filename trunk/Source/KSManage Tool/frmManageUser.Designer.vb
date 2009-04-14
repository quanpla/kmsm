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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(2, 222)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 49)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "New"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(90, 222)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(82, 49)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Change pw"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(178, 222)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(82, 49)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Delete"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmManageUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(262, 273)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lstUsers)
        Me.Name = "frmManageUser"
        Me.Text = "ManageUser"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstUsers As System.Windows.Forms.ListView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents colUsername As System.Windows.Forms.ColumnHeader
    Friend WithEvents colRole As System.Windows.Forms.ColumnHeader
End Class
