Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BurnSoft.Universal

' ReSharper disable once InconsistentNaming
<TestClass()> Public Class BSSystemInfoTest

    <TestMethod(), TestCategory("System Info")> Public Sub GetPhysicalMemory()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As String = obj.GetPhysicalMemory()
        General.HasValue(value)
    End Sub

    <TestMethod(), TestCategory("System Info")> Public Sub GetCpuSpeed()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As Long = obj.GetCpuSpeed()
        General.HasValue(value)
    End Sub

    <TestMethod(), TestCategory("System Info")> Public Sub GetCpuDescription()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As String = obj.GetCpuDescription()
        General.HasValue(value)
    End Sub

    <TestMethod(), TestCategory("System Info")> Public Sub GetCpuName()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As String = obj.GetCpuName()
        General.HasValue(value)
    End Sub

    <TestMethod(), TestCategory("System Info")> Public Sub GetUserName()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As String = obj.GetUserName()
        General.HasValue(value)
    End Sub

    <TestMethod(), TestCategory("System Info")> Public Sub GetDomainName()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As String = obj.GetDomainName()
        General.HasValue(value)
    End Sub
    <TestMethod(), TestCategory("System Info")> Public Sub IsOnNetWork()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As Boolean = obj.IsOnNetWork()
        General.HasValue(value)
    End Sub

    <TestMethod(), TestCategory("System Info")> Public Sub GetComputerName()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As String = obj.GetComputerName()
        General.HasValue(value)
    End Sub

    <TestMethod(), TestCategory("System Info")> Public Sub GetUsername2()
        Dim obj As BSSystemInfo = New BSSystemInfo()
        Dim value As String = obj.GetComputerName()
        General.HasValue(value)
    End Sub

End Class