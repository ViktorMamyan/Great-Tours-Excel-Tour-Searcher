<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExcelExtracter
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.components = New System.ComponentModel.Container()
        Me.btnLoadExcel = New System.Windows.Forms.Button()
        Me.btnExcelSheet = New System.Windows.Forms.Button()
        Me.btnExcelData = New System.Windows.Forms.Button()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtShhet = New System.Windows.Forms.TextBox()
        Me.txtCount = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTime = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnToExcel = New System.Windows.Forms.Button()
        Me.txtDirection = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLoadExcel
        '
        Me.btnLoadExcel.Location = New System.Drawing.Point(13, 23)
        Me.btnLoadExcel.Name = "btnLoadExcel"
        Me.btnLoadExcel.Size = New System.Drawing.Size(235, 32)
        Me.btnLoadExcel.TabIndex = 0
        Me.btnLoadExcel.Text = "Excel-ի Ֆայլ ..."
        Me.btnLoadExcel.UseVisualStyleBackColor = True
        '
        'btnExcelSheet
        '
        Me.btnExcelSheet.Location = New System.Drawing.Point(13, 61)
        Me.btnExcelSheet.Name = "btnExcelSheet"
        Me.btnExcelSheet.Size = New System.Drawing.Size(235, 32)
        Me.btnExcelSheet.TabIndex = 1
        Me.btnExcelSheet.Text = "Ստանալ Ցանկը"
        Me.btnExcelSheet.UseVisualStyleBackColor = True
        '
        'btnExcelData
        '
        Me.btnExcelData.Location = New System.Drawing.Point(13, 99)
        Me.btnExcelData.Name = "btnExcelData"
        Me.btnExcelData.Size = New System.Drawing.Size(235, 32)
        Me.btnExcelData.TabIndex = 2
        Me.btnExcelData.Text = "Ստանալ Excel-ի Պարունակությունը"
        Me.btnExcelData.UseVisualStyleBackColor = True
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(12, 148)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(923, 392)
        Me.GridControl1.TabIndex = 3
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridView1.OptionsView.EnableAppearanceOddRow = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(269, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Sheet"
        '
        'txtShhet
        '
        Me.txtShhet.Location = New System.Drawing.Point(341, 45)
        Me.txtShhet.Name = "txtShhet"
        Me.txtShhet.ReadOnly = True
        Me.txtShhet.Size = New System.Drawing.Size(339, 21)
        Me.txtShhet.TabIndex = 5
        Me.txtShhet.TabStop = False
        '
        'txtCount
        '
        Me.txtCount.Location = New System.Drawing.Point(341, 76)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.ReadOnly = True
        Me.txtCount.Size = New System.Drawing.Size(339, 21)
        Me.txtCount.TabIndex = 7
        Me.txtCount.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(269, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Tour Count"
        '
        'txtTime
        '
        Me.txtTime.Location = New System.Drawing.Point(341, 103)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.ReadOnly = True
        Me.txtTime.Size = New System.Drawing.Size(339, 21)
        Me.txtTime.TabIndex = 9
        Me.txtTime.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(269, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Time"
        '
        'btnToExcel
        '
        Me.btnToExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnToExcel.Location = New System.Drawing.Point(734, 23)
        Me.btnToExcel.Name = "btnToExcel"
        Me.btnToExcel.Size = New System.Drawing.Size(201, 32)
        Me.btnToExcel.TabIndex = 10
        Me.btnToExcel.Text = "Արտահանել Excel"
        Me.btnToExcel.UseVisualStyleBackColor = True
        '
        'txtDirection
        '
        Me.txtDirection.Location = New System.Drawing.Point(341, 18)
        Me.txtDirection.Name = "txtDirection"
        Me.txtDirection.ReadOnly = True
        Me.txtDirection.Size = New System.Drawing.Size(339, 21)
        Me.txtDirection.TabIndex = 12
        Me.txtDirection.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(269, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Direction"
        '
        'ExcelExtracter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(947, 552)
        Me.Controls.Add(Me.txtDirection)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnToExcel)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtShhet)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.btnExcelData)
        Me.Controls.Add(Me.btnExcelSheet)
        Me.Controls.Add(Me.btnLoadExcel)
        Me.Name = "ExcelExtracter"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Excel File Extracter"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnLoadExcel As Button
    Friend WithEvents btnExcelSheet As Button
    Friend WithEvents btnExcelData As System.Windows.Forms.Button
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtShhet As System.Windows.Forms.TextBox
    Friend WithEvents txtCount As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTime As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnToExcel As System.Windows.Forms.Button
    Friend WithEvents txtDirection As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
