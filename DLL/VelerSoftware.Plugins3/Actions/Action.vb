''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

<Serializable()>
Public Class Action
    Inherits System.Activities.Activity

#Region ".ctor"

    Public Sub New()
        Me.DisplayName = "Action"
        Me.Children_Actions = New System.Collections.Generic.List(Of Action)()
        Me.Description = "Action vierge"
    End Sub

#End Region

#Region "Functions"

    ''' <summary>
    ''' Fonction exécuté lorsque l'action est ajouté à l'éditeur de fonctions.
    ''' </summary>
    ''' <returns>Retourne une valeur Boolean indiquant si l'action sera ajouté à l'éditeur de fonctions (True) où s'il faut annuler l'ajout (False).</returns>
    ''' <remarks>Par défaut, la valeur retourné est True.</remarks> 
    Public Overridable Overloads Function Main() As Boolean
        Me.Added = True
        Return True
    End Function

    ''' <summary>
    ''' Fonction exécuté lorsque l'utilisateur clique sur le bouton "Modifier les paramètres de l'action".
    ''' </summary>
    ''' <returns>Retourne une valeur Boolean indiquant si les modifications apportés seront enregistrés (True) où s'il faut annuler les modifications (False).</returns>
    ''' <remarks>Par défaut, la valeur retourné est True.</remarks>
    Public Overridable Overloads Function Modify() As Boolean
        Return True
    End Function

    ''' <summary>
    ''' Fonction exécuté lorsque SoftwareZator génère les codes Visual Basic.Net avant une génération du projet.
    ''' </summary>
    ''' <returns>Retourne une valeur CodeDom.CodeObject représentant le code VB.Net généré et prêt à être compilé.</returns>
    ''' <remarks>Par défaut, la valeur retourné est nul si la propriété UseCustomVBCode est False, sinon, la valeur retourné est la propriété CustomVBCode.</remarks>
    Public Overridable Overloads Function GetVBCode(ByVal FromFunction As Boolean) As CodeDom.CodeObject
        If Me.UseCustomVBCode Then
            Return Me.CustomVBCode
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Fonction exécuté lorsque l'utilisateur veut corriger automatiquement une erreur de génération ou d'exécution.
    ''' </summary>
    ''' <returns>Retourne une valeur Boolean indiquant si la correction a été faite (True) ou n'a pas pu être faite (False).</returns>
    ''' <remarks>Par défaut, la valeur retourné est False.</remarks>
    Public Overridable Overloads Function ResolveError(ByVal ErrorToResole As VelerSoftware.SZVB.Projet.Erreur, ByVal e As System.EventArgs) As Boolean
        Return False
    End Function

    Public Function GetGACAssemblyList() As Generic.List(Of VelerSoftware.SZVB.Projet.Reference)
        Dim list As New Generic.List(Of VelerSoftware.SZVB.Projet.Reference)
        For Each b As VelerSoftware.SZC.Reference.GacInterop.AssemblyListEntry In (New VelerSoftware.SZC.Reference.GacInterop).GetAssemblyList
            list.Add(New VelerSoftware.SZVB.Projet.Reference(False, Nothing, False, b.Name, b.Version, b.FullName))
        Next
        Return list
    End Function


#End Region

#Region "Events"

    Public Delegate Sub OnDisplayNameChangedEventHandler(ByVal value As String, ByVal e As System.EventArgs)
    Public Event DisplayNameChanged As OnDisplayNameChangedEventHandler

    Public Delegate Sub OnActionChangedEventHandler(ByVal value As Object, ByVal popertyName As String, ByVal e As System.EventArgs)
    Public Event ActionChanged As OnActionChangedEventHandler

#End Region

#Region "Properties"

#Region "Configuration"

