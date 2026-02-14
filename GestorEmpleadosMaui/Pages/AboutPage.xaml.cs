using GestorEmpleadosMaui.PagesModels;

namespace GestorEmpleadosMaui.Pages;

public partial class AboutPage : ContentPage
{
	public AboutPage(AboutPageModel aboutPageModel)
	{
		BindingContext = aboutPageModel;
		InitializeComponent();
	}
}