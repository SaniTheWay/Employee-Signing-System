using Employee_Signing_System.Models.Entity;
using Employee_Signing_System.Repositories;
using Employee_Signing_System.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
//var provider = builder.Services.BuildServiceProvider();
//var configuration = provider.GetRequiredService<IConfiguration>();

// Add services to the container.
builder.Services.AddControllersWithViews();
string? connectionString = builder.Configuration.GetConnectionString("MyConn");
builder.Services.AddDbContext<EmployeeSigningSystemContext>(options => options.UseSqlServer(connectionString));

//For Identity Framework
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<EmployeeSigningSystemContext>();

//Repositories Registration
builder.Services.AddScoped<IUserDbRepository, UserDbRepository>();
builder.Services.AddScoped<IGuardDbRepository, GuardDbRepository>();

//Services Registration
builder.Services.AddScoped<IGuardService, GuardService>();
builder.Services.AddScoped<IUserService, UserService>();


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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
