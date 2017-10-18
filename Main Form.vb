Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports DevExpress.XtraGrid
Imports System.Data.SqlClient

Public Class ExcelExtracter

    Dim ExcelFile As String = String.Empty
    Dim ExcelSheetsName As System.Data.DataTable = Nothing
    Dim T As List(Of Tours) = Nothing

    Friend Direction As String = String.Empty
    Friend DirectionID As Integer = 0
    Friend DeleteRows As Boolean = False
    Friend AutoSave As Boolean = False

    Dim WithEvents Tm As New System.Timers.Timer

    Dim startTime As DateTime

    Structure RowVal
        Dim RO As String
        Dim BB As String
        Dim HB As String
        Dim FB As String
        Dim ALL As String
        Dim StayMin As String
        Dim StayMax As String
        Dim FreeNight As String
        Dim Weekdays As String
    End Structure

    Sub Timer_Tick() Handles Tm.Elapsed
        On Error Resume Next

        Dim endTime As DateTime = Now
        Dim duration As TimeSpan = endTime - startTime

        txtTime.Text = duration.ToString("dd\.hh\:mm\:ss")
        txtTime.Refresh()
    End Sub

#Region "Next"

    Private Function GetEndRow(startRow As Integer, sheet As Microsoft.Office.Interop.Excel.Worksheet) As Integer
        Dim xRange As Excel.Range
        For Each xRange In sheet.UsedRange
            If xRange.Column = 1 Then
                If xRange.MergeCells = True Then
                    If xRange.Address = "$A$" & startRow Then
                        Return xRange.MergeArea(xRange.MergeArea.Count).Row
                        Exit Function
                    End If
                End If
            End If
        Next
        Return 0
    End Function

    Private Function GetNext(startRow As Integer, RV As RowVal, hotel As String, sheet As Microsoft.Office.Interop.Excel.Worksheet) As Integer

        Dim endRow As Integer = GetEndRow(startRow, sheet)

        If startRow = 0 OrElse endRow = 0 Then Throw New Exception("Excel-ի Range-ը անորոշ է")

        Dim Room_Category As String = sheet.Range("A" & startRow).Value

        Dim LastAccommodation As String = String.Empty

        For j As Integer = startRow To endRow
            Dim Accommodation As String = sheet.Range("B" & j).Value
            Dim dateFrom As String = sheet.Range("C" & j).Value
            Dim dateTo As String = sheet.Range("D" & j).Value

            Dim BookingFrom As String = sheet.Range("E" & j).Value
            Dim BookingTill As String = sheet.Range("F" & j).Value

            Dim RO As Integer
            If RV.RO <> String.Empty Then RO = sheet.Range(RV.RO & j).Value

            Dim BB As Integer
            If RV.BB <> String.Empty Then BB = sheet.Range(RV.BB & j).Value

            Dim HB As Integer
            If RV.HB <> String.Empty Then HB = sheet.Range(RV.HB & j).Value

            Dim FB As Integer
            If RV.FB <> String.Empty Then FB = sheet.Range(RV.FB & j).Value

            Dim All As Integer
            If RV.ALL <> String.Empty Then All = sheet.Range(RV.ALL & j).Value

            Dim StayMin As Integer
            If RV.StayMin <> String.Empty Then StayMin = sheet.Range(RV.StayMin & j).Value

            Dim StayMax As Integer
            If RV.StayMax <> String.Empty Then StayMax = sheet.Range(RV.StayMax & j).Value

            Dim FreeNight As Integer
            If RV.FreeNight <> String.Empty Then FreeNight = sheet.Range(RV.FreeNight & j).Value

            Dim Weekdays As String = String.Empty
            If RV.Weekdays <> String.Empty Then Weekdays = sheet.Range(RV.Weekdays & j).Value

            If Accommodation <> String.Empty Then
                LastAccommodation = Accommodation
            ElseIf Accommodation = String.Empty Then
                If LastAccommodation <> String.Empty Then Accommodation = LastAccommodation
            End If

            T.Add(New Tours With {.Hotel = hotel, .Room_Category = Room_Category,
                  .Accommodation = Accommodation, .dateFrom = dateFrom, .dateTo = dateTo,
                  .BookingFrom = BookingFrom, .BookingTill = BookingTill,
                  .RO = RO, .BB = BB, .HB = HB, .FB = FB, .All = All,
                  .StayMin = StayMin, .StayMax = StayMax, .FreeNight = FreeNight, .Weekdays = Weekdays})

            'Save to DB
            If AutoSave = True Then
                Dim Parameters As New List(Of SqlParameter)
                With Parameters
                    .Add(New SqlParameter("@Hotel", hotel))
                    .Add(New SqlParameter("@DirectionID", DirectionID))

                    .Add(New SqlParameter("@RoomCategory", Room_Category))
                    .Add(New SqlParameter("@Accommodation", Accommodation))

                    If dateFrom = String.Empty Then
                        .Add(New SqlParameter("@From", DBNull.Value))
                    Else
                        Dim df As New Date(Microsoft.VisualBasic.Right(dateFrom, 4), Microsoft.VisualBasic.Mid(dateFrom, 4, 2), Microsoft.VisualBasic.Left(dateFrom, 2))
                        .Add(New SqlParameter("@From", df))
                    End If

                    If dateTo = String.Empty Then
                        .Add(New SqlParameter("@To", DBNull.Value))
                    Else
                        Dim dt As New Date(Microsoft.VisualBasic.Right(dateTo, 4), Microsoft.VisualBasic.Mid(dateTo, 4, 2), Microsoft.VisualBasic.Left(dateTo, 2))
                        .Add(New SqlParameter("@To", dt))
                    End If

                    If BookingFrom = String.Empty Then
                        .Add(New SqlParameter("@BookingFrom", DBNull.Value))
                    Else
                        Dim BF As New Date(Microsoft.VisualBasic.Right(BookingFrom, 4), Microsoft.VisualBasic.Mid(BookingFrom, 4, 2), Microsoft.VisualBasic.Left(BookingFrom, 2))
                        .Add(New SqlParameter("@BookingFrom", BF))
                    End If

                    If BookingTill = String.Empty Then
                        .Add(New SqlParameter("@BookingTill", DBNull.Value))
                    Else
                        Dim BT As New Date(Microsoft.VisualBasic.Right(BookingTill, 4), Microsoft.VisualBasic.Mid(BookingTill, 4, 2), Microsoft.VisualBasic.Left(BookingTill, 2))
                        .Add(New SqlParameter("@BookingTill", BT))
                    End If

                    .Add(New SqlParameter("@RO", IIf(RO = 0, DBNull.Value, RO)))
                    .Add(New SqlParameter("@BB", IIf(BB = 0, DBNull.Value, BB)))
                    .Add(New SqlParameter("@HB", IIf(HB = 0, DBNull.Value, HB)))
                    .Add(New SqlParameter("@FB", IIf(FB = 0, DBNull.Value, FB)))
                    .Add(New SqlParameter("@ALL", IIf(All = 0, DBNull.Value, All)))

                    .Add(New SqlParameter("@StayMin", IIf(StayMin = 0, DBNull.Value, StayMin)))
                    .Add(New SqlParameter("@StayMax", IIf(StayMax = 0, DBNull.Value, StayMax)))
                    .Add(New SqlParameter("@FreeNight", IIf(FreeNight = 0, DBNull.Value, FreeNight)))
                    .Add(New SqlParameter("@Weekdays", IIf(Weekdays = String.Empty, DBNull.Value, Weekdays)))

                End With
                ExecToSql("AddTourList", CommandType.StoredProcedure, Parameters.ToArray)
            End If

        Next

        If sheet.Range("A" & endRow + 1).Value <> String.Empty Then
            endRow = GetNext(endRow + 1, RV, hotel, sheet)
        End If

        Return endRow

    End Function

