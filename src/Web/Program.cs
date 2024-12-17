using Finnegans.Application;
using Finnegans.Application.PedidoDeVenta.Queries.GetPedidoVenta;
using Finnegans.Infrastructure;
using Finnegans.Infrastructure.Data;
using Finnegans.Web;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyVaultIfConfigured(builder.Configuration);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();

builder.Services.AddValidatorsFromAssemblyContaining<GetPedidoVentaQueryValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() && Environment.GetEnvironmentVariable("SkipDbInit") != "True")
{
    await app.InitialiseDatabaseAsync();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseSwaggerUi(settings =>
//{
//settings.Path = "/api";
//settings.DocumentPath = "/api/specification.json";
//});


app.UseSwaggerUi();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapFallbackToFile("index.html");

app.UseExceptionHandler(options => { });

app.Map("/", () => Results.Redirect("/api"));

app.MapEndpoints();

app.Run();

public partial class Program { }
