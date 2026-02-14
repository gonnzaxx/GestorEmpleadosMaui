using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GestorEmpleadosMaui.PagesModels;

public partial class MainPageModel : ObservableObject
{
    [RelayCommand]
    private async Task NavigateToEmployees()
    {
        await Shell.Current.GoToAsync("//EmployeePage");
    }

    [RelayCommand]
    private async Task NavigateToDepartments()
    {
        await Shell.Current.GoToAsync("//DepartmentPage");
    }

    [RelayCommand]
    private async Task NavigateToGraph()
    {
        await Shell.Current.GoToAsync("//GraphPage");
    }
}
