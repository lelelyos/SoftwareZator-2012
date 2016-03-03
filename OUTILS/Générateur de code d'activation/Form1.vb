Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim Nom, Prenom, Pays, CodePosal, Email, tmp2 As String
        Dim No_Facture, Edition As Integer
        Dim tmp1 As Double
        Dim CodeActivation As New System.Text.StringBuilder()

        With Me
            Nom = .TextBox_Nom.Text
            Prenom = .TextBox_Prenom.Text
            Pays = .TextBox_Pays.Text
            CodePosal = .TextBox_Code_Postal.Text
            Email = .TextBox_Email.Text
            No_Facture = .NumericUpDown_No_Facture.Value
            Edition = .ComboBox1.SelectedIndex

            CodeActivation.Clear()
            ' NOM
            For Each cha As Char In Nom.ToCharArray
                tmp1 = System.Math.Truncate(System.Math.Sqrt((System.Math.Pow((System.Math.Exp(System.Math.Sqrt(Microsoft.VisualBasic.Asc(cha))) / 35), 3) / 3874)))
                CodeActivation.Append(tmp1)
            Next

            ' PRENOM
            For Each cha As Char In Prenom.ToCharArray
                tmp1 = System.Math.Truncate(System.Math.Sqrt((System.Math.Pow((System.Math.Exp(System.Math.Sqrt(Microsoft.VisualBasic.Asc(cha))) / 12), 2) / 1256)))
                CodeActivation.Append(tmp1)
            Next

            ' EDITION :
            tmp1 = System.Math.Truncate(System.Math.Pow(Edition + 3, 5))
            CodeActivation.Append(tmp1)

            ' PAYS
            For Each cha As Char In Pays.ToCharArray
                tmp1 = System.Math.Truncate(System.Math.Sqrt((System.Math.Pow((System.Math.Exp(System.Math.Sqrt(Microsoft.VisualBasic.Asc(cha))) / 24), 2) / 3874)))
                CodeActivation.Append(tmp1)
            Next

            ' CODE POSTAL
            For Each cha As Char In CodePosal.ToCharArray
                tmp1 = System.Math.Truncate(System.Math.Sqrt((System.Math.Pow((System.Math.Exp(System.Math.Sqrt(Microsoft.VisualBasic.Asc(cha))) / 35), 3) / 5431)))
                CodeActivation.Append(tmp1)
            Next

            ' NUMERO DE FACTURE :
            tmp1 = System.Math.Pow(System.Math.Log(System.Math.Exp(No_Facture)), 2)
            CodeActivation.Append(tmp1)

            ' ADRESSE DE MESSAGERIE
            For Each cha As Char In Email.ToCharArray
                tmp1 = System.Math.Truncate(System.Math.Sqrt((System.Math.Pow((System.Math.Exp(System.Math.Sqrt(Microsoft.VisualBasic.Asc(cha))) / 47), 4) / 2346)))
                CodeActivation.Append(tmp1)
            Next

            ' FINITION
            tmp2 = CodeActivation.ToString().Replace("27", "A").Replace("76", "H").Replace("16", "B").Replace("09", "Z").Replace("65", "G").Replace("25", "U").Replace("35", "X").Replace("61", "J").Replace("94", "K").Replace("01", "E").Replace("46", "T").Replace("66", "Y").Replace("32", "O").Replace("57", "P").Replace("04", "F").Replace("10", "W").Replace("71", "M").Replace("83", "C").Replace("60", "N")

            .TextBox_Code.Text = tmp2
            .TextBox_Code.Refresh()
            .TextBox_Code.SelectAll()
            .TextBox_Code.Focus()
        End With

    End Sub

End Class
