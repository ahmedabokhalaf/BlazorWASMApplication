using AutoMapper;
using WASM.API.DTOs;
using WASMLibrary.Models;

namespace WASM.API.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDto, Employee>().ReverseMap();
        }
    }
}
