﻿'-------------------------------------------
' Created By BurnSoft
' www.burnsoft.net
'-------------------------------------------
Imports System.Management
' ReSharper disable once InconsistentNaming
Public Class BSProcessInfo
    ' ReSharper disable UnusedMember.Local
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
        Return sAns
    End Function
    ''' <summary>
    ''' Gets the process information by pid.
    ''' </summary>
    ''' <param name="pid">The pid.</param>
    ''' <param name="sObject">The s object.</param>
    ''' <returns>System.String.</returns>
    Private Function GetProcessInfoByPID(pid As String, sObject As String, Optional ByRef errMsg As String = "") As String
        Dim sAns As String = ""
        Try
            Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE ProcessId=" & pid)

            For Each process As ManagementObject In searcher.Get()
                sAns = process(sObject)
            Next
        Catch ex As Exception
            errMsg = ex.Message
        End Try
        Return sAns
    End Function
    ''' <summary>
    ''' Get the handlecount for a particular Process by PID
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <returns>Count</returns>
    Public Function GetProccessHandleCount(pid As String, Optional ByRef errMsg As String = "") As String
        Return GetProcessInfoByPID(pid, "HandleCount", errMsg)
    End Function
    ''' <summary>
    ''' Get the ThreadCount for a particular Process by PID
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <returns>Count</returns>
    Public Function GetProcessThreadCount(pid As String, Optional ByRef errMsg As String = "") As String
        Return GetProcessInfoByPID(pid, "ThreadCount", errMsg)
    End Function
    ''' <summary>
    ''' Get the TerminationDate for a particular Process by PID
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <returns>Termination Date</returns>
    Public Function GetProcessTerminationDate(pid As String, Optional ByRef errMsg As String = "") As String
        Return GetProcessInfoByPID(pid, "TerminationDate", errMsg)
    End Function
    ''' <summary>
    ''' Get the Caption for a particular Process by PID
    ''' Short description of an object—a one-line string.
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <returns>string</returns>
    Public Function GetProcessCaption(pid As String, Optional ByRef errMsg As String = "") As String
        Return GetProcessInfoByPID(pid, "Caption", errMsg)
    End Function
    ''' <summary>
    ''' Get the CommandLine for a particular Process by PID
    ''' Command line used to start a specific process, if applicable.
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <returns>string</returns>
    Public Function GetProcessCommandLine(pid As String, Optional ByRef errMsg As String = "") As String
        Return GetProcessInfoByPID(pid, "CommandLine", errMsg)
    End Function
    ''' <summary>
    ''' Get the CreationDate for a particular Process by PID
    ''' Date the process begins executing.
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <returns>datetime as string</returns>
    Public Function GetProcessCreationDate(pid As String) As String
        Return GetProcessInfoByPID(pid, "CreationDate")
    End Function
    ''' <summary>
    ''' Get the Description for a particular Process by PID
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <returns>Description of an object.</returns>
    Public Function GetProcessDescription(pid As String) As String
        Return GetProcessInfoByPID(pid, "Description")
    End Function
    ''' <summary>
    ''' Get the ExecutablePath for a particular Process by PID
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <return>Path to the executable file of the process.</return>
    Public Function GetProcessExecutablePath(pid As String) As String
        Return GetProcessInfoByPID(pid, "ExecutablePath")
    End Function
    ''' <summary>
    ''' Get the ExecutionState for a particular Process by PID
    ''' Unknown (0)
    ''' Other (1)
    ''' Ready (2)
    ''' Running (3)
    ''' Blocked (4)
    ''' Suspended Blocked (5)
    ''' Suspended Ready (6)
    ''' Terminated (7)
    ''' Stopped (8)
    ''' Growing (9)
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <return>Current operating condition of the process</return>
    Public Function GetProcessExecutionState(pid As String) As String
        Return GetProcessInfoByPID(pid, "ExecutionState")
    End Function
    ''' <summary>
    ''' Get the PageFaults for a particular Process by PID
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <return>Number of page faults that a process generates.</return>
    Public Function GetProcessPageFaults(pid As String) As String
        Return GetProcessInfoByPID(pid, "PageFaults")
    End Function
    ''' <summary>
    ''' Get the PageFileUsage for a particular Process by PID
    ''' Amount of page file space that a process is using currently. 
    ''' This value is consistent with the VMSize value in TaskMgr.exe.
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <return>Units ("kilobytes")</return>
    Public Function GetProcessPageFileUsage(pid As String) As String
        Return GetProcessInfoByPID(pid, "PageFileUsage")
    End Function
    ''' <summary>
    ''' Get the ParentProcessId for a particular Process by PID
    ''' Unique identifier of the process that creates a process. Process 
    ''' identifier numbers are reused, so they only identify a process for 
    ''' the lifetime of that process. It is possible that the process identified 
    ''' by ParentProcessId is terminated, so ParentProcessId may not refer to 
    ''' a running process. It is also possible that ParentProcessId incorrectly 
    ''' refers to a process that reuses a process identifier. You can use the 
    ''' CreationDate property to determine whether the specified parent was 
    ''' created after the process represented by this Win32_Process instance was created
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <return>Parent Process Id</return>
    Public Function GetProcessParentProcessId(pid As String) As String
        Return GetProcessInfoByPID(pid, "ParentProcessId")
    End Function
    ''' <summary>
    ''' Get the PeakPageFileUsage for a particular Process by PID
    ''' Maximum amount of page file space used during the life of a process.
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <return>Units ("kilobytes")</return>
    Public Function GetProcessPeakPageFileUsage(pid As String) As String
        Return GetProcessInfoByPID(pid, "PeakPageFileUsage")
    End Function
    ''' <summary>
    ''' Get the PeakVirtualSize for a particular Process by PID
    ''' Maximum virtual address space a process uses at any one time. 
    ''' Using virtual address space does not necessarily imply corresponding
    ''' use of either disk or main memory pages. However, virtual space is 
    ''' finite, and by using too much the process might not be able to load 
    ''' libraries.
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <return>Units ("bytes")</return>
    Public Function GetProcessPeakVirtualSize(pid As String) As String
        Return GetProcessInfoByPID(pid, "PeakVirtualSize")
    End Function
    ''' <summary>
    ''' Get the PeakWorkingSetSize for a particular Process by PID
    ''' Peak working set size of a process.
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <return>Units ("kilobytes")</return>
    Public Function GetProcessPeakWorkingSetSize(pid As String) As String
        Return GetProcessInfoByPID(pid, "PeakWorkingSetSize")
    End Function
    ''' <summary>
    ''' Get the PrivatePageCount for a particular Process by PID
    ''' Current number of pages allocated that are only accessible to the process 
    ''' represented by this Win32_Process instance.
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <return>count</return>
    Public Function GetProcessPrivatePageCount(pid As String) As String
        Return GetProcessInfoByPID(pid, "PrivatePageCount")
    End Function
    ''' <summary>
    ''' Get the SessionId for a particular Process by PID
    ''' Unique identifier that an operating system generates when a 
    ''' session is created. A session spans a period of time from logon 
    ''' until logoff from a specific system.
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <return>sessionID</return>
    Public Function GetProcessSessionId(pid As String) As String
        Return GetProcessInfoByPID(pid, "SessionId")
    End Function
    ''' <summary>
    ''' Get the UserModeTime for a particular Process by PID
    ''' Time in user mode, in 100 nanosecond units. If this information 
    ''' is not available, use a value of 0 (zero).
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <return>Units ("100 nanoseconds")</return>
    Public Function GetProcessUserModeTime(pid As String) As String
        Return GetProcessInfoByPID(pid, "UserModeTime")
    End Function
    ''' <summary>
    ''' Get the VirtualSize for a particular Process by PID
    ''' Current size of the virtual address space that a process is using, not
    ''' the physical or virtual memory actually used by the process. Using virtual 
    ''' address space does not necessarily imply corresponding use of either disk 
    ''' or main memory pages. Virtual space is finite, and by using too much, the 
    ''' process might not be able to load libraries. This value is consistent with 
    ''' what you see in Perfmon.exe.
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <return>Units ("bytes")</return>
    Public Function GetProcessVirtualSize(pid As String) As String
        Return GetProcessInfoByPID(pid, "VirtualSize")
    End Function
    ''' <summary>
    ''' Get the WorkingSetSize for a particular Process by PID
    ''' Amount of memory in bytes that a process needs to execute efficiently—for 
    ''' an operating system that uses page-based memory management. If the system 
    ''' does not have enough memory (less than the working set size), thrashing occurs. 
    ''' If the size of the working set is not known, use NULL or 0 (zero). If working 
    ''' set data is provided, you can monitor the information to understand the changing 
    ''' memory requirements of a process.
    ''' </summary>
    ''' <param name="pid"></param>
    ''' <return>Units ("bytes")</return>
    Public Function GetProcessWorkingSetSize(pid As String) As String
        Return GetProcessInfoByPID(pid, "WorkingSetSize")
    End Function

    ''' <summary>
    ''' Check to see if a process exists by name, Optionally get the PID and Process Count for the result(s)
    ''' </summary>
    ''' <param name="processName"></param>
    ''' <param name="pid"></param>
    ''' <param name="processCount"></param>
    ''' <returns></returns>
    Public Function ProcessExists(processName As String, Optional ByRef pid As String = "", Optional ByRef processCount As Integer = 0) As Boolean
        Dim bAns As Boolean = False
        Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name like '" &
                                                     processName & "%'")

        For Each process As ManagementObject In searcher.Get()
            bAns = True
            ProcessCount += 1
            pid &= process("ProcessId")
        Next

        Return bAns
    End Function
    ''' <summary>
    ''' Check to see if a process exists by name and what might be in the commandline parameters, Optionally get the PID and Process Count for the result(s)
    ''' </summary>
    ''' <param name="processName"></param>
    ''' <param name="commandLineContains"></param>
    ''' <param name="pid"></param>
    ''' <param name="processCount"></param>
    ''' <returns></returns>
    Public Function ProcessExists(processName As String, commandLineContains As String, Optional ByRef pid As String = "", Optional ByRef processCount As Integer = 0) As Boolean
        Dim bAns As Boolean = False
        Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name like '" &
                                                     ProcessName & "%' and CommandLine Like '%" &
                                                     commandLineContains & "%'")

        For Each process As ManagementObject In searcher.Get()
            bAns = True
            processCount += 1
            pid &= process("ProcessId")
        Next
        Return bAns
    End Function
    ''' <summary>
    ''' Check to see if a process is running or not.
    ''' </summary>
    ''' <param name="sProcessName"></param>
    ''' <returns>true/false</returns>
    Public Function ExactProcessExists(sProcessName As String, Optional ByRef processCount As Integer = 0) As Boolean
        Dim bAns As Boolean = False
        Dim p() As Process
        p = Process.GetProcessesByName(sProcessName)
        processCount = p.Count
        If p.Count > 0 Then
            bAns = True
        End If
        Return bAns
    End Function
    ''' <summary>
    ''' Use the Performance counter Process/Working Set - Private to get the 
    ''' memory that is used for a process
    ''' </summary>
    ''' <param name="processName"></param>
    ''' <returns>memory in bytes</returns>
    Public Function GetProcessMemoryUseage(processName As String) As String
        Dim sAns As String
        Dim o As New PerformanceCounter("Process", "Working Set - Private", processName)
        sAns = o.RawValue
        o.Close()
        Return sAns
    End Function
    ''' <summary>
    ''' Get the Process CPU Time via the Performance Counter
    ''' </summary>
    ''' <param name="processName"></param>
    ''' <param name="timerInterval"></param>
    ''' <param name="oldValue"></param>
    ''' <param name="newValue"></param>
    ''' <returns></returns>
    Public Function GetProcessCpuTime(processName As String, timerInterval As Long, oldValue As Double, ByRef newValue As Double) As String
        Dim sAns As String
        Dim o As New PerformanceCounter("Process", "% Processor Time", ProcessName)
' ReSharper disable once CompareOfFloatsByEqualityOperator
        If (OldValue = 0) Then
            sAns = "0"
            NewValue = o.RawValue
        Else
            NewValue = o.RawValue
            Dim cpu As Double = (((NewValue - OldValue) / timerInterval) / Environment.ProcessorCount) / 100
            sAns = FormatNumber(cpu, 2)
        End If
        o.Close()
        Return sAns
    End Function
    ''' <summary>
    ''' Get the Process Starting, first getProcessCPUtime is to initialize, the second is the time that is returned
    ''' </summary>
    ''' <param name="processName"></param>
    ''' <param name="timerInterval"></param>
    ''' <param name="newValue"></param>
    ''' <returns></returns>
    Public Function GetCpuProcessStarting(processName As String, timerInterval As Long, ByRef newValue As Double) As String
        Dim sAns As String
        Call GetProcessCPUTime(ProcessName, timerInterval, 0, NewValue)
        sAns = GetProcessCPUTime(ProcessName, timerInterval, NewValue, NewValue)
        Return sAns
    End Function
End Class
