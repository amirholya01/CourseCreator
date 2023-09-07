using CourseCreator.Core.Services;
using CourseCreator.Core.Services.Interfaces;
using CourseCreator.Core.Servieces.Interfaces;
using CourseCreator.Datalayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MySqlServerConnection");
builder.Services.AddDbContext<CourseCreatorContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddRazorPages();
#region Auyhentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/Login";
    options.LogoutPath = "/Logout";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(2);
});
#endregion

//IOC
#region IOC
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICourseService, CourseService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.MapRazorPages();

app.Run();
