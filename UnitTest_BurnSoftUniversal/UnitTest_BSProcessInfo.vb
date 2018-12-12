Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BurnSoft.Universal

' ReSharper disable once InconsistentNaming
<TestClass()> Public Class UnitTest_BSProcessInfo
    Private pid As String 
    Private errOut As String
    <TestInitialize()> Public Sub Init()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Dim processCount As Integer = 0
        obj.ProcessExists(Settings.ProcessName,pid, processCount)

    End Sub
    <TestMethod()> Public Sub TestMethod_GetProccessHandleCount()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProccessHandleCount(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetProcessThreadCount()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessThreadCount(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetProcessTerminationDate()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessTerminationDate(pid, errOut)
        If Not IsDBNull(value) Then
            value = "process still active!"
        End If
        General.HasValue(value, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetProcessCaption()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value as String = obj.GetProcessCaption(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetProcessCommandLine()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value as String = obj.GetProcessCommandLine(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetProcessCreationDate()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value as String = obj.GetProcessCreationDate(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetProcessDescription()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value as String = obj.GetProcessDescription(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetProcessExecutablePath()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value as String = obj.GetProcessExecutablePath(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetProcessExecutionState()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value as String = obj.GetProcessExecutionState(pid, errOut)
        If Not IsDBNull(value) Then
            value = "process still active!"
        End If
        General.HasValue(value, errOut)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetProcessPageFaults()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value as String = obj.GetProcessPageFaults(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetProcessPageFileUsage()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value as String = obj.GetProcessPageFileUsage(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetProcessParentProcessId()
       Dim obj As BSProcessInfo = New BSProcessInfo()
       Debug.Print("Using PID {0}", pid)
       Dim value as String = obj.GetProcessParentProcessId(pid, errOut)
       General.HasValue(value, errOut)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetProcessPeakPageFileUsage()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value as String = obj.GetProcessPeakPageFileUsage(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetProcessPeakVirtualSize()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value as String = obj.GetProcessPeakVirtualSize(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetProcessPeakWorkingSetSize()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value as String = obj.GetProcessPeakWorkingSetSize(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetProcessPrivatePageCount()
       Dim obj As BSProcessInfo = New BSProcessInfo()
       Debug.Print("Using PID {0}", pid)
       Dim value as String = obj.GetProcessPrivatePageCount(pid, errOut)
       General.HasValue(value, errOut)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetProcessSessionId()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value as String = obj.GetProcessSessionId(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetProcessUserModeTime()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value as String = obj.GetProcessUserModeTime(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetProcessVirtualSize()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value as String = obj.GetProcessVirtualSize(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetProcessWorkingSetSize()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value as String = obj.GetProcessWorkingSetSize(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    
    <TestMethod()> Public Sub TestMethod_ProcessExists()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Dim processCount As Integer = 0
        Dim didPass As Boolean = obj.ProcessExists(Settings.ProcessName,pid, processCount)
        Debug.Print("Using PID {0}", pid)
        Debug.Print("Process Count: {0}", processCount)
        General.HasValue(didPass, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_ExactProcessExists()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Dim processCount As Integer = 0
        Dim didPass As Boolean = obj.ExactProcessExists(Settings.ProcessName, processCount)
        Debug.Print("Process Count: {0}", processCount)
        General.HasValue(didPass, errOut)
    End Sub

    <TestMethod()> Public Sub TestMethod_ProcessExists2()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Dim processCount As Integer = 0
        Dim didPass As Boolean = obj.ProcessExists(Settings.ProcessName,Settings.CommandLineSearch,pid, processCount)
        Debug.Print("Using PID {0}", pid)
        Debug.Print("Process Count: {0}", processCount)
        General.HasValue(didPass, errOut)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetProcessMemoryUseage()
       Dim obj As BSProcessInfo = New BSProcessInfo()
       Debug.Print("Using Process {0}", Settings.ProcessName)
       Dim value as String = obj.GetProcessMemoryUseage(Settings.ProcessName)
       General.HasValue(value, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetProcessCpuTime()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using Process {0}", Settings.ProcessName)
        Dim newValue as Double = 0
        Dim value as String = obj.GetProcessCpuTime(Settings.ProcessName, 1, 0, newValue)
        Debug.Print("New Value: {0}", newValue)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetCpuProcessStarting()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using Process {0}", Settings.ProcessName)
        Dim newValue as Double = 0
        Dim value as String = obj.GetCpuProcessStarting(Settings.ProcessName, 1, newValue)
        Debug.Print("New Value: {0}", newValue)
        General.HasValue(value, errOut)
    End Sub

    '<TestMethod()> Public Sub TestMethod_()
    '   Dim obj As BSProcessInfo = New BSProcessInfo()
    '   Debug.Print("Using PID {0}", pid)
    '   Dim value as String = obj.(pid, errOut)
    '   General.HasValue(value, errOut)
    'End Sub

End Class