using GestorEmpleadosMaui.PagesModels;

namespace GestorEmpleadosMaui.Pages;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage(MainPageModel mainPageModel)
    {
        BindingContext = mainPageModel;
        InitializeComponent();
    }
}
