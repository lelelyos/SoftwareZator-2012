﻿Public Class Obtenir_Tous_Element_Groupe_Form
    Inherits VelerSoftware.Plugins3.ActionForm

    Private Sub FonctionForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me
            .CancelButtonText = RM.GetString("CancelButtonText")
            .Title = RM.GetString("DisplayName")
            .Help_File = RM.GetString("Help_File")

            .ParseCode_Button_Visible = True

            .Boutons_ComboBox.Items.Clear()
            For Each aaa As VelerSoftware.Plugins3.Windows.Core.Object In .Tools.GetCurrentProjectWindowsControls
                If aaa.ObjectType = GetType(CodeDom.CodeMemberField) AndAlso (DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "System.Windows.Forms.GroupBox" OrElse DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "ComponentFactory.Krypton.Toolkit.KryptonGroup" OrElse DirectCast(aaa.Object, CodeDom.CodeMemberField).Type.BaseType = "ComponentFactory.Krypton.Toolkit.KryptonGroupBox") Then
                    .Boutons_ComboBox.Items.Add(aaa.FullName)
                End If
            Next

            .ComboBox1.Items.Clear()
            For Each aaa As VelerSoftware.SZVB.Projet.Variable In .Tools.GetCurrentProjectVariableList
                If aaa.Array Then
                    .ComboBox1.Items.Add(aaa.Name)
                End If
            Next

            If Not .Param1 = Nothing Then
                If Not .Boutons_ComboBox.FindString(.Param1) = -1 Then
                    .Boutons_ComboBox.Text = .Boutons_ComboBox.Items(.Boutons_ComboBox.FindString(.Param1))
                End If
            End If

            If Not .Param2 = Nothing Then
                If Not .ComboBox1.FindString(.Param2) = -1 Then
                    .ComboBox1.Text = .ComboBox1.Items(.ComboBox1.FindString(.Param2))
                End If
            End If

        End With
    End Sub

    Private Sub FonctionForm_OnOKButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnOKButtonClicked
        With Me
            If .Boutons_ComboBox.Text = "" OrElse .ComboBox1.Text = "" Then
                MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            .Param1 = .Boutons_ComboBox.Text
            .Param2 = .ComboBox1.Text

            .DialogResult = Windows.Forms.DialogResult.OK
            .Close()
        End With
    End Sub

    Private Sub FonctionForm_OnCancelButtonClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnCancelButtonClicked
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FonctionForm_OnRefreshCodeButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.OnRefreshCodeButtonClick
        If Me.Boutons_ComboBox.Text = "" OrElse Me.ComboBox1.Text = "" Then
            MsgBox(RM.GetString("Formulaire_Incomplet"), MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim sourceWriter As New IO.StringWriter()

        Dim OperationStatement As CodeDom.CodeSnippetExpression
        If Me.Boutons_ComboBox.Text.StartsWith("Me.") Then
            OperationStatement = New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(" & Me.Boutons_ComboBox.Text & ".Controls))")
        Else
            OperationStatement = New CodeDom.CodeSnippetExpression("New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(Variables." & Me.Boutons_ComboBox.Text & ".Controls))")
        End If
        CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").GenerateCodeFromStatement(New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.ComboBox1.Text), OperationStatement), sourceWriter, New CodeDom.Compiler.CodeGeneratorOptions())

        sourceWriter.Close()

        Me.CodeEditor_Text = sourceWriter.ToString
    End Sub

    Private Sub FonctionForm_OnParseCodeButtonClick(ByVal sender As CodeDom.CodeCompileUnit, ByVal e As System.EventArgs) Handles MyBase.OnParseCodeButtonClick
        If (Not sender Is Nothing) AndAlso (sender.Namespaces.Count > 0) Then
            Dim metho As CodeDom.CodeMethodInvokeExpression
            For Each sta As CodeDom.CodeStatement In DirectCast(sender.Namespaces(0).Types(0).Members(0), CodeDom.CodeMemberMethod).Statements

                If TypeOf sta Is CodeDom.CodeAssignStatement AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Left Is CodeDom.CodeVariableReferenceExpression AndAlso TypeOf DirectCast(sta, CodeDom.CodeAssignStatement).Right Is CodeDom.CodeObjectCreateExpression Then
                    Me.ComboBox1.Text = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Left, CodeDom.CodeVariableReferenceExpression).VariableName

                    ' Dans le cas où se soit une simple méthode
                    If DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeObjectCreateExpression).Parameters.Count = 1 AndAlso TypeOf DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeObjectCreateExpression).Parameters(0) Is CodeDom.CodeMethodInvokeExpression Then
                        metho = DirectCast(DirectCast(sta, CodeDom.CodeAssignStatement).Right, CodeDom.CodeObjectCreateExpression).Parameters(0)
                        If metho.Method.MethodName = "Cast" AndAlso metho.Parameters.Count = 1 AndAlso TypeOf metho.Parameters(0) Is CodeDom.CodePropertyReferenceExpression AndAlso DirectCast(metho.Parameters(0), CodeDom.CodePropertyReferenceExpression).PropertyName = "Controls" Then
                            If Not Me.Boutons_ComboBox.FindString("Me." & DirectCast(DirectCast(metho.Parameters(0), CodeDom.CodePropertyReferenceExpression).TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName) = -1 Then
                                Me.Boutons_ComboBox.Text = Me.Boutons_ComboBox.Items(Me.Boutons_ComboBox.FindString("Me." & DirectCast(DirectCast(metho.Parameters(0), CodeDom.CodePropertyReferenceExpression).TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName))
                            End If
                            If Not Me.Boutons_ComboBox.FindString("Variables." & DirectCast(DirectCast(metho.Parameters(0), CodeDom.CodePropertyReferenceExpression).TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName) = -1 Then
                                Me.Boutons_ComboBox.Text = Me.Boutons_ComboBox.Items(Me.Boutons_ComboBox.FindString("Variables." & DirectCast(DirectCast(metho.Parameters(0), CodeDom.CodePropertyReferenceExpression).TargetObject, CodeDom.CodePropertyReferenceExpression).PropertyName))
                            End If
                        End If
                    End If

                End If

            Next
        End If
    End Sub

End Class