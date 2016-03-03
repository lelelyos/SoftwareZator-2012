<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Boucle_Limitee_Designer))> _
Public Class Boucle_Limitee
    Inherits VelerSoftware.Plugins3.ActionWithChildren

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Boucle_Limitee", GetType(Boucle_Limitee).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.boucle
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression1"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression2"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression3"))
            .Voice_Recognition_Expressions_Dictionary.Add(RM.GetString("DictionaryExpression4"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Boucle_Limitee", GetType(Boucle_Limitee).Assembly)
        Using frm As New Boucle_Limitee_Form
            frm.Tools = Me.Tools
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UseCustomVBCode = frm.CodeEditor_Used
                Me.CustomVBCode = New CodeDom.CodeSnippetStatement(frm.CodeEditor_Text)
                Me.Param1 = frm.Param1
                Me.Param2 = frm.Param2
                Me.Param3 = frm.Param3
                Me.Param5 = frm.Param5
                Me.Param6 = frm.Param6

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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Boucle_Limitee", GetType(Boucle_Limitee).Assembly)
        Using frm As New Boucle_Limitee_Form
            frm.Tools = Me.Tools
            frm.Param1 = Me.Param1
            frm.Param2 = Me.Param2
            frm.Param3 = Me.Param3
            frm.Param5 = Me.Param5
            frm.Param6 = Me.Param6
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
                Me.Param5 = frm.Param5
                Me.Param6 = frm.Param6
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
                Dim var_depart As New CodeDom.CodeVariableReferenceExpression(Me.Param1)
                Dim var_arrivee As New CodeDom.CodeVariableReferenceExpression(Me.Param3)

                Dim codeloop As New CodeDom.CodeIterationStatement()

                If Not Me.Param2 = Nothing Then
                    If IsNumeric(Me.Param2) Then
                        codeloop.InitStatement = New CodeDom.CodeAssignStatement(var_depart, New CodeDom.CodePrimitiveExpression(CInt(Me.Param2)))
                    Else
                        codeloop.InitStatement = New CodeDom.CodeAssignStatement(var_depart, New CodeDom.CodeVariableReferenceExpression(Me.Param2))
                    End If
                End If

                If Not Me.Param3 = Nothing Then
                    If IsNumeric(Me.Param3) Then
                        codeloop.TestExpression = New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.LessThan, New CodeDom.CodePrimitiveExpression(CInt(Me.Param3)))
                    Else
                        If Me.Param6 Then
                            codeloop.TestExpression = New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.LessThan, New CodeDom.CodePropertyReferenceExpression(var_arrivee, "Count"))
                        Else
                            codeloop.TestExpression = New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.LessThan, var_arrivee)
                        End If
                    End If
                End If

                If Not Me.Param5 = Nothing Then
                    If IsNumeric(Me.Param5) Then
                        codeloop.IncrementStatement = New CodeDom.CodeAssignStatement(var_depart, New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.Add, New CodeDom.CodePrimitiveExpression(CInt(Me.Param5))))
                    Else
                        codeloop.IncrementStatement = New CodeDom.CodeAssignStatement(var_depart, New CodeDom.CodeBinaryOperatorExpression(var_depart, CodeDom.CodeBinaryOperatorType.Add, New CodeDom.CodeVariableReferenceExpression(Me.Param5)))
                    End If
                End If

                Return codeloop
            Else
                Return Nothing
            End If
        End If
    End Function

End Class
