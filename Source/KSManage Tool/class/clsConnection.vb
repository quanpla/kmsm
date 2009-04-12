Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports KSManage_Tool.GlobalClass

Public Class clsConnection

    Public Function fsDatabaseConnection() As SqlConnection
        Dim conn As New SqlConnection(My.Settings.connectionStr)
        strConn = My.Settings.connectionStr.ToString
    End Function
    '    Public Function fsReportServerConnection() As String
    '        Return System.Configuration.ConfigurationManager.AppSettings("ReportServer")
    '    End Function
End Class
