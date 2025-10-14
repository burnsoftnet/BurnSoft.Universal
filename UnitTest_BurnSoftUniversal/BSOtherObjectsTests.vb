Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports BurnSoft.Universal

' ReSharper disable once InconsistentNaming
<TestClass()> Public Class BSOtherObjectsTests

    ''' <summary>
    ''' Defines the test method StringCompairMatch.
    ''' </summary>
    <TestMethod(), TestCategory("Other Objects")> Public Sub StringCompairMatch()
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
    ''' Defines the test method StringCompairMisMatch.
    ''' </summary>
    <TestMethod(), TestCategory("Other Objects")> Public Sub StringCompairMisMatch()
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
    <TestMethod(), TestCategory("Other Objects")> Public Sub ContentsExistsRegEx()
        Dim obj As New BSOtherObjects
        Dim didPass As Boolean = obj.ContentsExistsRegEx("This is a test, this is only a test", "only")
        If didPass Then
            Debug.Print("Keywork Found!")
        Else
            Debug.Print("Didn't find key work in phrse")
            didPass = True
        End If
        General.HasValue(didPass)
    End Sub
    <TestMethod(), TestCategory("Other Objects")> Public Sub ArraysEqual()
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
    <TestMethod(), TestCategory("Other Objects")> Public Sub Pause()
        Dim obj As New BSOtherObjects
        Dim didPass As Boolean
        Try
            obj.Pause(100)
            didPass = True
        Catch ex As Exception
            didPass = False
        End Try
        General.HasValue(didPass)
    End Sub
    <TestMethod(), TestCategory("Other Objects")> Public Sub Found()
        Dim obj As New BSOtherObjects
        Dim didPass As Boolean = obj.Found("This is a test, this is only a test", "only")
        If didPass Then
            Debug.Print("Keywork Found!")
        Else
            Debug.Print("Didn't find key work in phrse")
            didPass = True
        End If
        General.HasValue(didPass)
    End Sub
    <TestMethod(), TestCategory("Other Objects")> Public Sub GetLoggedonUser()
        Dim obj As New BSOtherObjects
        Dim value As String = obj.GetLoggedonUser()
        General.HasValue(value)
    End Sub
    <TestMethod(), TestCategory("Other Objects")> Public Sub GetCommandString()
        Dim obj As New BSOtherObjects
        Dim switch As String = "endpoint"
        Debug.Print(Settings.CommandArgs)
        Debug.Print("Getting switch value for {0}", switch)
        Dim value As String = obj.GetCommand(switch, "",, Settings.CommandArgs)
        Debug.Print("Returned value is: {0}", value)
        General.HasValue(value)
    End Sub
    <TestMethod(), TestCategory("Other Objects")> Public Sub GetCommandLong()
        Dim obj As New BSOtherObjects
        Dim switch As String = "interval"
        Debug.Print(Settings.CommandArgs)
        Debug.Print("Getting switch value for {0}", switch)
        Dim value As Long = obj.GetCommand(switch, 0,, Settings.CommandArgs)
        Debug.Print("Returned value is: {0}", value)
        General.HasValue(value)
    End Sub

    <TestMethod(), TestCategory("Other Objects")> Public Sub GetCommandBoolean()
        Dim obj As New BSOtherObjects
        Dim switch As String = "doRestart"
        Debug.Print(Settings.CommandArgs)
        Debug.Print("Getting switch value for {0}", switch)
        Dim value As Boolean = obj.GetCommand(switch, False,, Settings.CommandArgs)
        Debug.Print("Returned value is: {0}", value)
        General.HasValue(value)
    End Sub
    <TestMethod(), TestCategory("Other Objects")> Public Sub FC()
        Dim testString As String = "This is SQL's first test"
        Dim obj As New BSOtherObjects
        Dim value As String = obj.FC(testString)
        Debug.Print("Before: {0}", testString)
        Debug.Print("Returned value is: {0}", value)
        General.HasValue(value)
    End Sub
    <TestMethod(), TestCategory("Other Objects")> Public Sub ConvertBoolToInt()
        Dim obj As New BSOtherObjects
        Dim testValue As Boolean = True
        Dim value As Boolean = obj.ConvertBoolToInt(testValue)
        Debug.Print("Before: {0}", testValue)
        Debug.Print("Returned value is: {0}", value)
        General.HasValue(value)
    End Sub
    <TestMethod(), TestCategory("Other Objects")> Public Sub ConvertYNtoBool()
        Dim obj As New BSOtherObjects
        Dim testValue As String = "y"
        Dim value As Boolean = obj.ConvertYNtoBool(testValue)
        Debug.Print("Before: {0}", testValue)
        Debug.Print("Returned value is: {0}", value)
        General.HasValue(value)
    End Sub
    <TestMethod(), TestCategory("Other Objects")> Public Sub ConvertIntToBool()
        Dim obj As New BSOtherObjects
        Dim testValue As Integer = "1"
        Dim value As Boolean = obj.ConvertIntToBool(testValue)
        Debug.Print("Before: {0}", testValue)
        Debug.Print("Returned value is: {0}", value)
        General.HasValue(value)
    End Sub
    '<TestMethod()> Public Sub ()
    'End Sub
End Class