using Microsoft.EntityFrameworkCore;
using SampleWebApplication.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. This is for Dependency Injection.
builder.Services.AddControllersWithViews();

// Setting up database as Dependency Injection
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Use routes request to next middleware.
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map maps the route from request to corresponding controller and its actions.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run terminates the request pipeline and sends the response to browser.
app.Run();
