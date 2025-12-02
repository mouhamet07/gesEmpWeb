using gesEmpWeb.Data;
using gesEmpWeb.Services;
using gesEmpWeb.Services.Impl;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GesEmpDbContext>();
builder.Services.AddScoped<IDepartementService, DepartementService>();
builder.Services.AddScoped<IEmployeService, EmployeService>();
// Add services to the container.
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Departement}/{action=Index}/{id?}");

app.Run();
