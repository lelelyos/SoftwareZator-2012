Public Class VoiceRecognition
    Inherits System.ComponentModel.Component

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Requis pour la prise en charge du Concepteur de composition de classes Windows.Forms
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur de composants.
        InitializeComponent()

    End Sub

    'Component remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur de composants
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur de composants
    'Elle peut être modifiée à l'aide du Concepteur de composants.
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub






    Private _SRE As Speech.Recognition.SpeechRecognitionEngine
    Public Property SRE As Speech.Recognition.SpeechRecognitionEngine
        Get
            Return _SRE
        End Get
        Set(value As Speech.Recognition.SpeechRecognitionEngine)
            _SRE = value
        End Set
    End Property

    Private Sub SRE_SpeechRecognized(ByVal sender As Object, ByVal e As Speech.Recognition.SpeechRecognizedEventArgs)
        RaiseEvent OnSpeechRecognized(Me, e.Result.Text)
    End Sub

    Public Sub Start_SpeechRecognition()
        If Not RunningOnXP Then
            If SRE Is Nothing Then SRE = New Speech.Recognition.SpeechRecognitionEngine
            SRE.LoadGrammarAsync(New System.Speech.Recognition.DictationGrammar())
            SRE.SetInputToDefaultAudioDevice()
            SRE.RecognizeAsync(System.Speech.Recognition.RecognizeMode.Multiple)
            AddHandler SRE.SpeechRecognized, AddressOf SRE_SpeechRecognized
        Else
            Throw New NotSupportedException("Speech recognition is not available for Microsoft Windows XP.")
        End If
    End Sub

    Public Sub Stop_SpeechRecognition()
        If Not SRE Is Nothing Then
            RemoveHandler SRE.SpeechRecognized, AddressOf SRE_SpeechRecognized
            SRE.RecognizeAsyncCancel()
            SRE.RecognizeAsyncStop()
            SRE.UnloadAllGrammars()
            SRE.Dispose()
            SRE = Nothing
        End If
    End Sub



    ''' <summary>
    ''' Declare un delegate
    ''' </summary>
    Public Delegate Sub OnSpeechRecognizedEventHandler(ByVal sender As Object, ByVal e As String)
    ''' <summary>
    ''' Declare un evenement qui va contenir les informations que nous souhaitons envoyer
    ''' </summary>
    <ComponentModel.Description("Triggers when the user speaks into the microphone.")> _
    Public Event OnSpeechRecognized As OnSpeechRecognizedEventHandler

    ''' <summary>
    ''' Déterminer si l'application fonctionne sur Windows XP
    ''' </summary>
    Private ReadOnly Property RunningOnXP() As Boolean
        Get
            Return Environment.OSVersion.Version.Major = 5
        End Get
    End Property

End Class
