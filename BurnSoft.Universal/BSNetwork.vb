Imports System.Net
Imports System.Net.NetworkInformation
Public Class BSNetwork
    Public Sub New()

    End Sub

    ''' <summary>
    ''' Public network Protocol Types used
    ''' </summary>
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
    ''' <param name="ProtocolType"></param>
    ''' <returns></returns>
    Private Function PortOpen(sHost As System.Net.IPAddress, iPort As Long, ProtocolType As IPProtocolType) As Boolean
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
        Catch
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
    ''' <param name="sHost"></param>
    ''' <param name="iPort"></param>
    ''' <param name="ProtocolType"></param>
    ''' <param name="ErrMsg"></param>
    ''' <returns>true/false</returns>
    Public Function PortIsUP(sHost As String, iPort As Long, Optional ByVal ProtocolType As IPProtocolType = IPProtocolType.TCP, Optional ByRef ErrMsg As String = "") As Boolean
        Dim bAns As Boolean = False
        Try
            Dim myHost As System.Net.IPAddress = System.Net.Dns.GetHostEntry(sHost).AddressList(0)
            bAns = PortOpen(myHost, iPort, ProtocolType)
        Catch ex As Exception
            ErrMsg = ex.Message.ToString
        End Try
        Return bAns
    End Function

    Public Function DeviceIsUp(Host As String, Optional ByRef IPAddress As String = "", Optional ByRef lBytes As Long = 0, Optional ByRef lRTrip As Long = 0, Optional ByRef lTTL As Long = 0, Optional ByVal Timeout As Long = 1500, Optional ByRef ErrorMessage As String = "") As Boolean
        Dim bAns As Boolean = False
        Dim instance As New Ping
        Dim Results As PingReply
        Try
            Results = instance.Send(Host, Timeout)
            Select Case Results.Status
                Case IPStatus.Success
                    lBytes = Results.Buffer.Length
                    lRTrip = Results.RoundtripTime
                    lTTL = Results.Options.Ttl
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
