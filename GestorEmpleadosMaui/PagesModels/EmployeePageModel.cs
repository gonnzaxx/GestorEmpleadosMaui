using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorEmpleadosMaui.Models;
using GestorEmpleadosMaui.Services;
using System.Collections.ObjectModel;

namespace GestorEmpleadosMaui.PagesModels;

public partial class EmployeePageModel : ObservableObject
{

    private readonly IService<Employee> _employeeService;

    [ObservableProperty]
    private ObservableCollection<Employee> employees;

    [ObservableProperty]
    private Employee selectedEmployee;

    public EmployeePageModel(IService<Employee> employeeService)
    {
        _employeeService = employeeService;
        Employees = new ObservableCollection<Employee>(_employeeService.GetAll());
        Refresh();
    }

    

    [RelayCommand]
    private async Task ShowDetail()
    {
        
        if (SelectedEmployee != null)
        {
            await Shell.Current.GoToAsync("EmployeeDetail", new ShellNavigationQueryParameters { { "Employee", SelectedEmployee } });

            SelectedEmployee = null;
        }
    }

    [RelayCommand]
    private async Task AddEmployee()
    {
        await Shell.Current.GoToAsync("AddEmployee");
    }

    [RelayCommand]
    private void Refresh()
    {
        try
        {
            Employees = new ObservableCollection<Employee>(_employeeService.GetAll());
        }
        catch (Exception ex)
        {
            throw new Exception("Error al cargar los empleados: " + ex.Message);
        }
    }
}
