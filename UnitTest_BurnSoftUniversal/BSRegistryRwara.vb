Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BurnSoft.Universal
' ReSharper disable once InconsistentNaming
<TestClass()> Public Class BSRegistryRwara

    <TestMethod(), TestCategory("Registry")> Public Sub DefaultRegPath()
        Dim obj As BSRegistry = New BSRegistry()
        Dim value As String = obj.DefaultRegPath
        General.HasValue(value)
    End Sub
    <TestMethod(), TestCategory("Registry")> Public Sub CreateSubKey()
        Dim errOut As String = ""
        Dim obj As BSRegistry = New BSRegistry()
        obj.CreateSubKey(Settings.RegSubkey, errOut)
        Dim didPass As Boolean = (errOut.Length = 0)
        General.HasValue(didPass, errOut)
    End Sub

    <TestMethod(), TestCategory("Registry")> Public Sub RegSubKeyExists()
        Dim errOut As String = ""
        Dim obj As BSRegistry = New BSRegistry()
        Dim didPass As Boolean = obj.RegSubKeyExists(Settings.RegSubkey, errOut)
        General.HasValue(didPass, errOut)
    End Sub
    <TestMethod(), TestCategory("Registry")> Public Sub GetRegSubKeyValue()
        Dim errOut As String = ""
        Dim obj As BSRegistry = New BSRegistry()
        Dim value As String = obj.GetRegSubKeyValue(Settings.RegSubkey, Settings.RegSubkeyName, "")
        General.HasValue(value)
    End Sub

    <TestMethod(), TestCategory("Registry")> Public Sub CreateSubKeyRegValue()
        Dim errOut As String = ""
        Dim obj As BSRegistry = New BSRegistry()
        Dim didPass As Boolean = obj.SetRegSubKeyValue(Settings.RegSubkey, Settings.RegSubkeyName, Settings.RegSubkeyValue, "", errOut)
        Debug.Print("Wrote value {0} to HCLM\{1}\{2}", obj.GetRegSubKeyValue(Settings.RegSubkey, Settings.RegSubkeyName, ""), Settings.RegSubkey, Settings.RegSubkeyName)
        General.HasValue(didPass, errOut)
    End Sub

    <TestMethod(), TestCategory("Registry")> Public Sub Enum_Registry_Entries()
        Dim errOut As String = ""
        Dim regKey As String = "SYSTEM\CurrentControlSet\Services"
        Dim regCollection As Collection = BSRegistry.Enum_Registry_Entries(regKey, "DisplayName", errOut)

        For x = 1 To regCollection.Count - 1
            Dim sValue As String = regCollection.Item(x).ToString()
            Debug.Print(sValue)
        Next
        Dim didPass As Boolean = (regCollection.Count > 0)

        General.HasValue(didPass)
    End Sub

    '<TestMethod()> Public Sub ()
    'End Sub
End Class