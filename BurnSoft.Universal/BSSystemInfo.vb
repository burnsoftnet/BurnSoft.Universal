Imports System.Management
Imports System.Windows.Forms
Public Class BSSystemInfo
    ''' <summary>
    ''' Returns the Physical memory of the machine broken down to kb, mb, gb, or tb
    ''' </summary>
    ''' <returns>total</returns>
    Public Function GetPhysicalMemory() As String
        Return TranslateMemory(My.Computer.Info.TotalPhysicalMemory)
    End Function
    ''' <summary>
    ''' Gets the Current Clock Speed in MegaHertz, By Default it is looking as CPU 0 by Can be changed if
    ''' if needed by adding a value to the CPUID
    ''' </summary>
    ''' <param name="CPUID"></param>
    ''' <returns>Speed in Megahertz</returns>
    Public Function GetCPUSpeed(Optional ByVal CPUID As Integer = 0) As Long
        Return GetManagementObject("Win32_Processor.DeviceID='CPU" & CPUID & "'", "CurrentClockSpeed")
    End Function
    ''' <summary>
    ''' Gets the CPU Description, 
    ''' EXAMPLE: Intel64 Family 6 Model 58 Stepping 9
    ''' </summary>
    ''' <param name="CPUID"></param>
    ''' <returns>descriptoion</returns>
    Public Function GetCPUDescription(Optional ByVal CPUID As Integer = 0) As String
        Return GetManagementObject("Win32_Processor.DeviceID='CPU" & CPUID & "'", "Description")
    End Function
    ''' <summary>
    ''' Gets the Full CPU Name with Processor speed, 
    ''' Example: Intel(R) Core(TM) i5-3317U CPU @ 1.70GHz
    ''' </summary>
    ''' <param name="CPUID"></param>
    ''' <returns>name</returns>
    Public Function GetCPUName(Optional ByVal CPUID As Integer = 0) As String
        Return GetManagementObject("Win32_Processor.DeviceID='CPU" & CPUID & "'", "Name")
    End Function
    ''' <summary>
    ''' Uses My.User.Name to get the current user that is running the application
    ''' </summary>
    ''' <returns></returns>
    Public Function GetUserName() As String
        Dim sAns As String = ""
        Dim sSplit() = Split(My.User.Name, "\")
        Dim iBound As Integer = UBound(sSplit)
        If iBound >= 1 Then
            sAns = sSplit(iBound)
        Else
            sAns = My.User.Name
        End If
        Return sAns
    End Function
    ''' <summary>
    '''  Uses SystemInformation.UserDomainName to get the Domain from the user that is running the applications
    ''' </summary>
    ''' <returns></returns>
    Public Function GetDomainName() As String
        Return SystemInformation.UserDomainName
    End Function
    ''' <summary>
    ''' Uses SystemInformation.Network to see if it is network connected
    ''' </summary>
    ''' <returns></returns>
    Public Function IsOnNetWork() As Boolean
        Return SystemInformation.Network
    End Function
    ''' <summary>
    ''' Uses SystemInformation.ComputerName to Get the Computer that the application is running on
    ''' </summary>
    ''' <returns></returns>
    Public Function GetComputerName() As String
        Return SystemInformation.ComputerName
    End Function
    ''' <summary>
    ''' Uses SystemInformation.UserName to get the users that is running the applications
    ''' </summary>
    ''' <returns></returns>
    Public Function GetUsername2() As String
        Return SystemInformation.UserName
    End Function
    ''' <summary>
    ''' Simple WMI Call just pass the Object then the desciption of the object to look for
    ''' </summary>
    ''' <param name="sObject"></param>
    ''' <param name="sValue"></param>
    ''' <returns>value</returns>
    Private Function GetManagementObject(sObject As String, sValue As String) As String
        Dim Obj As ManagementObject = New ManagementObject(sObject)
        Dim sAns As String = CStr(Obj(sValue))
        Obj.Dispose()
        Obj = Nothing
        Return sAns
    End Function
    Public Function ProcessExists(sProcessName As String, CommandLineContains As String, Optional ByRef PID As String = "", Optional ByRef ProcessCount As Integer = 0) As Boolean
        Dim bAns As Boolean = False
        Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name='" &
                                                     sProcessName & "' and CommandLine Like '%" &
                                                     CommandLineContains & "%'")

        For Each process As ManagementObject In searcher.Get()
            bAns = True
            ProcessCount += 1
            PID &= process("ProcessId")
        Next
        searcher = Nothing
        Return bAns
    End Function
    ''' <summary>
    ''' Check to see if a process is running or not.
    ''' </summary>
    ''' <param name="sProcessName"></param>
    ''' <returns></returns>
    Public Function ProcessExists(sProcessName As String, Optional ByRef ProcessCount As Integer = 0) As Boolean
        Dim bAns As Boolean = False
        Dim p() As Process
        p = Process.GetProcessesByName(sProcessName)
        ProcessCount = p.Count
        If p.Count > 0 Then
            bAns = True
        End If
        p = Nothing
        Return bAns
    End Function
    ''' <summary>
    ''' Breaks down a byte value to determin if it is in KB, MB, GB, or TB
    ''' </summary>
    ''' <param name="lValue"></param>
    ''' <returns>KB, MB, GB, or TB</returns>
    Private Function TranslateMemory(lValue As Long) As String
        Dim sAns As String = ""
        Dim KiloBytes As Double = FormatNumber((lValue / 1024), 2)
        Dim MegaBytes As Double = FormatNumber((KiloBytes / 1024), 2)
        Dim GigaBytes As Double = FormatNumber((MegaBytes / 1024), 2)
        Dim TeraBytes As Double = FormatNumber((GigaBytes / 1024), 2)

        If CInt(TeraBytes) <> 0 Then
            sAns = TeraBytes & " TB"
        ElseIf CInt(GigaBytes) <> 0 Then
            sAns = GigaBytes & " GB"
        ElseIf CInt(MegaBytes) <> 0 Then
            sAns = MegaBytes & " MB"
        ElseIf CInt(KiloBytes) <> 0 Then
            sAns = KiloBytes & " KB"
        End If

        Return sAns
    End Function
    ''' <summary>
    ''' breaks down a value to determine if it is Khz, Mhz, Ghz, Thz
    ''' </summary>
    ''' <param name="lValue"></param>
    ''' <returns>Khz, Mhz, Ghz, Thz</returns>
    Private Function TranslateCPUSpeed(lValue As Long) As String
        Dim sAns As String = ""
        Dim kilohertz As Double = FormatNumber((lValue / 1024), 2)
        Dim megaHertz As Double = FormatNumber((kilohertz / 1024), 2)
        Dim gigaHertz As Double = FormatNumber((megaHertz / 1024), 2)
        Dim teraHertz As Double = FormatNumber((gigaHertz / 1024), 2)

        If CInt(teraHertz) <> 0 Then
            sAns = teraHertz & " Thz"
        ElseIf CInt(gigaHertz) <> 0 Then
            sAns = gigaHertz * " Ghz"
        ElseIf CInt(megaHertz) <> 0 Then
            sAns = megaHertz & " Mhz"
        ElseIf CInt(kilohertz) <> 0 Then
            sAns = kilohertz & " Khz"
        End If

        Return sAns
    End Function
End Class
