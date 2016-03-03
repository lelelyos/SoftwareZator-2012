<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Lire_Fichier_Texte_Ligne_Par_Ligne_Designer))> _
Public Class Lire_Fichier_Texte_Ligne_Par_Ligne
    Inherits VelerSoftware.Plugins3.ActionWithChildren

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Lire_Fichier_Texte_Ligne_Par_Ligne", GetType(Lire_Fichier_Texte_Ligne_Par_Ligne).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.Lire_Fichier_Texte_Ligne
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression1"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Lire_Fichier_Texte_Ligne_Par_Ligne", GetType(Lire_Fichier_Texte_Ligne_Par_Ligne).Assembly)
        Using frm As New Lire_Fichier_Texte_Ligne_Par_Ligne_Form
            frm.Tools = Me.Tools
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UseCustomVBCode = frm.CodeEditor_Used
                Me.CustomVBCode = New CodeDom.CodeSnippetStatement(frm.CodeEditor_Text)
                Me.Param1 = frm.Param1
                Me.Param2 = frm.Param2
                Me.Param3 = frm.Param3

                Return True
            Else
                Return False
            End If
            frm.Dispose()
        End Using
    End Function

    Public Overrides Function Modify() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Lire_Fichier_Texte_Ligne_Par_Ligne", GetType(Lire_Fichier_Texte_Ligne_Par_Ligne).Assembly)
        Using frm As New Lire_Fichier_Texte_Ligne_Par_Ligne_Form
            frm.Tools = Me.Tools
            frm.Param1 = Me.Param1
            frm.Param2 = Me.Param2
            frm.Param3 = Me.Param3
            frm.CodeEditor_Shown = Me.UseCustomVBCode
            frm.CodeEditor_Used = Me.UseCustomVBCode

            Dim sourceWriter As New IO.StringWriter()
            If Not Me.CustomVBCode Is Nothing Then CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(Me.CustomVBCode, sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())
            sourceWriter.Close()
            frm.CodeEditor_Text = sourceWriter.ToString

            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UseCustomVBCode = frm.CodeEditor_Used
                Me.CustomVBCode = New CodeDom.CodeSnippetStatement(frm.CodeEditor_Text)
                Me.Param1 = frm.Param1
                Me.Param2 = frm.Param2
                Me.Param3 = frm.Param3
                Return True
            Else
                Return False
            End If
            frm.Dispose()
        End Using
    End Function


    Public Overrides Function GetVBCode(ByVal FromFunction As Boolean) As System.CodeDom.CodeObject
        If Me.UseCustomVBCode Then
            Return Me.CustomVBCode
        Else
            If FromFunction Then
                Dim sourceWriter As New IO.StringWriter()
                Dim codestr As String = Nothing

                Dim var_depart As New CodeDom.CodeVariableReferenceExpression(Me.Param2)
                Dim var_arrivee As New CodeDom.CodeVariableReferenceExpression(Me.Param3)
                Dim codeloop As New CodeDom.CodeIterationStatement()

                codeloop.InitStatement = New CodeDom.CodeAssignStatement(var_depart, New CodeDom.CodeSnippetExpression("New System.IO.StreamReader(CStr(" & Me.Tools.TransformKeyVariables(Me.Param1, True) & "), True)"))
                codeloop.TestExpression = New CodeDom.CodePrimitiveExpression(True)
                codeloop.IncrementStatement = New CodeDom.CodeSnippetStatement("If " & Me.Param2 & ".EndOfStream Then " & Me.Param2 & ".Close() : Exit Do")
                codeloop.Statements.Add(New CodeDom.CodeSnippetExpression(Me.Param3 & " = " & Me.Param2 & ".ReadLine()"))

                Return codeloop
            Else
                Return Nothing
            End If
        End If
    End Function

End Class
