'-------------------------------------------
' Created By BurnSoft
' www.burnsoft.net
'-------------------------------------------
Imports Microsoft.Win32
' ReSharper disable once InconsistentNaming
Public Class BSRegistry
' ReSharper disable once InconsistentNaming
    Private _RegPath As String
    ''' <summary>
    ''' Set the Default registry path
    ''' </summary>
    ''' <returns></returns>
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
    ''' List all the entries in the registry
    ''' </summary>
    ''' <param name="sKey"></param>
    ''' <returns>collection</returns>
    Function Enum_Registry_Entries(sKey As String) As Collection
        Dim colKey As New Microsoft.VisualBasic.Collection()

        Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey(sKey, False)
        Dim subKeyNames() As String = key.GetSubKeyNames()
        Dim index As Integer
        Dim subKey As RegistryKey
        Dim keyValue As String = ""
        colKey.Clear()
        For index = 0 To key.SubKeyCount - 1
            subKey = Registry.LocalMachine.OpenSubKey(sKey + "\" + subKeyNames(index), False)
            keyValue = CType(subKey.GetValue("DisplayName", ""), String)
            colKey.Add(keyValue)
        Next
        Return colKey
    End Function
    ''' <summary>
    ''' List all the registry entries with their values
    ''' </summary>
    ''' <param name="sKey"></param>
    ''' <param name="sValue"></param>
    ''' <returns>collection</returns>
    Function Enum_Registry_Entries_WithValue(sKey As String, sValue As String) As Collection
        Dim colKey As New Microsoft.VisualBasic.Collection()

        Dim Key As RegistryKey = Registry.LocalMachine.OpenSubKey(sKey, False)
        Dim SubKeyNames() As String = Key.GetSubKeyNames()
        Dim Index As Integer
        Dim SubKey As RegistryKey
        Dim KeyValue As String = ""
        colKey.Clear()
        For Index = 0 To Key.SubKeyCount - 1
            SubKey = Registry.LocalMachine.OpenSubKey(sKey + "\" + SubKeyNames(Index), False)
            If Not SubKey.GetValue(sValue, "") Is "" Then
                KeyValue = CType(SubKey.GetValue("DisplayName", ""), String)
                colKey.Add(KeyValue)
            End If
        Next
        Return colKey
    End Function
    ''' <summary>
    ''' Creates the sub key in CurrentUser.
    ''' </summary>
    ''' <param name="strValue">The string value.</param>
    Public Sub CreateSubKey(ByVal strValue As String, Optional ByRef errMsg As String = "")
        Try 
            Microsoft.Win32.Registry.CurrentUser.CreateSubKey(strValue)
        Catch ex As Exception
            errMsg = ex.Message
        End Try
    End Sub
    ''' <summary>
    ''' Check to see if a sub registry key exists in current user
    ''' </summary>
    ''' <param name="strValue"></param>
    ''' <returns>true/false</returns>
    Public Function RegSubKeyExists(ByVal strValue As String, Optional ByRef errMsg As String = "") As Boolean
        Dim bAns As Boolean = False
        Try
            Dim myReg As RegistryKey
            myReg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(strValue, True)
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
    ''' Get the Regstry Sub Key Value in the Current User
    ''' </summary>
    ''' <param name="strKey"></param>
    ''' <param name="strValue"></param>
    ''' <param name="strDefault"></param>
    ''' <returns>string</returns>
    Public Function GetRegSubKeyValue(ByVal strKey As String, ByVal strValue As String, ByVal strDefault As String) As String
        Dim sAns As String = ""
        Dim strMsg As String = ""
        Dim myReg As RegistryKey
        Try
            If RegSubKeyExists(strKey) Then
                myReg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(strKey, True)
                If Len(myReg.GetValue(strValue)) > 0 Then
                    sAns = myReg.GetValue(strValue)
                Else
                    myReg.SetValue(strValue, strDefault)
                    sAns = strDefault
                End If
            Else
                Call CreateSubKey(strKey)
                myReg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(strKey, True)
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
    Public Function SettingsExists() As Boolean
        Dim bAns As Boolean = False
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
    Public Function GetViewSettings(ByVal sKey As String, Optional ByVal sDefault As String = "") As String
        Dim sAns As String = ""
        Dim strValue As String = _RegPath & "\Settings"
        sAns = GetRegSubKeyValue(strValue, sKey, sDefault)
        Return sAns
    End Function
End Class
