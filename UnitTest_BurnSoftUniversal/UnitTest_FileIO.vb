Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BurnSoft.Universal
<TestClass()> Public Class UnitTest_FileIO
    Private Dim appPath As String
    Private Dim FileIOPath As String
    Private Dim FileToDelete As String
    Private Dim FileThatExists As String
    Private Dim LogFile As string
    <TestInitialize()> public Sub Init()
        Dim obj as New FileIO
        appPath = "C:\test" 'System.Windows.Forms.Application.StartupPath
        FileIOPath = appPath & "\" & Settings.FileIoWrites
        obj.CreateDirectory(FileIOPath)
        FileToDelete = FileIOPath & "\deleteme.test"
        FileThatExists = FileIOPath & "\exists.test"
        LogFile = FileIOPath & "\LogFile.test"
        
        obj.LogFile(FileToDelete," Delete me please delete me!!")
        obj.LogFile(FileThatExists,"i exist to exist")
    End Sub

    <TestMethod()> Public Sub TestMethod_LogFile()
        Dim didPass As Boolean = false
        Try
            Dim message As String = "This is a test"
            Dim obj as New FileIO
            obj.LogFile(LogFile, message)
            didPass = True
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod()> Public Sub TestMethod_DeleteFile()
        Dim didPass As Boolean = false
        Try
            Dim obj as New FileIO
            obj.DeleteFile(FileToDelete)
            didPass = True
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod()> Public Sub TestMethod_FileExist()
        Dim didPass As Boolean = false
        Try
            Dim obj as New FileIO
            didPass = obj.FileExists(FileThatExists)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod()> Public Sub TestMethod_AppendToFile()
        Dim didPass As Boolean = false
        Try
            Dim obj as New FileIO
            obj.AppendToFile(LogFile,"This is appended to exists")
            didPass = True
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub

    <TestMethod()> Public Sub TestMethod_MoveFile()
        Dim didPass As Boolean = false
        Try
            Dim obj as New FileIO
            obj.MoveFile(FileThatExists, FileIOPath & "\exists.move")
            didPass = true
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod()> Public Sub TestMethod_CopyFile()
        Dim didPass As Boolean = false
        Try
            Dim obj as New FileIO
            obj.CopyFile(FileThatExists, FileIOPath & "\exists.copy")
            didPass = true
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod()> Public Sub TestMethod_CreateDirectory()
        Dim didPass As Boolean = false
        Try
            Dim obj as New FileIO
            obj.CreateDirectory(FileIOPath & "\existstest")
            didPass = true
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod()> Public Sub TestMethod_DirectoryExists()
        Dim didPass As Boolean = false
        Try
            Dim obj as New FileIO
            didPass = obj.DirectoryExists(FileIOPath)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod()> Public Sub TestMethod_DeleteDirectory()
        Dim didPass As Boolean = false
        Try
            Dim obj as New FileIO
            obj.DeleteDirectory(FileIOPath & "\existstest")
            didPass = true
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        General.HasValue(didPass)
    End Sub
End Class
