<System.ComponentModel.Designer(GetType(VelerSoftware.GeneralPlugin.Incrementer_Date_Designer))> _
Public Class Incrementer_Date
    Inherits VelerSoftware.Plugins3.Action

    Public Sub New()
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Incrementer_Date", GetType(Incrementer_Date).Assembly)

        With Me
            .DisplayName = RM.GetString("DisplayName")
            .Description = RM.GetString("Description")
            .Category = RM.GetString("Category")
            .ToolBoxImage = My.Resources.Incrementer_Date
            .CompatibleClass = False
            .CompatibleFonctions = True
            .FileHelp = RM.GetString("Help_File")

            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary1"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary2"))
            .Voice_Recognition_Dictionary.Add(RM.GetString("Dictionary3"))
        End With
    End Sub

    Public Overrides Function Main() As Boolean
        ' Initialisation de la langue et des ressources
        System.Threading.Thread.CurrentThread.CurrentUICulture = VelerSoftware.Plugins3.CurrentCulture
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Incrementer_Date", GetType(Incrementer_Date).Assembly)
        Using frm As New Incrementer_Date_Form
            frm.Tools = Me.Tools
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.UseCustomVBCode = frm.CodeEditor_Used
                Me.CustomVBCode = New CodeDom.CodeSnippetStatement(frm.CodeEditor_Text)
                Me.Param1 = frm.Param1
                Me.Param2 = frm.Param2
                Me.Param3 = frm.Param3
                Me.Param4 = frm.Param4
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
        RM = New System.Resources.ResourceManager("VelerSoftware.GeneralPlugin.Incrementer_Date", GetType(Incrementer_Date).Assembly)
        Using frm As New Incrementer_Date_Form
            frm.Tools = Me.Tools
            frm.Param1 = Me.Param1
            frm.Param2 = Me.Param2
            frm.Param3 = Me.Param3
            frm.Param4 = Me.Param4
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
                Me.Param4 = frm.Param4
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
                Dim comparer As String = Nothing
                Select Case CInt(Me.Param4)
                    Case 0
                        comparer = "Microsoft.VisualBasic.DateInterval.Year"
                    Case 1
                        comparer = "Microsoft.VisualBasic.DateInterval.DayOfYear"
                    Case 2
                        comparer = "Microsoft.VisualBasic.DateInterval.Day"
                    Case 3
                        comparer = "Microsoft.VisualBasic.DateInterval.Hour"
                    Case 4
                        comparer = "Microsoft.VisualBasic.DateInterval.Minute"
                    Case 5
                        comparer = "Microsoft.VisualBasic.DateInterval.Month"
                    Case 6
                        comparer = "Microsoft.VisualBasic.DateInterval.Quarter"
                    Case 7
                        comparer = "Microsoft.VisualBasic.DateInterval.Second"
                    Case 8
                        comparer = "Microsoft.VisualBasic.DateInterval.Weekday"
                    Case 9
                        comparer = "Microsoft.VisualBasic.DateInterval.WeekOfYear"
                End Select

                Return New CodeDom.CodeAssignStatement(New CodeDom.CodeVariableReferenceExpression(Me.Param6), New CodeDom.CodeMethodInvokeExpression(New CodeDom.CodeMethodReferenceExpression(New CodeDom.CodeTypeReferenceExpression("Microsoft.VisualBasic"), "DateAdd"), New CodeDom.CodeSnippetExpression(comparer), New CodeDom.CodeSnippetExpression(Me.Tools.TransformKeyVariables(Me.Param5, False, False)), New CodeDom.CodeSnippetExpression(Me.Param1)))
            Else
                Return Nothing
            End If
        End If
    End Function

End Class
