using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WASM.App;
using WASM.App.Services;
using WASMLibrary.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient<IDataService<Employee>, EmployeeDataService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7241");
});
builder.Services.AddHttpClient<IDataService<Country>, CountryDataService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7241");
});
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7241/Employees") }); //with HttpClient

await builder.Build().RunAsync();
