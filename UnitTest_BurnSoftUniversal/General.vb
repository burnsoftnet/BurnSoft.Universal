
<TestClass()> Public Class General
    Public Shared Sub HasValue(sValue As String,Optional errMsg As String = "")
        Dim didPass As Boolean = false
        If not IsDBNull(errMsg) then 
            errMsg = ""
        End If
        
        If (errMsg.Length > 0)
            Debug.Print("ERROR!!")
            Debug.Print(errMsg)
        Else 
            If (sValue.Length > 0)
                Debug.Print(sValue)
                didPass = True
            End If
        End If
        Assert.AreEqual(didPass, True)
    End Sub

    Public Shared Sub HasValue(lValue As Long,Optional zeroOk As Boolean = false, Optional errMsg As String = "")
        Dim didPass as Boolean = false
        if Not zeroOk Then
            If (lValue > 0) Then
                didPass = True
                Debug.Print("{0}",lValue)
            Else 
                Debug.Print("Value is Zero!!")
            End If
        Else 
            didPass = True
            Debug.Print("{0}",lValue)
        End If
        Assert.AreEqual(didPass, True)
    End Sub
    Public Shared Sub HasValue(lValue As Double,Optional zeroOk As Boolean = false, Optional errMsg As String = "")
        Dim didPass as Boolean = false
        if Not zeroOk Then
            If (lValue > 0) Then
                didPass = True
                Debug.Print("{0}",lValue)
            Else 
                Debug.Print("Value is Zero!!")
            End If
        Else 
            didPass = True
            Debug.Print("{0}",lValue)
        End If
        Assert.AreEqual(didPass, True)
    End Sub
    Public Shared Sub HasValue (bValue As Boolean, Optional errMsg As String = "")
        Assert.AreEqual(bValue, True)
    End Sub
End Class
