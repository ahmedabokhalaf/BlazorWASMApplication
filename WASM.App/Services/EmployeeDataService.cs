using System.Text;
using System.Text.Json;
using WASMLibrary.Models;

namespace WASM.App.Services
{
    public class EmployeeDataService : IDataService<Employee>
    {
        private readonly HttpClient httpClient;

        public EmployeeDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task CreateAsync(Employee entity)
        {
            var empObject = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("/Employees/", empObject);
        }

        public async Task DeleteAsync(int id)
        {
            await httpClient.DeleteAsync($"/Employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(
                await httpClient.GetStreamAsync("/Employees"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await JsonSerializer.DeserializeAsync<Employee>(
                await httpClient.GetStreamAsync($"/Employees/{id}"), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateAsync(Employee entity)
        {
            var empObj = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
            await httpClient.PutAsync($"/Employees/{entity.Id}", empObj);
        }
    }
}
