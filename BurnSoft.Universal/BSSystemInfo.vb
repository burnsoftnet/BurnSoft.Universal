'-------------------------------------------
' Created By BurnSoft
' www.burnsoft.net
'-------------------------------------------
Imports System.Management
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ApplicationServices
' ReSharper disable InconsistentNaming
''' <summary>
''' Class BSSystemInfo, To Get general information from the System
''' </summary>
Public Class BSSystemInfo
#If Not NET5_0 Then
    ' ReSharper restore InconsistentNaming
    ''' <summary>
    ''' Returns the Physical memory of the machine broken down to kb, mb, gb, or tb
    ''' </summary>
    ''' <returns>total</returns>
    Public Function GetPhysicalMemory() As String
        Return TranslateMemory(My.Computer.Info.TotalPhysicalMemory)
    End Function
#End If
    ''' <summary>
    ''' Gets the Current Clock Speed in MegaHertz, By Default it is looking as CPU 0 by Can be changed if
    ''' if needed by adding a value to the CPUID
    ''' </summary>
    ''' <param name="cpuid"></param>
    ''' <returns>Speed in Megahertz</returns>
    Public Function GetCpuSpeed(Optional ByVal cpuid As Integer = 0) As Long
        Return GetManagementObject("Win32_Processor.DeviceID='CPU" & cpuid & "'", "CurrentClockSpeed")
    End Function
    ''' <summary>
    ''' Gets the CPU Description, 
    ''' EXAMPLE: Intel64 Family 6 Model 58 Stepping 9
    ''' </summary>
    ''' <param name="cpuid"></param>
    ''' <returns>descriptoion</returns>
    Public Function GetCpuDescription(Optional ByVal cpuid As Integer = 0) As String
        Return GetManagementObject("Win32_Processor.DeviceID='CPU" & cpuid & "'", "Description")
    End Function
    ''' <summary>
    ''' Gets the Full CPU Name with Processor speed, 
    ''' Example: Intel(R) Core(TM) i5-3317U CPU @ 1.70GHz
    ''' </summary>
    ''' <param name="cpuid"></param>
    ''' <returns>name</returns>
    Public Function GetCpuName(Optional ByVal cpuid As Integer = 0) As String
        Return GetManagementObject("Win32_Processor.DeviceID='CPU" & cpuid & "'", "Name")
    End Function
#If Not NET5_0 Then
    ''' <summary>
    ''' Uses My.User.Name to get the current user that is running the application
    ''' </summary>
    ''' <returns></returns>
    Public Function GetUserName() As String
        Dim sAns As String = "NO USER FOUND"
        Dim sSplit() = Split(My.User.Name, "\")
        Dim iBound As Integer = UBound(sSplit)
        If iBound >= 1 Then
            sAns = sSplit(iBound)
        Else
            If My.User.Name.Length > 0 Then
                sAns = My.User.Name
            End If
        End If
        Return sAns
    End Function
#end if
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
        Dim obj As ManagementObject = New ManagementObject(sObject)
        Dim sAns As String = CStr(obj(sValue))
        obj.Dispose()
        obj = Nothing
        Return sAns
    End Function
    ''' <summary>
    ''' Processes the exists.
    ''' </summary>
    ''' <param name="sProcessName">Name of the s process.</param>
    ''' <param name="commandLineContains">The command line contains.</param>
    ''' <param name="PID">The pid.</param>
    ''' <param name="processCount">The process count.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    <Obsolete("Function Replaced By BSProcessInfo.ProcessExists")>
    Public Function ProcessExists(sProcessName As String, commandLineContains As String, Optional ByRef PID As String = "", Optional ByRef processCount As Integer = 0) As Boolean
        Dim bAns As Boolean = False
        'Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name='" &
        '                                            sProcessName & "' and CommandLine Like '%" & CommandLineContains & "%'")
        Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name='%" & sProcessName & "%'")
        'TOFIX:  This is not working as designed
        Dim commandLine As String = ""
        For Each process As ManagementObject In searcher.Get()
            commandLine = process("CommandLine")
            Debug.Print(commandLine)
            bAns = True
            processCount += 1
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
    <Obsolete("Function Replaced By BSProcessInfo.ProcessExists")>
    Public Function ProcessExists(sProcessName As String, Optional ByRef processCount As Integer = 0) As Boolean
        Dim bAns As Boolean = False
        Dim p() As Process
        p = Process.GetProcessesByName(sProcessName)
        processCount = p.Count
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
        Dim kiloBytes As Double = FormatNumber((lValue / 1024), 2)
        Dim megaBytes As Double = FormatNumber((kiloBytes / 1024), 2)
        Dim gigaBytes As Double = FormatNumber((megaBytes / 1024), 2)
        Dim teraBytes As Double = FormatNumber((gigaBytes / 1024), 2)

        If CInt(teraBytes) <> 0 Then
            sAns = teraBytes & " TB"
        ElseIf CInt(gigaBytes) <> 0 Then
            sAns = gigaBytes & " GB"
        ElseIf CInt(megaBytes) <> 0 Then
            sAns = megaBytes & " MB"
        ElseIf CInt(kiloBytes) <> 0 Then
            sAns = kiloBytes & " KB"
        End If

        Return sAns
    End Function
    ''' <summary>
    ''' breaks down a value to determine if it is Khz, Mhz, Ghz, Thz
    ''' </summary>
    ''' <param name="lValue"></param>
    ''' <returns>Khz, Mhz, Ghz, Thz</returns>
    Private Function TranslateCpuSpeed(lValue As Long) As String
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
