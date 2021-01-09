Public Class Form4

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TextBoxX1.Text = My.Settings.Password
    End Sub

    Private Sub ButtonX1_MouseEnter(sender As Object, e As EventArgs) Handles ButtonX1.MouseEnter
        Me.TextBoxX1.PasswordChar = ""
    End Sub

    Private Sub ButtonX1_MouseLeave(sender As Object, e As EventArgs) Handles ButtonX1.MouseLeave
        Me.TextBoxX1.PasswordChar = "●"
    End Sub
End Class