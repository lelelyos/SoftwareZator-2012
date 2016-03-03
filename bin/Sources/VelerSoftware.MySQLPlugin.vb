Module VelerSoftware_MySQLPlugin

    Private HostConnect As New MySql.Data.MySqlClient.MySqlConnection
    Private da As New MySql.Data.MySqlClient.MySqlDataAdapter
    Private cb As New MySql.Data.MySqlClient.MySqlCommandBuilder
    Private dst As New System.Data.DataSet

    Public Function Connect_MySQL(ByVal Host As String, ByVal Port As String, ByVal Login As String, ByVal Password As String, ByVal Initial_DataBase As String, ByVal Encrypt As Boolean) As Integer
        Disconnect_MySQL()

        HostConnect = New MySql.Data.MySqlClient.MySqlConnection("Server=" & Host & ";User ID=" & Login & ";Password=" & Password & ";")
        Try
            HostConnect.Open() ' connexion en cours
            If HostConnect.State = System.Data.ConnectionState.Open Then
                Return 1
            Else
                Return -3
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            If ex.Message.StartsWith("Unable") Then ' hote introuvable
                Return -1
            ElseIf ex.Message.StartsWith("#28000") Then ' login ou pwd incorrecte
                Return -2
            Else
                System.Windows.Forms.MessageBox.Show("Unable to connect to the server, with a unknow error : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return -3
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Unable to connect to the server, with a unknow error : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -3
        End Try
    End Function

    Public Function Disconnect_MySQL() As Integer
        Try
            If HostConnect IsNot Nothing AndAlso HostConnect.State = System.Data.ConnectionState.Open Then
                HostConnect.Close()
                HostConnect.Dispose()
            End If
            If HostConnect IsNot Nothing Then
                If HostConnect.State = System.Data.ConnectionState.Closed Then
                    Return 1
                Else
                    Return 0
                End If
            Else
                Return 1
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error closing the database : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function GetConnectStatus_MySQL() As Integer
        Try
            If HostConnect IsNot Nothing Then
                Select Case HostConnect.State
                    Case System.Data.ConnectionState.Broken
                        Return 2
                    Case System.Data.ConnectionState.Closed
                        Return 0
                    Case System.Data.ConnectionState.Connecting
                        Return 3
                    Case System.Data.ConnectionState.Executing
                        Return 4
                    Case System.Data.ConnectionState.Fetching
                        Return 5
                    Case System.Data.ConnectionState.Open
                        Return 1
                    Case Else
                        Return 0
                End Select
            Else
                Return 0
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error determine database's status : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function CreateNewDataBase_MySQL(ByVal database_name As String) As String
        Try
            If GetConnectStatus_MySQL() = 1 Then
                Dim cmd As New MySql.Data.MySqlClient.MySqlCommand("CREATE DATABASE " & database_name & ";", HostConnect)

                Try
                    cmd.ExecuteReader().Close()

                    Return 1
                Catch ex As MySql.Data.MySqlClient.MySqlException
                    System.Windows.Forms.MessageBox.Show("Unable to create the database : " + ex.Message)
                    Return -1
                Catch ex As System.Exception
                    System.Windows.Forms.MessageBox.Show("Unable to create the database : " + ex.Message)
                    Return -1
                Finally
                    cmd.Dispose()
                End Try
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error creating the database : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
        Return -1
    End Function

    Public Function ChangeDataBase_MySQL(ByVal database_name As String) As Integer
        Try
            HostConnect.ChangeDatabase(database_name)
            Return 1
        Catch ex As MySql.Data.MySqlClient.MySqlException
            System.Windows.Forms.MessageBox.Show("Unable touch database : " + ex.Message)
            Return -1
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Unable touch database : " + ex.Message)
            Return -1
        End Try
    End Function

    Public Function GetDatabases_MySQL() As System.Collections.Generic.List(Of Object)
        Dim resultat As New System.Collections.Generic.List(Of Object)
        If GetConnectStatus_MySQL() = 1 Then

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = Nothing
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand("SHOW DATABASES", HostConnect)

            Try
                reader = cmd.ExecuteReader()

                While (reader.Read())
                    resultat.Add(reader.GetString(0))
                End While
            Catch ex As MySql.Data.MySqlClient.MySqlException
                System.Windows.Forms.MessageBox.Show("Unable to get the list of database : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show("Unable to get the list of database : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                reader.Close()
            End Try

            If Not reader Is Nothing Then reader.Close()

        End If

        Return resultat
    End Function

    Public Function GetTables_MySQL() As System.Collections.Generic.List(Of Object)
        Dim resultat As New System.Collections.Generic.List(Of Object)
        If GetConnectStatus_MySQL() = 1 Then

            Dim reader As MySql.Data.MySqlClient.MySqlDataReader = Nothing
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand("SHOW TABLES", HostConnect)

            Try
                reader = cmd.ExecuteReader()

                While (reader.Read())
                    resultat.Add(reader.GetString(0))
                End While
                reader.Close()
            Catch ex As MySql.Data.MySqlClient.MySqlException
                System.Windows.Forms.MessageBox.Show("Unable to get the list of tables : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show("Unable to get the list of tables : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                reader.Close()
            End Try

            If Not reader Is Nothing Then reader.Close()

        End If

        Return resultat
    End Function

    Public Function GetTables_MySQL(ByVal database_name As String) As System.Collections.Generic.List(Of Object)
        Dim resultat As New System.Collections.Generic.List(Of Object)
        If GetConnectStatus_MySQL() = 1 Then
            If Not database_name = "" Then
                If ChangeDataBase_MySQL(database_name) = 1 Then resultat = GetTables_MySQL()
            Else
                resultat = GetTables_MySQL()
            End If
        End If
        Return resultat
    End Function

    Public Function GetDataTable_MySQL(ByVal table_name As String) As System.Data.DataTable
        Dim resultat As New System.Data.DataTable

        Try
            If GetConnectStatus_MySQL() = 1 Then
                Dim das As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM " + table_name, HostConnect)
                Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(das)
                das.Fill(resultat)
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            System.Windows.Forms.MessageBox.Show("Unable to get the DataTable from the table " & table_name & " : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Unable to get the DataTable from the table " & table_name & " : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return resultat
    End Function

    Public Function ExecuteRequest_MySQL(ByVal request As String) As System.Collections.Generic.List(Of Object)
        Dim resultat As New System.Collections.Generic.List(Of Object)
        Try
            If GetConnectStatus_MySQL() = 1 Then
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand(request, HostConnect)
                    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                    While (reader.Read())
                        resultat.Add(reader.GetValue(0))
                    End While
                    reader.Close()
                End Using
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error executing request : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return resultat
    End Function

    Public Function CreateNewTable_MySQL(ByVal nom As String, ByVal columns As System.Collections.Generic.List(Of String), ByVal types As System.Collections.Generic.List(Of String)) As Integer
        Try
            If GetConnectStatus_MySQL() = 1 Then
                Dim param As New System.Text.StringBuilder
                For i As Integer = 0 To columns.Count - 1
                    param.Append(columns(i) & " " & types(i) & ", ")
                Next

                If Not param.ToString = Nothing Then
                    Using cmd As New MySql.Data.MySqlClient.MySqlCommand("CREATE TABLE " & nom & "(Id integer default NULL auto_increment, " & param.ToString.TrimEnd(" ").TrimEnd(",") & ", PRIMARY KEY (Id));", HostConnect)
                        cmd.ExecuteReader().Close()
                    End Using
                Else
                    Using cmd As New MySql.Data.MySqlClient.MySqlCommand("CREATE TABLE " & nom & "(Id integer default NULL auto_increment, PRIMARY KEY (Id));", HostConnect)
                        cmd.ExecuteReader().Close()
                    End Using
                End If
                param.Clear()
                param = Nothing
                Return 1
            Else
                Return -1
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error creating table : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function UpdateDataTable_MySQL(ByVal dat As System.Data.DataTable, ByVal old_table_name As String) As String
        Dim resultat As String = Nothing

        Try
            If Not dat Is Nothing Then
                dat.TableName = old_table_name
                Dim changes As System.Data.DataTable = dat.GetChanges()
                If Not changes Is Nothing Then
                    Dim das As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM " + old_table_name, HostConnect)
                    Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(das)
                    das.Update(changes)
                    dat.AcceptChanges()
                    Return 1
                Else
                    Return 2
                End If
            Else
                Return -1
            End If
        Catch ex As MySql.Data.MySqlClient.MySqlException
            System.Windows.Forms.MessageBox.Show("Unable to update the table '" & old_table_name & "' : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Unable to update the table '" & old_table_name & "' : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try

        Return resultat
    End Function

    Public Function DeleteTable_MySQL(ByVal table_name As String) As Integer
        Try
            If GetConnectStatus_MySQL() = 1 Then
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand("DROP TABLE " & table_name & ";", HostConnect)
                    cmd.ExecuteReader().Close()
                End Using
                Return 1
            Else
                Return -1
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error deleting table : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function RenameTable_MySQL(ByVal table_name As String, ByVal new_name As String) As Integer
        Try
            If GetConnectStatus_MySQL() = 1 Then
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand("RENAME TABLE " & table_name & " TO " & new_name & ";", HostConnect)
                    cmd.ExecuteReader().Close()
                End Using
                Return 1
            Else
                Return -1
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error renaming table : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function GetColumnsList_MySQL(ByVal table_name As String) As System.Collections.Generic.List(Of Object)
        Dim resultat As New System.Collections.Generic.List(Of Object)
        Try
            If GetConnectStatus_MySQL() = 1 Then
                For Each col As System.Data.DataColumn In GetDataTable_MySQL(table_name).Columns
                    resultat.Add(col.ColumnName)
                Next
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error getting database's tables : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return resultat
    End Function

    Public Function GetColumnsCountTable_MySQL(ByVal table_name As String) As Integer
        Try
            If GetConnectStatus_MySQL() = 1 Then
                Return GetDataTable_MySQL(table_name).Columns.Count
            Else
                Return -1
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error getting number of columns in the table : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function AddColumnTable_MySQL(ByVal table_name As String, ByVal column_name As String, ByVal typed As String) As Integer
        Try
            If GetConnectStatus_MySQL() = 1 Then
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand("ALTER TABLE " & table_name & " ADD [" & column_name & "] " & typed & ";", HostConnect)
                    cmd.ExecuteReader().Close()
                End Using
                Return 1
            Else
                Return -1
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Unable to add a row to the table " & table_name & " : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function GetRowsCountTable_MySQL(ByVal table_name As String) As Integer
        Try
            If GetConnectStatus_MySQL() = 1 Then
                Dim columns As System.Collections.Generic.List(Of Object) = GetColumnsList_MySQL(table_name)
                If columns.Count > 0 Then
                    Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(" & columns(0) & ") FROM " & table_name & ";", HostConnect)
                        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        While (reader.Read())
                            Return reader.GetValue(0)
                            Exit While
                        End While
                        reader.Close()
                    End Using
                End If
                Return 0
            Else
                Return -1
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error getting number of rows in the table : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function AddRowTable_MySQL(ByVal table_name As String, ByVal index As Integer, ByVal values As System.Collections.Generic.List(Of Object)) As Integer
        Try
            If GetConnectStatus_MySQL() = 1 Then
                Dim param As New System.Text.StringBuilder
                For Each Val As Object In values
                    If TypeOf Val Is String Then
                        param.Append("'" & CStr(Val) & "', ")
                    Else
                        param.Append(Val & ", ")
                    End If
                Next

                Using cmd As New MySql.Data.MySqlClient.MySqlCommand("INSERT INTO " & table_name & " VALUES (" & index & ", " & param.ToString.TrimEnd(" ").TrimEnd(",") & ");", HostConnect)
                    cmd.ExecuteReader().Close()
                End Using

                param.Clear()
                param = Nothing
                Return 1
            Else
                Return -1
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Unable to add a row to the table " & table_name & " : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function ChangeRowTable_MySQL(ByVal table_name As String, ByVal index As Integer, ByVal column_name As String, ByVal value As Object) As Integer
        Try
            If GetConnectStatus_MySQL() = 1 Then
                If TypeOf value Is String Then
                    Using cmd As New MySql.Data.MySqlClient.MySqlCommand("UPDATE " & table_name & " SET [" & column_name & "] = '" & value & "' WHERE Id = " & index & ";", HostConnect)
                        cmd.ExecuteReader().Close()
                    End Using
                Else
                    Using cmd As New MySql.Data.MySqlClient.MySqlCommand("UPDATE " & table_name & " SET [" & column_name & "] = " & value & " WHERE Id = " & index & ";", HostConnect)
                        cmd.ExecuteReader().Close()
                    End Using
                End If
                Return 1
            Else
                Return -1
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Unable to change a row to the table " & table_name & " : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function DeleteRowTable_MySQL(ByVal table_name As String, ByVal index As Integer) As Integer
        Try
            If GetConnectStatus_MySQL() = 1 Then
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand("DELETE FROM " & table_name & " WHERE Id = " & index & ";", HostConnect)
                    cmd.ExecuteReader().Close()
                End Using
                Return 1
            Else
                Return -1
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Unable to delete a row to the table " & table_name & " : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function GetSingleValueOfRow_MySQL(ByVal table_name As String, ByVal column_name As String, Optional ByVal index As Integer = -1, Optional ByVal condition As String = Nothing) As Object
        Try
            If GetConnectStatus_MySQL() = 1 Then
                If Not index = -1 Then
                    Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT [" & column_name & "] FROM " & table_name & " WHERE Id = " & index & ";", HostConnect)
                        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        While (reader.Read())
                            Return reader.GetValue(0)
                            Exit While
                        End While
                        reader.Close()
                    End Using
                ElseIf Not condition = Nothing Then
                    Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT [" & column_name & "] FROM " & table_name & " WHERE " & condition & ";", HostConnect)
                        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        While (reader.Read())
                            Return reader.GetValue(0)
                            Exit While
                        End While
                        reader.Close()
                    End Using
                End If
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error getting database's tables : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing
    End Function

    Public Function GetValuesOfRows_MySQL(ByVal table_name As String, ByVal column_name As String, ByVal condition As String) As System.Collections.Generic.List(Of Object)
        Dim resultat As New System.Collections.Generic.List(Of Object)
        Try
            If GetConnectStatus_MySQL() = 1 Then
                If condition = Nothing Then
                    Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT [" & column_name & "] FROM " & table_name & ";", HostConnect)
                        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        While (reader.Read())
                            resultat.Add(reader.GetValue(0))
                        End While
                        reader.Close()
                    End Using
                Else
                    Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT [" & column_name & "] FROM " & table_name & " WHERE " & condition & ";", HostConnect)
                        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                        While (reader.Read())
                            resultat.Add(reader.GetValue(0))
                        End While
                        reader.Close()
                    End Using
                End If
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error getting database's tables : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return resultat
    End Function

End Module
