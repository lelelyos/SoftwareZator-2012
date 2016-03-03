''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class ClassFichier

    ' Permet de déterminer si un fichier est en lecture seule ou non
    ' Filz = est égale au nom du fichier pour lequel on doit déterminer le mode
    Shared Function IsReadOnly(ByVal Filz As String) As Boolean
        Dim RESULTAT As Boolean = False
        If My.Computer.FileSystem.FileExists(Filz) Then
            ' Récupération des attributs d'un fichier
            Dim Fa As IO.FileAttributes = IO.File.GetAttributes(Filz)
            ' Vérification si le fichier est en lecture seule
            If (Fa And IO.FileAttributes.ReadOnly) = IO.FileAttributes.ReadOnly Then
                RESULTAT = True ' est readonly
            Else
                RESULTAT = False ' n'est pas readonly
            End If
        End If
        Return RESULTAT
    End Function

    ' Permet de retourner un chemin depuis un emplacement existant
    ' Selectionne = Nom du fichier pour lequel on doit trouver le chemin
    ' FileName_Complete = Nom du fichier (ou dossier) duquel on doit partir pour faire la recherche
    Shared Function Ouvrir_Fichier(ByVal PathReference As String, ByVal PathLink As String) As String
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
            Then Exit For

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

    Shared Function Determine_Fichier_Existe(ByVal Nom As String, ByVal Dossier As String, ByVal Extension As String) As String
        ' on cherche un nom de dossier pour le projet où l'on est sur qu'il n'existe pas, de façon à éviter les message d'erreur disant que le dossier existe déja.
        Dim RESULTAT As String = Nothing
        Dim i As Integer = 1
        Do
            If Not My.Computer.FileSystem.FileExists(Dossier & "\" & Nom & i & "." & Extension) Then
                RESULTAT = Nom & i
                Return RESULTAT
                Exit Function
            Else
                i = i + 1
            End If
        Loop
        Return RESULTAT
    End Function

    Shared Function Determine_Dossier_Existe(ByVal Emplacement As String, ByVal Nom As String) As String
        ' on cherche un nom de dossier pour le projet où l'on est sur qu'il n'existe pas, de façon à éviter les message d'erreur disant que le dossier existe déja.
        Dim RESULTAT As String = Nothing
        Dim i As Integer = 1
        Do
            If Not My.Computer.FileSystem.DirectoryExists(Emplacement & "\" & Nom & i) Then
                RESULTAT = Nom & i
                Return RESULTAT
                Exit Function
            Else
                i = i + 1
            End If
        Loop
        Return RESULTAT
    End Function




    Shared Function Charger_Fichier_SZW(ByVal FileName As String) As VelerSoftware.SZVB.Projet.SZW_File
        If My.Computer.FileSystem.FileExists(FileName) Then
            Dim myFileStream As IO.Stream = IO.File.OpenRead(FileName)
            Dim deserializer As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            Try
                Return (DirectCast(deserializer.Deserialize(myFileStream), VelerSoftware.SZVB.Projet.SZW_File))
            Finally
                myFileStream.Close()
                myFileStream.Dispose()
            End Try
            Return Nothing
        Else
            Return Nothing
        End If
    End Function

    Shared Function Charger_Fichier_SZC(ByVal FileName As String) As VelerSoftware.SZVB.Projet.SZC_File
        If My.Computer.FileSystem.FileExists(FileName) Then
            Dim myFileStream As IO.Stream = IO.File.OpenRead(FileName)
            Dim deserializer As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            Try
                Return (DirectCast(deserializer.Deserialize(myFileStream), VelerSoftware.SZVB.Projet.SZC_File))
            Finally
                myFileStream.Close()
                myFileStream.Dispose()
            End Try
            Return Nothing
        Else
            Return Nothing
        End If
    End Function


    ' Créer une clé
    Shared Function CreateKey(ByVal strPassword As String) As Byte()
        Dim chrData() As Char = strPassword.ToCharArray
        Dim intLength As Integer = chrData.GetUpperBound(0)
        Dim bytDataToHash(intLength) As Byte
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Microsoft.VisualBasic.Asc(chrData(i)))
        Next
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        Dim bytKey(31) As Byte
        For i As Integer = 0 To 31
            bytKey(i) = bytResult(i)
        Next
        Return bytKey
    End Function

    ' Créer un IV
    Shared Function CreateIV(ByVal strPassword As String) As Byte()
        Dim chrData() As Char = strPassword.ToCharArray
        Dim intLength As Integer = chrData.GetUpperBound(0)
        Dim bytDataToHash(intLength) As Byte
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Microsoft.VisualBasic.Asc(chrData(i)))
        Next
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        Dim bytIV(15) As Byte
        For i As Integer = 32 To 47
            bytIV(i - 32) = bytResult(i)
        Next
        Return bytIV
    End Function

    Public Enum CryptoAction
        ActionEncrypt = 1
        ActionDecrypt = 2
    End Enum

    ' Encrypter/Décrypter un fichier
    Shared Sub EncryptOrDecryptFile(ByVal strInputFile As String, ByVal strOutputFile As String, ByVal bytKey() As Byte, ByVal bytIV() As Byte, ByVal Direction As CryptoAction)
        Dim fsInput As System.IO.FileStream
        Dim fsOutput As System.IO.FileStream
        fsInput = New System.IO.FileStream(strInputFile, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        fsOutput = New System.IO.FileStream(strOutputFile, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
        fsOutput.SetLength(0)
        Dim bytBuffer(4096) As Byte
        Dim lngBytesProcessed As Long = 0
        Dim lngFileLength As Long = fsInput.Length
        Dim intBytesInCurrentBlock As Integer
        Dim csCryptoStream As System.Security.Cryptography.CryptoStream
        Dim cspRijndael As New System.Security.Cryptography.RijndaelManaged
        Select Case Direction
            Case CryptoAction.ActionEncrypt
                csCryptoStream = New System.Security.Cryptography.CryptoStream(fsOutput, _
                cspRijndael.CreateEncryptor(bytKey, bytIV), _
                System.Security.Cryptography.CryptoStreamMode.Write)
                While lngBytesProcessed < lngFileLength
                    intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096)
                    csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                    lngBytesProcessed = lngBytesProcessed + CLng(intBytesInCurrentBlock)
                End While
                csCryptoStream.Close()

            Case CryptoAction.ActionDecrypt
                csCryptoStream = New System.Security.Cryptography.CryptoStream(fsOutput, _
                cspRijndael.CreateDecryptor(bytKey, bytIV), _
                System.Security.Cryptography.CryptoStreamMode.Write)
                While lngBytesProcessed < lngFileLength
                    intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096)
                    csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                    lngBytesProcessed = lngBytesProcessed + CLng(intBytesInCurrentBlock)
                End While
                csCryptoStream.Close()
        End Select
        fsInput.Close()
        fsOutput.Close()
    End Sub


End Class
