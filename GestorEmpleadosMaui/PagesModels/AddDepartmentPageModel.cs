using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorEmpleadosMaui.Models;
using GestorEmpleadosMaui.Services;
namespace GestorEmpleadosMaui.PagesModels;

public partial class AddDepartmentPageModel : ObservableObject
{

    private readonly IService<Department> _departmentService;

    [ObservableProperty]
    private Department? department;


    public AddDepartmentPageModel(IService<Department> departmentService)
    {
        _departmentService = departmentService;

        Department = new Department();
    }


    [RelayCommand]
    private async Task AddDepartment()
    {

        if (Department == null || string.IsNullOrWhiteSpace(Department.Name))
        {
            return;
        }

        _departmentService.Add(Department);

        await Shell.Current.GoToAsync("//DepartmentPage");
        await Shell.Current.DisplayAlertAsync("Información", "Departamento creado", "Aceptar");
    }


        [RelayCommand]
    private async Task Cancel()
    {
        await Shell.Current.GoToAsync("//DepartmentPage");
    }
}
