Public Class BSMath
    ''' <summary>
    ''' Function Used for Out of 100 Calculations
    ''' its more of a reverse round, where 0.270 would be 1 and 99.678 would be 99
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RoundValueNotZero(Value As Double) As Double
        Dim dAns As Double = 0.0
        Dim DecValue As Long = 0
        If Value > 0.0 Then
            If CInt(Value) > 0 Then
                DecValue = Math.Round(CDbl(Split(Value, ".")(1)), 1, MidpointRounding.ToEven)
                If DecValue < 5 Then
                    dAns = Math.Ceiling(Value)
                Else
                    dAns = Math.Floor(Value)
                End If
            Else
                dAns = Math.Ceiling(Value)
            End If
        Else
            dAns = Math.Floor(Value)
        End If
        Return dAns
    End Function
End Class
