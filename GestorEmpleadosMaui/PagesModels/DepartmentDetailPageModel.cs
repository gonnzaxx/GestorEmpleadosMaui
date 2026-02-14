using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorEmpleadosMaui.Models;
using GestorEmpleadosMaui.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GestorEmpleadosMaui.PagesModels;

[QueryProperty(nameof(Department), "Department")]
public partial class DepartmentDetailPageModel : ObservableObject
{

    private readonly IService<Department> _departmentService;

    [ObservableProperty]
    private Department department;

    public DepartmentDetailPageModel(IService<Department> departmentService)
    {
        _departmentService = departmentService;
    }


    [RelayCommand]
    private async Task Update()
    {

        if (Department != null)
        {
            _departmentService.Update(Department);
            await Shell.Current.GoToAsync("//EmployeePage");
        }

        await Shell.Current.GoToAsync("//DepartmentPage");
        await Shell.Current.DisplayAlertAsync("Información", "Departamento actualizado", "Aceptar");
    }


    [RelayCommand]
    private async Task Delete()
    {

        if (Department != null)
        {
            _departmentService.Delete((int)Department.Id);
        }

        await Shell.Current.GoToAsync("//DepartmentPage");
        await Shell.Current.DisplayAlertAsync("Información", "Departamento eliminado", "Aceptar");
    }
}
