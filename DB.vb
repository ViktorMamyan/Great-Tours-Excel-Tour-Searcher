Imports System.Data.SqlClient

Module DB

    Friend SQLString As String = "Server=127.0.0.1;Initial Catalog=GTListOfTours;Integrated Security=True;"

    'Friend SQLString As String = "Data Source=192.168.1.102\GT,9999;Initial Catalog=GTListOfTours;User ID=gtUser;Password=abcgtuserpass"

    Friend Function QueryToSqlServer(ByVal CommandText As String, ByVal SqlCommandType As CommandType, Optional ByVal Timeout As Integer = 30) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.CommandTimeout = Timeout
                cmd.Connection = cnn
                cmd.CommandType = SqlCommandType
                cmd.CommandText = CommandText
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
            cnn.Close()
        End Using
        Return dt
    End Function

    Friend Function QueryToSqlServer(ByVal CommandText As String, ByVal SqlCommandType As CommandType, ByVal p() As SqlClient.SqlParameter, Optional ByVal Timeout As Integer = 30) As DataTable
        Dim dt As DataTable
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.CommandTimeout = Timeout
                cmd.Connection = cnn
                cmd.CommandType = SqlCommandType
                cmd.CommandText = CommandText
                cmd.Parameters.AddRange(p)
                Using da As New SqlDataAdapter(cmd)
                    dt = New System.Data.DataTable
                    da.Fill(dt)
                End Using
            End Using
            cnn.Close()
        End Using
        Return dt
    End Function

    Friend Sub ExecToSql(ByVal CommandText As String, ByVal SqlCommandType As CommandType, ByVal p() As SqlClient.SqlParameter, Optional ByVal Timeout As Integer = 30)
        Using connection As New SqlConnection(SQLString)
            Dim Exec As New SqlCommand
            Exec.CommandTimeout = Timeout
            Exec.Connection = connection
            Exec.CommandText = CommandText
            Exec.CommandType = SqlCommandType
            Exec.Parameters.AddRange(p)
            connection.Open()
            Exec.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    Friend Sub ExecToSql(ByVal CommandText As String, ByVal SqlCommandType As CommandType, Optional ByVal Timeout As Integer = 30)
        Using connection As New SqlConnection(SQLString)
            Dim Exec As New SqlCommand
            Exec.CommandTimeout = Timeout
            Exec.Connection = connection
            Exec.CommandText = CommandText
            Exec.CommandType = SqlCommandType
            connection.Open()
            Exec.ExecuteNonQuery()
            connection.Close()
        End Using
    End Sub

    Friend Function Query_Scalar(ByVal CommandText As String) As Object
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = CommandText
                Return cmd.ExecuteScalar()
            End Using
        End Using
    End Function

    Friend Function Query_Scalar(ByVal CommandText As String, ByVal p() As SqlClient.SqlParameter) As Object
        Using cnn As New SqlConnection(SQLString)
            cnn.Open()
            Using cmd As New SqlCommand
                cmd.Connection = cnn
                cmd.Parameters.AddRange(p)
                cmd.CommandType = CommandType.Text
                cmd.CommandText = CommandText
                Return cmd.ExecuteScalar()
            End Using
        End Using
    End Function

End Module