Public Class Designer
	Inherits System.ComponentModel.Design.DesignSurface

	Public Sub New()
		ServiceContainer.AddService(GetType(ViewService), New ViewService())

		Dim designerOptionService As New System.Windows.Forms.Design.WindowsFormsDesignerOptionService()
		designerOptionService.CompatibilityOptions.ShowGrid = False
		designerOptionService.CompatibilityOptions.SnapToGrid = False
		designerOptionService.CompatibilityOptions.UseOptimizedCodeGeneration = False
		designerOptionService.CompatibilityOptions.UseSmartTags = False
		designerOptionService.CompatibilityOptions.UseSnapLines = False
		designerOptionService.CompatibilityOptions.ObjectBoundSmartTagAutoShow = False
		designerOptionService.CompatibilityOptions.EnableInSituEditing = False

		ServiceContainer.AddService(GetType(System.ComponentModel.Design.DesignerOptionService), designerOptionService)
	End Sub

End Class


Public Class ViewService

	Private _view As System.Windows.Forms.Control = Nothing

	Public Property View() As System.Windows.Forms.Control
		Get
			Return _view
		End Get
		Set(ByVal value As System.Windows.Forms.Control)
			_view = value
		End Set
	End Property

End Class
