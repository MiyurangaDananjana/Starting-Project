namespace Starting_Project.Configuration
{
    public class CosmosDbSettings
    {
        public string? EndpointUri { get; set; }
        public string? PrimaryKey { get; set; }
        public string? DatabaseName { get; set; }
        public Dictionary<string, string> Containers { get; set; }
    }
}
