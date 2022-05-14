using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TciketDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TciketDBContext") ?? throw new InvalidOperationException("Connection string 'TciketDBContext' not found.")));

//SQLite and SQL Server for DataBase Connection:
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<TciketDBContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("TciketDBContext")));
}
else
{
    builder.Services.AddDbContext<TciketDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionTicketDBContext")));
}
// Add services to the container.
builder.Services.AddControllersWithViews();

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
