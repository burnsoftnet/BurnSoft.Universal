Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BurnSoft.Universal
<TestClass()> Public Class UnitTest_BSNetwork
    Private Dim errOut As String
    <TestMethod()> Public Sub TestMethod_DeviceIsUp()
        Dim ipAddress As String = "127.0.0.1"
        Dim hostName as String = ""
        Dim lBytes As Long
        Dim lTTL As Long
        Dim lrTrip as Long
        Dim value As Boolean = BSNetwork.DeviceIsUp(hostName, ipAddress, lBytes, lrTrip, lTTL,,errOut)
        Debug.Print("Pinging Device {0}",ipAddress)
        Debug.Print("Bytes={0}",lBytes)
        Debug.Print("Trip={0}",lrTrip)
        Debug.Print("TTL={0}", lTTL)
        Debug.Print("Returned Value is {0}", value)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod()> Public Sub TestMethod_PortIsUPTCP()
        Dim ipAddress As String = "127.0.0.1"
        Dim port As String = "1488"
        Dim value As Boolean = BSNetwork.PortIsUP(ipAddress, port, BSNetwork.IPProtocolType.TCP,errOut)
        Debug.Print("Testing Port {0} on {1}", port, ipAddress )
        Debug.Print("Returned Value is {0}", value)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod()> Public Sub TestMethod_PortIsUPUDP()
        Dim ipAddress As String = "127.0.0.1"
        Dim port As String = "1900"
        Dim value As Boolean = BSNetwork.PortIsUP(ipAddress, port, BSNetwork.IPProtocolType.UDP,errOut)
        Debug.Print("Testing Port {0} on {1}", port, ipAddress )
        Debug.Print("Returned Value is {0}", value)
        General.HasValue(value, errOut)
    End Sub
End Class