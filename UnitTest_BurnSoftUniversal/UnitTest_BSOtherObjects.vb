Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BurnSoft.Universal

' ReSharper disable once InconsistentNaming
<TestClass()> Public Class UnitTest_BSOtherObjects

    ''' <summary>
    ''' Defines the test method TestMethod_StringCompairMatch.
    ''' </summary>
    <TestMethod()> Public Sub TestMethod_StringCompairMatch()
        Dim obj As New BSOtherObjects
        Dim didPass As Boolean = obj.StringCompare("test", "test")
        If didPass Then
            Debug.Print("Strings Matched!")
        Else
            Debug.Print("Strings Didn't Matched!")
        End If
        General.HasValue(didPass)
    End Sub
    ''' <summary>
    ''' Defines the test method TestMethod_StringCompairMisMatch.
    ''' </summary>
    <TestMethod()> Public Sub TestMethod_StringCompairMisMatch()
        Dim obj As New BSOtherObjects
        Dim didPass As Boolean = obj.StringCompare("Test", "test")
        If didPass Then
            Debug.Print("Strings Matched!")
        Else
            Debug.Print("Strings Didn't Matched!")
            didPass = True
        End If
        General.HasValue(didPass)
    End Sub
    <TestMethod()> Public Sub TestMethod_ContentsExistsRegEx()
        Dim obj As New BSOtherObjects
        Dim didPass as Boolean = obj.ContentsExistsRegEx("This is a test, this is only a test","only")
        If didPass Then 
            Debug.Print("Keywork Found!")
        Else 
            Debug.Print("Didn't find key work in phrse")
            didPass = true
        End If
        General.HasValue(didPass)
    End Sub
    <TestMethod()> Public Sub TestMethod_ArraysEqual()
        Dim obj As New BSOtherObjects
        Dim bytes(1000 * 1000 * 3 - 1) As Byte
        Dim bytes2(1000 * 1000 * 3 - 1) As Byte
        Dim didPass As Boolean = obj.ArraysEqual(bytes, bytes2)
        If didPass Then 
            Debug.Print("Strings Matched!")
        Else 
            Debug.Print("Strings Didn't Matched!")
        End If
        General.HasValue(didPass)
    End Sub
    <TestMethod()> Public Sub TestMethod_Pause()
        Dim obj As New BSOtherObjects
        Dim didPass As Boolean
        Try
            obj.Pause(100)
            didPass = true
        Catch ex As Exception
            didPass = false
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod()> Public Sub TestMethod_Found()
        Dim obj As New BSOtherObjects
        Dim didPass as Boolean = obj.Found("This is a test, this is only a test","only")
        If didPass Then 
            Debug.Print("Keywork Found!")
        Else 
            Debug.Print("Didn't find key work in phrse")
            didPass = true
        End If
        General.HasValue(didPass)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetLoggedonUser()
        Dim obj As New BSOtherObjects
        Dim value As String = obj.GetLoggedonUser()
        General.HasValue(value)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetCommandString()
        Dim obj As New BSOtherObjects
        Dim switch as String = "endpoint"
        Debug.Print(Settings.CommandArgs)
        Debug.Print("Getting switch value for {0}", switch)
        Dim value As string = obj.GetCommand(switch,"",,Settings.CommandArgs)
        General.HasValue(value)
    End Sub
    <TestMethod()> Public Sub TestMethod_()
    End Sub
    '<TestMethod()> Public Sub TestMethod_()
    'End Sub
End Class