using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorEmpleadosMaui.Models;
using GestorEmpleadosMaui.Services;
using System.Collections.ObjectModel;

namespace GestorEmpleadosMaui.PagesModels;

public partial class AddEmployeePageModel : ObservableObject
{
    private readonly IService<Employee> _employeeService;
    private readonly IService<Department> _departmentService;


    [ObservableProperty]
    private ObservableCollection<Department> departments;


    [ObservableProperty]
    private ObservableCollection<Employee> employees;

    [ObservableProperty]
    private Employee? employee;

    public AddEmployeePageModel(IService<Employee> employeeService, IService<Department> departmentService)
    {
        _employeeService = employeeService;
        _departmentService = departmentService;

        Employees = new ObservableCollection<Employee>(_employeeService.GetAll());
        Departments = new ObservableCollection<Department>(_departmentService.GetAll());

        Employee = new Employee();

    }

    [RelayCommand]
    private async Task AddEmployee()
    {
        if(Employee == null || string.IsNullOrWhiteSpace(Employee.Name))
        {
            return;
        }

        if (Employee.Department != null)
        {
            Employee.DepartmentId = Employee.Department.Id;    
        }

        Employee.Department = null;

        _employeeService.Add(Employee);
        Employees.Add(Employee);

        await Shell.Current.GoToAsync("//EmployeePage");

        await Shell.Current.DisplayAlertAsync("Información", "Empleado creado", "Aceptar");

    }


    [RelayCommand]
    private async Task Cancel()
    {
        await Shell.Current.GoToAsync("//EmployeePage");
    }
}
