using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
