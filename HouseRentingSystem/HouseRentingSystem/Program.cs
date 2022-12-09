using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HouseRentingSystem.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration["MySQLDatabase:ConnectionString"];

var serverVersion = new MySqlServerVersion(new Version(5, 7, 39));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString,serverVersion);
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:RequireConfirmedAccount");
        options.SignIn.RequireConfirmedEmail = builder.Configuration.GetValue<bool>("Identity:RequireConfirmedEmail");
        options.SignIn.RequireConfirmedPhoneNumber = builder.Configuration.GetValue<bool>("Identity:RequireConfirmedPhoneNumber");
        options.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:RequireDigit");
        options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:RequireNonAlphanumeric");
        options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:RequiredLength");
        
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Identity-related pages (Login, Register, etc) are loaded through Razor Pages (Areas -> Identity -> Pages)
app.MapRazorPages();

app.Run();