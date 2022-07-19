using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using help_desk.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HelpDeskContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("HelpDeskContext") ?? throw new InvalidOperationException("Connection string 'HelpDeskContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
//SQLite for Dev and SQL Server for prod
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<HelpDeskContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("HelpDeskContext")));
}
else
{
    builder.Services.AddDbContext<HelpDeskContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionHelpDeskContext")));
}

var app = builder.Build();


// Data Base Initializer
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<HelpDeskContext>();
    //Creates a new empty DB
    context.Database.EnsureCreated();

    //DB is filled with SeedData. Whenever the DB needs to be updated with new fields
    //just write on terminal dotnet ef database drop, and rerun the program
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
