using Finnegans.Domain.Constants;
using Finnegans.Domain.Entities;
using Finnegans.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Finnegans.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        //await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            // Verificar si la base de datos está accesible antes de intentar migraciones
            if (await _context.Database.CanConnectAsync())
            {
                await _context.Database.MigrateAsync();
            }
            else
            {
                _logger.LogWarning("No se pudo conectar a la base de datos. Se omitió la migración.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Se produjo un error al inicializar la base de datos.");
            // No relances la excepción para que no rompa la ejecución
        }
    }


    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Verificar si la base de datos está accesible
        if (!await _context.Database.CanConnectAsync())
        {
            _logger.LogWarning("No se puede conectar a la base de datos. Se omite el seed de datos.");
            return;
        }

        // roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        // Default data
        if (!_context.TodoLists.Any())
        {
            _context.TodoLists.Add(new TodoList
            {
                Title = "Todo List",
                Items =
            {
                new TodoItem { Title = "Make a todo list 📃" },
                new TodoItem { Title = "Check off the first item ✅" },
                new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
            }
            });

            await _context.SaveChangesAsync();
        }
    }
}
