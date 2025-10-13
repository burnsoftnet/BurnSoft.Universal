Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BurnSoft.Universal
<TestClass()> Public Class FileIOTests
    Private appPath As String
    Private FileIOPath As String
    Private FileToDelete As String
    Private FileThatExists As String
    Private MyLogFile As String
    <TestInitialize()> Public Sub Init()
        Dim obj As New FileIO
        appPath = "C:\test" 'System.Windows.Forms.Application.StartupPath
        FileIOPath = appPath & "\" & Settings.FileIoWrites
        obj.CreateDirectory(FileIOPath)
        obj.CreateDirectory(FileIOPath & "\movetest")
        FileToDelete = FileIOPath & "\deleteme.test"
        FileThatExists = FileIOPath & "\exists.test"
        MyLogFile = FileIOPath & "\LogFile.test"

        obj.LogFile(FileToDelete, " Delete me please delete me!!")
        obj.LogFile(FileThatExists, "i exist to exist")
    End Sub

    <TestMethod(), TestCategory("File IO")> Public Sub LogFile()
        Dim didPass As Boolean = False
        Try
            Dim message As String = "This is a test"
            Dim obj As New FileIO
            obj.LogFile(MyLogFile, message)
            didPass = True
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod(), TestCategory("File IO")> Public Sub DeleteFile()
        Dim didPass As Boolean = False
        Try
            Dim obj As New FileIO
            obj.DeleteFile(FileToDelete)
            didPass = True
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod(), TestCategory("File IO")> Public Sub FileExist()
        Dim didPass As Boolean = False
        Try
            Dim obj As New FileIO
            didPass = obj.FileExists(FileThatExists)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod(), TestCategory("File IO")> Public Sub AppendToFile()
        Dim didPass As Boolean = False
        Try
            Dim obj As New FileIO
            obj.AppendToFile(MyLogFile, "This is appended to exists")
            didPass = True
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub

    <TestMethod(), TestCategory("File IO")> Public Sub MoveFile()
        Dim didPass As Boolean = False
        Try
            Dim obj As New FileIO
            obj.DeleteFile(FileIOPath & "\exists.move")
            obj.MoveFile(FileThatExists, FileIOPath & "\exists.move")
            didPass = True
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod(), TestCategory("File IO")> Public Sub CopyFile()
        Dim didPass As Boolean = False
        Try
            Dim obj As New FileIO
            obj.DeleteFile(FileIOPath & "\exists.copy")
            obj.CopyFile(FileThatExists, FileIOPath & "\exists.copy")
            didPass = True
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod(), TestCategory("File IO")> Public Sub CreateDirectory()
        Dim didPass As Boolean = False
        Try
            Dim obj As New FileIO
            obj.CreateDirectory(FileIOPath & "\existstest")
            didPass = True
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod(), TestCategory("File IO")> Public Sub DirectoryExists()
        Dim didPass As Boolean = False
        Try
            Dim obj As New FileIO
            didPass = obj.DirectoryExists(FileIOPath)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod(), TestCategory("File IO")> Public Sub DeleteDirectory()
        Dim didPass As Boolean = False
        Try
            Dim obj As New FileIO
            obj.DeleteDirectory(FileIOPath & "\existstest")
            didPass = True
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
End Class

