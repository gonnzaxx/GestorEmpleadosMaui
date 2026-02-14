using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorEmpleadosMaui.Models;
using GestorEmpleadosMaui.Services;
using System.Collections.ObjectModel;

namespace GestorEmpleadosMaui.PagesModels;

public partial class DepartmentPageModel : ObservableObject
{
    private readonly IService<Department> _departmentService;

    [ObservableProperty]
    private ObservableCollection<Department> departments;

    [ObservableProperty]
    private Department selectedDepartment;

    public DepartmentPageModel(IService<Department> departmentService)
    {
        _departmentService = departmentService;
        Departments = new ObservableCollection<Department>(_departmentService.GetAll());
        Refresh();
    }


    [RelayCommand]
    private async Task ShowDetail()
    {
        if (SelectedDepartment != null)
        {
            await Shell.Current.GoToAsync("DepartmentDetail", new ShellNavigationQueryParameters { { "Department", SelectedDepartment } });

            SelectedDepartment = null;
        }
    }

    [RelayCommand]
    private async Task AddDepartment()
    {
        await Shell.Current.GoToAsync("AddDepartment");
    }

    [RelayCommand]
    private void Refresh()
    {
        try
        {
            Departments = new ObservableCollection<Department>(_departmentService.GetAll());
        }
        catch (Exception ex)
        {
            throw new Exception("Error al cargar departamentos: " + ex.Message);
        }
    }
}
