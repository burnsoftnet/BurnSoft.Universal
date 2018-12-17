Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BurnSoft.Universal

<TestClass()> Public Class UnitTest_BSMath

    <TestMethod()> Public Sub TestMethod_RoundValueNotZero()
        Dim rawValue As Double = 0.270
        Dim expectedValue As Double = 1
        Dim results As Double = BSMath.RoundValueNotZero(rawValue)
        Debug.Print("rawValue {0}", rawValue)
        Debug.Print("Expected Value {0}",expectedValue)
        Debug.Print("Returned Value {0}", results)
        Dim didPass As Boolean = False
        if (results = expectedValue) Then didPass = True
        General.HasValue(didPass)
    End Sub

    <TestMethod()> Public Sub TestMethod_ConvertToDollars()
        Dim rawValue As Double = 1.272344
        Dim expectedValue As Double = 1.27
        Dim results As Double = BSMath.ConvertToDollars(rawValue)
        Debug.Print("rawValue {0}", rawValue)
        Debug.Print("Expected Value {0}",expectedValue)
        Debug.Print("Returned Value {0}", results)
        Dim didPass As Boolean = False
        if (results = expectedValue) Then didPass = True
        General.HasValue(didPass)
    End Sub

    <TestMethod()> Public Sub TestMethod_Sin()
        Dim rawValue As Double = 1
        Dim results = BSMath.GetSin(rawValue)
        Debug.Print("rawValue {0}", rawValue)
        Debug.Print("Returned Value {0}", results)
        General.HasValue(results)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetCos()
        Dim rawValue As Double = 1.272344
        Dim results As Double = BSMath.GetCos(rawValue)
        Debug.Print("rawValue {0}", rawValue)
        Debug.Print("Returned Value {0}", results)
        General.HasValue(results)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetTangentOf()
        Dim x As Double = 60
        Dim y As Double = 45
        Dim results As Double = BSMath.GetTangentOf(y,x)
        Debug.Print("x Value {0}", x)
        Debug.Print("y Value {0}", y)
        Debug.Print("Returned Value {0}", results)
        General.HasValue(results)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetStandardDeviation()
        Dim data as List(Of Double) = New List(Of Double)()
        data.Add(970)
        data.Add(971)
        data.Add(975)
        data.Add(978)
        data.Add(979)
        data.Add(960)
        Dim results As Double = BSMath.GetStandardDeviation(data)
        Debug.Print("Returned Value {0}", results)
        General.HasValue(results)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetExtremeSpread()
        Dim data as List(Of Double) = New List(Of Double)()
        data.Add(970)
        data.Add(971)
        data.Add(975)
        data.Add(978)
        data.Add(979)
        data.Add(960)
        Dim results As Double = BSMath.GetExtremeSpread(data)
        Debug.Print("Returned Value {0}", results)
        General.HasValue(results)
    End Sub
End Class