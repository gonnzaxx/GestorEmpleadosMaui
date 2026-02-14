using GestorEmpleadosMaui.PagesModels;

namespace GestorEmpleadosMaui.Pages;

public partial class AddEmployeePage : ContentPage
{
	public AddEmployeePage(AddEmployeePageModel addEmployeePageModel)
	{
		BindingContext = addEmployeePageModel;
		InitializeComponent();
	}
}