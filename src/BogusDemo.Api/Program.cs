using BogusDemo.Api.Endpoints;
using BogusDemo.Api.Middlewares;
using BogusDemo.Application.Behaviors;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var constr = builder.Configuration.GetConnectionString("Constr");
builder.Services.AddSqlServer<BogusDemoContext>(constr);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<CreateDepartmentCommand>();
    cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseExceptionHandler();

app.MapPopulateFakeDataEndpoint();

app.MapCreateDepartmentEndpoint();
app.MapChangeDepartmentNameEndpoint();
app.MapCreateRoomEndpoint();
app.MapChangeRoomEndpoint();
app.MapDeleteRoomEndpoint();
app.MapDeleteDepartmentEndpoint();
app.MapGetDepartmentsEndpoint();

app.Run();