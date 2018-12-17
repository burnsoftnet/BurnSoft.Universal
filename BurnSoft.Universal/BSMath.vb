'-------------------------------------------
' Created By BurnSoft
' www.burnsoft.net
'-------------------------------------------
''' <summary>
''' Class BSMath.  General Math functions to simplify data manipulations 
''' </summary>
''' <example>
''' Import BurnSoft.Universal
''' </example>
Public Class BSMath
    ''' <summary>
    ''' Function Used for Out of 100 Calculations
    ''' its more of a reverse round, where 0.270 would be 1 and 99.678 would be 99
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns>System.Double.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSMath <br/>
    ''' <br/>
    ''' Dim rawValue As Double = 0.270 <br/>
    ''' Dim expectedValue As Double = 1 <br/>
    ''' Dim results As Double = BSMath.RoundValueNotZero(rawValue) <br/>
    ''' Debug.Print("rawValue {0}", rawValue) <br/>
    ''' Debug.Print("Expected Value {0}",expectedValue) <br/>
    ''' Debug.Print("Returned Value {0}", results) <br/>
    ''' </example>
    Public Shared Function RoundValueNotZero(value As Double) As Double
        Dim dAns As Double = 0.0
        Dim decValue As Long = 0
        If Value > 0.0 Then
            If CInt(Value) > 0 Then
                decValue = Math.Round(CDbl(Split(Value, ".")(1)), 1, MidpointRounding.ToEven)
                If decValue < 5 Then
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
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSMath <br/>
    ''' <br/>
    ''' Dim data as List(Of Double) = New List(Of Double)() <br/>
    ''' data.Add(970) <br/>
    ''' data.Add(971) <br/>
    ''' data.Add(975) <br/>
    ''' data.Add(978) <br/>
    ''' data.Add(979) <br/>
    ''' data.Add(960) <br/>
    ''' Dim results As Double = BSMath.GetStandardDeviation(data) <br/>
    ''' </example>
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
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSMath <br/>
    ''' <br/>
    ''' Dim data as List(Of Double) = New List(Of Double)() <br/>
    ''' data.Add(970) <br/>
    ''' data.Add(971) <br/>
    ''' data.Add(975) <br/>
    ''' data.Add(978) <br/>
    ''' data.Add(979) <br/>
    ''' data.Add(960) <br/>
    ''' Dim results As Double = BSMath.GetExtremeSpread(data) <br/>
    ''' </example>
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
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSMath <br/>
    ''' <br/>
    ''' Dim rawValue As Double = 1.272344 <br/>
    ''' Dim expectedValue As Double = 1.27 <br/>
    ''' Dim results As Double = BSMath.ConvertToDollars(rawValue) <br/>
    ''' Debug.Print("rawValue {0}", rawValue) <br/>
    ''' Debug.Print("Expected Value {0}",expectedValue) <br/>
    ''' Debug.Print("Returned Value {0}", results) <br/>
    ''' </example>
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
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSMath <br/>
    ''' <br/>
    ''' Dim rawValue As Double = 1 <br/>
    ''' Dim results = BSMath.GetSin(rawValue) <br/>
    ''' Debug.Print("rawValue {0}", rawValue) <br/>
    ''' Debug.Print("Returned Value {0}", results) <br/>
    ''' </example>
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
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSMath <br/>
    ''' <br/>
    ''' Dim rawValue As Double = 1.272344 <br/>
    ''' Dim results As Double = BSMath.GetCos(rawValue) <br/>
    ''' Debug.Print("rawValue {0}", rawValue) <br/>
    ''' Debug.Print("Returned Value {0}", results) <br/>
    ''' </example>
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
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSMath <br/>
    ''' <br/>
    ''' Dim x As Double = 60 <br/>
    ''' Dim y As Double = 45 <br/>
    ''' Dim results As Double = BSMath.GetTangentOf(y,x) <br/>
    ''' Debug.Print("x Value {0}", x) <br/>
    ''' Debug.Print("y Value {0}", y) <br/>
    ''' Debug.Print("Returned Value {0}", results) <br/>
    ''' </example>
    Public Shared Function GetTangentOf(y As Double, x As Double) As Double
        Dim angle As Double
        angle = System.Math.Atan2(y, x)
        Return angle
    End Function
End Class
