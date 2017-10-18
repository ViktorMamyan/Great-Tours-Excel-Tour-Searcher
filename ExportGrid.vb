Module ExportGrid

    Friend Sub ExportTo(ByVal iGrid As DevExpress.XtraGrid.GridControl, strFormText As String)
        Try
            Dim r As New Random
            Dim f As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\GreatToursTourSearch"
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)
            f &= "\" & strFormText
            If IO.Directory.Exists(f) = False Then IO.Directory.CreateDirectory(f)

            f &= "\REP" & r.Next(0, Integer.MaxValue) & ".xlsx"
            iGrid.ExportToXlsx(f)

            Process.Start("EXPLORER.EXE", Chr(34) & f & Chr(34))

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        End Try
    End Sub

End Module