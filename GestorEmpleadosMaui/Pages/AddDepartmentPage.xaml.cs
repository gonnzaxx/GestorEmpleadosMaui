using GestorEmpleadosMaui.PagesModels;

namespace GestorEmpleadosMaui.Pages;

public partial class AddDepartmentPage : ContentPage
{
	public AddDepartmentPage(AddDepartmentPageModel addDepartmentPageModel)
	{
		BindingContext = addDepartmentPageModel;

        InitializeComponent();
	}
}