using Starting_Project.Models.Entities;

namespace Starting_Project.Services
{
    public interface IEmployer
    {
        void Create();

        void InsertEmployee(string employeeName);

        string Test(int testId);

        void InsertEmployerAsync(Employer employer);
    }
}
