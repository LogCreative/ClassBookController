Imports System.Data.OleDb
Imports System.Windows.Forms
Public Class Form1
    Dim closeall As Boolean

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If Me.TextBoxX1.Text = My.Settings.Password Then
            Me.Panel1.Visible = False
            If SwitchButton1.Value = True Then
                My.Settings.SkipPass = True
            End If
            StepItem1.Value = 100
            Call DBLoadSystem()
        Else
            Panel1.Visible = False
            My.Settings.ErrorNum = 1
            Form5.Show()
        End If
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If closeall = True Then
            Application.Exit()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        closeall = True
        If My.Settings.SkipPass = True Then
            Me.Panel1.Visible = False
            StepItem1.Value = 100
            ButtonX2.Visible = True
        Else
            TextBoxX1.Focus()
        End If
    End Sub

    Private Sub DBLoadSystem()
        'TODO:  这行代码将数据加载到表“DatabaseCBCDataSetChinese.Chinese”中。您可以根据需要移动或删除它。
        Panel3.Visible = True
        Try
            Form3.ChineseTableAdapter2.Connection.Open()
            Me.StepItem2.Value = 20
            Form3.EnglishTableAdapter3.Connection.Open()
            Me.StepItem2.Value = 40
            Form3.UpdateHistoryTableAdapter1.Connection.Open()
            Me.StepItem2.Value = 60
            'TODO:  这行代码将数据加载到表“DatabaseCBCDataSetChinese.Chinese”中。您可以根据需要移动或删除它。
            Form3.ChineseTableAdapter2.Fill(Form3.DatabaseCBCDataSet4.Chinese)
            'TODO:  这行代码将数据加载到表“DatabaseCBCDataSet5.English”中。您可以根据需要移动或删除它。
            Form3.EnglishTableAdapter3.Fill(Form3.DatabaseCBCDataSet5.English)
            Me.StepItem2.Value = 80
            'TODO:  这行代码将数据加载到表“DatabaseCBCDataSetUH.UpdateHistory”中。您可以根据需要移动或删除它。
            Form3.UpdateHistoryTableAdapter1.Fill(Form3.DatabaseCBCDataSetUH2.UpdateHistory)
            Me.StepItem2.Value = 100
        Catch oledbe As OleDbException
            Panel3.Visible = False
            My.Settings.ErrorNum = 2
            Me.Panel2.Visible = True
            Me.LabelX4.Text = 30
            Me.Timer1.Start()
            Label1.Text = oledbe.Message
            Form5.Show()
        Catch ex As Exception
            Panel3.Visible = False
            My.Settings.ErrorNum = 4
            Me.Panel2.Visible = True
            Me.LabelX4.Text = 30
            Me.Timer1.Start()
            Label1.Text = ex.Message
            Form5.Show()
        End Try
        Try
            Me.NamesTableAdapter.Connection.Open()
            Me.StepItem3.Value = 20
            'TODO:  这行代码将数据加载到表“DatabaseCBCDataSet.Names”中。您可以根据需要移动或删除它。
            Form3.NamesTableAdapter.Fill(Form3.DatabaseCBCDataSet.Names)
            Me.StepItem3.Value = 40
            Me.Panel3.Visible = False
            Me.StepItem3.Value = 60
        Catch ex As Exception
            Panel3.Visible = False
            My.Settings.ErrorNum = 4
            Me.Panel2.Visible = True
            Me.LabelX4.Text = 30
            Me.Timer1.Start()
            Label1.Text = ex.Message
            Form5.Show()
        End Try
        If My.Settings.Themes = "Office2007Blue" Then
            Form3.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue
        ElseIf My.Settings.Themes = "Office2007Silver" Then
            Form3.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Silver
        ElseIf My.Settings.Themes = "Office2007Black" Then
            Form3.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Black
        ElseIf My.Settings.Themes = "Office2007VistaGlass" Then
            Form3.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007VistaGlass
        ElseIf My.Settings.Themes = "Office2010Silver" Then
            Form3.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Silver
        ElseIf My.Settings.Themes = "Office2010Blue" Then
            Form3.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue
        ElseIf My.Settings.Themes = "Office2010Black" Then
            Form3.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Black
        ElseIf My.Settings.Themes = "Windows7Blue" Then
            Form3.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Windows7Blue
        ElseIf My.Settings.Themes = "VisualStudio2010Blue" Then
            Form3.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2010Blue
        ElseIf My.Settings.Themes = "Office2013" Then
            Form3.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2013
        ElseIf My.Settings.Themes = "VisualStudio2012Light" Then
            Form3.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Light
        End If
        Me.StepItem3.Value = 80
        Form3.ComboBox3.SelectedText = My.Settings.Themes
        Me.StepItem3.Value = 100
        Form3.Show()
        closeall = False
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.LabelX4.Text <= 0 Then
            Me.Timer1.Stop()
            Me.Panel2.Visible = False
            Form5.Close()
            DBLoadSystem()
        Else
            Me.LabelX4.Text = Me.LabelX4.Text - 1
        End If
    End Sub

    Private Sub ProgressSteps1_ItemClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Call DBLoadSystem()
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        TouchKeyboard1.Text = "输入密码"
        TouchKeyboard1.ShowKeyboard(Me, DevComponents.DotNetBar.Keyboard.TouchKeyboardStyle.Floating)
    End Sub
End Class