using GestorEmpleadosMaui.PagesModels;

namespace GestorEmpleadosMaui.Pages;

public partial class DepartmentDetailPage : ContentPage
{
	public DepartmentDetailPage(DepartmentDetailPageModel departmentDetailPageModel)
	{
		BindingContext = departmentDetailPageModel;
		InitializeComponent();
	}
}