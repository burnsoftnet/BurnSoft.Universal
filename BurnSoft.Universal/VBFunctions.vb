Imports System.Runtime.Remoting.Messaging

''' <summary>
''' Functions that are availabel and make life easier in bn/vb.net but are not a part of c#
''' </summary>
Public Class VbFunctions
    ''' <summary>
    ''' Checks to see if the Value is Numeric or not, uses vb function IsNumeric
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    Public Shared Function ValueIsnumeric(value As Object) As Boolean
        Return IsNumeric(value)
    End Function
    ''' <summary>
    ''' Gets the date difference betweek two dates, or uses vb function datediff
    ''' </summary>
    ''' <param name="startDate">The start date.</param>
    ''' <param name="endDate">The end date.</param>
    ''' <param name="interval">The interval.</param>
    ''' <returns>System.Int64.</returns>
    Public Shared Function GetDateDiff(startDate As Date, endDate As Date, interval As DateInterval) As Long
        Return DateDiff(interval, startDate, endDate)
    End Function
    ''' <summary>
    ''' Determines whether [is a date] [the specified value].
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns><c>true</c> if [is a date] [the specified value]; otherwise, <c>false</c>.</returns>
    Public Shared Function IsADate(value As Object) As Boolean
            Return IsDate(value)
    End Function
    ''' <summary>
    ''' Determines whether [is an array] [the specified value].
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns><c>true</c> if [is an array] [the specified value]; otherwise, <c>false</c>.</returns>
    Public Shared Function IsAnArray(value As Object) As Boolean
        Return IsArray(value)
    End Function
End Class
