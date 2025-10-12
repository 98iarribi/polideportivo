using Polideportivo.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/padel/ids", () =>
{
    var table = new PadelCourtTable();
    var ids = table.GetAllIds();
    return Results.Ok(ids);
})
.WithName("GetPadelTimeSlotIds");

app.Run();
