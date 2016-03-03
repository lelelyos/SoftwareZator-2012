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

    Public Enum Edition
        Free
        Standard
        Education
        Professional
    End Enum

    Shared Sub Should_Professional_Edition()
        Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
        With vd
            .Owner = Form1
            .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
            .DefaultButton = VelerSoftware.SZVB.VistaDialog.VDialogResult.OK
            .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Information
            .Content = RM.GetString("Should_Professional")
            .MainInstruction = RM.GetString("MainInstruction11")
            .WindowTitle = My.Application.Info.Title
            .Show()
        End With
    End Sub

    Shared Sub Should_Education_Edition()
        Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
        With vd
            .Owner = Form1
            .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
            .DefaultButton = VelerSoftware.SZVB.VistaDialog.VDialogResult.OK
            .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Information
            .Content = RM.GetString("Should_Education")
            .MainInstruction = RM.GetString("MainInstruction11")
            .WindowTitle = My.Application.Info.Title
            .Show()
        End With
    End Sub

    Shared Sub Should_Standard_Edition()
        Dim vd As New VelerSoftware.SZVB.VistaDialog.VDialog()
        With vd
            .Owner = Form1
            .Buttons = New VelerSoftware.SZVB.VistaDialog.VDialogButton() {New VelerSoftware.SZVB.VistaDialog.VDialogButton(VelerSoftware.SZVB.VistaDialog.VDialogResult.OK)}
            .DefaultButton = VelerSoftware.SZVB.VistaDialog.VDialogResult.OK
            .MainIcon = VelerSoftware.SZVB.VistaDialog.VDialogIcon.Information
            .Content = RM.GetString("Should_Standard")
            .MainInstruction = RM.GetString("MainInstruction11")
            .WindowTitle = My.Application.Info.Title
            .Show()
        End With
    End Sub

    Shared Function Verify_License(ByVal Nom As String, ByVal Prenom As String, ByVal Pays As String, ByVal CodePostal As String, ByVal EMail As String, ByVal Facture As Integer, ByVal Edition As Integer, ByVal Code As String) As Boolean
        Dim tmp1 As Double
        Dim tmp2 As String
        Dim CodeActivation As New System.Text.StringBuilder()

        CodeActivation.Clear()

        For Each cha As Char In Nom.ToCharArray
            tmp1 = System.Math.Truncate(System.Math.Sqrt((System.Math.Pow((System.Math.Exp(System.Math.Sqrt(Microsoft.VisualBasic.Asc(cha))) / 35), 3) / 3874)))
            CodeActivation.Append(tmp1)
        Next

        For Each cha As Char In Prenom.ToCharArray
            tmp1 = System.Math.Truncate(System.Math.Sqrt((System.Math.Pow((System.Math.Exp(System.Math.Sqrt(Microsoft.VisualBasic.Asc(cha))) / 12), 2) / 1256)))
            CodeActivation.Append(tmp1)
        Next

        tmp1 = System.Math.Truncate(System.Math.Pow(Edition + 3, 5))
        CodeActivation.Append(tmp1)

        For Each cha As Char In Pays.ToCharArray
            tmp1 = System.Math.Truncate(System.Math.Sqrt((System.Math.Pow((System.Math.Exp(System.Math.Sqrt(Microsoft.VisualBasic.Asc(cha))) / 24), 2) / 3874)))
            CodeActivation.Append(tmp1)
        Next

        For Each cha As Char In CodePostal.ToCharArray
            tmp1 = System.Math.Truncate(System.Math.Sqrt((System.Math.Pow((System.Math.Exp(System.Math.Sqrt(Microsoft.VisualBasic.Asc(cha))) / 35), 3) / 5431)))
            CodeActivation.Append(tmp1)
        Next

        tmp1 = System.Math.Pow(System.Math.Log(System.Math.Exp(Facture)), 2)
        CodeActivation.Append(tmp1)

        For Each cha As Char In EMail.ToCharArray
            tmp1 = System.Math.Truncate(System.Math.Sqrt((System.Math.Pow((System.Math.Exp(System.Math.Sqrt(Microsoft.VisualBasic.Asc(cha))) / 47), 4) / 2346)))
            CodeActivation.Append(tmp1)
        Next

        tmp2 = CodeActivation.ToString().Replace("27", "A").Replace("76", "H").Replace("16", "B").Replace("09", "Z").Replace("65", "G").Replace("25", "U").Replace("35", "X").Replace("61", "J").Replace("94", "K").Replace("01", "E").Replace("46", "T").Replace("66", "Y").Replace("32", "O").Replace("57", "P").Replace("04", "F").Replace("10", "W").Replace("71", "M").Replace("83", "C").Replace("60", "N")
        If tmp2 = Code Then
            Return True
        Else
            Return False
        End If
    End Function





    Shared Function Determiner_Si_Document_Deja_Ouvert(ByVal UniqueName As String) As Boolean
        Dim result As Boolean
        If Form1.KryptonDockableWorkspace1.PageForUniqueName(UniqueName) Is Nothing Then
            result = False
        Else
            result = True
        End If
        Return result
    End Function



    ' Permet d'afficher le status de l'application dans la bar d'état
    ' Texte = est égale au texte à afficher
    ' Progress_Visible = indique s'il faut afficher la bar de progression ou non
    ' Progress_Value = est égale à la valeur que doit prendre la bar de progression
    Shared Function Status_Application(ByVal Texte As String, ByVal Progress_Visible As Boolean, ByVal Progress_Value As Integer) As Boolean
        If Not Texte = Nothing Then Form1.ToolStripStatusLabel2.Text = Texte
        With Form1.ToolStripProgressBar1
            .Alignment = ToolStripItemAlignment.Right
            .Visible = Progress_Visible
            .Value = Progress_Value
        End With

        Return True
    End Function

    ' Permet d'afficher le status de l'application dans la bar d'état
    ' Texte = est égale au texte à afficher
    Shared Function Status_Application(ByVal Texte As String) As Boolean
        Form1.ToolStripStatusLabel2.Text = Texte

        Return True
    End Function




    ' Permet de résolver le dossier de chargement des dlls des projets
    Shared Function LoadFromSameFolderResolveEventHandler(ByVal sender As Object, ByVal args As ResolveEventArgs) As Reflection.Assembly
        Dim assembly As Reflection.Assembly = Nothing
        If My.Computer.FileSystem.FileExists(IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly().Location) & "\Plugins\" & args.Name.Split(","c)(0) & ".dll") Then
            assembly = Reflection.Assembly.LoadFrom(IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly().Location) & "\Plugins\" & args.Name.Split(","c)(0) & ".dll")
        ElseIf My.Computer.FileSystem.FileExists(IO.Path.Combine(IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.Location), args.Name)) Then
            assembly = Reflection.Assembly.LoadFrom(IO.Path.Combine(IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.Location), args.Name))
        ElseIf My.Computer.FileSystem.FileExists(args.Name.Replace("\\", "\")) Then
            assembly = Reflection.Assembly.LoadFrom(args.Name.Replace("\\", "\"))
        End If

        If Not args.RequestingAssembly Is Nothing AndAlso My.Computer.FileSystem.FileExists(args.RequestingAssembly.Location.Replace("\\", "\")) Then assembly = Reflection.Assembly.LoadFile(args.RequestingAssembly.Location.Replace("\\", "\"))

        If assembly Is Nothing Then
            If args.RequestingAssembly Is Nothing Then
                Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Warning, String.Format("Assembly '{0}' has not been solved and loaded.", args.Name)))
            Else
                Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Warning, String.Format("Assembly '{0}' has not been solved and loaded.", args.Name & " path : " & args.RequestingAssembly.Location)))
            End If
        Else
            If args.RequestingAssembly Is Nothing Then
                Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format("Assembly '{0}' has been solved with success.", args.Name)))
            Else
                Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format("Assembly '{0}' has been solved with success.", args.Name & " path : " & args.RequestingAssembly.Location)))
            End If
        End If

        Return assembly

    End Function





    ' Permet d'associer les fichier .SZPROJ, .SZSL, SZSTAT, .SZW et .SZC à SoftwareZator 2011
    Shared Function Associer_Fichier_Au_Logiciel() As Boolean
        Dim fai As VelerSoftware.SZC.FileAssociation.FileAssociationInfo
        Dim pai As VelerSoftware.SZC.FileAssociation.ProgramAssociationInfo

        fai = Nothing
        pai = Nothing

        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Association_Fichier"), ".SZC")))

        ' .SZC
        fai = New VelerSoftware.SZC.FileAssociation.FileAssociationInfo(".szc")
        With fai
            If .Exists Then .Delete()
            If Not .Exists Then .Create()
            If .Exists Then
                .ProgID = "SoftwareZator.szcFile"
                .PerceivedType = VelerSoftware.SZC.FileAssociation.PerceivedTypes.None
            End If
            pai = New VelerSoftware.SZC.FileAssociation.ProgramAssociationInfo(.ProgID)
        End With
        With pai
            If .Exists Then .Delete()
            If Not .Exists Then .Create()
            If .Exists Then
                .Description = RM.GetString("File_Type_Description_SZC") & " " & My.Application.Info.Title
                .EditFlags = VelerSoftware.SZC.FileAssociation.EditFlags.None
                .DefaultIcon = New VelerSoftware.SZC.FileAssociation.ProgramIcon(Application.StartupPath & "\SZC_Icon.ico")
                .AddVerb(New VelerSoftware.SZC.FileAssociation.ProgramVerb("SoftwareZator.szcFile", ChrW(34) & Application.StartupPath & "\SoftwareZator 2012.exe" & ChrW(34) & " " & ChrW(34) & "%1" & ChrW(34)))
            End If
        End With




        fai = Nothing
        pai = Nothing

        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Association_Fichier"), ".SZW")))

        ' .SZW
        fai = New VelerSoftware.SZC.FileAssociation.FileAssociationInfo(".szw")
        With fai
            If .Exists Then .Delete()
            If Not .Exists Then .Create()
            If .Exists Then
                .ProgID = "SoftwareZator.szwFile"
                .PerceivedType = VelerSoftware.SZC.FileAssociation.PerceivedTypes.None
            End If
            pai = New VelerSoftware.SZC.FileAssociation.ProgramAssociationInfo(.ProgID)
        End With
        With pai
            If .Exists Then .Delete()
            If Not .Exists Then .Create()
            If .Exists Then
                .Description = RM.GetString("File_Type_Description_SZW") & " " & My.Application.Info.Title
                .EditFlags = VelerSoftware.SZC.FileAssociation.EditFlags.None
                .DefaultIcon = New VelerSoftware.SZC.FileAssociation.ProgramIcon(Application.StartupPath & "\SZW_Icon.ico")
                .AddVerb(New VelerSoftware.SZC.FileAssociation.ProgramVerb("SoftwareZator.szwFile", ChrW(34) & Application.StartupPath & "\SoftwareZator 2012.exe" & ChrW(34) & " " & ChrW(34) & "%1" & ChrW(34)))
            End If
        End With





        fai = Nothing
        pai = Nothing

        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Association_Fichier"), ".SZPROJ")))

        ' .SZPROJ
        fai = New VelerSoftware.SZC.FileAssociation.FileAssociationInfo(".szproj")
        With fai
            If .Exists Then .Delete()
            If Not .Exists Then .Create()
            If .Exists Then
                .ProgID = "SoftwareZator.szprojFile"
                .PerceivedType = VelerSoftware.SZC.FileAssociation.PerceivedTypes.None
            End If
            pai = New VelerSoftware.SZC.FileAssociation.ProgramAssociationInfo(.ProgID)
        End With
        With pai
            If .Exists Then .Delete()
            If Not .Exists Then .Create()
            If .Exists Then
                .Description = RM.GetString("File_Type_Description_SZPROJ") & " " & My.Application.Info.Title
                .EditFlags = VelerSoftware.SZC.FileAssociation.EditFlags.None
                .DefaultIcon = New VelerSoftware.SZC.FileAssociation.ProgramIcon(Application.StartupPath & "\SZProj_Icon.ico")
                .AddVerb(New VelerSoftware.SZC.FileAssociation.ProgramVerb("SoftwareZator.szprojFile", ChrW(34) & Application.StartupPath & "\SoftwareZator 2012.exe" & ChrW(34) & " " & ChrW(34) & "%1" & ChrW(34)))
            End If
        End With





        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Association_Fichier"), ".SZSL")))

        ' .SZSL
        fai = New VelerSoftware.SZC.FileAssociation.FileAssociationInfo(".szsl")
        With fai
            If .Exists Then .Delete()
            If Not .Exists Then .Create()
            If .Exists Then
                .ProgID = "SoftwareZator.szslFile"
                .PerceivedType = VelerSoftware.SZC.FileAssociation.PerceivedTypes.None
            End If
            pai = New VelerSoftware.SZC.FileAssociation.ProgramAssociationInfo(.ProgID)
        End With
        With pai
            If .Exists Then .Delete()
            If Not .Exists Then .Create()
            If .Exists Then
                .Description = RM.GetString("File_Type_Description_SZSL") & " " & My.Application.Info.Title
                .EditFlags = VelerSoftware.SZC.FileAssociation.EditFlags.None
                .DefaultIcon = New VelerSoftware.SZC.FileAssociation.ProgramIcon(Application.StartupPath & "\SZProj_Icon.ico")
                .AddVerb(New VelerSoftware.SZC.FileAssociation.ProgramVerb("SoftwareZator.szslFile", ChrW(34) & Application.StartupPath & "\SoftwareZator 2012.exe" & ChrW(34) & " " & ChrW(34) & "%1" & ChrW(34)))
            End If
        End With





        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Association_Fichier"), ".SZSTAT")))

        ' .SZSTAT
        fai = New VelerSoftware.SZC.FileAssociation.FileAssociationInfo(".szstat")
        With fai
            If .Exists Then .Delete()
            If Not .Exists Then .Create()
            If .Exists Then
                .ProgID = "SoftwareZator.szstatFile"
                .PerceivedType = VelerSoftware.SZC.FileAssociation.PerceivedTypes.None
            End If
            pai = New VelerSoftware.SZC.FileAssociation.ProgramAssociationInfo(.ProgID)
        End With
        With pai
            If .Exists Then .Delete()
            If Not .Exists Then .Create()
            If .Exists Then
                .Description = RM.GetString("File_Type_Description_SZSTAT") & " " & My.Application.Info.Title
                .EditFlags = VelerSoftware.SZC.FileAssociation.EditFlags.None
                .DefaultIcon = New VelerSoftware.SZC.FileAssociation.ProgramIcon(Application.StartupPath & "\SZProj_Icon.ico")
                .AddVerb(New VelerSoftware.SZC.FileAssociation.ProgramVerb("SoftwareZator.szstatFile", ChrW(34) & Application.StartupPath & "\SoftwareZator 2012.exe" & ChrW(34) & " " & ChrW(34) & "%1" & ChrW(34)))
            End If
        End With

        Return True
    End Function



    ' Charger Concepteur_ToolBox
    ' Recherche = est égale à la chaine recherché dans la boîte à outils
    Shared Sub Charger_ToolBox_Concepteur_Fenetre(ByVal Recherche As String)
        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Chargement_Toolbox_Windows_Designer"))))
        ClassApplication.Status_Application(RM.GetString("Status2"), True, 0)

        Dim XmlRead As New Xml.XmlDocument ' Lecture de XML
        Dim m_nodelist As Xml.XmlNodeList
        Dim newGroup, newSubItem As VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode
        Dim grouplist As New Generic.List(Of VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode)

        With DirectCast(Form1.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).Concepteur_Fenetre_ToolBox

            .SuspendLayout()
            .BeginUpdate()
            .Nodes.Clear()

            With My.Computer.FileSystem
                If Not .DirectoryExists(Application.StartupPath & "\Toolbox") Then .CreateDirectory(Application.StartupPath & "\Toolbox")
                If Not .DirectoryExists(Application.StartupPath & "\Images") Then .CreateDirectory(Application.StartupPath & "\Images")

                If .DirectoryExists(Application.StartupPath & "\Toolbox") Then
                    For Each Fichier As String In .GetFiles(Application.StartupPath & "\Toolbox", FileIO.SearchOption.SearchAllSubDirectories)
                        If .GetFileInfo(Fichier).Extension.ToUpper = ".XML" Then
                            XmlRead.Load(Fichier)
                            m_nodelist = XmlRead.SelectNodes("/Toolbox/Category")
                            For Each m_node As Xml.XmlNode In m_nodelist
                                newGroup = New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(m_node.Attributes.GetNamedItem("name_" & My.Settings.Langue).Value)
                                With newGroup.Nodes
                                    .AddRange(Charger_ToolBox_Concepteur_Fenetre_ToolBox_File(m_node, Fichier, Recherche))
                                    If .Count > 0 Then
                                        newSubItem = New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode("Pointer", "", "", "Pointer.html", "", "")
                                        newSubItem.ImageKey = "Pointer"
                                        newSubItem.SelectedImageKey = "Pointer"
                                        .Insert(0, newSubItem)
                                        grouplist.Add(newGroup)
                                    End If
                                End With
                            Next
                        End If
                    Next
                End If
            End With

            .Nodes.AddRange(grouplist.ToArray)
            .ExpandAll()
            .EndUpdate()
            .ResumeLayout()
            If .Nodes.Count > 0 Then .SelectedNode = .Nodes(0)

        End With

        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Chargement_Toolbox_Windows_Designer1"))))

        ClassApplication.Status_Application(RM.GetString("Status1"), False, 0)
    End Sub

    <CLSCompliant(False)>
    Shared Function Charger_ToolBox_Concepteur_Fenetre_ToolBox_File(ByRef XmlRead As Xml.XmlNode, ByRef Fichier As String, ByRef Recherche As String) As VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode()
        Dim resultat As New Generic.List(Of VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode)
        Dim newSubItem As VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode
        Dim img As String
        Dim name_langue As String

        With DirectCast(Form1.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).ImageList1.Images

            If Not XmlRead Is Nothing Then
                For Each m_node As Xml.XmlNode In XmlRead.ChildNodes
                    If My.Settings.Edition = Edition.Free AndAlso m_node.Attributes.GetNamedItem("fullname").Value.StartsWith("VelerSoftware.VoiceRecognitionLib") Then GoTo _next1
                    name_langue = m_node.Attributes.GetNamedItem("name_" & My.Settings.Langue).Value
                    If Not Recherche = Nothing AndAlso Not name_langue.ToLower.Contains(Recherche.ToLower) Then GoTo _next1

                    newSubItem = New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(name_langue, m_node.Attributes.GetNamedItem("fullname").Value, m_node.Attributes.GetNamedItem("assembly").Value, m_node.Attributes.GetNamedItem("help").Value, "", m_node.Attributes.GetNamedItem("name_en").Value)
                    img = Application.StartupPath & "\Images\" & m_node.Attributes.GetNamedItem("image").Value
                    If My.Computer.FileSystem.FileExists(img) Then
                        '.Add(System.Drawing.Image.FromFile(img), Color.Magenta)
                        'newSubItem.ImageIndex = .Count - 1
                        'newSubItem.SelectedImageIndex = newSubItem.ImageIndex  
                        newSubItem.ImageKey = img
                        newSubItem.SelectedImageKey = img
                    Else
                        newSubItem.ImageKey = "OTHER"
                        newSubItem.SelectedImageKey = "OTHER"
                    End If
                    If Not Recherche = Nothing Then
                        If newSubItem.Text.ToLower.Contains(Recherche.ToLower) Then resultat.Add(newSubItem)
                    Else
                        resultat.Add(newSubItem)
                    End If
