using Ibrahim_MVC_Frist.Data;
using Ibrahim_MVC_Frist.Repository;
using Ibrahim_MVC_Frist.Repository.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();





var conectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseLazyLoadingProxies().
    UseSqlServer(conectionString));

builder.Services.AddScoped(typeof(IRepository<>),typeof (MainRepository<>));
//builder.Services.AddScoped<IRepoProduct, RepoProduct>();
//builder.Services.AddScoped<IRepoCategory, RepoCategory>();
//builder.Services.AddScoped<IRepoEmployee, RepoEmployee>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapControllers(); // API attrebute routing

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acoount}/{action=Login}/{id?}");

app.Run();
