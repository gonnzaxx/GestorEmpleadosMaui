using GestorEmpleadosMaui.PagesModels;

namespace GestorEmpleadosMaui.Pages;

public partial class EmployeePage : ContentPage
{
	public EmployeePage(EmployeePageModel employeePageModel)
	{
		BindingContext = employeePageModel;
		InitializeComponent();
	}
}