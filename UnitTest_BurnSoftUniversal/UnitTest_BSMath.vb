Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BurnSoft.Universal

<TestClass()> Public Class UnitTest_BSMath

    <TestMethod()> Public Sub TestMethod_RoundValueNotZero()
        Dim rawValue As Double = 0.270
        Dim expectedValue As Double = 1
        Dim results = BSMath.RoundValueNotZero(rawValue)
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
        Dim results = BSMath.ConvertToDollars(rawValue)
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
        Dim results = BSMath.GetCos(rawValue)
        Debug.Print("rawValue {0}", rawValue)
        Debug.Print("Returned Value {0}", results)
        General.HasValue(results)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetTangentOf()
        Dim x As Double = 60
        Dim y As Double = 45
        Dim results = BSMath.GetTangentOf(y,x)
        Debug.Print("x Value {0}", x)
        Debug.Print("y Value {0}", y)
        Debug.Print("Returned Value {0}", results)
        General.HasValue(results)
    End Sub
End Class