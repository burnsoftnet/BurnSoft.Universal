Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BurnSoft.Universal

' ReSharper disable once InconsistentNaming
<TestClass()> Public Class BSProcessInfoTests
    Private pid As String
    Private errOut As String
    <TestInitialize()> Public Sub Init()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Dim processCount As Integer = 0
        obj.ProcessExists(Settings.ProcessName, pid, processCount)

    End Sub
    <TestMethod(), TestCategory("Process Information")> Public Sub GetProccessHandleCount()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProccessHandleCount(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessThreadCount()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessThreadCount(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessTerminationDate()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessTerminationDate(pid, errOut)
        If Not IsDBNull(value) Then
            value = "process still active!"
        End If
        General.HasValue(value, errOut)
    End Sub
    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessCaption()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessCaption(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessCommandLine()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessCommandLine(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessCreationDate()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessCreationDate(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessDescription()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessDescription(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessExecutablePath()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessExecutablePath(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessExecutionState()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessExecutionState(pid, errOut)
        If Not IsDBNull(value) Then
            value = "process still active!"
        End If
        General.HasValue(value, errOut)
    End Sub

    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessPageFaults()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessPageFaults(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessPageFileUsage()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessPageFileUsage(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessParentProcessId()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessParentProcessId(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessPeakPageFileUsage()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessPeakPageFileUsage(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessPeakVirtualSize()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessPeakVirtualSize(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessPeakWorkingSetSize()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessPeakWorkingSetSize(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessPrivatePageCount()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessPrivatePageCount(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessSessionId()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessSessionId(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessUserModeTime()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessUserModeTime(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessVirtualSize()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessVirtualSize(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessWorkingSetSize()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using PID {0}", pid)
        Dim value As String = obj.GetProcessWorkingSetSize(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod(), TestCategory("Process Information")> Public Sub ProcessExists()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Dim processCount As Integer = 0
        Dim didPass As Boolean = obj.ProcessExists(Settings.ProcessName, pid, processCount)
        Debug.Print("Using PID {0}", pid)
        Debug.Print("Process Count: {0}", processCount)
        General.HasValue(didPass, errOut)
    End Sub
    <TestMethod(), TestCategory("Process Information")> Public Sub ExactProcessExists()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Dim processCount As Integer = 0
        Dim didPass As Boolean = obj.ExactProcessExists(Settings.ProcessName, processCount)
        Debug.Print("Process Count: {0}", processCount)
        General.HasValue(didPass, errOut)
    End Sub

    <TestMethod(), TestCategory("Process Information")> Public Sub ProcessExists2()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Dim processCount As Integer = 0
        Dim didPass As Boolean = obj.ProcessExists(Settings.ProcessName, Settings.CommandLineSearch, pid, processCount)
        Debug.Print("Using PID {0}", pid)
        Debug.Print("Process Count: {0}", processCount)
        General.HasValue(didPass, errOut)
    End Sub

    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessMemoryUseage()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using Process {0}", Settings.ProcessName)
        Dim value As String = obj.GetProcessMemoryUseage(Settings.ProcessName)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod(), TestCategory("Process Information")> Public Sub GetProcessCpuTime()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using Process {0}", Settings.ProcessName)
        Dim newValue As Double = 0
        Dim value As String = obj.GetProcessCpuTime(Settings.ProcessName, 1, 0, newValue)
        Debug.Print("New Value: {0}", newValue)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod(), TestCategory("Process Information")> Public Sub GetCpuProcessStarting()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Debug.Print("Using Process {0}", Settings.ProcessName)
        Dim newValue As Double = 0
        Dim value As String = obj.GetCpuProcessStarting(Settings.ProcessName, 1, newValue)
        Debug.Print("New Value: {0}", newValue)
        General.HasValue(value, errOut)
    End Sub

    '<TestMethod()> Public Sub ()
    '   Dim obj As BSProcessInfo = New BSProcessInfo()
    '   Debug.Print("Using PID {0}", pid)
    '   Dim value as String = obj.(pid, errOut)
    '   General.HasValue(value, errOut)
    'End Sub

End Class