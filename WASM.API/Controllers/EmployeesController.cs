using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WASM.API.Data;
using WASM.API.DTOs;
using WASM.API.Helpers;
using WASMLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WASM.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public EmployeesController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET: <EmployeesController>
        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return context.Employees.Include("Country").ToList();
        }

        // GET <EmployeesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return context.Employees.Include("Country").FirstOrDefault(i => i.Id == id);
        }

        // POST <EmployeesController>
        [HttpPost]
        public void Post([FromBody] EmployeeDto dto)
        {
            var emp = mapper.Map<Employee>(dto);
            context.Employees.Add(emp);
            context.SaveChanges();
        }

        // PUT <EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeDto dto)
        {
            var emp = context.Employees.Include("Country").FirstOrDefault(e => e.Id == id);
            if(emp!=null)
            {
                mapper.Map(emp, dto);
                context.Employees.Update(emp);
                context.SaveChanges();
            }           
        }

        // DELETE <EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var emp = context.Employees.FirstOrDefault(e => e.Id == id);
            context.Employees.Remove(emp);
            context.SaveChanges();
        }
    }
}
