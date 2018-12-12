Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BurnSoft.Universal

' ReSharper disable once InconsistentNaming
<TestClass()> Public Class UnitTest_BSSystemInfo

    <TestMethod()> Public Sub TestMethod_GetPhysicalMemory()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As String = obj.GetPhysicalMemory()
        General.HasValue(value)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetCpuSpeed()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As long = obj.GetCpuSpeed()
        General.HasValue(value)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetCpuDescription()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As string = obj.GetCpuDescription()
        General.HasValue(value)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetCpuName()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As string = obj.GetCpuName()
        General.HasValue(value)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetUserName()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As string = obj.GetUserName()
        General.HasValue(value)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetDomainName()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As string = obj.GetDomainName()
        General.HasValue(value)
    End Sub
    <TestMethod()> Public Sub TestMethod_IsOnNetWork()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As Boolean = obj.IsOnNetWork()
        General.HasValue(value)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetComputerName()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As string = obj.GetComputerName()
        General.HasValue(value)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetUsername2()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As string = obj.GetComputerName()
        General.HasValue(value)
    End Sub
    <TestMethod()> Public Sub TestMethod_ProcessExists()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim processCount as Integer = 0
        Dim pid As String = ""
        Debug.Print("Looking for Process: {0}", Settings.ProcessName)
        Dim value As Boolean = obj.ProcessExists(Settings.ProcessName, processCount)
        If value Then
            Debug.Print("Process {0} was found with {1} instances.", Settings.ProcessName, processCount)
        Else 
            Debug.Print("No Process Found in system!")
        End If

        General.HasValue(value)
    End Sub

    <TestMethod()> Public Sub TestMethod_ProcessExists2()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim processCount as Integer = 0
        Dim pid As String = ""
        Debug.Print("Looking for Process: {0}", Settings.ProcessName)
        Dim value As Boolean = obj.ProcessExists(Settings.ProcessName, Settings.CommandLineSearch, pid, processCount)
        If value Then
            Debug.Print("Process {0} was found with {1} instances. and PIDS: {2}", Settings.ProcessName, processCount, pid)
        Else 
            Debug.Print("No Process Found in system!")
        End If

        General.HasValue(value)
    End Sub
End Class