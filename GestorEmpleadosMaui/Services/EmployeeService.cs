using GestorEmpleadosMaui.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace GestorEmpleadosMaui.Services;

public class EmployeeService : IService<Employee>
{

    HttpClient client = new();
    private JsonSerializerOptions _serializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };
    private string baseUri = "http://localhost:8000/employees/";
    public void Add(Employee item)
    {
        try
        {
            string json = JsonSerializer.Serialize(item, _serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync(baseUri, content).Result;
            response.EnsureSuccessStatusCode();

        }
        catch (Exception ex)
        {
            throw new Exception("Error al añadir el empleado: " + ex.Message);
        }
    }

    public void Delete(int id)
    {
        try
        {
            var response = client.DeleteAsync(baseUri + id).Result;
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar el empleado: " + ex.Message);
        }
    }

    public Employee Get(int id)
    {
        return client.GetFromJsonAsync<Employee>(baseUri + id, _serializerOptions).Result;
    }

    public List<Employee> GetAll()
    {
        return client.GetFromJsonAsync<List<Employee>>(baseUri, _serializerOptions).Result;
    }

    public void Update(Employee item)
    {
        try
        {
            string json = JsonSerializer.Serialize(item, _serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PatchAsync(baseUri + item.Id, content).Result;
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar el empleado: " + ex.Message);
        }
    }
}
