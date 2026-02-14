using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorEmpleadosMaui.Models;
using GestorEmpleadosMaui.Services;
using System.Collections.ObjectModel;

namespace GestorEmpleadosMaui.PagesModels;

[QueryProperty(nameof(Employee), "Employee")]
public partial class EmployeeDetailPageModel : ObservableObject
{
    private readonly IService<Department> _departmentService;
    private readonly IService<Employee> _employeeService;


    [ObservableProperty]
    private Employee employee;

    [ObservableProperty]
    private ObservableCollection<Department> departments;

    [ObservableProperty]
    private Department? selectedDepartment;

    public EmployeeDetailPageModel(IService<Department> departmentService, IService<Employee> employeeService)
    {
        _departmentService = departmentService;
        _employeeService = employeeService;

        Departments = new ObservableCollection<Department>(_departmentService.GetAll());
    }

    [RelayCommand]
    private async Task Update()
    {

       if(Employee != null)
        {
            _employeeService.Update(Employee);
            await Shell.Current.GoToAsync("//EmployeePage");
            await Shell.Current.DisplayAlertAsync("Información", "Empleado actualizado", "Aceptar");
        }
    }


    [RelayCommand]
    private async Task Delete()
    {

        if (Employee != null)
        {
            _employeeService.Delete((int)Employee.Id);
        }

        await Shell.Current.GoToAsync("//EmployeePage");
        await Shell.Current.DisplayAlertAsync("Información", "Empleado eliminado", "Aceptar");
    }
}
