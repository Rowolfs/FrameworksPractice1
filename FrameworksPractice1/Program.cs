using Microsoft.AspNetCore.Http.Json;
using FrameworksPractice1.Domain;
using FrameworksPractice1.Errors;
using FrameworksPractice1.Services;
using FrameworksPractice1.Middlewares;
using System.Text.Json.Serialization;





var builder = WebApplication.CreateBuilder(args);

// Настройка сериализации, чтобы ответы были компактнее
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddSingleton<ItemRepository, InMemoryItemRepository>();

var app = builder.Build();


app.UseMiddleware<RequestIdMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<TimingAndLogMiddleware>();

app.MapGet("/api/items/{id:guid}", (Guid id, ItemRepository repo) =>
{
    var item = repo.GetById(id);
    if (item == null)
    {
        throw new NotFoundException("Item not found");
    }
    return Results.Ok(item);

});


app.MapPost("/api/items", (HttpContext ctx, CreateItemRequest request, ItemRepository repo) =>
{
    if (string.IsNullOrWhiteSpace(request.Name))
        throw new ValidationException("Name is empty");

    if (request.Price < 0)
        throw new ValidationException("Price cant be negative");

    var created = repo.Create(request.Name.Trim(), request.Price);
    var location = $"/api/items/{created.Id}";
    ctx.Response.Headers.Location = location;

    return Results.Created(location, created);
});

app.Run();

public partial class Program { }
