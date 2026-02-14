using CommunityToolkit.Maui;
using GestorEmpleadosMaui.Models;
using GestorEmpleadosMaui.Pages;
using GestorEmpleadosMaui.PagesModels;
using GestorEmpleadosMaui.Services;
using Microsoft.Extensions.Logging;

namespace GestorEmpleadosMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        //servicios
        builder.Services.AddTransient<IService<Employee>, EmployeeService>();
        builder.Services.AddTransient<IService<Department>, DepartmentService>();


        //pagemodels
        builder.Services.AddTransient<MainPageModel>();

        builder.Services.AddTransient<EmployeePageModel>();
        builder.Services.AddTransient<EmployeeDetailPageModel>();
        builder.Services.AddTransient<AddEmployeePageModel>();

        builder.Services.AddTransient<DepartmentPageModel>();
        builder.Services.AddTransient<DepartmentDetailPageModel>();
        builder.Services.AddTransient<AddDepartmentPageModel>();

        builder.Services.AddTransient<GraphPageModel>();

        builder.Services.AddTransient<AboutPageModel>();


        //pages
        builder.Services.AddTransient<MainPage>();

        builder.Services.AddTransient<EmployeePage>();
        builder.Services.AddTransient<EmployeeDetailPage>();
        builder.Services.AddTransient<AddEmployeePage>();

        builder.Services.AddTransient<DepartmentPage>();
        builder.Services.AddTransient<DepartmentDetailPage>();
        builder.Services.AddTransient<AddDepartmentPage>();

        builder.Services.AddTransient<GraphPage>();
        builder.Services.AddTransient<AboutPage>();

        

        return builder.Build();
    }
}
