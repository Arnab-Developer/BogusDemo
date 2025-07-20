using Bogus;
using BogusDemo.Core;
using BogusDemo.Infra;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BogusDemo.Api.Endpoints;

internal static class PopulateFakeDataEndpoint
{
    public static void MapPopulateFakeDataEndpoint(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("populate-fake-data");

        group.MapPut("/insert", Insert);
        group.MapPut("/update", Update);
    }

    private static async Task<Results<Ok, NotFound>> Insert(
        BogusDemoContext context, CancellationToken ct)
    {
        var departmentFaker = new Faker<Department>()
            .RuleFor(d => d.Name, f => f.Random.String2(5));

        var departments = departmentFaker.Generate(100);

        foreach (var department in departments)
        {
            for (var i = 1; i <= 10; i++)
            {
                department.CreateRoom(new Faker().Random.String2(5));
            }
        }

        await context.Departments.AddRangeAsync(departments, ct);
        await context.SaveChangesAsync(ct);

        return TypedResults.Ok();
    }

    private static async Task<Results<Ok, NotFound>> Update(
        BogusDemoContext context, CancellationToken ct)
    {
        var departments = await context.Departments.Include(d => d.Rooms).ToListAsync(ct);

        foreach (var department in departments)
        {
            department.ChangeName(new Faker().Random.String2(5));

            for (var i = 1; i <= 10; i++)
            {
                department.CreateRoom(new Faker().Random.String2(5));
            }
        }

        await context.SaveChangesAsync(ct);
        return TypedResults.Ok();
    }
}