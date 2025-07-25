using EmployeeApp.Infrastructure.Extensions;
using System.Reflection;
using MediatR;
using System.Reflection;
using EmployeeApp.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(EmployeeApp.Application.AssemblyReference).Assembly));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // For dev only!
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();
app.UseCors("AllowAll");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddleware<ExceptionHandlingMiddleware>();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
