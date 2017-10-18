Imports System.ComponentModel

Module ListToDataTable

    <System.Runtime.CompilerServices.Extension>
    Friend Function ToDataTable(Of T)(data As IList(Of T)) As DataTable
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(GetType(T))
        Dim dt As New DataTable()
        For i As Integer = 0 To properties.Count - 1
            Dim [property] As PropertyDescriptor = properties(i)
            dt.Columns.Add([property].Name, [property].PropertyType)
        Next
        Dim values As Object() = New Object(properties.Count - 1) {}
        For Each item As T In data
            For i As Integer = 0 To values.Length - 1
                values(i) = properties(i).GetValue(item)
            Next
            dt.Rows.Add(values)
        Next
        Return dt
    End Function

End Module