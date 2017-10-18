Public Class Start_Form

    Private Sub LoadList()
        Try
            Dim dt As DataTable = QueryToSqlServer("SELECT DirectionID,Direction FROM Direction", CommandType.Text)

            With cList
                .DataSource = dt
                .DisplayMember = "Direction"
                .ValueMember = "DirectionID"
            End With

            btnNext.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub

    Private Sub ckUseDB_CheckedChanged(sender As Object, e As EventArgs) Handles ckUseDB.CheckedChanged
        If ckUseDB.Checked = True Then
            GroupControl1.Enabled = True
            btnNext.Enabled = False
            Call LoadList()
        Else
            ckDelete.Checked = False
            ckAddToDB.Checked = False
            GroupControl1.Enabled = False
            btnNext.Enabled = True
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

        Dim f As New ExcelExtracter
        With f
            If ckUseDB.Checked = True Then
                .Direction = cList.Text
                .DirectionID = cList.SelectedValue
                .DeleteRows = ckDelete.Checked
                .AutoSave = ckAddToDB.Checked
            End If
            .Show()
            Me.Close()
        End With

    End Sub

End Class