Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BurnSoft.Universal
<TestClass()> Public Class BSNetworkTests
    Private errOut As String
    Private host As String
    Private TcpPort As String
    Private UdpPort As String
    <TestInitialize()> Public Sub Init()
        host = "bsweb02"
        TcpPort = "80"
        UdpPort = "1900"
    End Sub
    <TestMethod(), TestCategory("Network Related")> Public Sub DeviceIsUp()
        Dim hostName As String = ""
        Dim lBytes As Long
        Dim lTTL As Long
        Dim lrTrip As Long
        Dim value As Boolean = BSNetwork.DeviceIsUp(hostName, host, lBytes, lrTrip, lTTL,, errOut)
        Debug.Print("Pinging Device {0}", host)
        Debug.Print("Bytes={0}", lBytes)
        Debug.Print("Trip={0}", lrTrip)
        Debug.Print("TTL={0}", lTTL)
        Debug.Print("Returned Value is {0}", value)
        General.HasValue(value, errOut)
    End Sub
    <TestMethod(), TestCategory("Network Related")> Public Sub PortIsUPTCP()
        Dim value As Boolean = BSNetwork.PortIsUP(host, TcpPort, BSNetwork.IPProtocolType.TCP, errOut)
        Debug.Print("Testing Port {0} on {1}", TcpPort, host)
        Debug.Print("Returned Value is {0}", value)
        General.HasValue(value, errOut)
    End Sub

    <TestMethod(), TestCategory("Network Related")> Public Sub PortIsUPUDP()
        Dim value As Boolean = BSNetwork.PortIsUP(host, UdpPort, BSNetwork.IPProtocolType.UDP, errOut)
        Debug.Print("Testing Port {0} on {1}", UdpPort, host)
        Debug.Print("Returned Value is {0}", value)
        General.HasValue(value, errOut)
    End Sub
End Class