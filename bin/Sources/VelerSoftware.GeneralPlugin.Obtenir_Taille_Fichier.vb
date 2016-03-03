Partial Public Class VelerSoftware_GeneralPlugin

    Shared Function GetFileLen(ByVal _pathh As String, ByVal _add_unitt As Boolean, ByVal _format_specifiedd As Boolean, ByVal _formatt As String) As String
        Dim Result As String = Nothing
        Dim fiLen As Long = 0

        If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(_pathh) Then
            fiLen = Microsoft.VisualBasic.FileIO.FileSystem.GetFileInfo(_pathh).Length
            If _format_specifiedd Then
                Select Case _formatt
                    Case "Octet"
                        If _add_unitt Then
                            result = Microsoft.VisualBasic.Strings.Format(fiLen, "##0 Octets")
                        Else
                            result = Microsoft.VisualBasic.Strings.Format(fiLen, "##0")
                        End If
                    Case "Ko"
                        If _add_unitt Then
                            result = Microsoft.VisualBasic.FormatNumber((fiLen / 1024), 0, TriState.True, TriState.True, TriState.True) & " Ko"
                        Else
                            result = Microsoft.VisualBasic.FormatNumber((fiLen / 1024), 0, TriState.True, TriState.True, TriState.True)
                        End If
                    Case "Mo"
                        If _add_unitt Then
                            result = Microsoft.VisualBasic.FormatNumber((fiLen / 1048576), 2, TriState.True, TriState.True, TriState.True) & " Mo"
                        Else
                            result = Microsoft.VisualBasic.FormatNumber((fiLen / 1048576), 2, TriState.True, TriState.True, TriState.True)
                        End If
                    Case "Go"
                        If _add_unitt Then
                            result = Microsoft.VisualBasic.FormatNumber((fiLen / 1073741824), 2, TriState.True, TriState.True, TriState.True) & " Go"
                        Else
                            result = Microsoft.VisualBasic.FormatNumber((fiLen / 1073741824), 2, TriState.True, TriState.True, TriState.True)
                        End If
                    Case "Auto"
                        Select Case filen
                            Case Is >= 1073741824
                                If _add_unitt Then
                                    result = Microsoft.VisualBasic.FormatNumber((fiLen / 1073741824), 2, TriState.True, TriState.True, TriState.True) & " Go"
                                Else
                                    result = Microsoft.VisualBasic.FormatNumber((fiLen / 1073741824), 2, TriState.True, TriState.True, TriState.True)
                                End If
                            Case Is >= 1048576
                                If _add_unitt Then
                                    result = Microsoft.VisualBasic.FormatNumber((fiLen / 1048576), 2, TriState.True, TriState.True, TriState.True) & " Mo"
                                Else
                                    result = Microsoft.VisualBasic.FormatNumber((fiLen / 1048576), 2, TriState.True, TriState.True, TriState.True)
                                End If
                            Case Is >= 1024
                                If _add_unitt Then
                                    result = Microsoft.VisualBasic.FormatNumber((fiLen / 1024), 0, TriState.True, TriState.True, TriState.True) & " Ko"
                                Else
                                    result = Microsoft.VisualBasic.FormatNumber((fiLen / 1024), 0, TriState.True, TriState.True, TriState.True)
                                End If
                            Case Else
                                If _add_unitt Then
                                    result = Microsoft.VisualBasic.Strings.Format(fiLen, "##0 Octets")
                                Else
                                    result = Microsoft.VisualBasic.Strings.Format(fiLen, "##0")
                                End If
                        End Select
                End Select
            Else
                If _add_unitt Then
                    result = Microsoft.VisualBasic.Strings.Format(fiLen, "##0 Octets")
                Else
                    result = Microsoft.VisualBasic.Strings.Format(fiLen, "##0")
                End If
            End If
        End If

        Return Result
    End Function

End Class
