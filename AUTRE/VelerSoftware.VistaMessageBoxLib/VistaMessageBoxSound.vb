Imports System.IO
Imports System.Media
Imports System.Security
Imports Microsoft.Win32



''' <summary>
''' Represents a sound.
''' </summary>
Public Interface ISound
	''' <summary>
	''' Plays the sound.
	''' </summary>
	Sub Play()
End Interface

''' <summary>
''' Represents a system sound.
''' </summary>
Public NotInheritable Class VistaMessageBoxSound
	Implements ISound

	Friend Sub New(ByVal name As String)
		Me.name = name
	End Sub

	Private Shared ReadOnly mediaPath As String = Environment.ExpandEnvironmentVariables("%SystemRoot%\Media\")
	Private name As String

	''' <summary>
	''' Plays the system sound.
	''' </summary>
	Public Sub Play() Implements ISound.Play
		Try
			Dim soundPath As String = TryCast(Registry.GetValue(("HKEY_CURRENT_USER\AppEvents\Schemes\Apps\.Default\" & Me.name & "\.Current"), Nothing, Nothing), String)
			If (Not File.Exists(soundPath) AndAlso File.Exists(Path.Combine(mediaPath, soundPath))) Then
				soundPath = Path.Combine(mediaPath, soundPath)
			End If
			Using player As SoundPlayer = New SoundPlayer(soundPath)
				player.Play()
			End Using
		Catch e1 As IOException
		Catch e2 As TimeoutException
		Catch e3 As ArgumentException
		Catch e4 As SecurityException
		Catch e5 As InvalidOperationException
		End Try
	End Sub


	Private Shared _default As ISound
	Private Shared _information As ISound
	Private Shared _question As ISound
	Private Shared _warning As ISound
	Private Shared _error As ISound
	Private Shared _security As ISound

	''' <summary>
	''' Gets the sound associated with the Default program event in the current Windows sound scheme.
	''' </summary>
	''' <returns>An ISound.</returns>
	Public Shared ReadOnly Property [Default]() As ISound
		Get
			If (_default Is Nothing) Then
				_default = New VistaMessageBoxSound(".Default")
			End If
			Return _default
		End Get
	End Property

	''' <summary>
	''' Gets the sound associated with the Asterisk program event in the current Windows sound scheme.
	''' </summary>
	''' <returns>An ISound.</returns>
	Public Shared ReadOnly Property Information() As ISound
		Get
			If (_information Is Nothing) Then
				_information = New VistaMessageBoxSound("SystemAsterisk")
			End If
			Return _information
		End Get
	End Property

	''' <summary>
	''' Gets the sound associated with the Question program event in the current Windows sound scheme.
	''' </summary>
	''' <returns>An ISound.</returns>
	Public Shared ReadOnly Property Question() As ISound
		Get
			If (_question Is Nothing) Then
				_question = New VistaMessageBoxSound("SystemQuestion")
			End If
			Return _question
		End Get
	End Property

	''' <summary>
	''' Gets the sound associated with the Exclamation program event in the current Windows sound scheme.
	''' </summary>
	''' <returns>An ISound.</returns>
	Public Shared ReadOnly Property Warning() As ISound
		Get
			If (_warning Is Nothing) Then
				_warning = New VistaMessageBoxSound("SystemExclamation")
			End If
			Return _warning
		End Get
	End Property

	''' <summary>
	''' Gets the sound associated with the Hand program event in the current Windows sound scheme.
	''' </summary>
	''' <returns>An ISound.</returns>
	Public Shared ReadOnly Property [Error]() As ISound
		Get
			If (_error Is Nothing) Then
				_error = New VistaMessageBoxSound("SystemHand")
			End If
			Return _error
		End Get
	End Property

	''' <summary>
	''' Gets the sound associated with the WindowsUAC program event in the current Windows sound scheme.
	''' </summary>
	''' <returns>An ISound.</returns>
	''' <remarks>On pre-Vista systems it gets the sound associated with the Hand program event in the current Windows sound scheme.</remarks>
	Public Shared ReadOnly Property Security() As ISound
		Get
			If (_security Is Nothing) Then
				If Environment.OSVersion.Version.Major >= 6 Then
					_security = New VistaMessageBoxSound("WindowsUAC")
				Else
					_security = New VistaMessageBoxSound("SystemHand")
				End If
			End If
			Return _security
		End Get
	End Property

End Class