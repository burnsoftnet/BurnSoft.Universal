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
        obj.CreateSubKey(Settings.RegSubkey, errOut)
        Dim didPass As Boolean = (errOut.Length = 0)
        General.HasValue(didPass, errOut)
    End Sub

    <TestMethod()> Public Sub TestMethod_RegSubKeyExists()
        Dim errOut As String = ""
        Dim obj As BSRegistry = New BSRegistry()
        Dim didPass As Boolean = obj.RegSubKeyExists(Settings.RegSubkey, errOut)
        General.HasValue(didPass, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetRegSubKeyValue()
        'TODO Need to finish
        Dim errOut As String = ""
        Dim obj As BSRegistry = New BSRegistry()
        Dim value As string = obj.GetRegSubKeyValue(Settings.RegSubkey, Settings.RegSubkeyName,"")
        General.HasValue(value)
    End Sub
    
    <TestMethod()> Public Sub TestMethod_SetRegSubKeyValue()
        Dim errOut As String = ""
        Dim obj As BSRegistry = New BSRegistry()
        Dim didPass As Boolean = obj.SetRegSubKeyValue(Settings.RegSubkey,Settings.RegSubkeyName,Settings.RegSubkeyValue,"", errOut)
        Debug.Print("Wrote value {0} to HCLM\{1}\{2}", obj.GetRegSubKeyValue(Settings.RegSubkey, Settings.RegSubkeyName,""), Settings.RegSubkey, Settings.RegSubkeyName)
        General.HasValue(didPass, errOut)
    End Sub
    '<TestMethod()> Public Sub TestMethod_()
    'End Sub
End Class