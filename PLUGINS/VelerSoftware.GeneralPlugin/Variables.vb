Module Variables

    Public RM As System.Resources.ResourceManager = Nothing

    ' Permet de retourner un chemin depuis un emplacement existant
    ' Selectionne = Nom du fichier pour lequel on doit trouver le chemin
    ' FileName_Complete = Nom du fichier (ou dossier) duquel on doit partir pour faire la recherche
    Public Function Ouvrir_Fichier(ByVal PathReference As String, ByVal PathLink As String) As String
        'Dim Chemin1 As String = FileName_Complete
        'Dim Chemin2 As String = Selectionne
        'Dim Resultat As String
        'Dim r As Long
        'Dim t As Long
        'Dim aaa As String()
        'Dim bbb As String()
        '
        'aaa = Split(Chemin1, "\")
        'bbb = Split(Chemin2, "\")
        'Resultat = ""
        'For r = 0 To aaa.Length - 1
        '    If aaa(r).ToUpper <> bbb(r).ToUpper Then Exit For
        'Next r
        '' Différence trouvée
        'If aaa.Length > 2 Then
        '    For t = r To aaa.Length - 2   ' -1 pour l'index 0 et -1 pour le nom du fichier
        '        Resultat = Resultat & "..\"
        '    Next t
        '    For r = r To bbb.Length - 2
        '        Resultat = Resultat & bbb(r) & "\"
        '    Next
        'End If
        '' Ajoute le nom du fichier qui est à la fin
        'Resultat = Resultat & bbb(bbb.Length - 1)
        'Return Resultat

        If PathReference = PathLink Then
            Return ""
            Exit Function
        End If

        Dim ArrPathRef(), ArrPathLink() As String 'tableau des noms de dossiers
        Dim Path As String 'le chemin relatif a renvoyer
        Dim k, maxLength As Integer 'un counter
        Dim numUp As Integer 'le nombre de dossier a monter dans le chemin de ref jusqu'a la divergence
        Dim numDiv As Integer = 1 'le nombre de dossier depuis la racine jusqu'a la divergence (la racine est 1)

        'On cree l'array de dossier
        ArrPathRef = Split(PathReference, "\")
        ArrPathLink = Split(PathLink, "\")

        'si les 2 chemins sont dans une partion differente
        'on renvoi le chemin entier de celui a lier
        If ArrPathRef(0) <> ArrPathLink(0) Then
            Return PathLink
            Exit Function
        End If

        'on cherche le chemin le plus long
        If ArrPathLink.Length > ArrPathRef.Length Then
            maxLength = ArrPathLink.Length
        Else
            maxLength = ArrPathRef.Length
        End If

        'obtention du point de divergence
        For k = 0 To maxLength
            'on incremente jusqu'a la fin des chemins ou
            'l'observation d'une divergence entre les chemins
            If k > ArrPathLink.Length - 1 _
            OrElse k > ArrPathRef.Length - 1 _
            OrElse ArrPathLink(k) <> ArrPathRef(k) _
            Then
                Exit For
            End If

            numDiv = numDiv + 1
        Next

        'maintenant avec le point de divergence, obtention du nombre
        'de dossier a monter ou a descendre
        numUp = ArrPathRef.Length - numDiv + 1

        'on reconstruit la chaine
        Path = ""

        'On ajoute la partie a monter
        If numUp = 0 Then
            Path = ""
        Else
            For k = 0 To numUp - 1
                If k = 0 Then
                    Path = ".."
                Else
                    Path = Path & "\.."
                End If
            Next
        End If

        'on ajoute la parti a descendre
        For k = (numDiv - 1) To ArrPathLink.Length - 1
            Path = Path & "\" & ArrPathLink(k)
        Next

        Path = Path.TrimStart("\")

        Return Path
    End Function

End Module
