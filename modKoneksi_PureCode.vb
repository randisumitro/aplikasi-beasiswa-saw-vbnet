Imports MySql.Data.MySqlClient
Imports System.Data

' =====================================================
' MODULE KONEKSI DATABASE + SESSION MANAGEMENT
' =====================================================

Module modKoneksi_PureCode

    ' ===== KONFIGURASI DATABASE =====
    Public Const DB_SERVER As String = "localhost"
    Public Const DB_PORT As String = "3306"
    Public Const DB_NAME As String = "db_beasiswa"
    Public Const DB_USER As String = "root"
    Public Const DB_PASSWORD As String = ""

    ' ===== VARIABEL KONEKSI =====
    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader
    Public da As MySqlDataAdapter
    Public dt As DataTable
    Public ds As DataSet

    ' ===== VARIABEL SESSION (untuk menyimpan data user yang login) =====
    Public SessionUserID As Integer = 0
    Public SessionUserName As String = ""
    Public SessionUserLevel As String = ""

    ' ===== FUNCTION: CONNECTION STRING =====
    Public Function GetConnectionString() As String
        Return String.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};", _
                           DB_SERVER, DB_PORT, DB_NAME, DB_USER, DB_PASSWORD)
    End Function

    ' ===== FUNCTION: BUKA KONEKSI =====
    Public Sub OpenConnection()
        Try
            If conn Is Nothing Then
                conn = New MySqlConnection(GetConnectionString())
            End If

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MsgBox("Error Koneksi: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ' ===== FUNCTION: TUTUP KONEKSI =====
    Public Sub CloseConnection()
        Try
            If conn IsNot Nothing Then
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ' ===== FUNCTION: CEK DATABASE EXISTS =====
    Public Function CheckDatabaseExists() As Boolean
        Try
            Dim tempConn As New MySqlConnection( _
                String.Format("Server={0};Port={1};Uid={2};Pwd={3};", _
                DB_SERVER, DB_PORT, DB_USER, DB_PASSWORD))

            tempConn.Open()

            Dim cmd As New MySqlCommand("SHOW DATABASES LIKE '" & DB_NAME & "'", tempConn)
            Dim result As Object = cmd.ExecuteScalar()

            tempConn.Close()

            Return (result IsNot Nothing)
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' ===== FUNCTION: EXECUTE QUERY (SELECT) =====
    Public Function ExecuteQuery(ByVal query As String) As DataTable
        Try
            OpenConnection()
            da = New MySqlDataAdapter(query, conn)
            dt = New DataTable()
            da.Fill(dt)
            CloseConnection()
            Return dt
        Catch ex As Exception
            CloseConnection()
            MsgBox("Error Query: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Try
    End Function

    ' ===== FUNCTION: EXECUTE NON-QUERY (INSERT, UPDATE, DELETE) =====
    Public Function ExecuteNonQuery(ByVal query As String) As Boolean
        Try
            OpenConnection()
            cmd = New MySqlCommand(query, conn)
            cmd.ExecuteNonQuery()
            CloseConnection()
            Return True
        Catch ex As Exception
            CloseConnection()
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    ' ===== FUNCTION: EXECUTE SCALAR (COUNT, SUM, dll) =====
    Public Function ExecuteScalar(ByVal query As String) As Object
        Try
            OpenConnection()
            cmd = New MySqlCommand(query, conn)
            Dim result As Object = cmd.ExecuteScalar()
            CloseConnection()
            Return result
        Catch ex As Exception
            CloseConnection()
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Try
    End Function

    ' ===== FUNCTION: GET TABLE COUNT =====
    Public Function GetTableCount(ByVal tableName As String) As Integer
        Try
            Dim query As String = "SELECT COUNT(*) FROM " & tableName
            Dim result As Object = ExecuteScalar(query)
            Return If(result IsNot Nothing, Convert.ToInt32(result), 0)
        Catch ex As Exception
            Return 0
        End Try
    End Function

End Module