using System.Text.Json;
using WASMLibrary.Models;

namespace WASM.App.Services
{
    public class CountryDataService : IDataService<Country>
    {
        private readonly HttpClient httpClient;

        public CountryDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task CreateAsync(Country entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
                (await httpClient.GetStreamAsync("/Countries"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await JsonSerializer.DeserializeAsync<Country>
                (await httpClient.GetStreamAsync($"/Employees/{id}"), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public Task UpdateAsync(Country entity)
        {
            throw new NotImplementedException();
        }
    }
}
