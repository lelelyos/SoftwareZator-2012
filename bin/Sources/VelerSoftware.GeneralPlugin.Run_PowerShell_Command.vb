Partial Public Class VelerSoftware_GeneralPlugin

    Shared Function RunPowerShellCommand(ByVal Script As String, ByVal StronglyString As Boolean) As System.Collections.Generic.List(Of Object)
        Dim list As New System.Collections.Generic.List(Of Object)
        Dim collection2 As System.Collections.ObjectModel.Collection(Of System.Management.Automation.PSObject)
        Dim obj As System.Management.Automation.PSObject
        Dim pipeline As System.Management.Automation.Runspaces.Pipeline
        Dim runspace As System.Management.Automation.Runspaces.Runspace = System.Management.Automation.Runspaces.RunspaceFactory.CreateRunspace()
        runspace.Open()
        pipeline = runspace.CreatePipeline()
        pipeline.Commands.AddScript(script)
        If StronglyString Then pipeline.Commands.Add("Out-String")
        collection2 = pipeline.Invoke
        If StronglyString Then
            Dim builder As New System.Text.StringBuilder
            For Each obj In collection2
                If (builder.Length > 0) Then
                    builder.Append(obj.ToString)
                Else
                    builder.AppendLine(obj.ToString)
                End If
            Next
            list = New System.Collections.Generic.List(Of Object)(System.Linq.Enumerable.Cast(Of Object)(builder.ToString().Split(System.Environment.NewLine)))
        Else
            For Each obj In collection2
                list.Add(obj.ImmediateBaseObject)
            Next
        End If
        Return list
    End Function

End Class
