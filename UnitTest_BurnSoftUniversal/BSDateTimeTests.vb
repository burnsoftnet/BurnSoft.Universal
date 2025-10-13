Imports BurnSoft.Universal
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class BSDateTimeTests
    Private errOut As String
    <TestMethod(), TestCategory("Date and Time")> Public Sub ISDatePastNow()
        Dim obj As New BSDateTime
        Dim testDate As String = "12/10/2018"
        Dim value As Boolean = obj.IsDatePastNow(testDate, errOut)
        Debug.Print("Date being used: {0}", testDate)
        Debug.Print("Is Past Due: {0}", value)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod(), TestCategory("Date and Time")> Public Sub ISDateNow()
        Dim obj As New BSDateTime
        Dim testDate As String = DateTime.Now
        Dim value As Boolean = obj.ISDateNow(testDate, errOut)
        Debug.Print("Date being used: {0}", testDate)
        Debug.Print("Is today the day: {0}", value)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod(), TestCategory("Date and Time")> Public Sub ISDateBeforeNow()
        Dim obj As New BSDateTime
        Dim testDate As String = DateAdd(DateInterval.Year, 1, DateTime.Now)
        Dim value As Boolean = obj.ISDateBeforeNow(testDate, errOut)
        Debug.Print("Date being used: {0}", testDate)
        Debug.Print("Is date after today? : {0}", value)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod(), TestCategory("Date and Time")> Public Sub isValidDate()
        Dim obj As New BSDateTime
        Dim testDate As String = "12/10/2018"
        Dim value As Boolean = obj.isValidDate(testDate)
        Debug.Print("Date being used: {0}", testDate)
        Debug.Print("Is Date Valid? : {0}", value)
        General.HasValue(value)
    End Sub
    <TestMethod(), TestCategory("Date and Time")> Public Sub FormatDate()
        Dim obj As New BSDateTime
        Dim testDate As String = "2/1/2018"
        Dim value As String = obj.FormatDate(testDate)
        Debug.Print("Date being used: {0}", testDate)
        Debug.Print("NewDate : {0}", value)
        General.HasValue(value)
    End Sub
    <TestMethod(), TestCategory("Date and Time")> Public Sub ConvertWeekToDays()
        Dim obj As New BSDateTime
        Dim testDate As Long = 10
        Dim value As String = obj.ConvertWeekToDays(testDate)
        Debug.Print("Date being used: {0}", testDate)
        Debug.Print("New Value : {0}", value)
        General.HasValue(value)
    End Sub
    <TestMethod(), TestCategory("Date and Time")> Public Sub ConvertType()
        Dim obj As New BSDateTime
        Dim testDate As String = "month"
        Debug.Print("Converting month to DateInterval.Month to add a month to current date!")
        Dim value As String = DateAdd(obj.ConvertType(testDate), 1, DateTime.Now)
        Debug.Print("New Value : {0}", value)
        General.HasValue(value)
    End Sub
    <TestMethod(), TestCategory("Date and Time")> Public Sub SQLFormatDate()
        Dim obj As New BSDateTime
        Dim testDate As String = "2/1/2018"
        Dim value As String = obj.SQLFormatDate(testDate)
        Debug.Print("Date being used: {0}", testDate)
        Debug.Print("NewDate : {0}", value)
        General.HasValue(value)
    End Sub
End Class