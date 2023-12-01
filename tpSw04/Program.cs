using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using tpSw04.Data;
using tpSw04.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<CarroContext>(opt =>
     opt.UseSqlite(builder.Configuration.GetConnectionString("TP04Context") ?? throw new InvalidOperationException("Connection string 'TP04Context' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{

    endpoints.MapControllers();
    endpoints.MapRazorPages();

    // Rota para a página de listagem (index)
    endpoints.MapControllerRoute(
        name: "carrosIndex",
        pattern: "Carros",
        defaults: new { controller = "Carros", action = "Index" });

    // Rota para a página de detalhes
    endpoints.MapControllerRoute(
        name: "carrosDetails",
        pattern: "Carros/{id}",
        defaults: new { controller = "Carros", action = "Details" });

    // Rota para a página de criação (create)
    endpoints.MapControllerRoute(
        name: "carrosCreate",
        pattern: "Carros/Create",
        defaults: new { controller = "Carros", action = "Create" });

    // Rota para a página de edição (edit)
    endpoints.MapControllerRoute(
        name: "carrosEdit",
        pattern: "Carros/Edit/{id?}",
        defaults: new { controller = "Carros", action = "Edit" });

    // Rota para a página de exclusão (delete)
    endpoints.MapControllerRoute(
        name: "carrosDelete",
        pattern: "Carros/Delete/{id?}",
        defaults: new { controller = "Carros", action = "Delete" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
