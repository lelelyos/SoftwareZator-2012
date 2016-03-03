''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class UIImageEditor
    Inherits System.Drawing.Design.UITypeEditor

    Public Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.Drawing.Design.UITypeEditorEditStyle
        Return Drawing.Design.UITypeEditorEditStyle.Modal
    End Function

    Public Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As System.IServiceProvider, ByVal value As Object) As Object
        Dim RESULTAT As System.Drawing.Image
        RESULTAT = Nothing

        Dim Frm As New Form_UIImageEditor
        If TypeOf value Is System.Drawing.Image Then
            Frm.IMG = value
        End If
        If Frm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            RESULTAT = Frm.IMG
        Else
            RESULTAT = value
        End If

        Return RESULTAT
    End Function

    Public Overrides Sub PaintValue(ByVal e As System.Drawing.Design.PaintValueEventArgs)
        MyBase.PaintValue(e)
        If Not e.Value Is Nothing Then e.Graphics.DrawImage(e.Value, e.Bounds)
    End Sub

    ' Indicates whether the UITypeEditor supports painting a 
    ' representation of a property's value.
    Public Overloads Overrides Function GetPaintValueSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function

End Class
