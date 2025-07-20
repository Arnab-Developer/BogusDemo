using BogusDemo.Api.Endpoints;
using BogusDemo.Application.Commands;
using BogusDemo.Infra;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();

var constr = builder.Configuration.GetConnectionString("Constr");
builder.Services.AddSqlServer<BogusDemoContext>(constr);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<CreateDepartmentCommand>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapCreateDepartmentEndpoint();
app.MapChangeDepartmentNameEndpoint();
app.MapCreateRoomEndpoint();
app.MapChangeRoomEndpoint();

app.Run();