Public Class Form5
    Dim pm As Integer

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Form1.Panel1.Visible = True
        Me.Close()
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 10
        Me.Left = My.Computer.Screen.Bounds.Width.ToString - Me.Width
        pm = 1
        Select Case My.Settings.ErrorNum
            Case 1
                Me.LabelX1.Text = "错误代码：001"
                Me.LabelX2.Text = "密码错误。"
                Me.ButtonX1.Visible = True
                Me.ButtonX2.Visible = False
                Me.TextBoxX1.Text = "密码错误。" & vbNewLine & "1.大小写是否正确。" & vbNewLine & "2.密码是否输入不当。" & vbNewLine & "3.无法解决问题请联系管理员。"
            Case 2
                Me.LabelX1.Text = "错误代码：002"
                Me.LabelX2.Text = "数据库连接超时或失败。"
                Me.ButtonX1.Visible = False
                Me.ButtonX2.Visible = True
                Me.TextBoxX1.Text = Form1.Label1.Text
            Case 3
                Me.LabelX1.Text = "错误代码：003"
                Me.LabelX2.Text = "数据库保存时出现异常。保存失败。"
                Me.ButtonX1.Visible = False
                Me.ButtonX2.Visible = True
                Me.TextBoxX1.Text = Form1.Label1.Text
            Case 4
                Me.LabelX1.Text = "错误代码：004"
                Me.LabelX2.Text = "数据库出现其他异常，详见详细信息。"
                Me.ButtonX1.Visible = False
                Me.ButtonX2.Visible = True
                Me.TextBoxX1.Text = Form1.Label1.Text
            Case 5
                Me.LabelX1.Text = "错误代码：005"
                Me.LabelX2.Text = "查询时出现异常，详见详细信息。"
                Me.ButtonX1.Visible = False
                Me.ButtonX2.Visible = True
                Me.TextBoxX1.Text = Form1.Label1.Text
            Case 6
                Me.LabelX1.Text = "错误代码：006"
                Me.LabelX2.Text = "删除行时出现异常，可能是选定了空单元格。最好退出程序，以避免不可预料的错误。"
                Me.ButtonX1.Visible = False
                Me.ButtonX2.Visible = True
                Me.TextBoxX1.Text = Form1.Label1.Text
        End Select
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Me.Close()
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If My.Settings.ErrorNum = 1 Then
            If pm = 5 Then
                Form4.Show()
            Else
                pm = pm + 1
            End If
        End If
    End Sub
End Class