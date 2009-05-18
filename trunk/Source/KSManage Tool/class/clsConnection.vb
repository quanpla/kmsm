Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports q3main.Applications.KSManageTool.GlobalClass

    Public Class clsConnection

        Public Function fsDatabaseConnection() As SqlConnection
            Dim conn As New SqlConnection(My.Settings.connectionStr)
            strConn = My.Settings.connectionStr.ToString
            Return conn
        End Function
        '    Public Function fsReportServerConnection() As String
        '        Return System.Configuration.ConfigurationManager.AppSettings("ReportServer")
        '    End Function
    End Class
