using GestorEmpleadosMaui.PagesModels;

namespace GestorEmpleadosMaui.Pages;

public partial class DepartmentPage : ContentPage
{
	public DepartmentPage(DepartmentPageModel departmentPageModel)
	{
		BindingContext = departmentPageModel;
		InitializeComponent();
	}
}