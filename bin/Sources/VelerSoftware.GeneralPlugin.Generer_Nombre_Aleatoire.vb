Partial Public Class VelerSoftware_GeneralPlugin

    Shared Function RandomNumber(ByVal Min As Single, ByVal Max As Single, ByVal NbrDec As Boolean) As Single
        Microsoft.VisualBasic.Randomize()
        Dim Nbr As Single = (Microsoft.VisualBasic.Rnd() * (Max - Min)) + Min
        If Not NbrDec Then Nbr = System.Math.Round(Nbr)
        Return Nbr
    End Function

End Class
