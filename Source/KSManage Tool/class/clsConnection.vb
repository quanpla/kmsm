Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class clsConnection

    Public Function fsDatabaseConnection() As SqlConnection
        Dim conn As New SqlConnection(My.Settings.connectionStr)
        Return conn
    End Function
    '    Public Function fsReportServerConnection() As String
    '        Return System.Configuration.ConfigurationManager.AppSettings("ReportServer")
    '    End Function
End Class
