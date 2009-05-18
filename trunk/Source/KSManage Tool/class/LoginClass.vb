Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

    Public Class LoginClass
        Public userRoleID As String
        Public userRoleName As String
        Public empCode As String
        Public empName As String

        Public Function LoginClass(ByVal UserName As String, ByVal Password As String) As Hashtable
            Dim databaseClass As New DatabaseClass
            Dim ds As New DataSet
            Dim ht As New Hashtable

            Try

                databaseClass.ConnectData()
                Dim dataAdapter As New System.Data.SqlClient.SqlDataAdapter("prcLogin", databaseClass.dataConn)
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

                With dataAdapter.SelectCommand.Parameters
                    .Add("@USERNAME", SqlDbType.Char, 20).Value = UserName
                    .Add("@PASSWORD", SqlDbType.VarChar, 255).Value = Password
                    .Add("@ROLEID", SqlDbType.Int).Direction = ParameterDirection.Output
                    .Add("@ROLENAME", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                    .Add("@EMPCODE", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                    .Add("@EMPNAME", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                End With

                dataAdapter.Fill(ds)

                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    ht.Add(ds.Tables(0).Rows(i).Item(1).ToString, "")
                Next

                userRoleID = dataAdapter.SelectCommand.Parameters.Item("@ROLEID").Value.ToString
                userRoleName = dataAdapter.SelectCommand.Parameters.Item("@ROLENAME").Value.ToString
                empCode = dataAdapter.SelectCommand.Parameters.Item("@EMPCODE").Value.ToString
                empName = dataAdapter.SelectCommand.Parameters.Item("@EMPNAME").Value.ToString
            Catch ex As Exception
                ex.ToString()
            Finally
                databaseClass.CloseData()
            End Try

            Return ht


        End Function

    End Class