#Region "For User"

    Private _DisplayName As String
    ''' <summary>
    ''' Obtient ou définit le texte par défaut affiché dans la Boîte à outils et dans le designer d'action (ActivityDesigner).
    ''' </summary>
    Public Overridable Overloads Property DisplayName As String
        Get
            Return MyBase.DisplayName
        End Get
        Set(ByVal value As String)
            Me._DisplayName = value
            MyBase.DisplayName = value
            RaiseEvent DisplayNameChanged(value, New EventArgs)
            RaiseEvent ActionChanged(value, "DisplayName", New EventArgs)
        End Set
    End Property

    <NonSerialized()> Public _ToolBoxImage As Drawing.Image
    ''' <summary>
    ''' Définit l'image affiché dans la Boîte à outils. Pour obtenir cette image, utilisez la variable _ToolBoxImage.
    ''' </summary>
    Public Overridable Overloads WriteOnly Property ToolBoxImage As Drawing.Image
        Set(ByVal value As Drawing.Image)
            Me._ToolBoxImage = value
            RaiseEvent ActionChanged(value, "ToolBoxImage", New EventArgs)
        End Set
    End Property

    Private _Description As String
    ''' <summary>
    ''' Obtient ou définit la description de l'action affiché dans la Boîte à outils.
    ''' </summary>
    Public Overridable Overloads Property Description As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            Me._Description = value
            RaiseEvent ActionChanged(value, "Description", New EventArgs)
        End Set
    End Property

    Private _Category As String
    ''' <summary>
    ''' Obtient ou définit la catégorie auquel appartient l'action. Cette cétagorie est affiché dans la Boîte à outils.
    ''' </summary>
    Public Overridable Overloads Property Category As String
        Get
            Return _Category
        End Get
        Set(ByVal value As String)
            Me._Category = value
            RaiseEvent ActionChanged(value, "Category", New EventArgs)
        End Set
    End Property

    Private _FileHelp As String
    ''' <summary>
    ''' Obtient ou définit le fichier de documentation (.html) de l'action.
    ''' </summary>
    Public Overridable Overloads Property FileHelp As String
        Get
            Return _FileHelp
        End Get
        Set(ByVal value As String)
            Me._FileHelp = value
            RaiseEvent ActionChanged(value, "FileHelp", New EventArgs)
        End Set
    End Property

    Private _Voice_Recognition_Dictionary As New Generic.List(Of String)
    ''' <summary>
    ''' Obtient ou définit la liste des mots clés utilisés par la reconnaissance vocale. Pour plus d'information, veuillez lire la documentation.
    ''' </summary>
    Public Overridable Overloads Property Voice_Recognition_Dictionary As Generic.List(Of String)
        Get
            If _Voice_Recognition_Dictionary Is Nothing Then _Voice_Recognition_Dictionary = New Generic.List(Of String)
            Return _Voice_Recognition_Dictionary
        End Get
        Set(ByVal value As Generic.List(Of String))
            Me._Voice_Recognition_Dictionary = value
            RaiseEvent ActionChanged(value, "Voice_Recognition_Dictionary", New EventArgs)
        End Set
    End Property

    Private _Voice_Recognition_Expressions_Dictionary As New Generic.List(Of String)
    ''' <summary>
    ''' Obtient ou définit la liste des mots clés utilisés par la reconnaissance vocale. Pour plus d'information, veuillez lire la documentation.
    ''' </summary>
    Public Overridable Overloads Property Voice_Recognition_Expressions_Dictionary As Generic.List(Of String)
        Get
            If _Voice_Recognition_Expressions_Dictionary Is Nothing Then _Voice_Recognition_Expressions_Dictionary = New Generic.List(Of String)
            Return _Voice_Recognition_Expressions_Dictionary
        End Get
        Set(ByVal value As Generic.List(Of String))
            Me._Voice_Recognition_Expressions_Dictionary = value
            RaiseEvent ActionChanged(value, "Voice_Recognition_Expressions_Dictionary", New EventArgs)
        End Set
    End Property

    ''''''''''   ''' <summary>
    ''''''''''   ''' Obtient l'action parent à celle-ci. Pour plus d'information, veuillez lire la documentation.
    ''''''''''   ''' </summary>
    ''''''''''   Public ReadOnly Property Parent As VelerSoftware.Plugins3.Action
    ''''''''''       Get
    ''''''''''           If Not Me.Tools Is Nothing Then
    ''''''''''               Return Me.Tools.GetParentAction(Me)
    ''''''''''           Else
    ''''''''''               Return Nothing
    ''''''''''           End If
    ''''''''''       End Get
    ''''''''''   End Property
    ''''''''''
    ''''''''''   ''' <summary>
    ''''''''''   ''' Obtient l'action parent à celle-ci. Pour plus d'information, veuillez lire la documentation.
    ''''''''''   ''' </summary>
    ''''''''''   Public ReadOnly Property Parents As Generic.List(Of VelerSoftware.Plugins3.Action)
    ''''''''''       Get
    ''''''''''           If Not Me.Tools Is Nothing Then
    ''''''''''               Return Me.Tools.GetParentsAction(Me)
    ''''''''''           Else
    ''''''''''               Return Nothing
    ''''''''''           End If
    ''''''''''       End Get
    ''''''''''   End Property

#End Region

#Region "For Generation"

    Private _References As New Generic.List(Of String)
    ''' <summary>
    ''' Obtient ou définit la liste des références nécessaires au projet pour que cette action fonctionne. Pour plus d'information, veuillez lire la documentation.
    ''' </summary>
    Public Overridable Overloads Property References As Generic.List(Of String)
        Get
            If _References Is Nothing Then _References = New Generic.List(Of String)
            Return _References
        End Get
        Set(ByVal value As Generic.List(Of String))
            Me._References = value
            RaiseEvent ActionChanged(value, "References", New EventArgs)
        End Set
    End Property

    Private _ClassCode As String
    Public Overridable Overloads Property ClassCode As String
        Get
            Return _ClassCode
        End Get
        Set(ByVal value As String)
            Me._ClassCode = value
            RaiseEvent ActionChanged(value, "ClassCode", New EventArgs)
        End Set
    End Property

    Private _CompatibleClass As Boolean
    ''' <summary>
    ''' Obtient ou définit si l'action peut être utilisé dans la racine d'une Class (premier onglet, non fermable, de l'éditeur de fonctions).
    ''' </summary>
    Public Overridable Overloads Property CompatibleClass As Boolean
        Get
            Return _CompatibleClass
        End Get
        Set(ByVal value As Boolean)
            Me._CompatibleClass = value
            RaiseEvent ActionChanged(value, "CompatibleClass", New EventArgs)
        End Set
    End Property

    Private _CompatibleFonctions As Boolean
    ''' <summary>
    ''' Obtient ou définit si l'action peut être utilisé dans les fonctions (tous les onglets de l'éditeur de fonctions sauf le premier) ou pas.
    ''' </summary>
    Public Overridable Overloads Property CompatibleFonctions As Boolean
        Get
            Return _CompatibleFonctions
        End Get
        Set(ByVal value As Boolean)
            Me._CompatibleFonctions = value
            RaiseEvent ActionChanged(value, "CompatibleFonctions", New EventArgs)
        End Set
    End Property

    Private _CustomVBCode As CodeDom.CodeObject
    Public Overridable Overloads Property CustomVBCode As CodeDom.CodeObject
        Get
            Return _CustomVBCode
        End Get
        Set(ByVal value As CodeDom.CodeObject)
            Me._CustomVBCode = value
            RaiseEvent ActionChanged(value, "CustomVBCode", New EventArgs)
        End Set
    End Property

    Private _UseCustomVBCode As Boolean
    Public Overridable Overloads Property UseCustomVBCode As Boolean
        Get
            Return _UseCustomVBCode
        End Get
        Set(ByVal value As Boolean)
            Me._UseCustomVBCode = value
            RaiseEvent ActionChanged(value, "UseCustomVBCode", New EventArgs)
        End Set
    End Property

    Public Overloads Property id As String

#End Region

#End Region

#Region "Other"

    Private _Added As Boolean = False
    Public Property Added As Boolean
        Get
            Return Me._Added
        End Get
        Set(ByVal value As Boolean)
            _Added = value
        End Set
    End Property

    Private _Tools As VelerSoftware.Plugins3.Tools
    Public Property Tools As VelerSoftware.Plugins3.Tools
        Get
            Return Me._Tools
        End Get
        Set(ByVal value As VelerSoftware.Plugins3.Tools)
            _Tools = value
        End Set
    End Property

    Private _Children_Actions As System.Collections.Generic.List(Of Action)
    ''' <summary>
    ''' Obtient ou définit les actions enfants contenu dans le designer d'action (ActivityDesigner) si celui-ci donne la possibilité d'ajouter des actions enfants.
    ''' </summary>
    Public Overridable Overloads Property Children_Actions As System.Collections.Generic.List(Of Action)
        Get
            If Me._Children_Actions Is Nothing Then Me._Children_Actions = New System.Collections.Generic.List(Of Action)
            Return Me._Children_Actions
        End Get
        Set(ByVal value As System.Collections.Generic.List(Of Action))
            Me._Children_Actions = value
        End Set
    End Property

#End Region

#Region "PARAMETRES"

    Private Function FlushParam(ByVal value As String) As String
        If Not String.IsNullOrEmpty(value) Then value = value.Replace(ChrW(26), "[CODE]ChrW(26)[/CODE]")
        Return value
    End Function

    Private Function ParseParam(ByVal value As String) As String
        'If Not String.IsNullOrEmpty(value) Then value = value.Replace("[CODE]ChrW(26)[/CODE]", ChrW(26))
        Return value
    End Function

    Private _Param1 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 1 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param1 As String
        Get
            Return ParseParam(_Param1)
        End Get
        Set(ByVal value As String)
            Me._Param1 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param1", New EventArgs)
        End Set
    End Property

    Private _Param2 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 2 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param2 As String
        Get
            Return ParseParam(_Param2)
        End Get
        Set(ByVal value As String)
            Me._Param2 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param2", New EventArgs)
        End Set
    End Property

    Private _Param3 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 3 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param3 As String
        Get
            Return ParseParam(_Param3)
        End Get
        Set(ByVal value As String)
            Me._Param3 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param3", New EventArgs)
        End Set
    End Property

    Private _Param4 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 4 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param4 As String
        Get
            Return ParseParam(_Param4)
        End Get
        Set(ByVal value As String)
            Me._Param4 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param4", New EventArgs)
        End Set
    End Property

    Private _Param5 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 5 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param5 As String
        Get
            Return ParseParam(_Param5)
        End Get
        Set(ByVal value As String)
            Me._Param5 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param5", New EventArgs)
        End Set
    End Property

    Private _Param6 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 6 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param6 As String
        Get
            Return ParseParam(_Param6)
        End Get
        Set(ByVal value As String)
            Me._Param6 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param6", New EventArgs)
        End Set
    End Property

    Private _Param7 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 7 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param7 As String
        Get
            Return ParseParam(_Param7)
        End Get
        Set(ByVal value As String)
            Me._Param7 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param7", New EventArgs)
        End Set
    End Property

    Private _Param8 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 8 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param8 As String
        Get
            Return ParseParam(_Param8)
        End Get
        Set(ByVal value As String)
            Me._Param8 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param8", New EventArgs)
        End Set
    End Property

    Private _Param9 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 9 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param9 As String
        Get
            Return ParseParam(_Param9)
        End Get
        Set(ByVal value As String)
            Me._Param9 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param9", New EventArgs)
        End Set
    End Property

    Private _Param10 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 10 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param10 As String
        Get
            Return ParseParam(_Param10)
        End Get
        Set(ByVal value As String)
            Me._Param10 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param10", New EventArgs)
        End Set
    End Property

    Private _Param11 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 11 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param11 As String
        Get
            Return ParseParam(_Param11)
        End Get
        Set(ByVal value As String)
            Me._Param11 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param11", New EventArgs)
        End Set
    End Property

    Private _Param12 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 12 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param12 As String
        Get
            Return ParseParam(_Param12)
        End Get
        Set(ByVal value As String)
            Me._Param12 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param12", New EventArgs)
        End Set
    End Property

    Private _Param13 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 13 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param13 As String
        Get
            Return ParseParam(_Param13)
        End Get
        Set(ByVal value As String)
            Me._Param13 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param13", New EventArgs)
        End Set
    End Property

    Private _Param14 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 14 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param14 As String
        Get
            Return ParseParam(_Param14)
        End Get
        Set(ByVal value As String)
            Me._Param14 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param14", New EventArgs)
        End Set
    End Property

    Private _Param15 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 15 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param15 As String
        Get
            Return ParseParam(_Param15)
        End Get
        Set(ByVal value As String)
            Me._Param15 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param15", New EventArgs)
        End Set
    End Property

    Private _Param16 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 16 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param16 As String
        Get
            Return ParseParam(_Param16)
        End Get
        Set(ByVal value As String)
            Me._Param16 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param16", New EventArgs)
        End Set
    End Property

    Private _Param17 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 17 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param17 As String
        Get
            Return ParseParam(_Param17)
        End Get
        Set(ByVal value As String)
            Me._Param17 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param17", New EventArgs)
        End Set
    End Property

    Private _Param18 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 18 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param18 As String
        Get
            Return ParseParam(_Param18)
        End Get
        Set(ByVal value As String)
            Me._Param18 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param18", New EventArgs)
        End Set
    End Property

    Private _Param19 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 19 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param19 As String
        Get
            Return ParseParam(_Param19)
        End Get
        Set(ByVal value As String)
            Me._Param19 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param19", New EventArgs)
        End Set
    End Property

    Private _Param20 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 20 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param20 As String
        Get
            Return ParseParam(_Param20)
        End Get
        Set(ByVal value As String)
            Me._Param20 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param20", New EventArgs)
        End Set
    End Property

    Private _Param21 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 21 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param21 As String
        Get
            Return ParseParam(_Param21)
        End Get
        Set(ByVal value As String)
            Me._Param21 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param21", New EventArgs)
        End Set
    End Property

    Private _Param22 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 22 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param22 As String
        Get
            Return ParseParam(_Param22)
        End Get
        Set(ByVal value As String)
            Me._Param22 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param22", New EventArgs)
        End Set
    End Property

    Private _Param23 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 23 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param23 As String
        Get
            Return ParseParam(_Param23)
        End Get
        Set(ByVal value As String)
            Me._Param23 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param23", New EventArgs)
        End Set
    End Property

    Private _Param24 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 24 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param24 As String
        Get
            Return ParseParam(_Param24)
        End Get
        Set(ByVal value As String)
            Me._Param24 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param24", New EventArgs)
        End Set
    End Property

    Private _Param25 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 25 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param25 As String
        Get
            Return ParseParam(_Param25)
        End Get
        Set(ByVal value As String)
            Me._Param25 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param25", New EventArgs)
        End Set
    End Property

    Private _Param26 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 26 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param26 As String
        Get
            Return ParseParam(_Param26)
        End Get
        Set(ByVal value As String)
            Me._Param26 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param26", New EventArgs)
        End Set
    End Property

    Private _Param27 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 27 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param27 As String
        Get
            Return ParseParam(_Param27)
        End Get
        Set(ByVal value As String)
            Me._Param27 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param27", New EventArgs)
        End Set
    End Property

    Private _Param28 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 28 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param28 As String
        Get
            Return ParseParam(_Param28)
        End Get
        Set(ByVal value As String)
            Me._Param28 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param28", New EventArgs)
        End Set
    End Property

    Private _Param29 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 29 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param29 As String
        Get
            Return ParseParam(_Param29)
        End Get
        Set(ByVal value As String)
            Me._Param29 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param29", New EventArgs)
        End Set
    End Property

    Private _Param30 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 30 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param30 As String
        Get
            Return ParseParam(_Param30)
        End Get
        Set(ByVal value As String)
            Me._Param30 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param30", New EventArgs)
        End Set
    End Property

    Private _Param31 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 31 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param31 As String
        Get
            Return ParseParam(_Param31)
        End Get
        Set(ByVal value As String)
            Me._Param31 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param31", New EventArgs)
        End Set
    End Property

    Private _Param32 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 32 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param32 As String
        Get
            Return ParseParam(_Param32)
        End Get
        Set(ByVal value As String)
            Me._Param32 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param32", New EventArgs)
        End Set
    End Property

    Private _Param33 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 33 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param33 As String
        Get
            Return ParseParam(_Param33)
        End Get
        Set(ByVal value As String)
            Me._Param33 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param33", New EventArgs)
        End Set
    End Property

    Private _Param34 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 34 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param34 As String
        Get
            Return ParseParam(_Param34)
        End Get
        Set(ByVal value As String)
            Me._Param34 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param34", New EventArgs)
        End Set
    End Property

    Private _Param35 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 35 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param35 As String
        Get
            Return ParseParam(_Param35)
        End Get
        Set(ByVal value As String)
            Me._Param35 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param35", New EventArgs)
        End Set
    End Property

    Private _Param36 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 36 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param36 As String
        Get
            Return ParseParam(_Param36)
        End Get
        Set(ByVal value As String)
            Me._Param36 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param36", New EventArgs)
        End Set
    End Property

    Private _Param37 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 37 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param37 As String
        Get
            Return ParseParam(_Param37)
        End Get
        Set(ByVal value As String)
            Me._Param37 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param37", New EventArgs)
        End Set
    End Property

    Private _Param38 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 38 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param38 As String
        Get
            Return ParseParam(_Param38)
        End Get
        Set(ByVal value As String)
            Me._Param38 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param38", New EventArgs)
        End Set
    End Property

    Private _Param39 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 39 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param39 As String
        Get
            Return ParseParam(_Param39)
        End Get
        Set(ByVal value As String)
            Me._Param39 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param39", New EventArgs)
        End Set
    End Property

    Private _Param40 As String
    ''' <summary>
    ''' Obtient ou définit la valeur du paramètres numéro 40 de l'action.
    ''' </summary>
    Public Overridable Overloads Property Param40 As String
        Get
            Return ParseParam(_Param40)
        End Get
        Set(ByVal value As String)
            Me._Param40 = FlushParam(value)
            RaiseEvent ActionChanged(value, "Param40", New EventArgs)
        End Set
    End Property

#End Region

#End Region

End Class