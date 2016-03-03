''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class ClassApplication

    Shared Function Determiner_Si_Document_Deja_Ouvert(ByVal UniqueName As String) As Boolean
        Dim result As Boolean
        If Form1.KryptonDockableWorkspace1.PageForUniqueName(UniqueName) Is Nothing Then
            result = False
        Else
            result = True
        End If
        Return result
    End Function

    ' Permet de récupérer la liste des répertoires et de les ajouter au treeview
    ' LeNod = TreeNode sélectionné
    ' Dossier = Dossier depuis lequel on doit récupérer la liste des dossiers
    Shared Function AjouterRepertoire(ByVal LeNod As TreeNode, ByVal Dossier As String)
        Dim ite As TreeNode = Nothing

        ' On ajoute les dossier
        For Each chDir As String In IO.Directory.GetDirectories(Dossier)
            If My.Computer.FileSystem.DirectoryExists(chDir) Then
                ite = New TreeNode
                ite.Text = IO.Path.GetFileName(chDir)
                ite.ImageIndex = 0
                ite.SelectedImageIndex = 1
                ite.ToolTipText = chDir
                ' S'il existe des dossiers ou fichier dans le répertoire, alors on ajoute une factice
                If (IO.Directory.GetDirectories(chDir).Length > 0) OrElse (IO.Directory.GetFiles(chDir).Length > 0) Then
                    ite.Nodes.Add("factice")
                End If
                LeNod.Nodes.Add(ite)
            End If
        Next
        Return Nothing
    End Function

    ' Permet de récupérer la liste des fichier et de les ajouter au treeview
    ' LeNod = TreeNode sélectionné
    ' Dossier = Dossier depuis lequel on doit récupérer la liste des fichiers
    Shared Function AjouterFichier(ByVal LeNod As TreeNode, ByVal Dossier As String)
        Dim ite As TreeNode = Nothing
        Dim fi As String

        ' Ajouts des fichiers
        For Each chfichier As String In IO.Directory.GetFiles(Dossier)
            If My.Computer.FileSystem.FileExists(chfichier) Then
                ite = New TreeNode
                With ite
                    .ToolTipText = chfichier
                    fi = My.Computer.FileSystem.GetFileInfo(chfichier).Extension
                    If fi.ToLower.EndsWith(".html") OrElse fi.ToLower.EndsWith(".htm") Then
                        .ImageIndex = 2
                        .SelectedImageIndex = 2
                        .Text = IO.Path.GetFileName(chfichier).Replace(IO.Path.GetExtension(chfichier), Nothing)
                        LeNod.Nodes.Add(ite)
                    End If
                End With
            End If
        Next
        Return Nothing
    End Function


End Class
