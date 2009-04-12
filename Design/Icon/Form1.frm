VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   5100
   ClientLeft      =   225
   ClientTop       =   825
   ClientWidth     =   7785
   LinkTopic       =   "Form1"
   ScaleHeight     =   5100
   ScaleWidth      =   7785
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command2 
      Caption         =   "Command2"
      Height          =   1095
      Left            =   3960
      TabIndex        =   1
      Top             =   720
      Width           =   1335
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   975
      Left            =   960
      TabIndex        =   0
      Top             =   840
      Width           =   1335
   End
   Begin VB.Menu mnuMain 
      Caption         =   "Menu1"
      Begin VB.Menu mnusp 
         Caption         =   "-"
      End
      Begin VB.Menu mnuMenu1 
         Caption         =   "mnuMenu"
         Index           =   0
         Visible         =   0   'False
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
Dim i As Integer
RemoveMenu
    For i = 1 To 10
       With mnuMenu1(i)
         Load mnuMenu1(i)
        
        .Caption = "Menu " & i
        .Visible = True
       End With
    Next i
End Sub

Private Sub RemoveMenu()
Dim Menu As Menu
  For Each Menu In mnuMenu1
    If Menu.Index <> 0 Then Unload Menu
  Next
End Sub

Private Sub Command2_Click()
    RemoveMenu
End Sub
