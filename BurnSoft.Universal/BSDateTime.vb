'-------------------------------------------
' Created By BurnSoft
' www.burnsoft.net
'-------------------------------------------
' ReSharper disable once InconsistentNaming
''' <summary>
''' Class BSDateTime.  Misc Date and Tim e Functions
''' </summary>
Public Class BSDateTime
    ''' <summary>
    ''' Determines whether [is date past now] [the specified s date].
    ''' Checks to see if the data that is passed is greater than or less then the current time
    ''' if not current then it is true
    ''' </summary>
    ''' <param name="sDate">The s date.</param>
    ''' <param name="sErrMsg">The s error MSG.</param>
    ''' <returns><c>true</c> if [is date past now] [the specified s date]; otherwise, <c>false</c>.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSDateTime <br/>
    ''' <br/>
    ''' Dim obj As New BSDateTime <br/>
    ''' Dim testDate As String = "12/10/2018" <br/>
    ''' Dim value As Boolean = obj.IsDatePastNow(testDate, errOut) <br/>
    ''' Debug.Print("Date being used:{0}", testDate) <br/>
    ''' Debug.Print("Is Past Due: {0}", value) <br/>
    ''' </example>
    Public Function IsDatePastNow(ByVal sDate As String, Optional ByRef sErrMsg As String = "") As Boolean
        Dim bAns As Boolean = False
        Try
            Dim dd As Long = DateDiff(DateInterval.Day, CDate(sDate), Now)
            If dd = 0 Then
                bAns = False
            ElseIf dd > 0 Then
                bAns = True
            ElseIf dd < 0 Then
                bAns = False
            End If
        Catch ex As Exception
            Dim strFrom As String = "modMain"
            Dim strSubFunc As String = "ISDatePastNow"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            sErrMsg = sMsg & "::" & strFrom & "." & strSubFunc
        End Try
        Return bAns
    End Function
    ''' <summary>
    ''' Determines whether [is date now] [the specified s date].
    ''' Checks to see if the data that is passed is greater than or less then the current time
    ''' if not current then it is false
    ''' </summary>
    ''' <param name="sDate">The s date.</param>
    ''' <param name="sErrMsg">The s error MSG.</param>
    ''' <returns><c>true</c> if [is date now] [the specified s date]; otherwise, <c>false</c>.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSDateTime <br/>
    ''' <br/>
    '''  Dim obj As New BSDateTime <br/>
    ''' Dim testDate As String = DateTime.Now <br/>
    ''' Dim value As Boolean = obj.ISDateNow(testDate, errOut) <br/>
    ''' Debug.Print("Date being used:{0}", testDate) <br/>
    ''' Debug.Print("Is today the day: {0}", value) <br/>
    ''' </example>
    Public Function ISDateNow(ByVal sDate As String, Optional ByRef sErrMsg As String = "") As Boolean
        Dim bAns As Boolean = False
        Try
            Dim dd As Long = DateDiff(DateInterval.Day, CDate(sDate), Now)
            If dd = 0 Then
                bAns = True
            ElseIf dd > 0 Then
                bAns = False
            ElseIf dd < 0 Then
                bAns = False
            End If
        Catch ex As Exception
            Dim strFrom As String = "modMain"
            Dim strSubFunc As String = "ISDateNow"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            sErrMsg = sMsg & "::" & strFrom & "." & strSubFunc
        End Try
        Return bAns
    End Function
    ''' <summary>
    ''' Determines whether [is date before now] [the specified s date].
    ''' Checks to see if the data that is passed is greater than or less then the current time
    ''' if not current then it is true
    ''' </summary>
    ''' <param name="sDate">The s date.</param>
    ''' <param name="sErrMsg">The s error MSG.</param>
    ''' <returns><c>true</c> if [is date before now] [the specified s date]; otherwise, <c>false</c>.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSDateTime <br/>
    ''' <br/>
    ''' Dim obj As New BSDateTime <br/>
    ''' Dim testDate As String = DateAdd(DateInterval.Year, 1,DateTime.Now) <br/>
    ''' Dim value As Boolean = obj.ISDateBeforeNow(testDate, errOut) <br/>
    ''' Debug.Print("Date being used: {0}", testDate) <br/>
    ''' Debug.Print("Is date after today? : {0}", value) <br/>
    ''' </example>
    Public Function ISDateBeforeNow(ByVal sDate As String, Optional ByRef sErrMsg As String = "") As Boolean
        Dim bAns As Boolean = False
        Try
            Dim dd As Long = DateDiff(DateInterval.Day, CDate(sDate), Now)
            If dd = 0 Then
                bAns = False
            ElseIf dd > 0 Then
                bAns = False
            ElseIf dd < 0 Then
                bAns = True
            End If
        Catch ex As Exception
            Dim strFrom As String = "modMain"
            Dim strSubFunc As String = "ISDateBeforeNow"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            sErrMsg = sMsg & "::" & strFrom & "." & strSubFunc
        End Try
        Return bAns
    End Function
    ''' <summary>
    ''' Formats the date.
    ''' Format the date
    ''' IE: 5/5/04 will turn into 05/05/2004
    ''' Extract the elements
    ''' </summary>
    ''' <param name="sDate">The s date.</param>
    ''' <returns>System.String.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSDateTime <br/>
    ''' <br/>
    ''' Dim obj As New BSDateTime <br/>
    ''' Dim testDate As String = "2/1/2018" <br/>
    ''' Dim value As string = obj.FormatDate(testDate) <br/>
    ''' Debug.Print("Date being used: {0}", testDate) <br/>
    ''' Debug.Print("NewDate : {0}", value) <br/>
    ''' </example>
    Public Function FormatDate(ByVal sDate As String) As String
        Dim sAns As String = ""
        Dim sArray As Object
        Dim iDateLoop As Integer
        Dim ObjM As New BSOtherObjects

        sArray = Split(sDate, "/", -1, vbTextCompare)
        For iDateLoop = 0 To 1
            If Len(sArray(iDateLoop)) = 1 Then
                sAns = sAns & "0" & sArray(iDateLoop) & "/"
            Else
                sAns = sAns + sArray(iDateLoop) & "/"
            End If
        Next iDateLoop
        sAns = sAns + ObjM.Parse(sArray(2), 0, " ")
        Return sAns
    End Function
    ''' <summary>
    ''' Determines whether [is valid date] [the specified s date].
    ''' Checks to see if the value is a valid date format
    ''' </summary>
    ''' <param name="sDate">The s date.</param>
    ''' <returns><c>true</c> if [is valid date] [the specified s date]; otherwise, <c>false</c>.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSDateTime <br/>
    ''' <br/>
    ''' Dim obj As New BSDateTime <br/>
    ''' Dim testDate As String = "12/10/2018" <br/>
    ''' Dim value As Boolean = obj.isValidDate(testDate) <br/>
    ''' Debug.Print("Date being used: {0}", testDate) <br/>
    ''' Debug.Print("Is Date Valid? : {0}", value) <br/>
    ''' </example>
    Public Function isValidDate(ByVal sDate As String) As Boolean
        If Len(sDate) < 10 Then
            Return False
            Exit Function
        End If
        On Error GoTo Trouble
        Dim x As String
        x = Err.Description

        Err.Clear()

        If Not Mid(sDate, 3, 1) = "/" Then
            Return False
            Exit Function
        End If
        If Not Mid(sDate, 6, 1) = "/" Then
            Return False
            Exit Function
        End If

        Dim strDate As String
        Dim datDate As Date

        strDate = sDate

        datDate = CDate(strDate)
        Return True
        Exit Function

