using DataLayer.Content;
using LearningWeb_Core.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();


#region Db Context

var configuration = builder.Configuration;
builder.Services.AddDbContext<SiteContext>(options =>
{
    //options.UseSqlServer(configuration["ConnectionStrings:EfCore"]);
    options.UseSqlServer(configuration.GetConnectionString("Learning_Site"));
});

#endregion

#region Ioc


builder.Services.AddTransient<IUserServices, UserServices>();

#endregion
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
