using Microsoft.AspNetCore.Components;
using WASMLibrary.Models;

namespace WASM.App.Pages
{
    public partial class EmployeeDetails
    {
        [Parameter]
        public int EmpId { get; set; }
        public Employee Employee { get; set; }

        List<Employee> Employees;
        List<Country> Countries;

        protected override Task OnInitializedAsync()
        {
            Employees = new List<Employee>
            {
                new Employee
                {
                    CountryId = 1,
                    MaritalStatus = MaritalStatus.Single,
                    BirthDate = new DateTime(1989, 3, 11),
                    Email = "basma@test.com",
                    Id = 1,
                    FirstName = "Basma",
                    LastName = "Hussien",
                    Gender = Gender.Female,
                    PhoneNumber = 01000101010,
                    Comment = "Hello there....",
                    ExitDate = null,
                    JoinedDate = new DateTime(2008, 3, 1)
                },
                new Employee
                {
                    CountryId = 2,
                    MaritalStatus = MaritalStatus.Married,
                    BirthDate = new DateTime(1989, 3, 11),
                    Email = "ahmed@test.com",
                    Id = 2,
                    FirstName = "Ahmed",
                    LastName = "Hussien",
                    Gender = Gender.Male,
                    PhoneNumber = 01000101010,
                    Comment = "Hello there222....",
                    ExitDate = null,
                    JoinedDate = new DateTime(2009, 7, 1)
                }
            };
            Countries = new List<Country>
            {
                new Country {Id = 1, Name = "Egypt"},
                new Country {Id = 2, Name = "USA"},
                new Country {Id = 3, Name = "Japan"},
                new Country {Id = 4, Name = "France"},
                new Country {Id = 5, Name = "Brazil"}
            };
            Employee = Employees.FirstOrDefault(e => e.Id == EmpId);
            return base.OnInitializedAsync();
        }
    }
}
