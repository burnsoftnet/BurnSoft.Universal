'-------------------------------------------
' Created By BurnSoft
' www.burnsoft.net
'-------------------------------------------
Public Class BSMath
    ''' <summary>
    ''' Function Used for Out of 100 Calculations
    ''' its more of a reverse round, where 0.270 would be 1 and 99.678 would be 99
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RoundValueNotZero(value As Double) As Double
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
    ''' <summary>
    ''' Get the standard deviation from an array of numbers
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    Public Shared Function GetStandardDeviation(data As List(Of Double)) As Double
        Dim dAns As Double = 0
        Dim mean As Double = data.Average()
        Dim avgList As New List(Of Double)
        Dim listAvg As Double

        For Each value As Double In data
            avgList.Add(Math.Pow(mean - value, 2))
        Next

        listAvg = avgList.Average()
        dAns = Math.Sqrt(listAvg)
        Return dAns
    End Function
    ''' <summary>
    ''' Get the Max difference between the highest and lowest number in an array of numbers
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    Public Shared Function GetExtremeSpread(data As List(Of Double)) As Double
        Dim dAns As Double = 0
        Dim dHighest As Double = 0
        Dim dLowest As Double = 0
        Dim i As Integer = 0
        data.Sort()
        For Each value As Double In data
            If i = 0 Then
                dLowest = value
            ElseIf i = (data.Count - 1) Then
                dHighest = value
            End If
            i += 1
        Next
        dAns = dHighest - dLowest
        Return dAns
    End Function
    ''' <summary>
    ''' Mostly converts the double value to the dollar format with two decimal points
    ''' and rounds up the 3 decimal.
    ''' </summary>
    ''' <param name="dValue"></param>
    ''' <returns></returns>
    Public Shared Function ConvertToDollars(ByVal dValue As Double) As Double
        Dim dAns As Double = 0
        dAns = Math.Round(dValue, 2)
        Return dAns
    End Function
    ''' <summary>
    ''' get the angle of Cosine
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    Public Shared Function GetSin(value As Double) As Double
        Dim angle As Double = 0
        Try
            angle = System.Math.Asin(value)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        Return angle
    End Function
    ''' <summary>
    ''' get the angle of Tangent
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    Public Shared Function GetCos(value As Double) As Double
        Dim angle As Double = 0
        Try
            angle = System.Math.Atan(value)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
            
        Return angle
    End Function
    ''' <summary>
    ''' get the Tangent of Two Values
    ''' </summary>
    ''' <param name="y">The y.</param>
    ''' <param name="x">The x.</param>
    ''' <returns>System.Double.</returns>
    Public Shared Function GetTangentOf(y As Double, x As Double) As Double
        Dim angle As Double
        angle = System.Math.Atan2(y, x)
        Return angle
    End Function
End Class
