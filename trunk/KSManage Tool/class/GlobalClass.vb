Imports Microsoft.VisualBasic

Public Class GlobalClass



#Region "Convert DateTime"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strDateValue"></param>
    ''' <param name="strCurrentDateFormat"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function convertDate(ByVal strDateValue As String, ByVal strCurrentDateFormat As String) As String

        Try
            Dim dateT As DateTime = DateTime.ParseExact(strDateValue.Trim(), strCurrentDateFormat, Nothing)
            Return dateT.Year.ToString() + "-" + dateT.Month.ToString() + "-" + dateT.Day.ToString()

        Catch ex As Exception
            Return False
        End Try

    End Function
#End Region
End Class
