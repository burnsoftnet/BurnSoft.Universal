Imports System.IO
Imports System.Security.Cryptography
Public Class BSEncryption
    Public Enum SHATYPE
        SHA1 = 1
        SHA256 = 256
        SHA384 = 384
        SHA515 = 512
    End Enum
    Function GetCheckSumIO(sValue As String) As String
        'Using Stream As Filestream = System.
        Return ""
    End Function
    Function GetCheckSum(file As String) As String
        Using stream As FileStream = System.IO.File.OpenRead(file)
            Dim sha As SHA1Managed = New SHA1Managed
            Dim checksum As [Byte]() = sha.ComputeHash(stream)
            Return BitConverter.ToString(checksum).Replace("-", String.Empty)
        End Using
    End Function
    Function GetCheckSum256(file As String) As String
        Using stream As FileStream = System.IO.File.OpenRead(file)
            Dim sha As SHA256Managed = New SHA256Managed
            Dim checksum As [Byte]() = sha.ComputeHash(stream)
            Return BitConverter.ToString(checksum).Replace("-", String.Empty)
        End Using
    End Function
    Function GetCheckSum384(file As String) As String
        Using stream As FileStream = System.IO.File.OpenRead(file)
            Dim sha As SHA384Managed = New SHA384Managed
            Dim checksum As [Byte]() = sha.ComputeHash(stream)
            Return BitConverter.ToString(checksum).Replace("-", String.Empty)
        End Using
    End Function
    Function GetCheckSum512(file As String) As String
        Using stream As FileStream = System.IO.File.OpenRead(file)
            Dim sha As SHA512Managed = New SHA512Managed
            Dim checksum As [Byte]() = sha.ComputeHash(stream)
            Return BitConverter.ToString(checksum).Replace("-", String.Empty)
        End Using
    End Function
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
