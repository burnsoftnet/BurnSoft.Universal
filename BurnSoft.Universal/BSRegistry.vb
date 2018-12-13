'-------------------------------------------
' Created By BurnSoft
' www.burnsoft.net
'-------------------------------------------
Imports Microsoft.Win32
''' <summary>
''' Class BSRegistry.  Class Containing functions used to read write or manage the windows registry.  Mostly for Current User
''' </summary>
' ReSharper disable once InconsistentNaming
Public Class BSRegistry
' ReSharper disable once InconsistentNaming
    Private _RegPath As String
    ''' <summary>
    ''' Set the Default registry path
    ''' </summary>
    ''' <returns></returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSRegistry <br/>
    ''' <br/>
    ''' Dim obj As BSRegistry = New BSRegistry()<br/>
    ''' Dim value as String = obj.DefaultRegPath<br/>
    ''' </example>
    Public Property DefaultRegPath() As String
        Get
            If Len(_RegPath) = 0 Then _RegPath = "Software\\BurnSoft\\"
            Return _RegPath
        End Get
        Set(ByVal value As String)
            _RegPath = value
        End Set
    End Property
    ''' <summary>
    ''' Enums the registry entries. Initially made to search for values in a tree if it exists. for example
    ''' in Services, any Windows service that is Displayed in services has a Display Name, so this can look
    ''' through all the reg keys in Services for ones that have a display name and add it to the collection
    ''' </summary>
    ''' <param name="sKey">The s key.</param>
    ''' <param name="lookfor">The lookfor.</param>
    ''' <param name="errMsg">The error MSG.</param>
    ''' <returns>Collection.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSRegistry <br/>
    ''' <br/>
    ''' Dim errOut As String = "" <br/>
    ''' Dim regKey As String = "SYSTEM\CurrentControlSet\Services" <br/>
    ''' Dim regCollection As Collection = BSRegistry.Enum_Registry_Entries(regKey,"DisplayName", errOut)     <br/>
    ''' for x = 1 To regCollection.Count - 1 <br/>
    ''' Dim sValue As String = regCollection.Item(x).ToString() <br/>
    '''     Debug.Print(sValue) <br/>
    ''' Next <br/>
    ''' </example>
    Public Shared Function Enum_Registry_Entries(sKey As String, lookfor As String, Optional ByRef errMsg As string = "") As Collection
        Dim colKey As New Collection()

        Try
            Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey(sKey, False)
            Dim subKeyNames() As String = key.GetSubKeyNames()
            Dim index As Integer
            Dim subKey As RegistryKey
            Dim keyValue As String
            colKey.Clear()
            For index = 0 To key.SubKeyCount - 1
                subKey = Registry.LocalMachine.OpenSubKey(sKey + "\" + subKeyNames(index), False)
                keyValue = CType(subKey.GetValue(lookfor, ""), String)
                If keyValue.Length > 0 Then
                    colKey.Add(keyValue)    
                End If
            Next
        Catch ex As Exception
            errMsg = ex.Message
        End Try
        Return colKey
    End Function
    ''' <summary>
    ''' List all the registry entries with their values
    ''' </summary>
    ''' <param name="sKey"></param>
    ''' <param name="sValue"></param>
    ''' <returns>collection</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSRegistry <br/>
    ''' <br/>
    ''' 
    ''' </example>
    Function Enum_Registry_Entries_WithValue(sKey As String, sValue As String) As Collection
        Dim colKey As New Collection()

        Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey(sKey, False)
        Dim subKeyNames() As String = key.GetSubKeyNames()
        Dim index As Integer
        Dim subKey As RegistryKey
        Dim keyValue As String
        colKey.Clear()
        For index = 0 To key.SubKeyCount - 1
            subKey = Registry.LocalMachine.OpenSubKey(sKey + "\" + subKeyNames(index), False)
            If Not subKey.GetValue(sValue, "") Is "" Then
                keyValue = CType(subKey.GetValue("DisplayName", ""), String)
                colKey.Add(keyValue)
            End If
        Next
        Return colKey
    End Function
    ''' <summary>
    ''' Creates the sub key in CurrentUser.
    ''' </summary>
    ''' <param name="strValue">The string value.</param>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSRegistry <br/>
    ''' <br/>
    ''' Dim errOut As String = ""<br/>
    ''' Dim obj As BSRegistry = New BSRegistry()<br/>
    ''' obj.CreateSubKey(Settings.RegSubkey, errOut)<br/>
    ''' </example>
    Public Sub CreateSubKey(ByVal strValue As String, Optional ByRef errMsg As String = "")
        Try
            Registry.CurrentUser.CreateSubKey(strValue)
        Catch ex As Exception
            errMsg = ex.Message
        End Try
    End Sub
    ''' <summary>
    ''' Check to see if a sub registry key exists in current user
    ''' </summary>
    ''' <param name="strValue"></param>
    ''' <returns>true/false</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSRegistry <br/>
    ''' <br/>
    ''' Dim errOut As String = ""<br/>
    ''' Dim obj As BSRegistry = New BSRegistry()<br/>
    ''' Dim didPass As Boolean = obj.RegSubKeyExists(Settings.RegSubkey, errOut)<br/>
    ''' </example>
    Public Function RegSubKeyExists(ByVal strValue As String, Optional ByRef errMsg As String = "") As Boolean
        Dim bAns As Boolean
        Try
            Dim myReg As RegistryKey
            myReg = Registry.CurrentUser.OpenSubKey(strValue, True)
            If myReg Is Nothing Then
                bAns = False
            Else
                bAns = True
            End If
        Catch ex As Exception
            bAns = False
            errMsg = ex.Message
        End Try
        Return bAns
    End Function
    ''' <summary>
    ''' Sets the reg sub key value.
    ''' </summary>
    ''' <param name="regPath">The reg path.</param>
    ''' <param name="sKey">The s key.</param>
    ''' <param name="sValue">The s value.</param>
    ''' <param name="sDefault">The s default.</param>
    ''' <param name="errOut">The error out.</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSRegistry <br/>
    ''' <br/>
    ''' Dim errOut As String = ""
    ''' Dim obj As BSRegistry = New BSRegistry() <br/>
    ''' Dim didPass As Boolean = obj.SetRegSubKeyValue(Settings.RegSubkey,Settings.RegSubkeyName,Settings.RegSubkeyValue,"", errOut) <br/>
    ''' Debug.Print("Wrote value {0} to HCLM\{1}\{2}", obj.GetRegSubKeyValue(Settings.RegSubkey, Settings.RegSubkeyName,""), Settings.RegSubkey, Settings.RegSubkeyName) <br/>
    ''' </example>
    Public Function SetRegSubKeyValue(ByVal regPath As String, ByVal sKey As String, ByVal sValue As String, ByVal sDefault As string, Optional ByRef errOut As String = "" ) As Boolean
        Dim bAns as Boolean = False
        Try
            Dim myReg as RegistryKey
            Registry.CurrentUser.OpenSubKey(regPath, True)
            myReg = Registry.CurrentUser.CreateSubKey(regPath)
            myReg.SetValue(sKey, sValue)
            myReg.Close()
            bAns = True
        Catch ex As Exception
            errOut = ex.Message
        End Try
        Return bAns
    End Function
    ''' <summary>
    ''' Get the Regstry Sub Key Value in the Current User
    ''' </summary>
    ''' <param name="strKey"></param>
    ''' <param name="strValue"></param>
    ''' <param name="strDefault"></param>
    ''' <returns>string</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSRegistry <br/>
    ''' <br/>
    ''' Dim errOut As String = "" <br/>
    ''' Dim obj As BSRegistry = New BSRegistry() <br/>
    ''' Dim value As string = obj.GetRegSubKeyValue(Settings.RegSubkey, Settings.RegSubkeyName,"") <br/>
    ''' </example>
    Public Function GetRegSubKeyValue(ByVal strKey As String, ByVal strValue As String, ByVal strDefault As String) As String
        Dim sAns As String

        Dim myReg As RegistryKey
        Try
            If RegSubKeyExists(strKey) Then
                myReg = Registry.CurrentUser.OpenSubKey(strKey, True)
                If Len(myReg.GetValue(strValue)) > 0 Then
                    sAns = myReg.GetValue(strValue)
                Else
                    myReg.SetValue(strValue, strDefault)
                    sAns = strDefault
                End If
            Else
                Call CreateSubKey(strKey)
                myReg = Registry.CurrentUser.OpenSubKey(strKey, True)
                myReg.SetValue(strValue, strDefault)
                sAns = strDefault
            End If
        Catch ex As Exception
            sAns = strDefault
        End Try
        Return sAns
    End Function
    ''' <summary>
    ''' Check to see if the Setting Registry Key is created in the the current user + defaultpath
    ''' </summary>
    ''' <returns></returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSRegistry <br/>
    ''' <br/>
    ''' 
    ''' </example>
    Public Function SettingsExists() As Boolean
        Dim bAns As Boolean
        Dim myReg As RegistryKey
        Dim strValue As String = _RegPath & "\Settings"
        On Error Resume Next
        myReg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(strValue, True)
        If myReg Is Nothing Then
            bAns = False
        Else
            bAns = True
        End If
        Return bAns
    End Function
    ''' <summary>
    ''' view a value in the settings sub set
    ''' </summary>
    ''' <param name="sKey"></param>
    ''' <param name="sDefault"></param>
    ''' <returns>string</returns>
    ''' <example>
    ''' SEE UNIT TESTS @ UnitTest_BSRegistry <br/>
    ''' <br/>
    ''' 
    ''' </example>
    Public Function GetViewSettings(ByVal sKey As String, Optional ByVal sDefault As String = "") As String
        Dim sAns As String
        Dim strValue As String = _RegPath & "\Settings"
        sAns = GetRegSubKeyValue(strValue, sKey, sDefault)
        Return sAns
    End Function
End Class
