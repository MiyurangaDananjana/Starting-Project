using Microsoft.Azure.Cosmos;
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


        public void Create()
        {
            throw new System.NotImplementedException();
        }

        public void InsertEmployee(string employeeName)
        {
            throw new NotImplementedException();
        }

        public string Test(int testId)
        {
           return "Test";
        }

        public void  InsertEmployerAsync(Employer employer)
        {
            var container = _cosmosClient.GetContainer(_databaseId, _containerName);
            container.CreateItemAsync(employer);
        }

    }
}
