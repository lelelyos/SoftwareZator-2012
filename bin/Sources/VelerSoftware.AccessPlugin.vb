Module VelerSoftware_AccessPlugin

    Private HostConnect As New System.Data.OleDb.OleDbConnection
    Private da As New System.Data.OleDb.OleDbDataAdapter
    Private cb As New System.Data.OleDb.OleDbCommandBuilder
    Private dst As New System.Data.DataSet

    Public Function Connect_Access(ByVal File As String, ByVal Password As String) As Integer
        Disconnect_Access()
        Try
            If System.IO.File.Exists(File) Then
                HostConnect = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & File & ";Jet OLEDB:Database Password=" & Password)
                HostConnect.Open()
                If HostConnect.State = System.Data.ConnectionState.Open Then
                    Return 1
                Else
                    Return -2
                End If
            Else
                Return 0
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Unable to connect to the database, with a unknow error : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
        Return -1
    End Function

    Public Function Disconnect_Access() As Integer
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
        Return -1
    End Function

    Public Function GetConnectStatus_Access() As Integer
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
        Return -1
    End Function

    Public Function CreateNewDataBase_Access(ByVal File As String, ByVal Password As String) As String
        Try
            If Not System.IO.File.Exists(File) Then
                Dim cat As New Interop.ADOX.Catalog
                cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & File & ";Jet OLEDB:Database Password=" & Password)
                cat.ActiveConnection.Close()
                cat = Nothing
                Return 1
            Else
                Return 0
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error creating the database : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
        Return -1
    End Function

    Public Function GetTableList_Access() As System.Collections.Generic.List(Of Object)
        Dim resultat As New System.Collections.Generic.List(Of Object)
        Try
            If GetConnectStatus_Access() = 1 Then
                For Each row As System.Data.DataRow In HostConnect.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, New [Object]() {Nothing, Nothing, Nothing, "TABLE"}).Rows
                    resultat.Add(row.ItemArray(2).ToString)
                Next
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error getting database's tables : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return resultat
    End Function

    Public Function GetDataTable_Access(ByVal table_name As String) As System.Data.DataTable
        Dim resultat As New System.Data.DataTable

        Try
            If GetConnectStatus_Access() = 1 AndAlso GetTableList_Access.Contains(table_name) Then
                Using da As New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM " & table_name, HostConnect)
                    Using cb As New System.Data.OleDb.OleDbCommandBuilder(da)
                        Using dst As New System.Data.DataSet
                            da.Fill(resultat)
                        End Using
                    End Using
                End Using
            End If
        Catch ex As System.Data.OleDb.OleDbException
            System.Windows.Forms.MessageBox.Show("Unable to get the DataTable from the table " & table_name & " : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Unable to get the DataTable from the table " & table_name & " : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return resultat
    End Function

    Public Function ExecuteRequest_Access(ByVal request As String) As System.Collections.Generic.List(Of Object)
        Dim resultat As New System.Collections.Generic.List(Of Object)
        Try
            If GetConnectStatus_Access() = 1 Then
                Using cmd As New System.Data.OleDb.OleDbCommand(request, HostConnect)
                    Dim reader As System.Data.OleDb.OleDbDataReader = cmd.ExecuteReader()
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

    Public Function CreateNewTable_Access(ByVal nom As String, ByVal columns As System.Collections.Generic.List(Of String), ByVal types As System.Collections.Generic.List(Of String)) As Integer
        Try
            If GetConnectStatus_Access() = 1 Then
                If Not GetTableList_Access.Contains(nom) Then
                    Dim param As New System.Text.StringBuilder
                    For i As Integer = 0 To columns.Count - 1
                        param.Append(columns(i) & " " & types(i) & ", ")
                    Next

                    If Not param.ToString = Nothing Then
                        Using cmd As New System.Data.OleDb.OleDbCommand("CREATE TABLE " & nom & "(Id integer PRIMARY KEY, " & param.ToString.TrimEnd(" ").TrimEnd(",") & ");", HostConnect)
                            cmd.ExecuteReader().Close()
                        End Using
                    Else
                        Using cmd As New System.Data.OleDb.OleDbCommand("CREATE TABLE " & nom & "(Id integer PRIMARY KEY);", HostConnect)
                            cmd.ExecuteReader().Close()
                        End Using
                    End If
                    param.Clear()
                    param = Nothing
                    Return 1
                Else
                    Return 0
                End If
            Else
                Return -1
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error creating table : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function UpdateDataTable_Access(ByVal dat As System.Data.DataTable, ByVal old_table_name As String) As String
        Dim resultat As String = Nothing

        Try
            If GetConnectStatus_Access() = 1 Then
                If Not dat Is Nothing AndAlso GetTableList_Access.Contains(old_table_name) Then
                    Dim changes As System.Data.DataTable = dat.GetChanges()
                    If Not changes Is Nothing Then
                        Using da As New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM " + old_table_name, HostConnect)
                            Using cb As New System.Data.OleDb.OleDbCommandBuilder(da)
                                da.Update(changes)
                                dat.AcceptChanges()
                            End Using
                        End Using
                        Return 1
                    Else
                        Return 2
                    End If
                Else
                    Return 0
                End If
            Else
                Return -1
            End If
        Catch ex As System.Data.OleDb.OleDbException
            System.Windows.Forms.MessageBox.Show("Unable to update the table '" & old_table_name & "' : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Unable to update the table '" & old_table_name & "' : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try

        Return resultat
    End Function

    Public Function DeleteTable_Access(ByVal table_name As String) As Integer
        Try
            If GetConnectStatus_Access() = 1 Then
                Using cmd As New System.Data.OleDb.OleDbCommand("DROP TABLE " & table_name & ";", HostConnect)
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

    Public Function RenameTable_Access(ByVal table_name As String, ByVal new_name As String) As Integer
        Try
            If GetConnectStatus_Access() = 1 Then
                Using cmd As New System.Data.OleDb.OleDbCommand("SELECT * INTO " & new_name & " FROM " & table_name & ";", HostConnect)
                    cmd.ExecuteReader().Close() ' exécution de la requête
                End Using
                Using cmd As New System.Data.OleDb.OleDbCommand("DROP TABLE " & table_name & ";", HostConnect)
                    cmd.ExecuteReader().Close() ' exécution de la requête
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

    Public Function GetColumnsList_Access(ByVal table_name As String) As System.Collections.Generic.List(Of Object)
        Dim resultat As New System.Collections.Generic.List(Of Object)
        Try
            If GetConnectStatus_Access() = 1 Then
                For Each col As System.Data.DataColumn In GetDataTable_Access(table_name).Columns
                    resultat.Add(col.ColumnName)
                Next
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error getting database's tables : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return resultat
    End Function

    Public Function GetColumnsCountTable_Access(ByVal table_name As String) As Integer
        Try
            If GetConnectStatus_Access() = 1 Then
                Return GetDataTable_Access(table_name).Columns.Count
            Else
                Return -1
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error getting number of columns in the table : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function AddColumnTable_Access(ByVal table_name As String, ByVal column_name As String, ByVal typed As String) As Integer
        Try
            If GetConnectStatus_Access() = 1 Then
                Using cmd As New System.Data.OleDb.OleDbCommand("ALTER TABLE " & table_name & " ADD COLUMN [" & column_name & "] " & typed & ";", HostConnect)
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

    Public Function GetRowsCountTable_Access(ByVal table_name As String) As Integer
        Try
            If GetConnectStatus_Access() = 1 Then
                Dim columns As System.Collections.Generic.List(Of Object) = GetColumnsList_Access(table_name)
                If columns.Count > 0 Then
                    Using cmd As New System.Data.OleDb.OleDbCommand("SELECT COUNT(" & columns(0) & ") FROM " & table_name & ";", HostConnect)
                        Dim reader As System.Data.OleDb.OleDbDataReader = cmd.ExecuteReader()
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

    Public Function AddRowTable_Access(ByVal table_name As String, ByVal index As Integer, ByVal values As System.Collections.Generic.List(Of Object)) As Integer
        Try
            If GetConnectStatus_Access() = 1 Then
                Dim param As New System.Text.StringBuilder
                For Each Val As Object In values
                    If TypeOf Val Is String Then
                        param.Append("'" & CStr(Val) & "', ")
                    Else
                        param.Append(Val & ", ")
                    End If
                Next

                Using cmd As New System.Data.OleDb.OleDbCommand("INSERT INTO " & table_name & " VALUES (" & index & ", " & param.ToString.TrimEnd(" ").TrimEnd(",") & ");", HostConnect)
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

    Public Function ChangeRowTable_Access(ByVal table_name As String, ByVal index As Integer, ByVal column_name As String, ByVal value As Object) As Integer
        Try
            If GetConnectStatus_Access() = 1 Then
                If TypeOf value Is String Then
                    Using cmd As New System.Data.OleDb.OleDbCommand("UPDATE " & table_name & " SET [" & column_name & "] = '" & value & "' WHERE Id = " & index & ";", HostConnect)
                        cmd.ExecuteReader().Close()
                    End Using
                Else
                    Using cmd As New System.Data.OleDb.OleDbCommand("UPDATE " & table_name & " SET [" & column_name & "] = " & value & " WHERE Id = " & index & ";", HostConnect)
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

    Public Function DeleteRowTable_Access(ByVal table_name As String, ByVal index As Integer) As Integer
        Try
            If GetConnectStatus_Access() = 1 Then
                Using cmd As New System.Data.OleDb.OleDbCommand("DELETE FROM " & table_name & " WHERE Id = " & index & ";", HostConnect)
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

    Public Function GetSingleValueOfRow_Access(ByVal table_name As String, ByVal column_name As String, Optional ByVal index As Integer = -1, Optional ByVal condition As String = Nothing) As Object
        Try
            If GetConnectStatus_Access() = 1 Then
                If Not index = -1 Then
                    Using cmd As New System.Data.OleDb.OleDbCommand("SELECT [" & column_name & "] FROM " & table_name & " WHERE Id = " & index & ";", HostConnect)
                        Dim reader As System.Data.OleDb.OleDbDataReader = cmd.ExecuteReader()
                        While (reader.Read())
                            Return reader.GetValue(0)
                            Exit While
                        End While
                        reader.Close()
                    End Using
                ElseIf Not condition = Nothing Then
                    Using cmd As New System.Data.OleDb.OleDbCommand("SELECT [" & column_name & "] FROM " & table_name & " WHERE " & condition & ";", HostConnect)
                        Dim reader As System.Data.OleDb.OleDbDataReader = cmd.ExecuteReader()
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

    Public Function GetValuesOfRows_Access(ByVal table_name As String, ByVal column_name As String, ByVal condition As String) As System.Collections.Generic.List(Of Object)
        Dim resultat As New System.Collections.Generic.List(Of Object)
        Try
            If GetConnectStatus_Access() = 1 Then
                If condition = Nothing Then
                    Using cmd As New System.Data.OleDb.OleDbCommand("SELECT [" & column_name & "] FROM " & table_name & ";", HostConnect)
                        Dim reader As System.Data.OleDb.OleDbDataReader = cmd.ExecuteReader()
                        While (reader.Read())
                            resultat.Add(reader.GetValue(0))
                        End While
                        reader.Close()
                    End Using
                Else
                    Using cmd As New System.Data.OleDb.OleDbCommand("SELECT [" & column_name & "] FROM " & table_name & " WHERE " & condition & ";", HostConnect)
                        Dim reader As System.Data.OleDb.OleDbDataReader = cmd.ExecuteReader()
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
