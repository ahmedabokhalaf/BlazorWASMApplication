using Microsoft.AspNetCore.Components;
using WASM.App.Services;
using WASMLibrary.Models;

namespace WASM.App.Pages
{
    public partial class EditEmployee
    {
        [Parameter]
        public int EmpId { get; set; }
        [Inject]
        public IDataService<Employee> EmployeeDataService { get; set; }
        [Inject]
        public IDataService<Country> CountryDataService { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public Employee Employee { get; set; }
        public bool Saved = false;
        public string Status = string.Empty;
        public string Message = string.Empty;
        public EditEmployee(IDataService<Employee> employeeDataService, IDataService<Country> countryDataService)
        {
            EmployeeDataService = employeeDataService;
            CountryDataService = countryDataService;
        }
        protected async override Task OnInitializedAsync()
        {
            Countries = await CountryDataService.GetAllAsync();
            Employee = await EmployeeDataService.GetByIdAsync(EmpId);
            await EmployeeDataService.UpdateAsync(Employee);
        }

        protected async void HandelValidSubmit()
        {
            Saved = false;
            if (Employee.Id == 0)
            {
                await EmployeeDataService.CreateAsync(Employee);
                Status = "alert-success";
                Message = "New employee added successfuly ^_^";
                Saved = true;
            }
            else
            {
                await EmployeeDataService.UpdateAsync(Employee);
                Status = "alert-success";
                Message = "Employee updated successfuly ^_^";
                Saved = true;
            }
        }

        protected void HandelInvalidSubmit()
        {
            Status = "alert-danger";
            Message = "There are some error, please try again!";
        }
    }
}
