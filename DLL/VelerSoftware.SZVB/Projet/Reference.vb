''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Namespace Projet

    ' REFERENCES
    Public Class Reference

        Sub New()

        End Sub

        Sub New(ByVal Project As Boolean, ByVal ref As Reflection.Assembly, ByVal copy As Boolean, ByVal name As String, ByVal version As String, ByVal full As String)
            With Me
                .IsProject = Project
                .Assembly = ref
                .FullName = full
                If ref Is Nothing Then
                    .Location = ""
                    .Name = name
                    .Version = version
                Else
                    .Location = ref.Location
                    .Name = ref.GetName().Name
                    .Version = ref.GetName().Version.ToString
                    .FullName = full
                End If
                If .Name = Nothing AndAlso ref IsNot Nothing Then .Name = ref.GetName.Name
                .Copy = copy
            End With

        End Sub

        Public Property IsProject As Boolean

        Public Property Assembly As Reflection.Assembly

        Public Property Copy As Boolean

        Public Property Location As String

        Public Property Name As String

        Public Property Version As String

        Public Property FullName As String

    End Class

End Namespace