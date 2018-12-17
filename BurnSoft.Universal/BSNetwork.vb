'-------------------------------------------
' Created By BurnSoft
' www.burnsoft.net
'-------------------------------------------
Imports System.Net
Imports System.Net.NetworkInformation
''' <summary>
''' Class BSNetwork.  General Class that contains functions to help manage network information on a machine
''' </summary>
Public Class BSNetwork
    Public Sub New()

    End Sub

    ''' <summary>
    ''' Public network Protocol Types used
    ''' </summary>
    ''' <example>
    ''' Dim ProtocolType As IPProtocolType
    ''' </example>
    Public Enum IPProtocolType
        TCP = 1
        UDP = 2
        IPX = 3
        SPX = 4
    End Enum
    ''' <summary>
    ''' Private Function to check and see if the port is operational
    ''' </summary>
    ''' <param name="sHost"></param>
    ''' <param name="iPort"></param>
    ''' <param name="protocolType"></param>
    ''' <returns></returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSNetwork <br/>
    ''' <br/>
    ''' Dim value as Boolean = PortOpen("localhost", "80", IPProtocolType.TCP)
    ''' </example>
    Private shared Function PortOpen(sHost As System.Net.IPAddress, iPort As Long, protocolType As IPProtocolType) As Boolean
        Dim bAns As Boolean = False
        Dim EPHost As New System.Net.IPEndPoint(sHost, iPort)
        Dim s As System.Net.Sockets.Socket = Nothing
        Dim IsUDP As Boolean = False
        Select Case ProtocolType
            Case IPProtocolType.TCP
                s = New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork,
                                                  System.Net.Sockets.SocketType.Stream,
                                                  System.Net.Sockets.ProtocolType.Tcp)
            Case IPProtocolType.UDP
                IsUDP = True
                s = New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork,
                                                  System.Net.Sockets.SocketType.Dgram,
                                                  System.Net.Sockets.ProtocolType.Udp)
            Case IPProtocolType.IPX
                s = New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork,
                                                  System.Net.Sockets.SocketType.Stream,
                                                  System.Net.Sockets.ProtocolType.Ipx)
            Case IPProtocolType.SPX
                s = New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork,
                                                  System.Net.Sockets.SocketType.Stream,
                                                  System.Net.Sockets.ProtocolType.Spx)
        End Select
        Try
            s.Connect(EPHost)
        Catch e As Exception
            Debug.Print(e.Message)
        End Try
        If Not s.Connected Then
            bAns = False
        Else
            If Not IsUDP Then
                s.Disconnect(False)
            End If
            bAns = True
        End If
        Return bAns
    End Function
    ''' <summary>
    ''' Quick Public Function to check and see if a port on the host is up and running
    ''' </summary>
    ''' <param name="sHost">The s host.</param>
    ''' <param name="iPort">The i port.</param>
    ''' <param name="protocolType">Type of the protocol.</param>
    ''' <param name="ErrMsg">The error MSG.</param>
    ''' <returns>true/false</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSNetwork <br />
    ''' Dim ipAddress As String = "127.0.0.1" <br />
    ''' Dim port As String = "1488" <br />
    ''' Dim value As Boolean = BSNetwork.PortIsUP(ipAddress, port, BSNetwork.IPProtocolType.TCP,errOut) <br />
    ''' Debug.Print("Testing Port {0} on {1}", port, ipAddress ) <br />
    ''' Debug.Print("Returned Value is {0}", value) <br />
    ''' </example>
    Public Shared Function PortIsUP(sHost As String, iPort As Long, Optional ByVal protocolType As IPProtocolType = IPProtocolType.TCP, Optional ByRef ErrMsg As String = "") As Boolean
        Dim bAns As Boolean = False
        Try
            Dim myHost As System.Net.IPAddress = System.Net.Dns.GetHostEntry(sHost).AddressList(0)
            bAns = PortOpen(myHost, iPort, ProtocolType)
        Catch ex As Exception
            ErrMsg = ex.Message.ToString
        End Try
        Return bAns
    End Function

    ''' <summary>
    ''' Devices the is up.
    ''' </summary>
    ''' <param name="host">The host.</param>
    ''' <param name="ipAddress">The ip address.</param>
    ''' <param name="lBytes">The l bytes.</param>
    ''' <param name="lRTrip">The l r trip.</param>
    ''' <param name="lTTL">The l TTL.</param>
    ''' <param name="Timeout">The timeout.</param>
    ''' <param name="ErrorMessage">The error message.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSNetwork <br/>
    ''' <br/>
    '''  Dim ipAddress As String = "127.0.0.1" <br />
    ''' Dim hostName as String = "" <br />
    ''' Dim lBytes As Long <br />
    ''' Dim lTTL As Long <br />
    ''' Dim lrTrip as Long <br />
    ''' Dim value As Boolean = BSNetwork.DeviceIsUp(hostName, ipAddress, lBytes, lrTrip, lTTL,,errOut) <br />
    ''' Debug.Print("Pinging Device {0}",ipAddress) <br />
    ''' Debug.Print("Bytes={0}",lBytes) <br />
    ''' Debug.Print("Trip={0}",lrTrip) <br />
    ''' Debug.Print("TTL={0}", lTTL) <br />
    ''' Debug.Print("Returned Value is {0}", value) <br />
    ''' </example>
    Public Shared Function DeviceIsUp(host As String, Optional ByRef ipAddress As String = "", Optional ByRef lBytes As Long = 0, Optional ByRef lRTrip As Long = 0, Optional ByRef lTTL As Long = 0, Optional ByVal Timeout As Long = 1500, Optional ByRef ErrorMessage As String = "") As Boolean
        Dim bAns As Boolean = False
        Dim instance As New Ping
        Dim results As PingReply
        If (host.Length =0) Then
            host = ipAddress
        End If
        Try
            results = instance.Send(Host, Timeout)
            Select Case results.Status
                Case IPStatus.Success
                    lBytes = results.Buffer.Length
                    lRTrip = results.RoundtripTime
                    lTTL = results.Options.Ttl
                    bAns = True
                Case IPStatus.TtlExpired
                    ErrorMessage = "TTL Expired in Transit."
                Case IPStatus.BadDestination
                    ErrorMessage = "Bad Destination."
                Case Else
                    ErrorMessage = "Request timed out."
            End Select
        Catch ex As Exception
            ErrorMessage = Err.Number & "::" & ex.Message.ToString
        End Try
        Return bAns
    End Function
End Class
