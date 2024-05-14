using Microsoft.Azure.Cosmos;
using Starting_Project.Configuration;
using Starting_Project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add Cosmos DB service
builder.Services.AddSingleton(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var cosmosDbSettings = configuration.GetSection("CosmosDbSettings").Get<CosmosDbSettings>();
    var cosmosClientOptions = new CosmosClientOptions
    {
        SerializerOptions = new CosmosSerializationOptions
        {
            PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
        }
    };
    return new CosmosClient(cosmosDbSettings.EndpointUri, cosmosDbSettings.PrimaryKey, cosmosClientOptions);
});

// Add your other services, repositories, etc.
builder.Services.AddScoped<IEmployer, EmployerService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
