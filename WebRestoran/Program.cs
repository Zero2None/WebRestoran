using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebRestoran.Data;
using WebRestoran.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Register the generic repository for DI
builder.Services.AddScoped(typeof(IRepo<>), typeof(Repository<>));

// Register other dependencies
builder.Services.AddScoped<IRepo<Food>, Repository<Food>>();
builder.Services.AddScoped<IRepo<Ingredient>, Repository<Ingredient>>();
builder.Services.AddScoped<IRepo<Category>, Repository<Category>>();
builder.Services.AddScoped<IRepo<FoodIngredient>, Repository<FoodIngredient>>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)  //promjena iz IdentityUser to ApplicationUser
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // session expires after 20 minutes of inactivity
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();   
app.UseSession();   //enable session state
app.UseAuthorization(); //enable authorization

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Ingredient}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
