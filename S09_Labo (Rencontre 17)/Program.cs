using Microsoft.EntityFrameworkCore;
using S09_Labo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<S09LaboContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("S09_Labo"));
});
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
        pattern: "{controller=Musique}/{action=Index}/{id?}"
);

app.MapRazorPages();

app.Run();
