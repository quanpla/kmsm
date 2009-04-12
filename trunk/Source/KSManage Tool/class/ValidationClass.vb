Imports Microsoft.VisualBasic
Imports System.Threading
Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Text

Public Class ValidationClass

    ''' <summary>
    ''' Using to validate Null
    ''' </summary>
    ''' <param name="arrTextBox">array list of TextBox</param>
    ''' <param name="arrLabel">array list of Label show validation Message</param>
    ''' <param name="strMessgeToShow">Message to show validation Message</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function validateNull(ByVal arrTextBox As ArrayList, ByVal arrLabel As ArrayList, ByVal strMessgeToShow As String) As Boolean
        Dim strReturn As Boolean = True
        For i As Int16 = 0 To arrTextBox.Count - 1
            If CType(arrTextBox(i), TextBox).Text.Trim() = "" Then
                CType(arrLabel(i), Label).Visible = True
                CType(arrLabel(i), Label).Text = strMessgeToShow

                strReturn = False
            Else
                CType(arrLabel(i), Label).Visible = False
            End If
        Next
        Return strReturn
    End Function

    ''' <summary>
    ''' Using to validate Number
    ''' </summary>
    ''' <param name="arrTextBox">array list of TextBox</param>
    ''' <param name="arrLabel">array list of Label show validation Message</param>
    ''' <param name="strMessgeToShow">Message to show validation Message</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function validateNumber(ByVal arrTextBox As ArrayList, ByVal arrLabel As ArrayList, ByVal strMessgeToShow As String) As Boolean
        Dim strReturn As Boolean = True
        Dim strFormat = ""
        For i As Int16 = 0 To arrTextBox.Count - 1
            Try
                strFormat = CType(arrTextBox(i), TextBox).Text.Trim()
                Dim dblFormat As Double = Double.Parse(strFormat)
                CType(arrLabel(i), Label).Visible = False
            Catch ex As Exception
                CType(arrLabel(i), Label).Visible = True
                CType(arrLabel(i), Label).Text = strMessgeToShow
                strReturn = False
            End Try
        Next
        Return strReturn

    End Function

    Public Function validateStringByArraySpecialCharacter(ByVal strInputString As String, ByVal arrSpecialCharacter As ArrayList) As Boolean
        Dim i As Integer
        For i = 0 To arrSpecialCharacter.Count - 1 Step i + 1
            If strInputString.IndexOf(arrSpecialCharacter(i).ToString(), 0) >= 0 Then
                Return False
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strInputDateString">type string: input date string</param>
    ''' <param name="strDateFormat">type string: date format to validate</param>
    ''' <returns>type bool: true if date input valid, else return false</returns>
    Public Function validateDateStringByStringFormat(ByVal strInputDateString As String, ByVal strDateFormat As String) As Boolean

        Try
            Dim dateT As DateTime = DateTime.ParseExact(strInputDateString.Trim(), strDateFormat.Trim(), Nothing)
            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function


    Dim lbtVector() As Byte = {240, 3, 45, 40, 0, 76, 173, 59}
    Private lscryptoKey As String = "ChangeThis!"

    Public Function EncryptData(ByVal sSource As String) As String
        Dim loCryptoClass As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
        Dim loCryptoProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
        Dim lbtBuffer() As Byte
        Try
            lbtBuffer = System.Text.Encoding.ASCII.GetBytes(sSource)
            loCryptoClass.Key = loCryptoProvider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(lscryptoKey))
            loCryptoClass.IV = lbtVector
            Return Convert.ToBase64String(loCryptoClass.CreateEncryptor().TransformFinalBlock(lbtBuffer, 0, lbtBuffer.Length))
        Catch ex As Exception
            Return ""
        Finally
            loCryptoClass.Clear()
            loCryptoProvider.Clear()
            loCryptoClass = Nothing
            loCryptoProvider = Nothing
        End Try
        Return ""
    End Function

    Public Function DecryptData(ByVal sSource As String) As String
        Dim buffer() As Byte
        Dim loCryptoClass As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
        Dim loCryptoProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()

        Try
            buffer = Convert.FromBase64String(sSource)
            loCryptoClass.Key = loCryptoProvider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(lscryptoKey))
            loCryptoClass.IV = lbtVector
            Return Encoding.ASCII.GetString(loCryptoClass.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length))
        Catch ex As Exception
            Return ""
        Finally
            loCryptoClass.Clear()
            loCryptoProvider.Clear()
            loCryptoClass = Nothing
            loCryptoProvider = Nothing
        End Try
        Return ""
    End Function

End Class
