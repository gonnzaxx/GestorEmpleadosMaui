using GestorEmpleadosMaui.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace GestorEmpleadosMaui.Services
{
    public class DepartmentService : IService<Department>
    {

        HttpClient client = new();
        private JsonSerializerOptions _serializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };
        private string baseUri = "http://localhost:8000/departments/";
        public void Add(Department item)
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
                throw new Exception("Error al añadir el departamento: " + ex.Message);
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
                throw new Exception("Error al eliminar el departamento: " + ex.Message);
            }
        }

        public Department Get(int id)
        {
            return client.GetFromJsonAsync<Department>(baseUri + id, _serializerOptions).Result;
        }

        public List<Department> GetAll()
        {
            return client.GetFromJsonAsync<List<Department>>(baseUri, _serializerOptions).Result;
        }

        public void Update(Department item)
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
                throw new Exception("Error al actualizar el departamento: " + ex.Message);
            }
        }
    }
}
