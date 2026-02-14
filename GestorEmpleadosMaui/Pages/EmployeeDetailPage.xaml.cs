using GestorEmpleadosMaui.PagesModels;

namespace GestorEmpleadosMaui.Pages;

public partial class EmployeeDetailPage : ContentPage
{
	public EmployeeDetailPage(EmployeeDetailPageModel employeeDetailPageModel)
	{
		BindingContext = employeeDetailPageModel;
		InitializeComponent();
	}
}