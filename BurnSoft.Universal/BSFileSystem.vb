Imports System.IO
Imports System.Text
Public Class FileIO
    ''' <summary>
    ''' The Log File Sub is a quick and easy way to create a log file for your application.
    ''' </summary>
    ''' <param name="strPath"></param>
    ''' <param name="strMessage"></param>
    Public Sub LogFile(ByVal strPath As String, ByVal strMessage As String)
        Dim SendMessage As String = DateTime.Now & vbTab & strMessage
        Call AppendToFile(strPath, SendMessage)
    End Sub
    ''' <summary>
    ''' The DeleteFile Sub will check to see if the file exists, if it does exist it will delete it.
    ''' </summary>
    ''' <param name="strPath"></param>
    Public Sub DeleteFile(ByVal strPath As String)
        If File.Exists(strPath) Then
            File.Delete(strPath)
        End If
    End Sub
    ''' <summary>
    ''' The AppendToFile Sub is like the LogFile Sub except it will not add the Date and Time Stamp to the File.
    ''' </summary>
    ''' <param name="sPath"></param>
    ''' <returns></returns>
    Public Function FileExists(ByVal sPath As String) As Boolean
        Return File.Exists(sPath)
    End Function
    ''' <summary>
    ''' Private Sub to Create a file if it doesn't exist
    ''' </summary>
    ''' <param name="strPath"></param>
    Private Sub CreateFile(ByVal strPath As String)
        If File.Exists(strPath) = False Then
            Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.Write)
            fs.Close()
        End If
    End Sub
    ''' <summary>
    ''' Public Sub to write a new line to a file that already exists, if the file doesn't not exist, it will create it.
    ''' </summary>
    ''' <param name="strPath"></param>
    ''' <param name="strNewLine"></param>
    Public Sub AppendToFile(ByVal strPath As String, ByVal strNewLine As String)
        If File.Exists(strPath) = False Then Call CreateFile(strPath)
        Dim sw As New StreamWriter(strPath, True, Encoding.ASCII)
        sw.WriteLine(strNewLine)
        sw.Close()
    End Sub
    ''' <summary>
    ''' The MoveFile Sub will check to see if the File exists if the Source path, if it does exist then it will move it over to the destination path.
    ''' </summary>
    ''' <param name="strFrom"></param>
    ''' <param name="strTo"></param>
    Public Sub MoveFile(ByVal strFrom As String, ByVal strTo As String)
        If File.Exists(strFrom) Then
            File.Move(strFrom, strTo)
        End If
    End Sub
    ''' <summary>
    ''' The MoveFile Sub will check to see if the File exists if the Source path, if it does exist then it will copy it over to the destination path.
    ''' </summary>
    ''' <param name="strFrom"></param>
    ''' <param name="strTo"></param>
    Public Sub CopyFile(ByVal strFrom As String, ByVal strTo As String)
        If File.Exists(strFrom) Then
            File.Copy(strFrom, strTo)
        End If
    End Sub
    ''' <summary>
    ''' The CreateDirectory Sub will check to see if the directory exists in the Target path that you provided. If it doesn’t exist, it will create it.
    ''' </summary>
    ''' <param name="strPath"></param>
    Public Sub CreateDirectory(ByVal strPath As String)
        If Directory.Exists(strPath) Then
            Directory.CreateDirectory(strPath)
        End If
    End Sub
    ''' <summary>
    ''' The DirectoryExists Function will check to see the directory that you provided exists.
    ''' </summary>
    ''' <param name="strPath"></param>
    ''' <returns></returns>
    Public Function DirectoryExists(ByVal strPath As String) As Boolean
        Return Directory.Exists(strPath)
    End Function
    ''' <summary>
    ''' The DeleteDirectory Sub will check to see the directory that you provided exists. If it does exist, it will delete it.
    ''' </summary>
    ''' <param name="strPath"></param>
    Public Sub DeleteDirectory(ByVal strPath As String)
        If Directory.Exists(strPath) Then
            Directory.Delete(strPath)
        End If
    End Sub
    ''' <summary>
    ''' The MoveDirectory Sub will check to see the directory that you provided exists in the Source, if it Does exist, it will move it to the targe path that you provided.
    ''' </summary>
    ''' <param name="strFrom"></param>
    ''' <param name="strTo"></param>
    Public Sub MoveDirectory(ByVal strFrom As String, ByVal strTo As String)
        If Directory.Exists(strFrom) Then
            Directory.Move(strFrom, strTo)
        End If
    End Sub
    ''' <summary>
    ''' The RenameFile Sub will rename the file that you provide in the source and rename it to that of the target
    ''' </summary>
    ''' <param name="strFrom"></param>
    ''' <param name="strTo"></param>
    Public Sub RenameFile(ByVal strFrom As String, ByVal strTo As String)
        'If File.Exists(strFrom) Then
        File.Move(strFrom, strTo)
        'name strFrom as strto\
        'End If
    End Sub
    ''' <summary>
    ''' The GetPathOfFile Function will return the Full Directory of the File that you give it. Let’s say you Passed “C:\Temp\MyFile.log”, it will return “C:\Temp”
    ''' </summary>
    ''' <param name="strFile"></param>
    ''' <returns></returns>
    Public Function GetPathOfFile(ByVal strFile As String) As String
        Dim sAns As String = ""
        sAns = Path.GetDirectoryName(strFile)
        Return sAns
    End Function
    ''' <summary>
    ''' The GetExtOfFile Function will return just the file extension of the file that you give it. Let’s say you Passed “C:\Temp\MyFile.log”, it will return “.Log”
    ''' </summary>
    ''' <param name="strFile"></param>
    ''' <returns></returns>
    Public Function GetExtOfFile(ByVal strFile As String) As String
        Dim sAns As String = ""
        sAns = Path.GetExtension(strFile)
        Return sAns
    End Function
    ''' <summary>
    ''' The GetNameOfFile function will return just the file name of the file that you give it. Let’s say you Passed “C:\Temp\MyFile.log”, it will return “MyFile.Log”
    ''' </summary>
    ''' <param name="strFile"></param>
    ''' <returns></returns>
    Public Function GetNameOfFile(ByVal strFile As String) As String
        Dim sAns As String = ""
        sAns = Path.GetFileName(strFile)
        Return sAns
    End Function
    ''' <summary>
    ''' This will check and see if the file you provided has a file extension type.
    ''' </summary>
    ''' <param name="strFile"></param>
    ''' <returns></returns>
    Public Function FileHasExtension(ByVal strFile As String) As Boolean
        Dim bAns As Boolean = False
        bAns = Path.HasExtension(strFile)
        Return bAns
    End Function
    ''' <summary>
    ''' The GetNameOfFileWOExt function will return just the file name of the file that you give it. Let’s say you Passed “C:\Temp\MyFile.log”, it will return “MyFile”
    ''' </summary>
    ''' <param name="strFile"></param>
    ''' <returns></returns>
    Public Function GetNameOfFileWOExt(ByVal strFile As String) As String
        Dim sAns As String = ""
        sAns = Path.GetFileNameWithoutExtension(strFile)
        Return sAns
    End Function
    ''' <summary>
    ''' Public Function to get the version of a file, usually useful for getting application, library versions
    ''' </summary>
    ''' <param name="sFile"></param>
    ''' <returns>Version as string</returns>
    Public Function GetFileVersion(ByVal sFile As String) As String
        Dim sAns As String = ""
        Dim sFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(sFile)
        sAns = sFileVersionInfo.FileVersion
        Return sAns
    End Function
    ''' <summary>
    ''' Public Function to get any description of a file in the tag property
    ''' </summary>
    ''' <param name="sFile"></param>
    ''' <returns>Description as string</returns>
    Public Function GetFileDescription(ByVal sFile As String) As String
        Dim sAns As String = ""
        Dim sFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(sFile)
        sAns = sFileVersionInfo.FileDescription
        Return sAns
    End Function
    ''' <summary>
    ''' Public Function to get any File Comments in the tag property section
    ''' </summary>
    ''' <param name="sFile"></param>
    ''' <returns>Comments as string</returns>
    Public Function GetFileComments(ByVal sFile As String) As String
        Dim sAns As String = ""
        Dim sFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(sFile)
        sAns = sFileVersionInfo.Comments
        Return sAns
    End Function
    ''' <summary>
    ''' Public Function to get the Company that created the application or library
    ''' </summary>
    ''' <param name="sFile"></param>
    ''' <returns>Company Name as string</returns>
    Public Function GetFileCompany(ByVal sFile As String) As String
        Dim sAns As String = ""
        Dim sFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(sFile)
        sAns = sFileVersionInfo.CompanyName
        Return sAns
    End Function
    ''' <summary>
    ''' Get the Createion date and time of the file that is passed
    ''' </summary>
    ''' <param name="sFile"></param>
    ''' <returns>Date and Time</returns>
    Public Function GetCreationDateTime(sFile As String) As String
        Dim sAns As String = File.GetCreationTime(sFile).ToString
        Return sAns
    End Function
    ''' <summary>
    ''' Get the Last Access date and time fo the file that is being passed
    ''' </summary>
    ''' <param name="sFile"></param>
    ''' <returns>Date and Time</returns>
    Public Function GetLastAccessDateTime(sFile As String) As String
        Dim sAns As String = File.GetLastAccessTime(sFile).ToString
        Return sAns
    End Function
    ''' <summary>
    ''' Get the last time the file was written to from the file that was being passed
    ''' </summary>
    ''' <param name="sFile"></param>
    ''' <returns>Date and Time</returns>
    Public Function GetLastWriteDateTime(sFile As String) As String
        Dim sAns As String = File.GetLastWriteTime(sFile).ToString
        Return sAns
    End Function
