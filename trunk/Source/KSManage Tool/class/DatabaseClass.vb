Imports Microsoft.VisualBasic
Imports System
Imports System.Data

Public Class DatabaseClass
    Public dataConn As System.Data.SqlClient.SqlConnection
    Public dataComm As System.Data.SqlClient.SqlCommand
    Public dataRead As System.Data.SqlClient.SqlDataReader
    Public dataSet As System.Data.DataSet
    Public dataAdapter As System.Data.SqlClient.SqlDataAdapter
    Public strConnectionString As String = strConn

    Public Sub New(Optional ByVal ConnectString As String = "")
        MyBase.new()
    End Sub

    Function checkConnection() As Boolean
        ConnectData()
        Return dataConn.State = ConnectionState.Open
        CloseData()
    End Function

    Public Sub ConnectData()
        strConnectionString = strConn
        Try
            If dataConn Is Nothing Then dataConn = New System.Data.SqlClient.SqlConnection
            If dataConn.State = System.Data.ConnectionState.Closed Then
                dataConn.ConnectionString = vbNullString
                dataConn.ConnectionString = strConnectionString
                dataConn.Open()
            End If
            If dataComm Is Nothing Then dataComm = New System.Data.SqlClient.SqlCommand
            dataComm.Connection = dataConn
            dataComm.CommandTimeout = 20
            dataComm.CommandType = CommandType.Text
        Catch ex As Exception
        End Try

    End Sub
    Public Sub CloseData()
        If Not dataRead Is Nothing Then dataRead.Close()
        If Not dataConn Is Nothing Then If dataConn.State = ConnectionState.Open Then dataConn.Dispose()
        dataRead = Nothing
        dataConn = Nothing
    End Sub

    'run ExecuteNonQuery (do not return value)
    Public Sub ExeNonQuery(ByVal strQuery As String)
        If dataConn Is Nothing Then Call ConnectData()
        dataComm.CommandText = strQuery
        dataComm.ExecuteNonQuery()
    End Sub

    'Run ExecuteReader 
    Public Sub ExeReader(ByVal strQuery As String)
        If dataConn Is Nothing Then Call ConnectData()
        If Not dataRead Is Nothing Then dataRead.Close()
        dataComm.CommandText = strQuery
        dataRead = dataComm.ExecuteReader()
    End Sub

    Public Function ExeDataset(ByVal strQuery As String) As System.Data.DataSet
        If dataConn Is Nothing Then Call ConnectData()
        dataAdapter = New System.Data.SqlClient.SqlDataAdapter
        dataAdapter.SelectCommand = dataComm
        dataSet = New System.Data.DataSet
        dataComm.CommandText = strQuery
        Try
            dataAdapter.Fill(dataSet)
            Return dataSet
        Catch ex As Exception
            CloseData()
            Return Nothing
        Finally
            CloseData()
        End Try
    End Function
End Class
