using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MovieWebShop.Data;
using MovieWebShop.Interfaces;
using MovieWebShop.Models;
using MovieWebShop.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();

// Identity
//5 rows below is one way to do it
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("defaultconnection")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

// 4 rows below one way to do it
//builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//               .AddEntityFrameworkStores<AppDbContext>();

//For Sessions
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IMovieRepo, MovieRepo>();
builder.Services.AddScoped<IGenericRepo<Genre>, GenreRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IGenericRepo<ShoppingcartItems>, ShoppingCartItemRepo>();
builder.Services.AddScoped<ShoppingCart>(sc => ShoppingCart.GetCart(sc));
builder.Services.AddScoped<AppDbContext>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


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


// Identity
app.UseAuthentication();
//SampleData.Initialize(app); <---- CREATES SAMPLE ADMIN ON RUN TIME
//DummyData.Initialize(app.Services); <--- DOES NOT WORK
app.UseAuthorization();
// Identity


app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
