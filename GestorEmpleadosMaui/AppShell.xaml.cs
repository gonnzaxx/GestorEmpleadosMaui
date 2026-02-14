using GestorEmpleadosMaui.Pages;

namespace GestorEmpleadosMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        RegisterRoutes();
    }

    private void RegisterRoutes() { 

        Routing.RegisterRoute("EmployeeDetail", typeof(EmployeeDetailPage));
        Routing.RegisterRoute("AddEmployee", typeof(AddEmployeePage));

        Routing.RegisterRoute("DepartmentDetail", typeof(DepartmentDetailPage));
        Routing.RegisterRoute("AddDepartment", typeof(AddDepartmentPage));
    }
}
