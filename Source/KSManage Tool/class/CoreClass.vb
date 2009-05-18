' ============================================================================ '
' =         Copyright (c) 2006. MMSOFT Co., Ltd. All Rights Reserved.        = '
' =                                                                          = '
' =  Permission to use, copy, modify, and distribute this software and its   = '
' =  documentation for any purpose, without fee, and without a written       = '
' =  agreement, is here by granted, provided that the above copyright notice,= '
' =  this paragraph and the following two paragraphs appear in all copies,   = '
' =  modifications, and distributions.  Created by:                          = '
' =                                                                          = '
' =                        M.M..S.O.F.T.W.A.R.E                              = '
' =                                                                          = '
' =  MM Software Co., Ltd, 35 Tan Vinh Street, Ward 4                        = '
' =  District 4, Ho Chi Minh City, Viet Nam.                                 = '
' =  For technical information, contact mmsoftvn@gmail.com                   = '
' =                                                                          = '
' =  IN NO EVENT SHALL REGENTS BE LIABLE TO ANY PARTY FOR DIRECT, INDIRECT,  = '
' =  SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES, INCLUDING LOST PROFITS,  = '
' =  ARISING OUT OF THE USE OF THIS SOFTWARE AND ITS DOCUMENTATION, EVEN IF  = '
' =  REGENTS HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.             = '
' =                                                                          = '
' =  REGENTS SPECIFICALLY DISCLAIMS ANY WARRANTIES, INCLUDING, BUT NOT       = '
' =  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A = '
' =  PARTICULAR PURPOSE. THE SOFTWARE AND ACCOMPANYING DOCUMENTATION, IF     = '
' =  ANY, PROVIDED HEREUNDER IS PROVIDED "AS IS". REGENTS HAS NO OBLIGATION  = '
' =  TO PROVIDE MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS, OR              = '
' =  MODIFICATIONS.                                                          = '
' ============================================================================ '


'Author: VTHIEP
'Purpose: This class is general used for all class inherit from its general and share function

Imports Microsoft.VisualBasic

Public Class CoreClass
#Region "Declare Value"
    Public objData As New DatabaseClass()

    'VTHIEP added on 24-Dec-06
    'This variable for storing the roleCode
    Public Shared RoleCode As String = ""
#End Region




    'This function will return datetime as Year-Month-Day Format
    'base on Day-Month-Year variable add in
    Public Function YMDFormat(ByVal dt As String) As String
        Dim d As String = ""
        Dim m As String = ""
        Dim y As String = ""

        d = dt.Substring(0, 2)
        m = dt.Substring(3, 2)
        y = dt.Substring(6, 4)


        Return y + "/" + m + "/" + d
    End Function
    'Function to return Month Name
    Public Function GetMonthName(ByVal num As String) As String

        If num = "1" Then
            GetMonthName = "January"
        ElseIf num = "2" Then
            GetMonthName = "February"
        ElseIf num = "3" Then
            GetMonthName = "March"
        ElseIf num = "4" Then
            GetMonthName = "April"
        ElseIf num = "5" Then
            GetMonthName = "May"
        ElseIf num = "6" Then
            GetMonthName = "June"
        ElseIf num = "7" Then
            GetMonthName = "July"
        ElseIf num = "8" Then
            GetMonthName = "August"
        ElseIf num = "9" Then
            GetMonthName = "September"
        ElseIf num = "10" Then
            GetMonthName = "October"
        ElseIf num = "11" Then
            GetMonthName = "November"
        ElseIf num = "12" Then
            GetMonthName = "December"
        Else
            GetMonthName = num
        End If
    End Function

    Public Function ConvertWildChar(ByVal str As String) As String
        Dim returnString As String = ""

        returnString = str.Replace("&amp;", "&")
        returnString = returnString.Replace("&lt;", "<")
        returnString = returnString.Replace("&gt;", ">")
        returnString = returnString.Replace("&quot;", """")

        Return returnString
    End Function
End Class