End Class
Public Class FSInfo
    Private Declare Auto Function GetShortPathName Lib "kernel32.dll" (ByVal strLongPath As String, ByVal objStringBuilder As System.Text.StringBuilder, ByVal intBufferSize As Integer) As Integer
    Private Declare Auto Function GetLongPathName Lib "Kernel32.dll" (ByVal strShortname As String, ByVal objStringBuilder As System.Text.StringBuilder, ByVal intBufferSize As Integer) As Integer

    Public Enum DirectoryPathlength
        WindowsXP = 256
    End Enum
    ''' <summary>
    ''' Return the Shot 8-BIT DOS name of the path
    ''' </summary>
    ''' <param name="sPath"></param>
    ''' <param name="enumDirectoryPathlength"></param>
    ''' <returns></returns>
    Public Function GetShortPathName(ByVal sPath As String, Optional ByVal enumDirectoryPathlength As DirectoryPathlength = DirectoryPathlength.WindowsXP) As String
        Dim strStringBuilder As New System.Text.StringBuilder(enumDirectoryPathlength)
        Dim intNewStringLength As Integer
        intNewStringLength = GetShortPathName(sPath, strStringBuilder, enumDirectoryPathlength)
        Return strStringBuilder.ToString
    End Function
    ''' <summary>
    ''' Return the Long Path Name
    ''' </summary>
    ''' <param name="sPath"></param>
    ''' <param name="enumDirectoryPathLength"></param>
    ''' <returns></returns>
    Public Function GetLongPathName(ByVal sPath As String, Optional ByVal enumDirectoryPathLength As DirectoryPathlength = DirectoryPathlength.WindowsXP) As String
        Dim strStringBuilder As New System.Text.StringBuilder(enumDirectoryPathLength)
        Dim intNewStringLength As Integer
        intNewStringLength = GetLongPathName(sPath, strStringBuilder, enumDirectoryPathLength)
        Return strStringBuilder.ToString
    End Function
    ''' <summary>
    ''' Private function using a windows API to get the diskfreespace
    ''' </summary>
    ''' <param name="lpDirectoryName"></param>
    ''' <param name="lpFreeBytesAvailableToCaller"></param>
    ''' <param name="lpTotalNumberOfBytes"></param>
    ''' <param name="lpTotalNumberOfFreeBytes"></param>
    ''' <returns>Bytes as long</returns>
    Private Declare Function GetDiskFreeSpaceEx _
           Lib "kernel32" _
           Alias "GetDiskFreeSpaceExA" _
           (ByVal lpDirectoryName As String,
           ByRef lpFreeBytesAvailableToCaller As Long,
           ByRef lpTotalNumberOfBytes As Long,
           ByRef lpTotalNumberOfFreeBytes As Long) As Long
    ''' <summary>
    ''' Counts all the directories from the target path ( sPath )
    ''' </summary>
    ''' <param name="sPath"></param>
    ''' <param name="ErrMsg"></param>
    ''' <returns>Count as long</returns>
    Private Function CountAllDirectoriesEx(ByVal sPath As String, Optional ByRef ErrMsg As String = "") As Long
        Dim lAns As Long = 0
        Try
            Dim dirInfo As DirectoryInfo = New DirectoryInfo(sPath)
            Dim dirSubDirectory As DirectoryInfo
            Dim iCount As Long = 1
            For Each dirSubDirectory In dirInfo.GetDirectories
                iCount += CountAllDirectoriesEx(dirSubDirectory.FullName)
            Next
            dirInfo = Nothing
            dirSubDirectory = Nothing
        Catch ex As Exception
            ErrMsg = ex.Message.ToString
        End Try
        Return lAns
    End Function
    ''' <summary>
    ''' The FSInfo.CountAllDirectories function will return the count of all the sub folders in the selected target path.
    ''' </summary>
    ''' <param name="sPath"></param>
    ''' <param name="ErrMsg"></param>
    ''' <returns></returns>
    Public Function CountAllDirectories(ByVal sPath As String, Optional ByRef ErrMsg As String = "") As Long
        Dim lCount As Long = CountAllDirectoriesEx(sPath, ErrMsg)
        If lCount > 1 Then lCount = lCount - 1
        Return lCount
    End Function
    ''' <summary>
    ''' The FSInfo.CountAllFiles function will return the total number of files in the target directory/drive, this includes files in all sub directories including that what is in the root path.
    ''' </summary>
    ''' <param name="sPath"></param>
    ''' <param name="ErrMsg"></param>
    ''' <returns></returns>
    Public Function CountAllFiles(ByVal sPath As String, Optional ByRef ErrMsg As String = "") As Long
        Dim lAns As Long = 0
        Try
            Dim dirInfo As DirectoryInfo = New DirectoryInfo(sPath)
            Dim dirSubDirectory As DirectoryInfo
            Dim iCount As Long = CountFiles(sPath)
            For Each dirSubDirectory In dirInfo.GetDirectories
                iCount += CountAllFiles(dirSubDirectory.FullName)
            Next
            dirInfo = Nothing
            dirSubDirectory = Nothing
        Catch ex As Exception
            ErrMsg = ex.Message.ToString
        End Try
        Return lAns
    End Function
    ''' <summary>
    ''' Private function to count all the files in teh target path ( spath )
    ''' </summary>
    ''' <param name="sPath"></param>
    ''' <param name="ErrMsg"></param>
    ''' <returns>Count as long</returns>
    Private Function CountFiles(ByVal sPath As String, Optional ByRef ErrMsg As String = "") As Long
        Dim lAns As Long = 0
        Try
            Dim dirInfo As DirectoryInfo = New DirectoryInfo(sPath)
            Dim dirFile As FileInfo
            For Each dirFile In dirInfo.GetFiles
                lAns += 1
            Next
            dirInfo = Nothing
            dirFile = Nothing
        Catch ex As Exception
            ErrMsg = ex.Message.ToString
        End Try
        Return lAns
    End Function
    ''' <summary>
    ''' The FSInfo.GetFreeSpace will give you the free space of the selected drive
    ''' </summary>
    ''' <param name="Drive"></param>
    ''' <returns>Value in GigaBytes</returns>
    Public Function GetFreeSpace(ByVal Drive As String) As Double

        '// Return GB

        Dim lBytesTotal, lFreeBytes, lFreeBytesAvailable, iAns As Long

        iAns = GetDiskFreeSpaceEx(Drive, lFreeBytesAvailable, lBytesTotal, lFreeBytes)
        If iAns > 0 Then
            Return ((lFreeBytes / 1024) / 1024) / 1024
        Else
            Return 0
        End If

    End Function
    ''' <summary>
    ''' The FSInfo.GetTotalSpace will give you the Total space of the selected drive
    ''' </summary>
    ''' <param name="Drive"></param>
    ''' <returns>Value in GigaBytes</returns>
    Public Function GetTotalSpace(ByVal Drive As String) As Double

        '// Return GB

        Dim lBytesTotal, lFreeBytes, lFreeBytesAvailable, iAns As Long

        iAns = GetDiskFreeSpaceEx(Drive, lFreeBytesAvailable, lBytesTotal, lFreeBytes)
        If iAns > 0 Then
            Return ((lBytesTotal / 1024) / 1024) / 1024
        Else
            Return 0
        End If

    End Function
End Class