#End Region

#Region "Grid"

    Private Sub SetGreed()
        GridControl1.BeginUpdate()
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        GridControl1.DataSource = ToDataTable(T)

        With GridView1
            .OptionsCustomization.AllowColumnMoving = False
            .OptionsCustomization.AllowGroup = False
            .OptionsSelection.EnableAppearanceFocusedCell = False
            .OptionsSelection.EnableAppearanceFocusedRow = False

            '.Columns("TourOperatorID").Visible = False
            '.Columns("OperatorName").Caption = "Օպերատոր"

            For i As Integer = 0 To GridView1.Columns.Count - 1
                .Columns(i).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
            Next

        End With

        If GridView1.RowCount > 0 Then
            If GridView1.Columns("Hotel").Summary.ActiveCount = 0 Then
                Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Hotel", "{0}")
                GridView1.Columns("Hotel").Summary.Add(item)
            End If
        End If

        GridView1.ClearSelection()
        GridControl1.EndUpdate()
    End Sub

#End Region

    Private Sub btnLoadExcel_Click(sender As Object, e As EventArgs) Handles btnLoadExcel.Click
        btnLoadExcel.Enabled = False
        btnExcelSheet.Enabled = False
        btnExcelData.Enabled = False
        Try
            Dim fDialog As OpenFileDialog = New OpenFileDialog
            With fDialog
                .Filter = ""
                .Multiselect = False
                .Title = "Նշեք Excel-ի Ֆայլ"
                If .ShowDialog() <> Windows.Forms.DialogResult.OK Then Exit Sub
                If String.IsNullOrEmpty(.FileName) Then Exit Sub
                ExcelFile = .FileName
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        Finally
            btnExcelSheet.Enabled = True
            btnExcelData.Enabled = True
        End Try
    End Sub

    Private Sub btnExcelSheet_Click(sender As Object, e As EventArgs) Handles btnExcelSheet.Click
        btnExcelSheet.Enabled = False
        btnExcelData.Enabled = False

        Dim connExcel As OleDbConnection
        Dim cmdExcel As New OleDbCommand()
        Dim oda As New OleDbDataAdapter()

        Try
            If String.IsNullOrEmpty(ExcelFile) Then Throw New Exception("Excel-ի ֆայլը նշված չէ")

            ExcelSheetsName = Nothing

            connExcel = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" & ExcelFile & ";Extended Properties=Excel 12.0;")

            cmdExcel.Connection = connExcel
            connExcel.Open()

            Dim dt As System.Data.DataTable
            dt = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

            connExcel.Close()

            ExcelSheetsName = New System.Data.DataTable

            ExcelSheetsName = (From n In dt.AsEnumerable()
                               Where n.Field(Of String)("TABLE_TYPE") = "TABLE"
                               Select n).CopyToDataTable()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        Finally
            If Not IsNothing(connExcel) Then
                If connExcel.State <> ConnectionState.Closed Then
                    connExcel.Close()
                End If
                connExcel.Dispose()
                connExcel = Nothing
            End If
            btnExcelData.Enabled = True
        End Try
    End Sub

    Private Sub btnExcelData_Click(sender As Object, e As EventArgs) Handles btnExcelData.Click
        btnExcelData.Enabled = False
        Dim xlApp As New Microsoft.Office.Interop.Excel.Application
        Try
            If String.IsNullOrEmpty(ExcelFile) Then Throw New Exception("Excel-ի ֆայլը նշված չէ")
            If IsNothing(ExcelSheetsName) OrElse ExcelSheetsName.Rows.Count = 0 Then Throw New Exception("Excel—ի պարունակությունը բացակայում է")

            xlApp.DisplayAlerts = False

            Dim wbk As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Open(ExcelFile)

            T = Nothing
            T = New List(Of Tours)

            startTime = Now

            Tm.Interval = 1000
            Tm.Start()

            For j As Integer = 0 To ExcelSheetsName.Rows.Count - 1
                Dim Table_Name As String = ExcelSheetsName.Rows(j)("TABLE_NAME")

                Table_Name = Replace(Table_Name, "'", "")
                Table_Name = Replace(Table_Name, "$", "")

                txtShhet.Text = Table_Name

                If Table_Name = "GENERAL" Then Continue For
                If Table_Name = "CONTACTS" Then Continue For
                If Table_Name = "TRANSFER" Then Continue For
                If Table_Name = "VISA" Then Continue For
                If Table_Name = "AIRPORT SERVICES" Then Continue For
                If Table_Name = "TOURS&EXCURSIONS" Then Continue For

                Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(wbk.Worksheets(Table_Name), Microsoft.Office.Interop.Excel.Worksheet)

                Dim hotel As String = sheet.Range("B8").Value

                'delete list from db
                If DeleteRows = True AndAlso Not String.IsNullOrEmpty(hotel) Then
                    Dim Parameters As New List(Of SqlParameter)
                    With Parameters
                        .Add(New SqlParameter("@DirectionID", DirectionID))
                        .Add(New SqlParameter("@Hotel", hotel))
                    End With
                    ExecToSql("DelTourList", CommandType.StoredProcedure, Parameters.ToArray)
                End If

                Dim excRange As Excel.Range

                For i = 9 To CInt(sheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row)
                    excRange = sheet.Range("A" & i)

                    If excRange.Value = "ROOM CATEGORY" Then

                        Dim RV As New RowVal

                        Dim _G As String = sheet.Range("G" & i).Value
                        Select Case _G
                            Case "RO"
                                RV.RO = "G"
                            Case "BB"
                                RV.BB = "G"
                            Case "HB"
                                RV.HB = "G"
                            Case "FB"
                                RV.FB = "G"
                            Case "ALL"
                                RV.ALL = "G"
                            Case Else
                                If InStr(_G, "Min") > 0 Then
                                    RV.StayMin = "G"
                                ElseIf InStr(_G, "Max") > 0 Then
                                    RV.StayMax = "G"
                                ElseIf _G = "FreeNight" Then
                                    RV.FreeNight = "G"
                                ElseIf _G = "Weekdays" Then
                                    RV.Weekdays = "G"
                                End If
                        End Select

                        Dim _H As String = sheet.Range("H" & i).Value
                        Select Case _H
                            Case "RO"
                                RV.RO = "H"
                            Case "BB"
                                RV.BB = "H"
                            Case "HB"
                                RV.HB = "H"
                            Case "FB"
                                RV.FB = "H"
                            Case "ALL"
                                RV.ALL = "H"
                            Case Else
                                If InStr(_H, "Min") > 0 Then
                                    RV.StayMin = "H"
                                ElseIf InStr(_H, "Max") > 0 Then
                                    RV.StayMax = "H"
                                ElseIf _H = "FreeNight" Then
                                    RV.FreeNight = "H"
                                ElseIf _H = "Weekdays" Then
                                    RV.Weekdays = "H"
                                End If
                        End Select

                        Dim _I As String = sheet.Range("I" & i).Value
                        Select Case _I
                            Case "RO"
                                RV.RO = "I"
                            Case "BB"
                                RV.BB = "I"
                            Case "HB"
                                RV.HB = "I"
                            Case "FB"
                                RV.FB = "I"
                            Case "ALL"
                                RV.ALL = "I"
                            Case Else
                                If InStr(_I, "Min") > 0 Then
                                    RV.StayMin = "I"
                                ElseIf InStr(_I, "Max") > 0 Then
                                    RV.StayMax = "I"
                                ElseIf _I = "FreeNight" Then
                                    RV.FreeNight = "I"
                                ElseIf _I = "Weekdays" Then
                                    RV.Weekdays = "I"
                                End If
                        End Select

                        Dim _J As String = sheet.Range("J" & i).Value
                        Select Case _J
                            Case "RO"
                                RV.RO = "J"
                            Case "BB"
                                RV.BB = "J"
                            Case "HB"
                                RV.HB = "J"
                            Case "FB"
                                RV.FB = "J"
                            Case "ALL"
                                RV.ALL = "J"
                            Case Else
                                If InStr(_J, "Min") > 0 Then
                                    RV.StayMin = "J"
                                ElseIf InStr(_J, "Max") > 0 Then
                                    RV.StayMax = "J"
                                ElseIf _J = "FreeNight" Then
                                    RV.FreeNight = "J"
                                ElseIf _J = "Weekdays" Then
                                    RV.Weekdays = "J"
                                End If
                        End Select

                        Dim _K As String = sheet.Range("K" & i).Value
                        Select Case _K
                            Case "RO"
                                RV.RO = "K"
                            Case "BB"
                                RV.BB = "K"
                            Case "HB"
                                RV.HB = "K"
                            Case "FB"
                                RV.FB = "K"
                            Case "ALL"
                                RV.ALL = "K"
                            Case Else
                                If InStr(_K, "Min") > 0 Then
                                    RV.StayMin = "K"
                                ElseIf InStr(_K, "Max") > 0 Then
                                    RV.StayMax = "K"
                                ElseIf _K = "FreeNight" Then
                                    RV.FreeNight = "K"
                                ElseIf _K = "Weekdays" Then
                                    RV.Weekdays = "K"
                                End If
                        End Select

                        Dim _L As String = sheet.Range("L" & i).Value
                        Select Case _L
                            Case "RO"
                                RV.RO = "L"
                            Case "BB"
                                RV.BB = "L"
                            Case "HB"
                                RV.HB = "L"
                            Case "FB"
                                RV.FB = "L"
                            Case "ALL"
                                RV.ALL = "L"
                            Case Else
                                If InStr(_L, "Min") > 0 Then
                                    RV.StayMin = "L"
                                ElseIf InStr(_L, "Max") > 0 Then
                                    RV.StayMax = "L"
                                ElseIf _L = "FreeNight" Then
                                    RV.FreeNight = "L"
                                ElseIf _L = "Weekdays" Then
                                    RV.Weekdays = "L"
                                End If
                        End Select

                        Dim _M As String = sheet.Range("M" & i).Value
                        Select Case _M
                            Case "RO"
                                RV.RO = "M"
                            Case "BB"
                                RV.BB = "M"
                            Case "HB"
                                RV.HB = "M"
                            Case "FB"
                                RV.FB = "M"
                            Case "ALL"
                                RV.ALL = "M"
                            Case Else
                                If InStr(_M, "Min") > 0 Then
                                    RV.StayMin = "M"
                                ElseIf InStr(_M, "Max") > 0 Then
                                    RV.StayMax = "M"
                                ElseIf _M = "FreeNight" Then
                                    RV.FreeNight = "M"
                                ElseIf _M = "Weekdays" Then
                                    RV.Weekdays = "M"
                                End If
                        End Select

                        Dim _N As String = sheet.Range("N" & i).Value
                        Select Case _N
                            Case "RO"
                                RV.RO = "N"
                            Case "BB"
                                RV.BB = "N"
                            Case "HB"
                                RV.HB = "N"
                            Case "FB"
                                RV.FB = "N"
                            Case "ALL"
                                RV.ALL = "N"
                            Case Else
                                If InStr(_N, "Min") > 0 Then
                                    RV.StayMin = "N"
                                ElseIf InStr(_N, "Max") > 0 Then
                                    RV.StayMax = "N"
                                ElseIf _N = "FreeNight" Then
                                    RV.FreeNight = "N"
                                ElseIf _N = "Weekdays" Then
                                    RV.Weekdays = "N"
                                End If
                        End Select

                        Dim _P As String = sheet.Range("P" & i).Value
                        Select Case _P
                            Case "RO"
                                RV.RO = "P"
                            Case "BB"
                                RV.BB = "P"
                            Case "HB"
                                RV.HB = "P"
                            Case "FB"
                                RV.FB = "P"
                            Case "ALL"
                                RV.ALL = "P"
                            Case Else
                                If InStr(_P, "Min") > 0 Then
                                    RV.StayMin = "P"
                                ElseIf InStr(_P, "Max") > 0 Then
                                    RV.StayMax = "P"
                                ElseIf _P = "FreeNight" Then
                                    RV.FreeNight = "P"
                                ElseIf _P = "Weekdays" Then
                                    RV.Weekdays = "P"
                                End If
                        End Select

                        i = GetNext(i + 1, RV, hotel, sheet)
                    End If

                    txtCount.Text = T.Count

                    Me.Refresh()
                    My.Application.DoEvents()
                Next

            Next


            wbk.Close(SaveChanges:=False)
            xlApp.Quit()
            xlApp = Nothing

            Call SetGreed()

            txtShhet.Text = String.Empty
            txtCount.Text = String.Empty

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, My.Application.Info.Title)
        Finally
            If Not IsNothing(xlApp) Then xlApp = Nothing
            Tm.Stop()
        End Try
    End Sub

    Private Sub ExcelExtracter_Load(sender As Object, e As EventArgs) Handles Me.Load
        Control.CheckForIllegalCrossThreadCalls = False
        txtDirection.Text = Direction
    End Sub

    Private Sub btnToExcel_Click(sender As Object, e As EventArgs) Handles btnToExcel.Click
        ExportTo(GridControl1, Me.Text)
    End Sub

    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        On Error Resume Next
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Dim grid As DevExpress.XtraGrid.GridControl = sender
            Dim view As New DevExpress.XtraGrid.Views.Grid.GridView()
            view = GridControl1.FocusedView
            Clipboard.SetText(view.GetFocusedDisplayText())
            e.Handled = True
        End If
    End Sub

End Class