Imports System.Net.Mail
Public Class MainForm
    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.EnableSsl = True
            SmtpServer.Credentials = New Net.NetworkCredential(txtFrom.Text, txtPass.Text)
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"
            mail = New MailMessage()
            mail.From = New MailAddress(txtFrom.Text)
            mail.To.Add(txtTo.Text)
            mail.Subject = txtSubject.Text
            mail.Body = txtMessage.Text
            SmtpServer.Send(mail)
            lblStatus.Text = "Mail SENT"
            lblStatus.ForeColor = Color.Green
        Catch ex As Exception
            lblStatus.Text = "Error, Details also in clipboard"
            lblStatus.ForeColor = Color.Red
            MsgBox(ex.ToString)
            Clipboard.SetText(ex.ToString)
        End Try
    End Sub

   
    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblStatus.Text = "Ready"
    End Sub
End Class
