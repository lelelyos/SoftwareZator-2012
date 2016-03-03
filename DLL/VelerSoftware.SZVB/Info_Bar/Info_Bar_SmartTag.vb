''' *****************************************************************************
''' 
'''  © Veler Software 2012. All rights reserved.
'''  The current code and the associated software are the proprietary 
'''  information of Etienne Baudoux from Veler Software and are
'''  supplied subject to licence terms.
''' 
'''  www.velersoftware.com
''' *****************************************************************************

Public Class Info_Bar_SmartTag
    Inherits System.Windows.Forms.Design.ControlDesigner

    Private Mon_Info_Bar As Info_Bar
    Public Overloads Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
        If TypeOf component Is Info_Bar Then
            Mon_Info_Bar = CType(component, Info_Bar)
        End If
        MyBase.Initialize(component)
    End Sub

    Public Overloads Overrides ReadOnly Property ActionLists() As ComponentModel.Design.DesignerActionListCollection
        Get
            Dim content As ComponentModel.Design.DesignerActionListCollection = New ComponentModel.Design.DesignerActionListCollection()
            content.AddRange(MyBase.ActionLists)
            content.Add(New Info_Bar_ActionList(Mon_Info_Bar))
            Return content
        End Get
    End Property
End Class


Public Class Info_Bar_ActionList
	Inherits ComponentModel.Design.DesignerActionList

	Private Mon_Info_Bar As Info_Bar
	Public Sub New(ByVal monControl As Info_Bar)
		MyBase.New(monControl)
		Mon_Info_Bar = monControl
	End Sub

	Public Property Dock() As System.Windows.Forms.DockStyle
		Get
			Return Mon_Info_Bar.Dock
		End Get
		Set(ByVal value As System.Windows.Forms.DockStyle)
			If Mon_Info_Bar IsNot Nothing Then
				Dim pd As ComponentModel.PropertyDescriptor = ComponentModel.TypeDescriptor.GetProperties(Mon_Info_Bar)("Dock")
				If pd IsNot Nothing Then
					pd.SetValue(Mon_Info_Bar, value)
				End If
			End If
		End Set
	End Property

	Public Property BarStyle() As Info_Bar.Style
		Get
			Return Mon_Info_Bar.BarStyle
		End Get
		Set(ByVal value As Info_Bar.Style)
			If Mon_Info_Bar IsNot Nothing Then
				Dim pd As ComponentModel.PropertyDescriptor = ComponentModel.TypeDescriptor.GetProperties(Mon_Info_Bar)("BarStyle")
				If pd IsNot Nothing Then
					pd.SetValue(Mon_Info_Bar, value)
				End If
			End If
		End Set
	End Property

	Public Property BarText() As String
		Get
			Return Mon_Info_Bar.BarText
		End Get
		Set(ByVal value As String)
			If Mon_Info_Bar IsNot Nothing Then
				Dim pd As ComponentModel.PropertyDescriptor = ComponentModel.TypeDescriptor.GetProperties(Mon_Info_Bar)("BarText")
				If pd IsNot Nothing Then
					pd.SetValue(Mon_Info_Bar, value)
				End If
			End If
		End Set
	End Property

	Public Property ButtonText() As String
		Get
			Return Mon_Info_Bar.ButtonText
		End Get
		Set(ByVal value As String)
			If Mon_Info_Bar IsNot Nothing Then
				Dim pd As ComponentModel.PropertyDescriptor = ComponentModel.TypeDescriptor.GetProperties(Mon_Info_Bar)("ButtonText")
				If pd IsNot Nothing Then
					pd.SetValue(Mon_Info_Bar, value)
				End If
			End If
		End Set
	End Property

	Public Property Image() As Drawing.Image
		Get
			Return Mon_Info_Bar.Image
		End Get
		Set(ByVal value As Drawing.Image)
			If Mon_Info_Bar IsNot Nothing Then
				Dim pd As ComponentModel.PropertyDescriptor = ComponentModel.TypeDescriptor.GetProperties(Mon_Info_Bar)("Image")
				If pd IsNot Nothing Then
					pd.SetValue(Mon_Info_Bar, value)
				End If
			End If
		End Set
	End Property

	Public Sub SiteInternet()
		System.Diagnostics.Process.Start("http://www.velersoftware.fr.nf/")
	End Sub

	Public Overloads Overrides Function GetSortedActionItems() As ComponentModel.Design.DesignerActionItemCollection
		Dim actions As ComponentModel.Design.DesignerActionItemCollection = New ComponentModel.Design.DesignerActionItemCollection()

        With actions
            .Add(New ComponentModel.Design.DesignerActionHeaderItem("Propriétés de l'Info_Bar :", "Propriétés de l'Info_Bar"))
            .Add(New ComponentModel.Design.DesignerActionPropertyItem("BarStyle", "Style :", "Propriétés de l'Info_Bar"))
            .Add(New ComponentModel.Design.DesignerActionPropertyItem("BarText", "Texte :", "Propriétés de l'Info_Bar"))
            .Add(New ComponentModel.Design.DesignerActionPropertyItem("ButtonText", "Texte du bouton :", "Propriétés de l'Info_Bar"))
            .Add(New ComponentModel.Design.DesignerActionPropertyItem("Image", "Image :", "Propriétés de l'Info_Bar"))

            .Add(New ComponentModel.Design.DesignerActionHeaderItem("Propriétés standards :", "Propriétés standards"))
            .Add(New ComponentModel.Design.DesignerActionPropertyItem("Dock", "Dock :", "Propriétés standards"))

            .Add(New ComponentModel.Design.DesignerActionHeaderItem("Divers :", "Divers"))
            .Add(New ComponentModel.Design.DesignerActionMethodItem(Me, "SiteInternet", "www.velersoftware.fr.nf", "Divers", "Site internet de l'auteur"))
        End With

		Return actions
	End Function
End Class