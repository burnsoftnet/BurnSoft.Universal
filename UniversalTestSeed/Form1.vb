'-------------------------------------------
' Created By BurnSoft
' www.burnsoft.net
'-------------------------------------------
Imports BurnSoft.Universal
Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtDevice.Text = "localhost"
        txtport.Text = "80"
        cmbProto.Text = "TCP"

        txtURL.Text = "http://www.google.com"
        chkGetContent.Checked = True
        chkUseAuth.Checked = False
        chkNTLM.Enabled = False
        txtUserName.Enabled = False
        txtPassword.Enabled = False
        txtDomain.Enabled = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Dim obj As New BSNetwork
        Dim iPort As Long = CLng(txtport.Text)
        Dim sDevice As String = txtDevice.Text
        Dim ErrMsg As String = ""
        Dim MyProType As BSNetwork.IPProtocolType

        Select Case UCase(cmbProto.Text)
            Case "TCP"
                MyProType = BSNetwork.IPProtocolType.TCP
            Case "UDP"
                MyProType = BSNetwork.IPProtocolType.UDP
            Case "IPX"
                MyProType = BSNetwork.IPProtocolType.IPX
            Case "SPX"
                MyProType = BSNetwork.IPProtocolType.SPX

        End Select

        If obj.PortIsUP(sDevice, iPort, MyProType, ErrMsg) Then
            MsgBox("Port " & iPort & " is up!")
        Else
            If Len(ErrMsg) = 0 Then
                MsgBox("Port " & iPort & " is down!")
            Else
                MsgBox(ErrMsg)
            End If
        End If
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim ObjW As New BSWebResponse
        Dim sURL As String = txtURL.Text
        Dim ErrorMsg As String = ""
        Dim sContext As String = ""
        If chkUseAuth.Checked Then
            ObjW.UseAuthentication = True
            ObjW.UserName = txtUserName.Text
            ObjW.Password = txtPassword.Text
            ObjW.Domain = txtDomain.Text
            ObjW.UseNTLM = chkNTLM.Checked
        End If
        If ObjW.SiteIsUp(sURL, sContext, ErrorMsg) Then
            If chkGetContent.Checked Then TextBox2.Text = sContext
        Else
            MsgBox(ErrorMsg)
        End If
        If chkCompair.Checked Then

            Dim array1() As Byte = System.Text.Encoding.ASCII.GetBytes(TextBox3.Text)
            Dim array2() As Byte = System.Text.Encoding.ASCII.GetBytes(TextBox2.Text)
            If ObjW.ArraysEqual(array1, array2) Then
                MsgBox("array site compair is the same")
            Else
                MsgBox("array site compair is different")
            End If

        End If
        If chkLookUp.Checked Then
            Dim sLookup As String = txtLookUP.Text
            If ObjW.ContentsExistsRegEx(TextBox2.Text, "\b(" & sLookup & ")\b") Then
                MsgBox("Found Word/Phrase: " & sLookup)
            Else
                MsgBox("Unable to find " & sLookup)
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        TextBox3.Text = TextBox2.Text
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        TextBox3.Text = ""
    End Sub

    Private Sub chkNTLM_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkNTLM.CheckedChanged
        If chkNTLM.Checked Then
            txtUserName.Enabled = False
            txtPassword.Enabled = False
            txtDomain.Enabled = False
        Else
            txtUserName.Enabled = True
            txtPassword.Enabled = True
            txtDomain.Enabled = True
        End If
    End Sub

    Private Sub chkUseAuth_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkUseAuth.CheckedChanged
        If chkUseAuth.Checked Then
            chkNTLM.Enabled = True
            txtUserName.Enabled = True
            txtPassword.Enabled = True
            txtDomain.Enabled = True
        Else
            chkNTLM.Enabled = False
            txtUserName.Enabled = False
            txtPassword.Enabled = False
            txtDomain.Enabled = False
        End If
    End Sub
End Class
