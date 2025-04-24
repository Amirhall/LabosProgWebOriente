using Microsoft.EntityFrameworkCore;
using S08_Labo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<S08EmployesContext>(
    options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("EmployesBD"));
        options.UseLazyLoadingProxies();
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Artistes}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
