'-------------------------------------------
' Created By BurnSoft
' www.burnsoft.net
'-------------------------------------------
Imports System.Text.RegularExpressions
Imports System.Net.Mail
Imports System.Threading
Imports System.Xml
' ReSharper disable once InconsistentNaming
''' <summary>
''' Class BSOtherObjects.  Currently Misc Functions that can be useful for strings, sending email parse through command lines
''' or Convert misc objects
''' </summary>
Public Class BSOtherObjects
    ''' <summary>
    ''' Strings the compare, A quick compairison of string value1 to string value2 if both are the same, then it will return true
    ''' </summary>
    ''' <param name="sValue1">The s value1.</param>
    ''' <param name="sValue2">The s value2.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSOtherObjects <br/>
    ''' <br/>
    ''' Dim obj As New BSOtherObjects
    ''' Dim didPass As Boolean = obj.StringCompare("test","test")
    ''' </example>
    Public Function StringCompare(sValue1 As String, sValue2 As String) As Boolean
        Dim bAns As Boolean = False
        If String.Compare(sValue1, sValue2) = 0 Then
            bAns = True
        End If
        Return bAns
    End Function
    ''' <summary>
    ''' Contentses the exists reg ex.  Using regular expression to search the Content String for a word or phrase
    ''' </summary>
    ''' <param name="sContent">Content of the s.</param>
    ''' <param name="sSearchFor">The s search for.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSOtherObjects <br/>
    ''' <br/>
    ''' Dim obj As New BSOtherObjects
    ''' Dim didPass As Boolean =  obj.ContentsExistsRegEx("This is a test, this is only a test","only")
    ''' </example>
    Public Function ContentsExistsRegEx(sContent As String, sSearchFor As String) As Boolean
        Dim bAns As Boolean
        If (Regex.IsMatch(sContent, sSearchFor, RegexOptions.IgnoreCase)) Then
            bAns = True
        Else
            bAns = False
        End If
        Return bAns
    End Function
    ''' <summary>
    ''' Arrayses the equal. Checks the first array against the second array to see if they are equal to each other
    ''' </summary>
    ''' <param name="first">The first.</param>
    ''' <param name="second">The second.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSOtherObjects <br/>
    ''' <br/>
    '''  Dim obj As New BSOtherObjects
    ''' Dim bytes(1000 * 1000 * 3 - 1) As Byte
    ''' Dim bytes2(1000 * 1000 * 3 - 1) As Byte
    ''' Dim didPass As Boolean = obj.ArraysEqual(bytes, bytes2)
    ''' </example>
    Public Function ArraysEqual(first As Byte(), second As Byte()) As Boolean
        If (first Is second) Then
            Return True
        End If

        If (first Is Nothing OrElse second Is Nothing) Then
            Return False
        End If

        For i As Integer = 0 To first.Length - 1
            If (first(i) <> second(i)) Then
                Return False
            End If
        Next
        Return True
    End Function
    ' ReSharper disable once UnusedMember.Local    
    ''' <summary>
    ''' Sleeps the specified dw milliseconds. Private Sub used for sleep functions
    ''' </summary>
    ''' <param name="dwMilliseconds">The dw milliseconds.</param>
    Private Declare Sub Sleep Lib "kernel32.dll" (ByVal dwMilliseconds As Long)
    ''' <summary>
    ''' Pauses the specified i secs.  Uses the Stopwatch to pause the application for x amount of seconds
    ''' </summary>
    ''' <param name="iSecs">The i secs.</param>
    ''' <param name="iIncrement">The i increment.</param>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSOtherObjects <br/>
    ''' <br/>
    '''  Dim obj As New BSOtherObjects
    ''' Dim didPass As Boolean
    ''' Try
    '''     obj.Pause(100)
    '''     didPass = true
    ''' Catch ex As Exception
    '''     didPass = false
    ''' End Try
    ''' </example>
    Public Sub Pause(ByVal iSecs As Long, Optional ByVal iIncrement As Long = 100)
        Dim stopwatch As Stopwatch = Stopwatch.StartNew
        Thread.Sleep(iSecs * 1000)
        stopwatch.Stop()
    End Sub
    ''' <summary>
    ''' Events the action. More of a place holder for over commands, no code listed in this but has been used for other functions
    ''' </summary>
    ''' <param name="sender">The sender.</param>
    Private Sub EventAction(ByVal sender As Object)

    End Sub
    ''' <summary>
    ''' Sends the email.
    ''' </summary>
    ''' <param name="sTo">The s to.</param>
    ''' <param name="sFrom">The s from.</param>
    ''' <param name="sFromName">Name of the s from.</param>
    ''' <param name="sSubject">The s subject.</param>
    ''' <param name="sMessage">The s message.</param>
    ''' <param name="mailServerName">Name of the mail server.</param>
    ''' <param name="mailServerPort">The mail server port.</param>
    ''' <param name="usehtml">if set to <c>true</c> [usehtml].</param>
    ''' <param name="usebcc">if set to <c>true</c> [usebcc].</param>
    ''' <param name="sBcc">The s BCC.</param>
    ''' <param name="sErrMsg">The s error MSG.</param>
    Public Sub SendMail(ByVal sTo As String, ByVal sFrom As String, ByVal sFromName As String, ByVal sSubject As String, ByVal sMessage As String, ByVal mailServerName As String, Optional ByVal mailServerPort As Integer = 25, Optional ByVal usehtml As Boolean = True, Optional ByVal usebcc As Boolean = False, Optional ByVal sBcc As String = "", Optional ByRef sErrMsg As String = "")
        'NOTE: This sub will send an email to a person or group of people in HTML Format
        Dim strSendFrom As MailAddress = New MailAddress(sFrom, sFromName)
        Dim message As MailMessage = New MailMessage
        Dim i As Integer 
        Dim strSplit As Array = Split(sTo, ",")
        Dim intBound As Integer = UBound(strSplit)
        Dim client As New SmtpClient
        message.From = strSendFrom
        If intBound <> 0 Then
            For i = 0 To intBound
                If Len(strSplit(i)) > 0 Then message.To.Add(strSplit(i))
            Next
        Else
            message.To.Add(sTo)
        End If
        If USEBCC Then
            message.Bcc.Add(sBCC)
        End If
        Try
            message.IsBodyHtml = USEHTML
            message.Subject = sSubject
            message.Body = sMessage
            client.Host = mailServerName
            client.Port = mailServerPort
        Catch ex As Exception
            Dim strFrom As String = "ModGlobal"
            Dim strSubFunc As String = "SendMail"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            sErrMsg = sMsg & "::" & strFrom & "." & strSubFunc
        Finally
            message.Dispose()

        End Try
    End Sub
    ''' <summary>
    ''' Parses the specified s input. Parses s tring of information based on the field or location that it is at in the string
    ''' </summary>
    ''' <param name="sInput">The s input.</param>
    ''' <param name="lField">The l field.</param>
    ''' <param name="sDelimiter">The s delimiter.</param>
    ''' <returns>System.String.</returns>
    Public Function Parse(ByVal sInput As String, ByVal lField As Integer, ByVal sDelimiter As String) As String
        Dim lLen As Long
        Dim lCnt As Long
        Dim lTmp As Long
        Dim sTemp As String
        Dim lPos As Long
        Dim sAns As String

        If lField < 0 Then
            sAns = vbNullString
            Return sAns
            Exit Function
        End If
        sTemp = vbNullString & Trim$(sInput) & sDelimiter
        For lCnt = 1 To lField
            lLen = Len(sTemp)
            lPos = InStr(1, sTemp, sDelimiter)
            lTmp = lLen - lPos
            sTemp = Right$(sTemp, lTmp)
        Next lCnt
        lPos = InStr(1, sTemp, sDelimiter)
        If lPos > 0 Then
            sTemp = Left$(sTemp, lPos - 1)
        End If
        sAns = Trim$(sTemp)
        Return sAns
    End Function

    ''' <summary>
    ''' Gets the XML node.  Gets the instance of the selected XML node and returns as string
    ''' </summary>
    ''' <param name="instance">The instance.</param>
    ''' <returns>System.String.</returns>
    Public Function GetXmlNode(ByVal instance As XmlNode) As String
        'NOTE:This will Get the Values that are stored in the XML Note.
        Dim myAns As String = ""
        On Error Resume Next
        myAns = instance.InnerText
        Return myAns
    End Function
    ''' <summary>
    ''' Founds the specified text.
    '''  Searchs one string for a key word to see if there is a match
    ''' txt is the string of information you want to search
    ''' strSearch is the word/value that you are looking for
    ''' </summary>
    ''' <param name="txt">The text.</param>
    ''' <param name="strSearch">The string search.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSOtherObjects <br/>
    ''' <br/>
    ''' Dim obj As New BSOtherObjects
    ''' Dim didPass as Boolean = obj.Found("This is a test, this is only a test","only")
    ''' </example>
    Function Found(ByVal txt As String, ByVal strSearch As String) As Boolean
        Dim bAns As Boolean = False
        Dim pos As Integer = 0
        pos = InStr(1, Txt, strSearch, vbTextCompare)
        If pos <> 0 Then
            bAns = True
        Else
            bAns = False
        End If
        Return bAns
    End Function
    ''' <summary>
    ''' Gets the loggedon user. This uses WMI to get the user that is logged on the local machine based on the who is signed on at the time
    ''' This scrolls through all the running processes on the PC to determine who is running the "explorer.exe" process. It then returns the username ready for comparison.
    ''' </summary>
    ''' <returns>System.String.</returns>
    '''  <example>
    ''' SEE UNIT TESTS @ UnitTest_BSOtherObjects <br/>
    ''' <br/>
    '''  Dim obj As New BSOtherObjects
    ''' Dim value As String = obj.GetLoggedonUser()
    ''' </example>
    Public Function GetLoggedonUser() As String
        Dim sAns As String = ""
        Dim strCurrentUser As String = ""
        Dim moReturn As Management.ManagementObjectCollection
        Dim moSearch As Management.ManagementObjectSearcher
        Dim mo As Management.ManagementObject

        moSearch = New Management.ManagementObjectSearcher("Select * from Win32_Process")
        moReturn = moSearch.Get

        For Each mo In moReturn
            Dim arOwner(2) As String
            mo.InvokeMethod("GetOwner", arOwner)
            Dim strOut As String = String.Format("{0} Owner {1} Domain {2}", mo("Name"), arOwner(0), arOwner(1))
            If (mo("Name") = "explorer.exe") Then
                sAns = String.Format("{0}", arOwner(0))
            End If
        Next
        Return sAns
    End Function
    ''' <summary>
    ''' Detects the switch.Loop Through one of the Values passed in the command arguments and count the first non alphabetical 
    ''' characters as the switch parameter that needs to be filtered out.
    ''' </summary>
    ''' <param name="sValue">The s value.</param>
    ''' <returns>System.String.</returns>
    '''  <example>
    ''' <br/>
    ''' Dim Switch as string = detectSwitch("/dothis=true")
    ''' </example>
    Private Function detectSwitch(sValue As String) As String
        Dim sAns As String = ""
        For Each c As Char In sValue
            If Not Char.IsLetter(c) Then
                If sAns.Equals("") Then
                    sAns = c.ToString
                Else
                    sAns &= c.ToString
                End If
            Else
                Exit For
            End If
        Next
        Return sAns
    End Function
    ''' <summary>
    ''' The Get Command will looks for Command Line Arguments, this on will return as string
    ''' the switch will be something like /mystring="this is fun"
    ''' if it is just /mystring then it will return what is set in the sDefault string.
    ''' </summary>
    ''' <param name="strLookFor">The string look for.</param>
    ''' <param name="sDefault">The s default.</param>
    ''' <param name="didExist">if set to <c>true</c> [did exist].</param>
    ''' <param name="args">The arguments.</param>
    ''' <returns>System.String.</returns>
    '''  <example>
    ''' SEE UNIT TESTS @ UnitTest_BSOtherObjects <br/>
    ''' <br/>
    ''' 
    ''' </example>
    Public Function GetCommand(ByVal strLookFor As String, ByVal sDefault As String, Optional ByRef didExist As Boolean = False, Optional ByVal args As string = "") As String
        Dim sAns As String = ""
        DidExist = False
        Dim cmdLine() As String
        If (args.Length = 0) Then
            cmdLine = System.Environment.GetCommandLineArgs
        Else 
            cmdLine = Split(args," ")
        End If

        
        Dim i As Integer = 0
        Dim intCount As Integer = cmdLine.Length
        Dim strValue As String = ""
        Dim switch As String = ""
        If intCount > 1 Then
            For i = 1 To intCount - 1
                strValue = cmdLine(i)
                switch = detectSwitch(strValue)
                strValue = Replace(strValue, switch, "")
                Dim strSplit() As String = Split(strValue, "=")
                Dim intLBound As Integer = LBound(strSplit)
                Dim intUBound As Integer = UBound(strSplit)
                If LCase(strSplit(intLBound)) = LCase(strLookFor) Then
                    If intUBound <> 0 Then
                        sAns = strSplit(intUBound)
                    Else
                        sAns = sDefault
                    End If
                    DidExist = True
                    Exit For
                End If
            Next
        End If
        Return LCase(sAns)
    End Function
    ''' <summary>
    ''' The Get Command will looks for Command Line Arguments, this on will return as long
    ''' the switch will be something like /mylongvalue=92
    ''' if it is just /mylongvalue it will return the lDefault value
    ''' </summary>
    ''' <param name="strLookFor">The string look for.</param>
    ''' <param name="lDefault">The l default.</param>
    ''' <param name="didExist">if set to <c>true</c> [did exist].</param>
    ''' <param name="args">The arguments.</param>
    ''' <returns>System.Int64.</returns>
    '''  <example>
    ''' SEE UNIT TESTS @ UnitTest_BSOtherObjects <br/>
    ''' <br/>
    ''' </example>
    Public Function GetCommand(ByVal strLookFor As String, ByVal lDefault As Long, Optional ByRef didExist As Boolean = False, Optional ByVal args As string = "") As Long
        Dim lAns As Long = 0
        DidExist = False
        Dim cmdLine() As String
        If (args.Length = 0) Then
            cmdLine = System.Environment.GetCommandLineArgs
        Else 
            cmdLine = Split(args," ")
        End If
        Dim i As Integer = 0
        Dim intCount As Integer = cmdLine.Length
        Dim strValue As String = ""
        Dim switch As String = ""
        If intCount > 1 Then
            For i = 1 To intCount - 1
                strValue = cmdLine(i)
                switch = detectSwitch(strValue)
                strValue = Replace(strValue, switch, "")
                Dim strSplit() As String = Split(strValue, "=")
                Dim intLBound As Integer = LBound(strSplit)
                Dim intUBound As Integer = UBound(strSplit)
                If LCase(strSplit(intLBound)) = LCase(strLookFor) Then
                    If intUBound <> 0 Then
                        lAns = strSplit(intUBound)
                    Else
                        lAns = lDefault
                    End If
                    DidExist = True
                    Exit For
                End If
            Next
        End If
        Return lAns
    End Function
    ''' <summary>
    ''' The Get Command will looks for Command Line Arguments, this on will return as boolean.
    ''' if the command is /swtich it will return as true since it did exist
    ''' you can also use /switch=false
    ''' </summary>
    ''' <param name="strLookFor">The string look for.</param>
    ''' <param name="bDefault">if set to <c>true</c> [b default].</param>
    ''' <param name="didExist">if set to <c>true</c> [did exist].</param>
    ''' <param name="args">The arguments.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    '''  <example>
    ''' SEE UNIT TESTS @ UnitTest_BSOtherObjects <br/>
    ''' <br/>
    ''' </example>
    Public Function GetCommand(ByVal strLookFor As String, ByVal bDefault As Boolean, Optional ByRef didExist As Boolean = False, Optional ByVal args As string = "") As Boolean
        Dim bAns As Boolean = bDefault
        DidExist = False
        Dim cmdLine() As String
        If (args.Length = 0) Then
            cmdLine = System.Environment.GetCommandLineArgs
        Else 
            cmdLine = Split(args," ")
        End If
        Dim i As Integer = 0
        Dim intCount As Integer = cmdLine.Length
        Dim strValue As String = ""
        Dim switch As String = ""
        If intCount > 1 Then
            For i = 1 To intCount - 1
                strValue = cmdLine(i)
                switch = detectSwitch(strValue)
                strValue = Replace(strValue, switch, "")
                Dim strSplit() As String = Split(strValue, "=")
                Dim intLBound As Integer = LBound(strSplit)
                Dim intUBound As Integer = UBound(strSplit)
                If LCase(strSplit(intLBound)) = LCase(strLookFor) Then
                    If intUBound <> 0 Then
                        bAns = strSplit(intUBound)
                    Else
                        bAns = True
                    End If
                    DidExist = True
                    Exit For
                End If
            Next
        End If
        Return bAns
    End Function
    ''' <summary>
    ''' Usually Stands for Fluff Content, this is usually good for formating SQL Strings
    ''' taking away the single qoute and putting a single qoute twice to prevent errors
    ''' on SQL commands.
    ''' </summary>
    ''' <param name="sValue">The s value.</param>
    ''' <param name="DefaultValue">The default value.</param>
    ''' <returns>System.String.</returns>
    '''  <example>
    ''' SEE UNIT TESTS @ UnitTest_BSOtherObjects <br/>
    ''' <br/>
    ''' </example>
    Public Function FC(ByVal sValue As String, Optional ByVal DefaultValue As String = "") As String
        Dim sAns As String = ""
        sAns = Replace(sValue, "'", "''")
        If DefaultValue.Length > 0 Then If sAns.Length = 0 Then sAns = DefaultValue
        Return sAns
    End Function
    ''' <summary>
    ''' Converts the bool to int.
    ''' </summary>
    ''' <param name="bValue">if set to <c>true</c> [b value].</param>
    ''' <returns>System.Int32.</returns>
    '''  <example>
    ''' SEE UNIT TESTS @ UnitTest_BSOtherObjects <br/>
    ''' <br/>
    ''' </example>
    Public Function ConvertBoolToInt(bValue As Boolean) As Integer
        Dim iAns As Integer = 0
        If bValue Then iAns = 1
        Return iAns
    End Function
    ''' <summary>
    ''' Converts a y/Y or n/N value to boolean
    ''' </summary>
    ''' <param name="sValue">The s value.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    '''  <example>
    ''' SEE UNIT TESTS @ UnitTest_BSOtherObjects <br/>
    ''' <br/>
    ''' </example>
    Public Function ConvertYNtoBool(sValue As String) As Boolean
        Dim bAns As Boolean = False
        If LCase(sValue) = "y" Then bAns = True
        Return bAns
    End Function
    ''' <summary>
    ''' Converts a Integer to to boolean value, if it is not 0 it is true
    ''' </summary>
    ''' <param name="iValue">The i value.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    '''  <example>
    ''' SEE UNIT TESTS @ UnitTest_BSOtherObjects <br/>
    ''' <br/>
    ''' </example>
    Public Function ConvertIntToBool(iValue As Integer) As Boolean
        Dim bAns As Boolean = False
        If iValue <> 0 Then bAns = True
        Return bAns
    End Function


End Class