_next1:
                Next
            End If

        End With

        Return resultat.ToArray
    End Function

    ' Charger Concepteur_ToolBox
    ' Recherche = est égale à la chaine recherché dans la boîte à outils
    Shared Function Charger_ToolBox_Editeur_Fonctions(ByVal Recherche As String)
        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Chargement_Toolbox_Fonctions"))))
        ClassApplication.Status_Application(RM.GetString("Status3"), False, 0)

        Dim newSubItem As VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode
        Dim Nom_Group_Fonction As New Generic.List(Of String)
        Dim Nom_Group_Class As New Generic.List(Of String)
        Dim Uncategorised As String = RM.GetString("Uncategorised")
        Dim act_fullname As String

        With DirectCast(Form1.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils)

            .Classes_ToolBox.SuspendLayout()
            .Fonctions_ToolBox.SuspendLayout()
            .Classes_ToolBox.BeginUpdate()
            .Fonctions_ToolBox.BeginUpdate()
            .Classes_ToolBox.Nodes.Clear()
            .Fonctions_ToolBox.Nodes.Clear()

            For Each plug As ClassPluginServices.Plugin In PLUGINS
                For Each act As VelerSoftware.Plugins3.Action In plug.Actions
                    If Not Recherche = Nothing AndAlso Not act.DisplayName.ToLower.Contains(Recherche.ToLower) Then GoTo _next1

                    act_fullname = act.GetType.FullName

                    If act.CompatibleFonctions Then
                        newSubItem = New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(act.DisplayName, act_fullname, act.GetType, act.FileHelp, act.DisplayName, act.Description)
                        With newSubItem
                            If act._ToolBoxImage Is Nothing Then
                                .ImageIndex = 0
                                .SelectedImageIndex = 0
                            Else
                                '.ImageList1.Images.Add(act._ToolBoxImage, Color.Magenta)
                                'newSubItem.ImageIndex = .ImageList1.Images.Count - 1
                                'newSubItem.SelectedImageIndex = newSubItem.ImageIndex
                                .ImageKey = act_fullname
                                .SelectedImageKey = act_fullname
                            End If
                        End With
                        If Recherche = Nothing Then
                            If act.Category = Nothing Then
                                If Not Nom_Group_Fonction.Contains(Uncategorised) Then
                                    Nom_Group_Fonction.Add(Uncategorised)
                                    .Fonctions_ToolBox.Nodes.Add(New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(Uncategorised))
                                End If
                                .Fonctions_ToolBox.Nodes(Uncategorised).Nodes.Add(newSubItem)
                            Else
                                If Not Nom_Group_Fonction.Contains(act.Category) Then
                                    Nom_Group_Fonction.Add(act.Category)
                                    .Fonctions_ToolBox.Nodes.Add(New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(act.Category))
                                End If
                                .Fonctions_ToolBox.Nodes(act.Category).Nodes.Add(newSubItem)
                            End If
                        ElseIf act.DisplayName.ToLower.Contains(Recherche.ToLower) Then
                            If act.Category = Nothing Then
                                If Not Nom_Group_Fonction.Contains(Uncategorised) Then
                                    Nom_Group_Fonction.Add(Uncategorised)
                                    .Fonctions_ToolBox.Nodes.Add(New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(Uncategorised))
                                End If
                                .Fonctions_ToolBox.Nodes(Uncategorised).Nodes.Add(newSubItem)
                            Else
                                If Not Nom_Group_Fonction.Contains(act.Category) Then
                                    Nom_Group_Fonction.Add(act.Category)
                                    .Fonctions_ToolBox.Nodes.Add(New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(act.Category))
                                End If
                                .Fonctions_ToolBox.Nodes(act.Category).Nodes.Add(newSubItem)
                            End If
                        End If
                    End If

                    If act.CompatibleClass Then
                        newSubItem = New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(act.DisplayName, act_fullname, act.GetType, act.FileHelp, act.DisplayName, act.Description)
                        With newSubItem
                            If act._ToolBoxImage Is Nothing Then
                                .ImageIndex = 0
                                .SelectedImageIndex = 0
                            Else
                                '.ImageList1.Images.Add(act._ToolBoxImage, Color.Magenta)
                                'newSubItem.ImageIndex = .ImageList1.Images.Count - 1
                                'newSubItem.SelectedImageIndex = newSubItem.ImageIndex
                                .ImageKey = act_fullname
                                .SelectedImageKey = act_fullname
                            End If
                        End With
                        If Recherche = Nothing Then
                            If act.Category = Nothing Then
                                If Not Nom_Group_Class.Contains(Uncategorised) Then
                                    Nom_Group_Class.Add(Uncategorised)
                                    .Classes_ToolBox.Nodes.Add(New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(Uncategorised))
                                End If
                                .Classes_ToolBox.Nodes(Uncategorised).Nodes.Add(newSubItem)
                            Else
                                If Not Nom_Group_Class.Contains(act.Category) Then
                                    Nom_Group_Class.Add(act.Category)
                                    .Classes_ToolBox.Nodes.Add(New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(act.Category))
                                End If
                                .Classes_ToolBox.Nodes(act.Category).Nodes.Add(newSubItem)
                            End If
                        ElseIf act.DisplayName.ToLower.Contains(Recherche.ToLower) Then
                            If act.Category = Nothing Then
                                If Not Nom_Group_Class.Contains(Uncategorised) Then
                                    Nom_Group_Class.Add(Uncategorised)
                                    .Classes_ToolBox.Nodes.Add(New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(Uncategorised))
                                End If
                                .Classes_ToolBox.Nodes(Uncategorised).Nodes.Add(newSubItem)
                            Else
                                If Not Nom_Group_Class.Contains(act.Category) Then
                                    Nom_Group_Class.Add(act.Category)
                                    .Classes_ToolBox.Nodes.Add(New VelerSoftware.SZC.ToolBox.ToolBox.VSTreeNode(act.Category))
                                End If
                                .Classes_ToolBox.Nodes(act.Category).Nodes.Add(newSubItem)
                            End If
                        End If
                    End If

