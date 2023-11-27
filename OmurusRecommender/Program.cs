using MediatR;
using OmurusRecommender.Services.Implementations.Neo4jProvider;
using OmurusRecommender.Services.Interfaces.INeo4jProvider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<INeo4jProvider, Neo4jProvider>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var uri = configuration["NEO4JLocal:NEO4J_URI"];
    var username = configuration["NEO4JLocal:NEO4J_USERNAME"];
    var password = configuration["NEO4JLocal:NEO4J_PASSWORD"];

    return new Neo4jProvider(uri, username, password);
});


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
