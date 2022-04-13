''' <summary>
''' Functions that are availabel and make life easier in bn/vb.net but are not a part of c#
''' </summary>
Public Class VbFunctions
    ''' <summary>
    ''' Checks to see if the Value is Numeric or not
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    Public Shared Function ValueIsnumeric(value As Object) As Boolean
        Return IsNumeric(value)
    End Function
End Class
