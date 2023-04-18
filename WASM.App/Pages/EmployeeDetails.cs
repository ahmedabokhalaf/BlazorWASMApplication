using Microsoft.AspNetCore.Components;
using WASM.App.Services;
using WASMLibrary.Models;

namespace WASM.App.Pages
{
    public partial class EmployeeDetails
    {
        [Inject]
        public IDataService<Employee> DataService { get; set; }
        [Parameter]
        public int EmpId { get; set; }
        public Employee Employee { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Employee = await DataService.GetByIdAsync(EmpId);
        }
    }
}
