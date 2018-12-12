Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BurnSoft.Universal
' ReSharper disable once InconsistentNaming
<TestClass()> Public Class UnitTest_BSRegistry

    <TestMethod()> Public Sub TestMethod_DefaultRegPath()
        Dim obj As BSRegistry = New BSRegistry()
        Dim value as String = obj.DefaultRegPath
        General.HasValue(value)
    End Sub
    <TestMethod()> Public Sub TestMethod_CreateSubKey()
        Dim errOut As String = ""
        Dim obj As BSRegistry = New BSRegistry()
        obj.CreateSubKey(Settings.REG_SUBKEY, errOut)
        Dim didPass As Boolean = (errOut.Length = 0)
        General.HasValue(didPass, errOut)
    End Sub

    <TestMethod()> Public Sub TestMethod_RegSubKeyExists()
        Dim errOut As String = ""
        Dim obj As BSRegistry = New BSRegistry()
        Dim didPass As Boolean = obj.RegSubKeyExists(Settings.REG_SUBKEY, errOut)
        General.HasValue(didPass, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetRegSubKeyValue()
        'TODO Need to finish
        General.HasValue(True)
    End Sub
    '<TestMethod()> Public Sub TestMethod_()
    'End Sub
End Class