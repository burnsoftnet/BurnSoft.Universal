Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BurnSoft.Universal

' ReSharper disable once InconsistentNaming
<TestClass()> Public Class UnitTest_BSOtherObjects

    <TestMethod()> Public Sub TestMethod_StringCompairMatch()
        Dim obj As New BSOtherObjects
        Dim didPass As Boolean = obj.StringCompare("test","test")
        If didPass Then 
            Debug.Print("Strings Matched!")
        Else 
            Debug.Print("Strings Didn't Matched!")
        End If
        General.HasValue(didPass)
    End Sub
    <TestMethod()> Public Sub TestMethod_StringCompairMisMatch()
        Dim obj As New BSOtherObjects
        Dim didPass As Boolean = obj.StringCompare("Test","test")
        If didPass Then 
            Debug.Print("Strings Matched!")
        Else 
            Debug.Print("Strings Didn't Matched!")
            didPass = true
        End If
        General.HasValue(didPass)
    End Sub
    '<TestMethod()> Public Sub TestMethod_()
    'End Sub
End Class