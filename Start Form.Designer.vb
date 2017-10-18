<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Start_Form
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
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.btnNext = New System.Windows.Forms.Button()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.ckAddToDB = New DevExpress.XtraEditors.CheckEdit()
        Me.ckDelete = New DevExpress.XtraEditors.CheckEdit()
        Me.cList = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ckUseDB = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.ckAddToDB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckDelete.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckUseDB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DefaultLookAndFeel1
        '
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful"
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(288, 251)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(164, 33)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Առաջ >>"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.ckAddToDB)
        Me.GroupControl1.Controls.Add(Me.ckDelete)
        Me.GroupControl1.Controls.Add(Me.cList)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Enabled = False
        Me.GroupControl1.Location = New System.Drawing.Point(26, 65)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(426, 164)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Տվյալների Բազա"
        '
        'ckAddToDB
        '
        Me.ckAddToDB.Location = New System.Drawing.Point(20, 120)
        Me.ckAddToDB.Name = "ckAddToDB"
        Me.ckAddToDB.Properties.Caption = "Տվյալները Սինխրոն Ավելացնել Բազա"
        Me.ckAddToDB.Size = New System.Drawing.Size(232, 19)
        Me.ckAddToDB.TabIndex = 2
        '
        'ckDelete
        '
        Me.ckDelete.Location = New System.Drawing.Point(20, 82)
        Me.ckDelete.Name = "ckDelete"
        Me.ckDelete.Properties.Caption = "Ջնջել Բազայի Պարունակությունը"
        Me.ckDelete.Size = New System.Drawing.Size(232, 19)
        Me.ckDelete.TabIndex = 1
        '
        'cList
        '
        Me.cList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cList.FormattingEnabled = True
        Me.cList.Location = New System.Drawing.Point(101, 37)
        Me.cList.Name = "cList"
        Me.cList.Size = New System.Drawing.Size(307, 21)
        Me.cList.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ուղղություն"
        '
        'ckUseDB
        '
        Me.ckUseDB.Location = New System.Drawing.Point(26, 26)
        Me.ckUseDB.Name = "ckUseDB"
        Me.ckUseDB.Properties.Caption = "Օգտագործել Տվյալների Բազա"
        Me.ckUseDB.Size = New System.Drawing.Size(192, 19)
        Me.ckUseDB.TabIndex = 0
        '
        'Start_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(483, 313)
        Me.Controls.Add(Me.ckUseDB)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.btnNext)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Start_Form"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Պարամետրեր"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.ckAddToDB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckDelete.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckUseDB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ckAddToDB As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ckDelete As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cList As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ckUseDB As DevExpress.XtraEditors.CheckEdit
End Class
