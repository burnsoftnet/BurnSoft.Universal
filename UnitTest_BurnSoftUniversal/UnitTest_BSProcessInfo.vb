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
        Dim value As String = obj.GetProccessHandleCount(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetProcessThreadCount()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Dim value As String = obj.GetProcessThreadCount(pid, errOut)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetProcessTerminationDate()
        Dim obj As BSProcessInfo = New BSProcessInfo()
        Dim value As String = obj.GetProcessTerminationDate(pid, errOut)
        General.HasValue(value, errOut)
    End Sub

    '<TestMethod()> Public Sub TestMethod_()
    'Dim obj As BSProcessInfo = New BSProcessInfo()
    'End Sub

End Class