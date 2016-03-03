''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Imports System.Collections.Generic

Public Class ClassBasesDeDonneesMySQL

    Private HostConnect As New MySql.Data.MySqlClient.MySqlConnection
    Private da As New MySql.Data.MySqlClient.MySqlDataAdapter
    Private cb As New MySql.Data.MySqlClient.MySqlCommandBuilder
    Private dst As New System.Data.DataSet

    ' résultat :
    ' 1 = connecté
    ' -1 = Impossible de se connecter au serveur
    ' -2 = Accès refusé à la connexion avec l'utilisateur X et le mdp Y
    ' -3 = erreur inconnu
    Public Function Connect(ByVal Host As String, ByVal Port As String, ByVal Login As String, ByVal Password As String, ByVal Initial_DataBase As String, ByVal Encrypt As Boolean) As Integer
        Disconnect()
        HostConnect = New MySql.Data.MySqlClient.MySqlConnection("Server=" & Host & ";User ID=" & Login & ";Password=" & Password & ";")
        Try
            HostConnect.Open() ' connexion en cours
            If HostConnect.State = ConnectionState.Open Then
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
                Return -3
            End If
        Catch ex As System.Exception
            Return -3
        End Try
    End Function

    ' Se déconnecter d'une base de donnée
    ' Valeur retourné :
    ' -1 = erreur inconnu
    ' 0 = impossible de se déconnecter pour une raison inconnue
    ' 1 = déconnecté de la base de donnée
    Public Function Disconnect() As Integer
        Try
            If HostConnect IsNot Nothing AndAlso HostConnect.State = ConnectionState.Open Then
                HostConnect.Close()
                HostConnect.Dispose()
            End If
            If HostConnect IsNot Nothing Then
                If HostConnect.State = ConnectionState.Closed Then
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

    ' Détermine si l'on est connecté à une base de donnée ou pas.
    ' Valeur retourné :
    ' -1 = erreur inconnu
    ' 0 = déconnecté
    ' 1 = connecté
    ' 2 = Interrompu
    ' 3 = connexion en cours
    ' 4 = En cours d'exécution
    ' 5 = En cours de réception
    Public Function GetConnectStatus() As Integer
        Try
            If HostConnect IsNot Nothing Then
                Select Case HostConnect.State
                    Case ConnectionState.Broken
                        Return 2
                    Case ConnectionState.Closed
                        Return 0
                    Case ConnectionState.Connecting
                        Return 3
                    Case ConnectionState.Executing
                        Return 4
                    Case ConnectionState.Fetching
                        Return 5
                    Case ConnectionState.Open
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

    Public Function CreateNewDataBase(ByVal database_name As String) As String
        ' la requête SHOW TABLES permet de récupérer la liste des bases de données
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand("CREATE DATABASE " & database_name & ";", HostConnect)

        Try
            cmd.ExecuteReader().Close() ' exécution de la requête

            Return 1
        Catch ex As MySql.Data.MySqlClient.MySqlException
            System.Windows.Forms.MessageBox.Show("Error creating the database : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error creating the database : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        Finally
            cmd.Dispose()
        End Try
        Return -1
    End Function

    ' 1 = base chargé avec succès
    ' -1 = impossible de charger la base
    Public Function ChangeDataBase(ByVal database_name As String) As String
        Try
            ' changement de la base de donnée
            HostConnect.ChangeDatabase(database_name)
            Return 1
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Return -1
        Catch ex As System.Exception
            Return -1
        End Try
    End Function

    Public Function GetDatabases() As Generic.List(Of String)
        Dim resultat As New Generic.List(Of String)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = Nothing
        ' la requête EXEC sp_databases permet de récupérer la liste des bases de données
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand("SHOW DATABASES", HostConnect)

        Try
            reader = cmd.ExecuteReader() ' exécution de la requête

            While (reader.Read())
                resultat.Add(reader.GetString(0))
            End While
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show("Impossible d'obtenir la liste de base de données : " + ex.Message)
            resultat = Nothing
        Catch ex As System.Exception
            MessageBox.Show("Impossible d'obtenir la liste de base de données : " + ex.Message)
            resultat = Nothing
        Finally
            reader.Close()
        End Try

        If Not reader Is Nothing Then reader.Close()

        Return resultat
    End Function

    Public Function GetTables() As Generic.List(Of String)
        Dim resultat As New Generic.List(Of String)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = Nothing
        ' changement de la base de donnée
        'ChangeDataBase(database_name)
        ' la requête SHOW TABLES permet de récupérer la liste des bases de données
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand("SHOW TABLES", HostConnect)

        Try
            reader = cmd.ExecuteReader() ' exécution de la requête

            While (reader.Read())
                resultat.Add(reader.GetString(0))
            End While
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show("Impossible d'obtenir la liste de tables : " + ex.Message)
        Catch ex As System.Exception
            MessageBox.Show("Impossible d'obtenir la liste de tables : " + ex.Message)
        Finally
            reader.Close()
        End Try

        If Not reader Is Nothing Then reader.Close()

        Return resultat
    End Function

    Public Function GetTables(ByVal database_name As String) As Generic.List(Of String)
        Dim resultat As New Generic.List(Of String)

        Dim reader As MySql.Data.MySqlClient.MySqlDataReader = Nothing
        ' changement de la base de donnée
        ChangeDataBase(database_name)
        ' la requête SHOW TABLES permet de récupérer la liste des bases de données
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand("SHOW TABLES", HostConnect)

        Try
            reader = cmd.ExecuteReader() ' exécution de la requête

            While (reader.Read())
                resultat.Add(reader.GetString(0))
            End While
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show("Impossible d'obtenir la liste de tables : " + ex.Message)
        Catch ex As System.Exception
            MessageBox.Show("Impossible d'obtenir la liste de tables : " + ex.Message)
        Finally
            reader.Close()
        End Try

        If Not reader Is Nothing Then reader.Close()

        Return resultat
    End Function

    Public Function GetDataTable(ByVal table_name As String) As System.Data.DataTable
        Dim resultat As New System.Data.DataTable

        Try
            Dim das As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM " + table_name, HostConnect)
            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(das)
            das.Fill(resultat)
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show("Impossible d'obtenir le DataTable de la table " & table_name & " : " + ex.Message)
        Catch ex As System.Exception
            MessageBox.Show("Impossible d'obtenir le DataTable de la table " & table_name & " : " + ex.Message)
        End Try

        Return resultat
    End Function

    Public Function ExecuteRequest(ByVal request As String) As System.Collections.Generic.List(Of Object)
        Dim resultat As New System.Collections.Generic.List(Of Object)
        Try
            If GetConnectStatus() = 1 Then
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

    ' resultat
    ' 1 = table créé
    ' -1 = erreur inconnue
    Public Function CreateNewTable(ByVal nom As String, ByVal columns As Generic.List(Of String), ByVal types As Generic.List(Of String)) As Integer
        Try
            If GetConnectStatus() = 1 Then
                Dim param As New System.Text.StringBuilder
                For i As Integer = 0 To columns.Count - 1
                    param.Append(columns(i) & " " & types(i) & ", ")
                Next

                If Not param.ToString = Nothing Then
                    Using cmd As New MySql.Data.MySqlClient.MySqlCommand("CREATE TABLE " & nom & "(Id integer default NULL auto_increment, " & param.ToString.TrimEnd(" ").TrimEnd(",") & ", PRIMARY KEY (Id));", HostConnect)
                        cmd.ExecuteReader().Close() ' exécution de la requête
                    End Using
                Else
                    Using cmd As New MySql.Data.MySqlClient.MySqlCommand("CREATE TABLE " & nom & "(Id integer default NULL auto_increment, PRIMARY KEY (Id));", HostConnect)
                        cmd.ExecuteReader().Close() ' exécution de la requête
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

    ' Valeur retourné :
    ' -1 = erreur inconnu
    ' 0 = La mise à jour de la table n'a pas été effectué car aucune table n'a été trouvé
    ' 1 = mise à jour effectué avec succès
    ' 2 = il n'y a rien à mettre à jour
    Public Function UpdateDataTable(ByVal dat As System.Data.DataTable, ByVal old_table_name As String) As String
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
            MsgBox(ex.Message)
            Return -1
        Catch ex As System.Exception
            MsgBox(ex.Message)
            Return -1
        End Try

        Return resultat
    End Function



    ' Supprimer une Table.
    ' Valeur retourné :
    ' -1 = erreur inconnu
    ' 0 = la table n'existe pas
    ' 1 = la table a été suprimée
    Public Function DeleteTable(ByVal table_name As String) As Integer
        Try
            If GetConnectStatus() = 1 Then
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand("DROP TABLE " & table_name & ";", HostConnect)
                    cmd.ExecuteReader().Close() ' exécution de la requête
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

    ' Renommer une Table.
    ' Valeur retourné :
    ' -1 = erreur inconnu
    ' 0 = la table n'existe pas
    ' 1 = la table a été renommée
    ' 2 = le nouveau nom est déjà utilisée par une autre table
    Public Function RenameTable(ByVal table_name As String, ByVal new_name As String) As Integer
        Try
            If GetConnectStatus() = 1 Then
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand("RENAME TABLE " & table_name & " TO " & new_name & ";", HostConnect)
                    cmd.ExecuteReader().Close() ' exécution de la requête
                End Using
                'Using cmd As New MySql.Data.MySqlClient.MySqlCommand("DROP TABLE " & table_name & ";", HostConnect)
                '    cmd.ExecuteReader().Close() ' exécution de la requête
                'End Using
                Return 1
            Else
                Return -1
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error renaming table : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function




    ' Récupère le nom de toutes les colonnes d'une Table.
    ' Paramètres :
    ' table_name = nom de la table concerné
    ' Valeur retourné :
    ' liste de valeur textuelle
    Public Function GetColumnsList(ByVal table_name As String) As Generic.List(Of String)
        Dim resultat As New Generic.List(Of String)
        Try
            If GetConnectStatus() = 1 Then
                For Each col As System.Data.DataColumn In GetDataTable(table_name).Columns
                    resultat.Add(col.ColumnName)
                Next
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error getting database's tables : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return resultat
    End Function

    ' Récupère le nombre de colonnes d'une Table.
    ' Paramètres :
    ' table_name = nom de la table concerné
    ' Valeur retourné :
    ' -1 = erreur inconnu
    ' -2 = la table n'existe pas
    ' autre = nombre de colonne dans la table
    Public Function GetColumnsCountTable(ByVal table_name As String) As Integer
        Try
            If GetConnectStatus() = 1 Then
                Return GetDataTable(table_name).Columns.Count
            Else
                Return -1
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error getting number of columns in the table : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    ' Ajouter une colonne à une Table.
    ' Paramètres :
    ' table_name = nom de la table
    ' column_name = nom de la colonne à ajouter
    ' typed = type de valeur pour cette colonne
    ' Valeur retourné :
    ' -1 = erreur inconnu
    ' 0 = la table n'existe pas
    ' 1 = la colonne a correctement été ajoutée
    Public Function AddColumnTable(ByVal table_name As String, ByVal column_name As String, ByVal typed As String) As Integer
        Try
            If GetConnectStatus() = 1 Then
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


    ' Obtenir le nombre de lignes dans une Table.
    ' Valeur retourné :
    ' -1 = erreur inconnu
    ' -2 = la table n'existe pas
    ' autre = nombre de ligne dans la table
    Public Function GetRowsCountTable(ByVal table_name As String) As Integer
        Try
            If GetConnectStatus() = 1 Then
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(Id) FROM " & table_name & ";", HostConnect)
                    Dim reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                    While (reader.Read())
                        Return reader.GetValue(0)
                        Exit While
                    End While
                    reader.Close()
                End Using
                Return 0
            Else
                Return -1
            End If
        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show("Error getting number of rows in the table : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    ' Ajouter une ligne à une Table.
    ' Paramètres :
    ' table_name = nom de la table
    ' index = index auquel la ligne sera ajouté
    ' values = valeurs à mettre dans la ligne
    ' Valeur retourné :
    ' -1 = erreur inconnu
    ' 0 = la table n'existe pas
    ' 1 = la ligne a correctement été ajoutée
    Public Function AddRowTable(ByVal table_name As String, ByVal index As Integer, ByVal values As Generic.List(Of Object)) As Integer
        Try
            If GetConnectStatus() = 1 Then
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

    ' Changer une ligne à une Table.
    ' Paramètres :
    ' table_name = nom de la table
    ' index = index auquel la ligne sera modifiée
    ' column_name = nom de la colonne à modifier
    ' value = valeurs à mettre dans la colonne
    ' Valeur retourné :
    ' -1 = erreur inconnu
    ' 0 = la table n'existe pas
    ' 1 = la ligne a correctement été modifiée
    Public Function ChangeRowTable(ByVal table_name As String, ByVal index As Integer, ByVal column_name As String, ByVal value As Object) As Integer
        Try
            If GetConnectStatus() = 1 Then
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

    ' Supprimer une ligne dans une Table.
    ' Paramètres :
    ' table_name = nom de la table
    ' index = index auquel la ligne sera supprimée
    ' Valeur retourné :
    ' -1 = erreur inconnu
    ' 0 = la table n'existe pas
    ' 1 = la ligne a correctement été supprimée
    Public Function DeleteRowTable(ByVal table_name As String, ByVal index As Integer) As Integer
        Try
            If GetConnectStatus() = 1 Then
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

    ' Récupère une valeur dans une Table.
    ' Paramètres :
    ' table_name = nom de la table concerné  
    ' column_name = nom de la colonne dans laquelle se trouve la valeur
    ' index (optionel) = index de la valeur dans la table
    ' condition (optionel) = si on ne connais pas l'index, on peut spécifié, par exemple "la ligne sur laquelle le champ Téléphone = 0671665378"
    ' Valeur retourné :
    ' objet
    Public Function GetSingleValueOfRow(ByVal table_name As String, ByVal column_name As String, Optional ByVal index As Integer = -1, Optional ByVal condition As String = Nothing) As Object
        Try
            If GetConnectStatus() = 1 Then
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

    ' Récupère une valeur dans une Table.
    ' Paramètres :
    ' table_name = nom de la table concerné  
    ' column_name = nom de la colonne dans laquelle se trouve la valeur
    ' index (optionel) = index de la valeur dans la table
    ' condition (optionel) = si on ne connais pas l'index, on peut spécifié, par exemple "la ligne sur laquelle le champ Téléphone = 0671665378"
    ' Valeur retourné :
    ' liste d'objets
    Public Function GetValuesOfRows(ByVal table_name As String, ByVal column_name As String, ByVal condition As String) As System.Collections.Generic.List(Of Object)
        Dim resultat As New System.Collections.Generic.List(Of Object)
        Try
            If GetConnectStatus() = 1 Then
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

End Class
