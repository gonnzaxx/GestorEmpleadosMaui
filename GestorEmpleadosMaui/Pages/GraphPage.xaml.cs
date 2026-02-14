using GestorEmpleadosMaui.PagesModels;

namespace GestorEmpleadosMaui.Pages;

public partial class GraphPage : ContentPage
{
	public GraphPage(GraphPageModel graphPageModel)
	{
		BindingContext = graphPageModel;
        InitializeComponent();
	}
}