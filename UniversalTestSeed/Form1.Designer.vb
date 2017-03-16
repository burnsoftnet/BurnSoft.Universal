<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDevice = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtport = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbProto = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.chkGetContent = New System.Windows.Forms.CheckBox()
        Me.chkCompair = New System.Windows.Forms.CheckBox()
        Me.chkLookUp = New System.Windows.Forms.CheckBox()
        Me.chkUseAuth = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtDomain = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.txtLookUP = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.chkNTLM = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Device Name"
        '
        'txtDevice
        '
        Me.txtDevice.Location = New System.Drawing.Point(90, 20)
        Me.txtDevice.Name = "txtDevice"
        Me.txtDevice.Size = New System.Drawing.Size(114, 20)
        Me.txtDevice.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(529, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Scan"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Port #:"
        '
        'txtport
        '
        Me.txtport.Location = New System.Drawing.Point(255, 20)
        Me.txtport.Name = "txtport"
        Me.txtport.Size = New System.Drawing.Size(100, 20)
        Me.txtport.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(371, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Protocol:"
        '
        'cmbProto
        '
        Me.cmbProto.FormattingEnabled = True
        Me.cmbProto.Items.AddRange(New Object() {"TCP", "UDP", "IPX", "SPX"})
        Me.cmbProto.Location = New System.Drawing.Point(427, 19)
        Me.cmbProto.Name = "cmbProto"
        Me.cmbProto.Size = New System.Drawing.Size(85, 21)
        Me.cmbProto.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Web URL:"
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(90, 59)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(174, 20)
        Me.txtURL.TabIndex = 8
        '
        'chkGetContent
        '
        Me.chkGetContent.AutoSize = True
        Me.chkGetContent.Location = New System.Drawing.Point(290, 62)
        Me.chkGetContent.Name = "chkGetContent"
        Me.chkGetContent.Size = New System.Drawing.Size(71, 17)
        Me.chkGetContent.TabIndex = 9
        Me.chkGetContent.Text = "Get Code"
        Me.chkGetContent.UseVisualStyleBackColor = True
        '
        'chkCompair
        '
        Me.chkCompair.AutoSize = True
        Me.chkCompair.Location = New System.Drawing.Point(374, 61)
        Me.chkCompair.Name = "chkCompair"
        Me.chkCompair.Size = New System.Drawing.Size(92, 17)
        Me.chkCompair.TabIndex = 10
        Me.chkCompair.Text = "Compair Code"
        Me.chkCompair.UseVisualStyleBackColor = True
        '
        'chkLookUp
        '
        Me.chkLookUp.AutoSize = True
        Me.chkLookUp.Location = New System.Drawing.Point(473, 62)
        Me.chkLookUp.Name = "chkLookUp"
        Me.chkLookUp.Size = New System.Drawing.Size(132, 17)
        Me.chkLookUp.TabIndex = 11
        Me.chkLookUp.Text = "Look for word/Phrase:"
        Me.chkLookUp.UseVisualStyleBackColor = True
        '
        'chkUseAuth
        '
        Me.chkUseAuth.AutoSize = True
        Me.chkUseAuth.Location = New System.Drawing.Point(18, 94)
        Me.chkUseAuth.Name = "chkUseAuth"
        Me.chkUseAuth.Size = New System.Drawing.Size(70, 17)
        Me.chkUseAuth.TabIndex = 12
        Me.chkUseAuth.Text = "Use Auth"
        Me.chkUseAuth.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(186, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "User Name:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(361, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Password"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(534, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Domain"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(255, 91)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(100, 20)
        Me.txtUserName.TabIndex = 16
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(420, 92)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(108, 20)
        Me.txtPassword.TabIndex = 17
        '
        'txtDomain
        '
        Me.txtDomain.Location = New System.Drawing.Point(583, 91)
        Me.txtDomain.Name = "txtDomain"
        Me.txtDomain.Size = New System.Drawing.Size(118, 20)
        Me.txtDomain.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Results:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(374, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Original:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(18, 146)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox2.Size = New System.Drawing.Size(308, 157)
        Me.TextBox2.TabIndex = 21
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(374, 146)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox3.Size = New System.Drawing.Size(308, 157)
        Me.TextBox3.TabIndex = 22
        '
        'txtLookUP
        '
        Me.txtLookUP.Location = New System.Drawing.Point(611, 60)
        Me.txtLookUP.Name = "txtLookUP"
        Me.txtLookUP.Size = New System.Drawing.Size(100, 20)
        Me.txtLookUP.TabIndex = 23
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(324, 310)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "Test Web"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(329, 176)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(39, 23)
        Me.Button3.TabIndex = 25
        Me.Button3.Text = "-->"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(329, 216)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(41, 23)
        Me.Button4.TabIndex = 26
        Me.Button4.Text = "C"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'chkNTLM
        '
        Me.chkNTLM.AutoSize = True
        Me.chkNTLM.Location = New System.Drawing.Point(95, 92)
        Me.chkNTLM.Name = "chkNTLM"
        Me.chkNTLM.Size = New System.Drawing.Size(78, 17)
        Me.chkNTLM.TabIndex = 27
        Me.chkNTLM.Text = "Use NTLM"
        Me.chkNTLM.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 345)
        Me.Controls.Add(Me.chkNTLM)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtLookUP)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtDomain)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkUseAuth)
        Me.Controls.Add(Me.chkLookUp)
        Me.Controls.Add(Me.chkCompair)
        Me.Controls.Add(Me.chkGetContent)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbProto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtport)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtDevice)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDevice As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtport As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbProto As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents chkGetContent As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompair As System.Windows.Forms.CheckBox
    Friend WithEvents chkLookUp As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseAuth As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtDomain As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents txtLookUP As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents chkNTLM As System.Windows.Forms.CheckBox

End Class
