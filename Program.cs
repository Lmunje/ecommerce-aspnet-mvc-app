using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using onlineTickets.Data;
using onlineTickets.Data.Cart;
using onlineTickets.Data.Services;
using onlineTickets.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// lionel added services here Demo
//adding DbContext configuration

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString ("DefaultConnectionString")));

//Services Configuration
builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<IProducersService, ProducersService>();  
builder.Services.AddScoped<ICinemasService, CinemasService>();  
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));


//Authentication and authorization
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});


builder.Services.AddSession();

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
app.UseSession();

//Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Seed Database

AppDbInitializer.Seed(app);
AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();

app.Run();



 
