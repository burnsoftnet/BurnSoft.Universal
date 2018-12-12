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

    '<TestMethod()> Public Sub TestMethod_()
    '   Dim obj As BSProcessInfo = New BSProcessInfo()
    '   Debug.Print("Using PID {0}", pid)
    '   Dim value as String = obj.(pid, errOut)
    '   General.HasValue(value, errOut)
    'End Sub

End Class