''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class DocConcepteurFenetreErreurs

    Private Sub KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton1.Click
        Dim files() As String = New String(-1) {}
        Dim Safefiles() As String = New String(-1) {}
        Dim projects() As VelerSoftware.SZVB.Projet.Projet = New VelerSoftware.SZVB.Projet.Projet(-1) {}

        ReDim Preserve files(files.Length)
        ReDim Preserve Safefiles(Safefiles.Length)
        ReDim Preserve projects(projects.Length)
        files(files.Length - 1) = "PARAMETREDUPROJET"
        Safefiles(Safefiles.Length - 1) = "PARAMETREDUPROJET"
        projects(projects.Length - 1) = SOLUTION.GetProject(DirectCast(Form1.KryptonDockableWorkspace1.ActivePage.Controls(0), DocConcepteurFenetre).Nom_Projet)

        ClassProjet.Ouvrir_Document(files, Safefiles, projects)
    End Sub

    Private Sub DocConcepteurFenetreErreurs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler VelerSoftware.Design.Toolkit.KryptonManager.GlobalPaletteChanged, AddressOf OnGlobalPaletteChanged
        OnGlobalPaletteChanged(Nothing, EventArgs.Empty)

    End Sub

    Private Sub OnGlobalPaletteChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Use the current font from the global palette
        Dim palette As VelerSoftware.Design.Toolkit.IPalette = VelerSoftware.Design.Toolkit.KryptonManager.CurrentGlobalPalette
        Dim font As System.Drawing.Font = palette.GetContentShortTextFont(VelerSoftware.Design.Toolkit.PaletteContentStyle.LabelNormalControl, VelerSoftware.Design.Toolkit.PaletteState.Normal)
    End Sub

End Class