Trouble:
        Return False

    End Function
    ''' <summary>
    ''' convert the number of weeks into days
    ''' </summary>
    ''' <param name="iWeek">The i week.</param>
    ''' <returns>System.Int64.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSDateTime <br/>
    ''' <br/>
    ''' Dim obj As New BSDateTime <br/>
    ''' Dim testDate As Long = 10 <br/>
    ''' Dim value As string = obj.ConvertWeekToDays(testDate) <br/>
    ''' Debug.Print("Date being used: {0}", testDate) <br/>
    ''' Debug.Print("New Value : {0}", value) <br/>
    ''' </example>
    Public Function ConvertWeekToDays(ByVal iWeek As Long) As Long
        Dim lAns As Long = 0
        If iWeek = 1 Or iWeek = 0 Then
            lAns = 7
        Else
            lAns = 7 * iWeek
        End If
        Return lAns
    End Function
    ''' <summary>
    ''' convert english to dateinterval
    ''' </summary>
    ''' <param name="sValue">The s value.</param>
    ''' <returns>DateInterval.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSDateTime <br/>
    ''' <br/>
    ''' Dim obj As New BSDateTime <br/>
    ''' Dim testDate As String = "month" <br/>
    ''' Debug.Print("Converting month to DateInterval.Month to add a month to current date!") <br/>
    ''' Dim value As string = DateAdd(obj.ConvertType(testDate), 1, DateTime.Now) <br/>
    ''' Debug.Print("New Value : {0}", value) <br/>
    ''' </example>
    Public Function ConvertType(ByVal sValue As String) As DateInterval
        Dim lAns As DateInterval = DateInterval.Hour
        Select Case LCase(sValue)
            Case "day"
                lAns = DateInterval.Day
            Case "hour"
                lAns = DateInterval.Hour
            Case "minute"
                lAns = DateInterval.Minute
            Case "month"
                lAns = DateInterval.Month
        End Select
        Return lAns
    End Function
    ''' <summary>
    ''' SQLs the format date. Formats the date into an SQL Friendly date, used for SQL Commands
    ''' </summary>
    ''' <param name="myDate">My date.</param>
    ''' <returns>System.String.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSDateTime <br/>
    ''' <br/>
    ''' Dim obj As New BSDateTime <br/>
    ''' Dim testDate As String = "2/1/2018" <br/>
    ''' Dim value As string = obj.SQLFormatDate(testDate) <br/>
    ''' Debug.Print("Date being used: {0}", testDate) <br/>
    ''' Debug.Print("NewDate : {0}", value) <br/>
    ''' </example>
    Public Function SQLFormatDate(ByVal myDate As String) As String
        myDate = FormatDateTime(myDate, DateFormat.ShortDate)
        Dim strSplit As Array = Split(myDate, "/")
        Dim stryear As String = strSplit(2)
        Dim strmonth As String = strSplit(0)
        Dim strday As String = strSplit(1)
        If Len(strmonth) = 1 Then strmonth = "0" & strmonth
        If Len(strday) = 1 Then strday = "0" & strday
        Dim sAns As String = stryear & "-" & strmonth & "-" & strday
        Return sAns
    End Function
End Class
