Public Class Form3
    Dim chc, enc, uhc As Boolean
    Dim cp As Boolean
    Private Sub Form3_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If chc = True Or enc = True Or uhc = True Then
            If MsgBox("需要全部保存吗？", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "数据保存") = MsgBoxResult.Yes Then
                Call saveall()
            End If
        End If
        My.Settings.SWidthw = Me.Width
        My.Settings.SHeightw = Me.Height
        My.Settings.SLeftw = Me.Left
        My.Settings.STopw = Me.Top
        My.Settings.Themes = Me.ComboBox3.Text
        Me.ChineseTableAdapter.Connection.Close()
    End Sub



    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO:  这行代码将数据加载到表“DatabaseCBCDataSet1.HistorySet”中。您可以根据需要移动或删除它。
        Me.HistorySetTableAdapter.Fill(Me.DatabaseCBCDataSet1.HistorySet)
        chc = False
        enc = False
        uhc = False
        Me.LabelItem5.Text = Me.Width.ToString & "," & Me.Height.ToString
        Me.LabelItem6.Text = "( " & Me.Left & " , " & Me.Top & " )"
        Me.Width = My.Settings.SWidthw
        Me.Height = My.Settings.SHeightw
        Me.Left = My.Settings.SLeftw
        Me.Top = My.Settings.STopw
        If Me.SuperTabControl1.SelectedTabIndex = 0 Then
            Me.Text = "班级图书管理器 - 语文"
        ElseIf Me.SuperTabControl1.SelectedTabIndex = 1 Then
            Me.Text = "班级图书管理器 - 英语"
        ElseIf Me.SuperTabControl1.SelectedTabIndex = 2 Then
            Me.Text = "班级图书管理器 - 更新记录"
        End If
        If My.Settings.SkipPass = True Then
            Me.SwitchButtonItem1.Value = True
            Me.ButtonX1.Enabled = False
        Else
            Me.SwitchButtonItem1.Value = False
            Me.ButtonX1.Enabled = True
        End If
        LabelX5.Text = "班级图书管理器 " & Application.ProductVersion
        cp = False

    End Sub

    Private Sub ComboBoxSubject_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If Me.SuperTabControl1.SelectedTabIndex = 0 Then
            If chc = True Then
                Me.Text = "班级图书管理器 - 语文*"
            Else
                Me.Text = "班级图书管理器 - 语文"
            End If
            RibbonBar2.Visible = False
            RibbonBar4.Visible = True
            '+删除行按钮的可见性
            'RibbonBar5 语文
            'RibbonBar3 英语
            'RibbonBar6 更新记录
            RibbonBar5.Visible = True
            RibbonBar3.Visible = False
            RibbonBar6.Visible = False
        ElseIf Me.SuperTabControl1.SelectedTabIndex = 1 Then
            If enc = True Then
                Me.Text = "班级图书管理器 - 英语*"
            Else
                Me.Text = "班级图书管理器 - 英语"
            End If
            RibbonBar2.Visible = False
            RibbonBar4.Visible = True
            '+
            RibbonBar5.Visible = False
            RibbonBar3.Visible = True
            RibbonBar6.Visible = False
        ElseIf Me.SuperTabControl1.SelectedTabIndex = 2 Then
            If uhc = True Then
                Me.Text = "班级图书管理器 - 更新记录*"
            Else
                Me.Text = "班级图书管理器 - 更新记录"
            End If
            RibbonBar2.Visible = True
            RibbonBar4.Visible = False
            '+
            RibbonBar5.Visible = False
            RibbonBar3.Visible = False
            RibbonBar6.Visible = True
        End If
    End Sub

    Private Sub ButtonItem14_Click(sender As Object, e As EventArgs) Handles ButtonItem14.Click
        Call save()
    End Sub

    Private Sub ButtonItem7_Click(sender As Object, e As EventArgs) Handles ButtonItem7.Click
        Me.Close()
    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click
        Call saveall()

    End Sub
    Private Sub save()
        Try
            If Me.SuperTabControl1.SelectedTabIndex = 0 Then
                DataGridViewX1.EndEdit()
                If DatabaseCBCDataSet4.HasChanges Then
                    'FIXME: lost method of Update
                    ChineseTableAdapter2.Update(DatabaseCBCDataSet4.GetChanges)
                End If
                chc = False
                Me.LabelState.Text = "保存信息：保存 [ 语文 ] 已成功。"
            ElseIf Me.SuperTabControl1.SelectedTabIndex = 1 Then
                DataGridViewX2.EndEdit()
                If DatabaseCBCDataSet5.HasChanges Then
                    'FIXME: lost method of Update
                    EnglishTableAdapter3.Update(DatabaseCBCDataSet5.GetChanges)
                End If
                enc = False
                Me.LabelState.Text = "保存信息：保存 [ 英语 ] 已成功。"
            ElseIf Me.SuperTabControl1.SelectedTabIndex = 2 Then
                DataGridViewX3.EndEdit()
                If DatabaseCBCDataSetUH2.HasChanges Then
                    UpdateHistoryTableAdapter1.Update(DatabaseCBCDataSetUH2.GetChanges)
                End If
                uhc = False
                Me.LabelState.Text = "保存信息：保存 [ 更新记录 ] 已成功。"
            End If
            '是否更改
            If Me.SuperTabControl1.SelectedTabIndex = 0 Then
                If chc = True Then
                    Me.Text = "班级图书管理器 - 语文*"
                Else
                    Me.Text = "班级图书管理器 - 语文"
                End If
            ElseIf Me.SuperTabControl1.SelectedTabIndex = 1 Then
                If enc = True Then
                    Me.Text = "班级图书管理器 - 英语*"
                Else
                    Me.Text = "班级图书管理器 - 英语"
                End If
            ElseIf Me.SuperTabControl1.SelectedTabIndex = 2 Then
                If uhc = True Then
                    Me.Text = "班级图书管理器 - 更新记录*"
                Else
                    Me.Text = "班级图书管理器 - 更新记录"
                End If
            End If
        Catch ex As Exception
            My.Settings.ErrorNum = 3
            Form1.Label1.Text = ex.Message
            Me.LabelState.Text = "错误信息：保存时出现异常。(0x3)"
            Form5.Show()
        End Try
    End Sub
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        Call save()
    End Sub

    Private Sub saveall()
        Try
            DataGridViewX1.EndEdit()
            If DatabaseCBCDataSet4.HasChanges Then
                ChineseTableAdapter.Update(DatabaseCBCDataSet4.GetChanges)
            End If
            DataGridViewX2.EndEdit()
            If DatabaseCBCDataSet5.HasChanges Then
                EnglishTableAdapter1.Update(DatabaseCBCDataSet5.GetChanges)
            End If
            DataGridViewX3.EndEdit()
            If DatabaseCBCDataSetUH2.HasChanges Then
                UpdateHistoryTableAdapter1.Update(DatabaseCBCDataSetUH2.GetChanges)
            End If
            chc = False
            enc = False
            uhc = False
            If Me.SuperTabControl1.SelectedTabIndex = 0 Then
                If chc = True Then
                    Me.Text = "班级图书管理器 - 语文*"
                Else
                    Me.Text = "班级图书管理器 - 语文"
                End If
            ElseIf Me.SuperTabControl1.SelectedTabIndex = 1 Then
                If enc = True Then
                    Me.Text = "班级图书管理器 - 英语*"
                Else
                    Me.Text = "班级图书管理器 - 英语"
                End If
            ElseIf Me.SuperTabControl1.SelectedTabIndex = 2 Then
                If uhc = True Then
                    Me.Text = "班级图书管理器 - 更新记录*"
                Else
                    Me.Text = "班级图书管理器 - 更新记录"
                End If
            End If
            Me.LabelState.Text = "保存信息： 全部保存 已成功。"
        Catch ex As Exception
            My.Settings.ErrorNum = 3
            Form1.Label1.Text = ex.Message
            Me.LabelState.Text = "错误信息：保存时出现异常。(0x3)"
            Form5.Show()
        End Try
    End Sub
    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click
        Call saveall()
    End Sub

    Private Sub ButtonItem6_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click
        Form2.Show()
    End Sub

    Private Sub ButtonItem5_Click(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        '快捷输入姓名模块
        Dim scpc As Integer
        Dim scpr As Integer
        Select Case Me.SuperTabControl1.SelectedTabIndex
            Case 0
                scpc = CInt(Me.DataGridViewX1.SelectedCells(0).ColumnIndex.ToString)
                scpr = CInt(Me.DataGridViewX1.SelectedCells(0).RowIndex.ToString)
                If scpc = 2 Then
                    Me.LabelState.Text = "错误信息：不合法的输入位置。(0x7)"
                Else
                    Me.DataGridViewX1.Item(scpc, scpr).Value = Me.ComboBox1.Text
                    Me.LabelState.Text = "快捷输入姓名：已快捷输入" & " [ " & Me.ComboBox1.Text & " ] " & "至 语文  (" & scpc & "," & scpr & ")"
                End If
            Case 1
                scpc = CInt(Me.DataGridViewX2.SelectedCells(0).ColumnIndex.ToString)
                scpr = CInt(Me.DataGridViewX2.SelectedCells(0).RowIndex.ToString)
                If scpc = 3 Then
                    Me.LabelState.Text = "错误信息：不合法的输入位置。(0x7)"
                Else
                    Me.DataGridViewX2.Item(scpc, scpr).Value = Me.ComboBox1.Text
                    Me.LabelState.Text = "快捷输入姓名：已快捷输入" & " [ " & Me.ComboBox1.Text & " ] " & "至 英语  (" & scpc & "," & scpr & ")"
                End If
        End Select
    End Sub

    Private Sub ButtonItem8_Click(sender As Object, e As EventArgs) Handles ButtonItem8.Click
        Try
            Select Case Me.SuperTabControl1.SelectedTabIndex
                Case 0
                    Dim sr As Integer
                    sr = CInt(Me.DataGridViewX1.SelectedCells(0).RowIndex.ToString)
                        Me.DataGridViewX1.Rows.RemoveAt(sr)
                        Me.LabelState.Text = "删除信息：删除了选定行(" & sr & ")。"
                Case 1
                    Dim sr As Integer
                    sr = CInt(Me.DataGridViewX2.SelectedCells(0).RowIndex.ToString)
                    Me.DataGridViewX2.Rows.RemoveAt(sr)
                    Me.LabelState.Text = "删除信息：删除了选定行(" & sr & ")。"
                Case 2
                    Dim sr As Integer
                    sr = CInt(Me.DataGridViewX3.SelectedCells(0).RowIndex.ToString)
                    Me.DataGridViewX3.Rows.RemoveAt(sr)
                    Me.LabelState.Text = "删除信息：删除了选定行(" & sr & ")。"
            End Select
        Catch ex As Exception
            My.Settings.ErrorNum = 6
            Form1.Label1.Text = ex.Message
            Me.LabelState.Text = "错误信息：删除行时出现异常。(0x6)"
            Form5.Show()
        End Try
        
    End Sub

    Private Sub DataGridViewX1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX1.CellValueChanged
        chc = True
        Me.Text = "班级图书管理器 - 语文*"
    End Sub

    Private Sub DataGridViewX2_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX2.CellValueChanged
        enc = True
        Me.Text = "班级图书管理器 - 英语*"
    End Sub

    Private Sub DataGridViewX3_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX3.CellValueChanged
        uhc = True
        Me.Text = "班级图书管理器 - 更新记录*"
    End Sub

    Private Sub ButtonItem10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonItem11_Click(sender As Object, e As EventArgs)
        Call saveall()
    End Sub

    Private Sub ButtonItem16_Click(sender As Object, e As EventArgs) Handles ButtonItem16.Click
        Application.Exit()
    End Sub

    Private Sub SwitchButtonItem1_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If cp = False Then
            cp = True
            PanelEx1.Visible = True
            Me.TextBoxX1.Enabled = True
            Me.ButtonX1.Enabled = True
            Me.ButtonX1.Text = "取消更改密码"
        Else
            cp = False
            PanelEx1.Visible = False
            Me.ButtonX1.Text = "更改密码..."
        End If
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        If TextBoxX1.Text = My.Settings.Password Then
            Me.ButtonX2.Enabled = False
            Me.TextBoxX1.Enabled = False
            PanelEx2.Visible = True
        Else
            Me.LabelX7.Visible = True
        End If
    End Sub

    Private Sub TextBoxX1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX1.TextChanged
        Me.LabelX7.Visible = False
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        My.Settings.Password = Me.TextBoxX2.Text
        Me.LabelX10.Visible = True
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.LabelX10.Visible = False
        Me.PanelEx2.Visible = False
        Me.TextBoxX1.Enabled = True
        Me.TextBoxX1.Text = ""
        Me.ButtonX2.Enabled = True
        Me.TextBoxX2.Text = ""
        Me.PanelEx2.Visible = False
        cp = False
        PanelEx1.Visible = False
        Me.ButtonX1.Text = "更改密码..."
        Me.Timer1.Stop()
    End Sub

    Private Sub SwitchButtonItem1_ValueChanged_2(sender As Object, e As EventArgs) Handles SwitchButtonItem1.ValueChanged
        If Me.SwitchButtonItem1.Value = True Then
            My.Settings.SkipPass = True
            Me.ButtonX1.Enabled = False
        Else
            My.Settings.SkipPass = False
            Me.ButtonX1.Enabled = True
        End If
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        If ButtonX4.Text = "确定" Then
            If TextBoxX3.Text = My.Settings.Password Then
                PanelEx3.Visible = True
                TextBoxX3.Enabled = False
                Me.ButtonX4.Text = "锁定"
            Else
                Me.LabelX11.Visible = True
            End If
        Else
            PanelEx3.Visible = False
            TextBoxX3.Enabled = True
            Me.ButtonX4.Text = "确定"
            Me.TextBoxX3.Text = ""
        End If
    End Sub

    Private Sub TextBoxX3_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX3.TextChanged
        Me.LabelX11.Visible = False
    End Sub

    Private Sub ButtonX5_Click(sender As Object, e As EventArgs) Handles ButtonX5.Click
        Dim sr As Integer
        sr = CInt(Me.DataGridViewX4.SelectedCells(0).RowIndex.ToString)
        Me.DataGridViewX4.Rows.RemoveAt(sr)
    End Sub

    Private Sub ButtonItem4_Click_1(sender As Object, e As EventArgs) Handles ButtonItem4.Click
        Dim scpc As Integer
        Dim scpr As Integer
        Select Case Me.SuperTabControl1.SelectedTabIndex
            Case 3
                scpc = CInt(Me.DataGridViewX3.SelectedCells(0).ColumnIndex.ToString)
                scpr = CInt(Me.DataGridViewX3.SelectedCells(0).RowIndex.ToString)
                Me.DataGridViewX3.Item(scpc, scpr).Value = Me.ComboBox2.Text
                Me.LabelState.Text = "快捷输入记录：已快捷输入" & " [ " & Me.ComboItem2.Text & " ] " & "至 更新记录  (" & scpc & "," & scpr & ")"
        End Select
    End Sub

    Private Sub ButtonX6_Click(sender As Object, e As EventArgs) Handles ButtonX6.Click
        Dim sr As Integer
        sr = CInt(Me.DataGridViewX5.SelectedCells(0).RowIndex.ToString)
        Me.DataGridViewX5.Rows.RemoveAt(sr)
    End Sub

    Private Sub DataGridViewX4_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX4.CellClick
        ButtonX5.Enabled = True
    End Sub

    Private Sub DataGridViewX4_LostFocus(sender As Object, e As EventArgs) Handles DataGridViewX4.LostFocus
        ButtonX5.Enabled = False
    End Sub

    Private Sub DataGridViewX5_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX5.CellClick
        ButtonX6.Enabled = True
    End Sub

    Private Sub DataGridViewX5_LostFocus(sender As Object, e As EventArgs) Handles DataGridViewX5.LostFocus
        ButtonX6.Enabled = False
    End Sub

    Private Sub DataGridViewX1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX1.CellClick
        'ButtonItem8 语文
        'ButtonItem9 英语
        'ButtonItem10 更新记录
        ButtonItem8.Enabled = True
    End Sub

    Private Sub DataGridViewX1_LostFocus(sender As Object, e As EventArgs) Handles DataGridViewX1.LostFocus
        ButtonItem8.Enabled = False
    End Sub

    Private Sub DataGridViewX2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX2.CellClick
        ButtonItem9.Enabled = True
    End Sub

    Private Sub DataGridViewX2_LostFocus(sender As Object, e As EventArgs) Handles DataGridViewX2.LostFocus
        ButtonItem9.Enabled = False
    End Sub

    Private Sub DataGridViewX3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewX3.CellClick
        ButtonItem10.Enabled = True
    End Sub

    Private Sub DataGridViewX3_LostFocus(sender As Object, e As EventArgs) Handles DataGridViewX3.LostFocus
        ButtonItem10.Enabled = False
    End Sub

    Private Sub ButtonItem15_Click(sender As Object, e As EventArgs) Handles ButtonItem15.Click
        DataGridViewX3.EndEdit()
        Try
            If DatabaseCBCDataSetUH2.HasChanges Then
                UpdateHistoryTableAdapter1.Update(DatabaseCBCDataSetUH2.GetChanges)
            End If
            uhc = False
            Me.LabelState.Text = "保存信息：保存 [ 更新记录 ] 已成功。"
        Catch ex As Exception
            My.Settings.ErrorNum = 3
            Form1.Label1.Text = ex.Message
            Me.LabelState.Text = "错误信息：保存时出现异常。(0x3)"
            Form5.Show()
        End Try
    End Sub

    Private Sub ButtonItem12_Click(sender As Object, e As EventArgs) Handles ButtonItem12.Click
        DataGridViewX1.EndEdit()
        Try
            If DatabaseCBCDataSetChinese1.HasChanges Then
                ChineseTableAdapter.Update(DatabaseCBCDataSetChinese1.GetChanges)
            End If
            chc = False
            Me.LabelState.Text = "保存信息：保存 [ 语文 ] 已成功。"
        Catch ex As Exception
            My.Settings.ErrorNum = 3
            Form1.Label1.Text = ex.Message
            Me.LabelState.Text = "错误信息：保存时出现异常。(0x3)"
            Form5.Show()
        End Try
    End Sub

    Private Sub ButtonItem13_Click(sender As Object, e As EventArgs) Handles ButtonItem13.Click
        DataGridViewX2.EndEdit()
        Try
            If DatabaseCBCDataSetEnglish2.HasChanges Then
                EnglishTableAdapter1.Update(DatabaseCBCDataSetEnglish2.GetChanges)
            End If
            enc = False
            Me.LabelState.Text = "保存信息：保存 [ 英语 ] 已成功。"
        Catch ex As Exception
            My.Settings.ErrorNum = 3
            Form1.Label1.Text = ex.Message
            Me.LabelState.Text = "错误信息：保存时出现异常。(0x3)"
            Form5.Show()
        End Try
    End Sub

    Private Sub ButtonX8_Click(sender As Object, e As EventArgs) Handles ButtonX8.Click
        Call saveall()
    End Sub

    Private Sub ButtonX7_Click(sender As Object, e As EventArgs) Handles ButtonX7.Click
        Call save()
    End Sub

    Private Sub ButtonX9_Click(sender As Object, e As EventArgs) Handles ButtonX9.Click
        DataGridViewX4.EndEdit()
        If DatabaseCBCDataSet.HasChanges Then
            NamesTableAdapter.Update(DatabaseCBCDataSet.GetChanges)
        End If
        Me.LabelState.Text = "保存信息：保存 [ 快捷输入姓名数据库 ] 已成功。"
    End Sub

    Private Sub ButtonX10_Click(sender As Object, e As EventArgs) Handles ButtonX10.Click
        DataGridViewX5.EndEdit()
        If DatabaseCBCDataSet1.HasChanges Then
            HistorySetTableAdapter.Update(DatabaseCBCDataSet1.GetChanges)
        End If
        Me.LabelState.Text = "保存信息：保存 [ 快捷输入记录数据库 ] 已成功。"
    End Sub

    Private Sub ButtonX11_Click(sender As Object, e As EventArgs) Handles ButtonX11.Click
        If ButtonX11.Text = "确定" Then
            If TextBoxX4.Text = My.Settings.Password Then
                PanelEx4.Visible = True
                TextBoxX4.Enabled = False
                Me.ButtonX11.Text = "锁定"
            Else
                Me.LabelX15.Visible = True
            End If
        Else
            PanelEx4.Visible = False
            TextBoxX4.Enabled = True
            Me.ButtonX11.Text = "确定"
            Me.TextBoxX4.Text = ""
        End If
    End Sub

    Private Sub TextBoxX4_TextChanged(sender As Object, e As EventArgs) Handles TextBoxX4.TextChanged
        Me.LabelX15.Visible = False
    End Sub

    Private Sub ButtonX12_Click(sender As Object, e As EventArgs) Handles ButtonX12.Click
        My.Settings.Reset()
        LabelX18.Visible = True
        Timer2.Start()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Application.Restart()
    End Sub

    Private Sub ButtonItem11_Click_1(sender As Object, e As EventArgs)
        StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2013
    End Sub

    Private Sub ButtonItem17_Click(sender As Object, e As EventArgs)
        StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue
    End Sub

    Private Sub ButtonItem18_Click(sender As Object, e As EventArgs)
        StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Black
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If Me.ComboBox3.Text = "Office2007Blue" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue
        ElseIf Me.ComboBox3.Text = "Office2007Silver" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Silver
        ElseIf Me.ComboBox3.Text = "Office2007Black" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Black
        ElseIf Me.ComboBox3.Text = "Office2007VistaGlass" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007VistaGlass
        ElseIf Me.ComboBox3.Text = "Office2010Silver" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Silver
        ElseIf Me.ComboBox3.Text = "Office2010Blue" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue
        ElseIf Me.ComboBox3.Text = "Office2010Black" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Black
        ElseIf Me.ComboBox3.Text = "Windows7Blue" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Windows7Blue
        ElseIf Me.ComboBox3.Text = "VisualStudio2010Blue" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2010Blue
        ElseIf Me.ComboBox3.Text = "Office2013" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2013
        ElseIf Me.ComboBox3.Text = "VisualStudio2012Light" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.VisualStudio2012Light
        End If
    End Sub

    Private Sub ButtonItem11_Click_2(sender As Object, e As EventArgs) Handles ButtonItem11.Click
        TouchKeyboard1.ShowKeyboard(Me, DevComponents.DotNetBar.Keyboard.TouchKeyboardStyle.Floating)
    End Sub

    Private Sub Form3_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.LabelItem6.Text = "( " & Me.Left & " , " & Me.Top & " )"
        Me.NumericUpDown3.Value = Me.Left
        Me.NumericUpDown4.Value = Me.Top
    End Sub

    Private Sub Form3_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Me.LabelItem5.Text = Me.Width.ToString & "," & Me.Height.ToString
        Me.NumericUpDown1.Value = Me.Width
        Me.NumericUpDown2.Value = Me.Height
    End Sub

    Private Sub ButtonItem18_Click_1(sender As Object, e As EventArgs) Handles ButtonItem18.Click
        Me.Width = 700
        Me.Height = 400
    End Sub

    Private Sub ButtonItem19_Click(sender As Object, e As EventArgs) Handles ButtonItem19.Click
        Me.Width = 800
        Me.Height = 600
    End Sub

    Private Sub ButtonItem20_Click(sender As Object, e As EventArgs) Handles ButtonItem20.Click
        Me.Width = 1024
        Me.Height = 680
    End Sub

    Private Sub ButtonItem21_Click(sender As Object, e As EventArgs) Handles ButtonItem21.Click
        Me.Left = 0
        Me.Top = 0
    End Sub

    Private Sub ButtonItem22_Click(sender As Object, e As EventArgs) Handles ButtonItem22.Click
        Me.Left = My.Computer.Screen.Bounds.Width.ToString - Me.Width
        Me.Top = 0
    End Sub

    Private Sub ButtonItem23_Click(sender As Object, e As EventArgs) Handles ButtonItem23.Click
        Me.Left = 0
        Me.Top = My.Computer.Screen.Bounds.Height.ToString - Me.Height - 40
    End Sub

    Private Sub ChineseBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles ChineseBindingSource.CurrentChanged

    End Sub

    Private Sub ChineseBindingSource2_CurrentChanged(sender As Object, e As EventArgs) Handles ChineseBindingSource2.CurrentChanged

    End Sub

    Private Sub ButtonItem24_Click(sender As Object, e As EventArgs) Handles ButtonItem24.Click
        Me.Left = My.Computer.Screen.Bounds.Width.ToString - Me.Width
        Me.Top = My.Computer.Screen.Bounds.Height.ToString - Me.Height - 40
    End Sub

    Private Sub ButtonX13_Click(sender As Object, e As EventArgs) Handles ButtonX13.Click
        Me.Width = Me.NumericUpDown1.Value
        Me.Height = Me.NumericUpDown2.Value
        Me.Left = Me.NumericUpDown3.Value
        Me.Top = Me.NumericUpDown4.Value
    End Sub
End Class