using MicroRabbit.Banking.Data.Context;
using Microsoft.EntityFrameworkCore;
using MicroRabbit.Infra.IoC;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new() {
        Title = "Banking Microservice",
        Version = "v1"
    });
});

string? connectionString = builder.Configuration.GetConnectionString("BankingDbConnection");
builder.Services.AddSqlServer<BankingDbContext>(connectionString);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(ui =>
        ui.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Microservice"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();