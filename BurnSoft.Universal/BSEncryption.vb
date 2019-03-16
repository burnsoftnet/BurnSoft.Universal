'-------------------------------------------
' Created By BurnSoft
' www.burnsoft.net
'-------------------------------------------
Imports System.IO
Imports System.Security.Cryptography
''' <summary>
''' Class BSEncryption.
''' </summary>
Public Class BSEncryption
    ''' <summary>
    ''' Enum SHATYPE
    ''' </summary>
    Public Enum SHATYPE
        SHA1 = 1
        SHA256 = 256
        SHA384 = 384
        SHA515 = 512
    End Enum
    ''' <summary>
    ''' Gets the check sum io.
    ''' </summary>
    ''' <param name="sValue">The s value.</param>
    ''' <returns>System.String.</returns>
    Function GetCheckSumIO(sValue As String) As String
        'Using Stream As Filestream = System.
        Return ""
    End Function
    ''' <summary>
    ''' Gets the check sum.
    ''' </summary>
    ''' <param name="file">The file.</param>
    ''' <returns>System.String.</returns>
    Function GetCheckSum(file As String) As String
        Using stream As FileStream = System.IO.File.OpenRead(file)
            Dim sha As SHA1Managed = New SHA1Managed
            Dim checksum As [Byte]() = sha.ComputeHash(stream)
            Return BitConverter.ToString(checksum).Replace("-", String.Empty)
        End Using
    End Function
    ''' <summary>
    ''' Gets the check sum256.
    ''' </summary>
    ''' <param name="file">The file.</param>
    ''' <returns>System.String.</returns>
    Function GetCheckSum256(file As String) As String
        Using stream As FileStream = System.IO.File.OpenRead(file)
            Dim sha As SHA256Managed = New SHA256Managed
            Dim checksum As [Byte]() = sha.ComputeHash(stream)
            Return BitConverter.ToString(checksum).Replace("-", String.Empty)
        End Using
    End Function
    ''' <summary>
    ''' Gets the check sum384.
    ''' </summary>
    ''' <param name="file">The file.</param>
    ''' <returns>System.String.</returns>
    Function GetCheckSum384(file As String) As String
        Using stream As FileStream = System.IO.File.OpenRead(file)
            Dim sha As SHA384Managed = New SHA384Managed
            Dim checksum As [Byte]() = sha.ComputeHash(stream)
            Return BitConverter.ToString(checksum).Replace("-", String.Empty)
        End Using
    End Function
    ''' <summary>
    ''' Gets the check sum512.
    ''' </summary>
    ''' <param name="file">The file.</param>
    ''' <returns>System.String.</returns>
    Function GetCheckSum512(file As String) As String
        Using stream As FileStream = System.IO.File.OpenRead(file)
            Dim sha As SHA512Managed = New SHA512Managed
            Dim checksum As [Byte]() = sha.ComputeHash(stream)
            Return BitConverter.ToString(checksum).Replace("-", String.Empty)
        End Using
    End Function
    ''' <summary>
    ''' Returns the sha check sum.
    ''' </summary>
    ''' <param name="sFile">The s file.</param>
    ''' <param name="MySHAType">Type of my sha.</param>
    ''' <returns>System.String.</returns>
    Public Function ReturnSHACheckSum(sFile As String, MySHAType As SHATYPE) As String
        Dim sAns As String = ""
        Select Case MySHAType
            Case SHATYPE.SHA1
                sAns = GetCheckSum(sFile)
            Case SHATYPE.SHA256
                sAns = GetCheckSum256(sFile)
            Case SHATYPE.SHA384
                sAns = GetCheckSum384(sFile)
            Case SHATYPE.SHA515
                sAns = GetCheckSum512(sFile)
            Case Else
                sAns = GetCheckSum(sFile)
        End Select
        Return sAns
    End Function
End Class
