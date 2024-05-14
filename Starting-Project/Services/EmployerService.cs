using Microsoft.Azure.Cosmos;
using Starting_Project.Models.DTOs;
using Starting_Project.Models.Entities;

namespace Starting_Project.Services
{
    public class EmployerService : IEmployer
    {

        private readonly CosmosClient _cosmosClient;
        private readonly string _containerName;
        private readonly string _databaseId;

        public EmployerService(CosmosClient cosmosClient, IConfiguration configuration)
        {
            _cosmosClient = cosmosClient;
            _containerName = configuration.GetValue<string>("CosmosDbSettings:Containers:ContainerEmployer");
            _databaseId = configuration.GetValue<string>("CosmosDbSettings:DatabaseName"); // Retrieve databaseId from configuration
        }

        public async Task<IEnumerable<EmployerDTO>> GetEmployeeDetails()
        {
            var container = _cosmosClient.GetContainer(_databaseId, _containerName);

            // Execute a SQL query to retrieve all items from the container
            var query = new QueryDefinition("SELECT * FROM c");
            var resultSet = container.GetItemQueryIterator<Employer>(query);

            var employeeDetails = new List<EmployerDTO>();
            while (resultSet.HasMoreResults)
            {
                var response = await resultSet.ReadNextAsync();
                foreach (var item in response)
                {
                    // Map Employer entity to EmployerDTO
                    var employerDTO = MapToDTO(item);
                    employeeDetails.Add(employerDTO);
                }
            }
            return employeeDetails;
        }

        private EmployerDTO MapToDTO(Employer employer)
        {
            return new EmployerDTO
            {
                FirstName = employer.FirstName,
                LastName = employer.LastName,
                Email = employer.Email,
                Nationality = employer.Nationality,
                CurrentResidence = employer.CurrentResidence,
                IdNumber = employer.IdNumber,
                DateOfBirth = employer.DateOfBirth,
                Gender = employer.Gender,
                question = new QuestionDTO
                {
                    Type = employer.question.Type
                }
            };
        }

        public void  InsertEmployerAsync(Employer employer)
        {
            var container = _cosmosClient.GetContainer(_databaseId, _containerName);
            container.CreateItemAsync(employer);
        }

    }
}