_next1:
                Next
            Next

            .Fonctions_ToolBox.TreeViewNodeSorter = New VelerSoftware.SZC.TreeViewComparer.TreeViewComparer()
            .Classes_ToolBox.TreeViewNodeSorter = New VelerSoftware.SZC.TreeViewComparer.TreeViewComparer()
            .Classes_ToolBox.EndUpdate()
            .Fonctions_ToolBox.EndUpdate()
            .Classes_ToolBox.ResumeLayout()
            .Fonctions_ToolBox.ResumeLayout()
            If .Fonctions_ToolBox.Nodes.Count > 0 Then .Fonctions_ToolBox.SelectedNode = .Fonctions_ToolBox.Nodes(0)
            If .Classes_ToolBox.Nodes.Count > 0 Then .Classes_ToolBox.SelectedNode = .Classes_ToolBox.Nodes(0)

        End With

        Log_SZ.Log.Add(New ClassLog.LogType(ClassLog.LogType.Tip.Info, String.Format(System.Globalization.CultureInfo.InvariantCulture, RM_Log.GetString("Chargement_Toolbox_Fonctions1"))))
        ClassApplication.Status_Application(RM.GetString("Status1"), False, 0)

        Return Nothing
    End Function


    <CLSCompliant(False)>
    Shared Function SearchAction(ByVal Root As VelerSoftware.Plugins3.ActionWithChildren, ByVal ID As String, ByVal condition As Boolean, ByVal alors As Boolean) As VelerSoftware.Plugins3.Action
        Dim Resultat As VelerSoftware.Plugins3.Action = Nothing

        If Not condition Then
            If Root.id = ID Then
                Resultat = Root
            Else
                For Each aaa As VelerSoftware.Plugins3.Action In Root.Children_Actions
                    If aaa.id = ID Then
                        Resultat = aaa
                        Exit For
                    ElseIf aaa.GetType.IsSubclassOf(GetType(VelerSoftware.Plugins3.ActionWithChildren)) Then
                        If aaa.GetType.FullName = "VelerSoftware.GeneralPlugin.Si_Alors_Sinon" Then
                            Resultat = SearchAction(aaa, ID, True, True)
                            If Resultat Is Nothing Then Resultat = SearchAction(aaa, ID, True, False)
                        Else
                            Resultat = SearchAction(aaa, ID, False, False)
                        End If
                        If Resultat IsNot Nothing Then Exit For
                    End If
                Next
            End If
        Else
            If alors Then
                If Root.id = ID Then
                    Resultat = Root
                Else
                    For Each aaa As VelerSoftware.Plugins3.Action In Root.Children_Actions
                        If aaa.id = ID Then
                            Resultat = aaa
                            Exit For
                        ElseIf aaa.GetType.IsSubclassOf(GetType(VelerSoftware.Plugins3.ActionWithChildren)) Then
                            If aaa.GetType.FullName = "VelerSoftware.GeneralPlugin.Si_Alors_Sinon" Then
                                Resultat = SearchAction(aaa, ID, True, True)
                                If Resultat Is Nothing Then SearchAction(aaa, ID, True, False)
                            Else
                                Resultat = SearchAction(aaa, ID, False, False)
                            End If
                            If Resultat IsNot Nothing Then Exit For
                        End If
                    Next
                End If
            Else
                If Root.id = ID Then
                    Resultat = Root
                Else
                    For Each aaa As VelerSoftware.Plugins3.Action In DirectCast(DirectCast(Root, Object).Children_Actions2, Generic.List(Of VelerSoftware.Plugins3.Action))
                        If aaa.id = ID Then
                            Resultat = aaa
                            Exit For
                        ElseIf aaa.GetType.IsSubclassOf(GetType(VelerSoftware.Plugins3.ActionWithChildren)) Then
                            If aaa.GetType.FullName = "VelerSoftware.GeneralPlugin.Si_Alors_Sinon" Then
                                Resultat = SearchAction(aaa, ID, True, True)
                                If Resultat Is Nothing Then SearchAction(aaa, ID, True, False)
                            Else
                                Resultat = SearchAction(aaa, ID, False, False)
                            End If
                            If Resultat IsNot Nothing Then Exit For
                        End If
                    Next
                End If
            End If
        End If

        Return Resultat
    End Function


    Shared Sub Activer_Desactiver_Interface(ByVal activate As Boolean)
        With Form1
            DirectCast(.Box_Boite_A_Outils.Controls(0), BoxBoiteAOutils).Enabled = activate
            DirectCast(.Box_Erreur_Generation.Controls(0), BoxErreurGeneration).Enabled = activate
            DirectCast(.Box_Explorateur_Solutions.Controls(0), BoxExplorateurSolutions).Enabled = activate
            DirectCast(.Box_Proprietes.Controls(0), BoxProprietes).Enabled = activate
            DirectCast(.Box_Reconnaissance_Vocale.Controls(0), BoxReconnaissanceVocale).Enabled = activate
            .Fermer_Projet_KryptonRibbonGroupButton.Enabled = activate
            .Parametre_Projet_KryptonRibbonGroupButton3.Enabled = activate
            .Gestionnaire_Variables_KryptonRibbonGroupButton5.Enabled = activate
            .Ordre_Generation_KryptonRibbonGroupButton.Enabled = activate
            .Ajouter_Projet_KryptonRibbonGroupButton.Enabled = activate
            .Nouveau_Document_KryptonRibbonGroupButton.Enabled = activate
            .Generer_KryptonRibbonGroupButton.Enabled = activate
            .Executer_Le_Projet_KryptonRibbonGroupButton.Enabled = activate
            .Voir_Les_Codes_KryptonRibbonGroupButton.Enabled = activate
            .Nouvelle_Fonction_KryptonRibbonGroupButton.Enabled = activate
            .Nouveau_Projet_KryptonRibbonGroupButton.Enabled = activate
            .Ouvrir_Projet_KryptonRibbonGroupButton.Enabled = activate
            .Exporter_Projet_KryptonRibbonGroupButton.Enabled = activate
            .QAT_Fermer.Enabled = activate
            .QAT_Generer.Enabled = activate
            .QAT_Ouvrir.Enabled = activate
        End With
    End Sub

End Class
