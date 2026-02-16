# Gestor de Empleados y Departamentos Maui
> Aplicación multiplataforma desarrollada en .NET MAUI para la gestión de empleados y departamentos mediante una API REST desplegada con Docker.

![.NET MAUI](https://img.shields.io/badge/.NET-MAUI-purple?style=flat-square&logo=dotnet)
![Docker](https://img.shields.io/badge/Docker-Ready-blue?style=flat-square&logo=docker)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-Supported-blue?style=flat-square&logo=postgresql)
![SQLite](https://img.shields.io/badge/SQLite-Supported-lightgrey?style=flat-square&logo=sqlite)

---

## Preview de la aplicación

![Snapshot de la aplicación](snapshot.png)

---

## Características

- Listado de empleados y departamentos 
- Gestión de empleados y departamentos (CRUD BÁSICO)
- Alertas tras operaciones  

---

## Cosas a tener en cuenta
La aplicación no recarga los datos en caliente, por lo que cuando se añade, elimina o actualiza algo he puesto una alerta para que se vea.

Antes de ejecutar la aplicación, hay que ejecutar el contendor Docker para conectarse a la API. Para ello:

## Instalación
### Clonar repositorio
```
git clone https://github.com/gonnzaxx/APIGestorEmpleados.git
```

### Construir la imagen de Docker
En el directorio raíz de tu proyecto (donde se encuentra el archivo Dockerfile), ejecuta el siguiente comando para construir la imagen Docker:

```
docker build -t empleados_api .
```

### Ejecutar el contendor Docker
Utilizando SQLite: 
```
docker run -d -p 8000:8000 --name APIempleadosSQLite empleados_api
```

Utilizando PostgreSQL:
  En el caso de no tener PostgreSQL instalado, utilizar estos comandos para ejecutar el contenedor:

```
docker network create empleados-network
```
```
docker run -d --name APIempleados_postgres --network empleados-network -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=123456 -e POSTGRES_DB=empleados_db -p 5432:5432 postgres:15-alpine
```

```
docker run -d --name APIempleados --network empleados-network -p 8000:8000 -e DATABASE_URL="postgresql://postgres:123456@APIempleados_postgres:5432/empleados_db" empleados_api
```

## Uso

1. Ejecutar la API mediante Docker.  
2. Abrir el proyecto MAUI en Visual Studio.  
3. Ejecutar la aplicación.  
4. Gestionar empleados y departamentos desde la interfaz.


### Requisitos

- Visual Studio 2022 o superior  
- .NET 10 SDK  
- Docker Desktop

## Estructura del Proyecto

```
GestorEmpleadosMaui/
│
├── Properties/
├── Models/
│    ├── Employee.cs
│    └── Department.cs
│
├── Pages/
│    ├── AboutPage.xaml
│    ├── AddDepartmentPage.xaml
│    ├── AddEmployeePage.xaml
│    ├── DepartmentDetailPage.xaml
│    ├── DepartmentPage.xaml
│    ├── EmployeeDetailPage.xaml
│    ├── EmployeePage.xaml
│    ├── GraphPage.xaml
│    └── MainPage.xaml
│ 
├── PagesModels/
│    ├── AboutPageModel.xaml
│    ├── AddDepartmentPageModel.xaml
│    ├── AddEmployeePageModel.xaml
│    ├── DepartmentDetailPageModel.xaml
│    ├── DepartmentPageModel.xaml
│    ├── EmployeeDetailPageModel.xaml
│    ├── EmployeePageModel.xaml
│    ├── GraphPageModel.xaml
│    └── MainPageModel.xaml
│ 
├── Platforms/
│    ├── Android
│    ├── IOS
│    ├── MacCatalyst
│    └── Windows
│ 
├── Resources/
│    ├── AppIcon
│    ├── Fonts
│    ├── Raw
│    ├── Images
│    └── Styles
│ 
├── Services/
│    ├── DepartmentService.cs
│    ├── EmployeeService.cs
│    └── IService.cs
│ 
├── Templates/
│    ├── DepartmentCardTemplate.xaml
│    └── EmployeeCardTemplate.xaml
│ 
├── App.xaml/
├── AppShell.xaml
└── MauiProgram.cs
```

---

## Historial de versiones

### 1.0.0
- Versión inicial funcional  
- CRUD completo de empleados  
- CRUD completo de departamentos  
- Soporte SQLite y PostgreSQL  

---

## Autor

**Gonzalo Santiago Ariza**  
Proyecto académico – Desarrollo de Aplicaciones Multiplataforma  

Repositorio API:  
https://github.com/gonnzaxx/APIGestorEmpleados  

---

## Licencia

Proyecto académico sin fines comerciales.
