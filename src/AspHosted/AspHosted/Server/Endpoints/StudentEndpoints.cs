using Microsoft.EntityFrameworkCore;
using AspHosted.Server.Data;
using AspHosted.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace AspHosted.Server.Endpoints;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Student").WithTags(nameof(Student));

        group.MapGet("/", async (AspHostedServerContext db) =>
        {
            return await db.Student.ToListAsync();
        })
        .WithName("GetAllStudents")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Student>, NotFound>> (int id, AspHostedServerContext db) =>
        {
            return await db.Student.FindAsync(id)
                is Student model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetStudentById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<NotFound, NoContent>> (int id, Student student, AspHostedServerContext db) =>
        {
            var foundModel = await db.Student.FindAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }

            db.Update(student);
            await db.SaveChangesAsync();

            return TypedResults.NoContent();
        })
        .WithName("UpdateStudent")
        .WithOpenApi();

        group.MapPost("/", async (Student student, AspHostedServerContext db) =>
        {
            db.Student.Add(student);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Student/{student.Id}", student);
        })
        .WithName("CreateStudent")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok<Student>, NotFound>> (int id, AspHostedServerContext db) =>
        {
            if (await db.Student.FindAsync(id) is Student student)
            {
                db.Student.Remove(student);
                await db.SaveChangesAsync();
                return TypedResults.Ok(student);
            }

            return TypedResults.NotFound();
        })
        .WithName("DeleteStudent")
        .WithOpenApi();
    }
}
