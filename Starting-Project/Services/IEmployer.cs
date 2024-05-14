using Starting_Project.Models.DTOs;
using Starting_Project.Models.Entities;

namespace Starting_Project.Services
{
    public interface IEmployer
    {
       

        void InsertEmployerAsync(Employer employer);

        Task<IEnumerable<EmployerDTO>> GetEmployeeDetails();
    }
}
