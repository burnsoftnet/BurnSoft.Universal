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
        Debug.Print("Returned value is: {0}", value)
        General.HasValue(value)
    End Sub
    <TestMethod()> Public Sub TestMethod_GetCommandLong()
        Dim obj As New BSOtherObjects
        Dim switch as String = "interval"
        Debug.Print(Settings.CommandArgs)
        Debug.Print("Getting switch value for {0}", switch)
        Dim value As long = obj.GetCommand(switch,0,,Settings.CommandArgs)
        Debug.Print("Returned value is: {0}", value)
        General.HasValue(value)
    End Sub

    <TestMethod()> Public Sub TestMethod_GetCommandBoolean()
        Dim obj As New BSOtherObjects
        Dim switch as String = "doRestart"
        Debug.Print(Settings.CommandArgs)
        Debug.Print("Getting switch value for {0}", switch)
        Dim value As Boolean = obj.GetCommand(switch,false,,Settings.CommandArgs)
        Debug.Print("Returned value is: {0}", value)
        General.HasValue(value)
    End Sub
    <TestMethod()> Public Sub TestMethod_FC()
        Dim testString as String = "This is SQL's first test"
        Dim obj as New BSOtherObjects
        Dim value as string = obj.FC(testString)
        Debug.Print("Before: {0}", testString)
        Debug.Print("Returned value is: {0}", value)
        General.HasValue(value)
    End Sub
    <TestMethod()> Public Sub TestMethod_ConvertBoolToInt()
        Dim obj as New BSOtherObjects
        Dim testValue as Boolean = True
        Dim value As Boolean = obj.ConvertBoolToInt(testValue)
        Debug.Print("Before: {0}", testValue)
        Debug.Print("Returned value is: {0}", value)
        General.HasValue(value)
    End Sub
    <TestMethod()> Public Sub TestMethod_ConvertYNtoBool()
        Dim obj as New BSOtherObjects
        Dim testValue as String = "y"
        Dim value As Boolean = obj.ConvertYNtoBool(testValue)
        Debug.Print("Before: {0}", testValue)
        Debug.Print("Returned value is: {0}", value)
        General.HasValue(value)
    End Sub
    <TestMethod()> Public Sub TestMethod_ConvertIntToBool()
        Dim obj as New BSOtherObjects
        Dim testValue as Integer = "1"
        Dim value As Boolean = obj.ConvertIntToBool(testValue)
        Debug.Print("Before: {0}", testValue)
        Debug.Print("Returned value is: {0}", value)
        General.HasValue(value)
    End Sub
    '<TestMethod()> Public Sub TestMethod_()
    'End Sub
End Class