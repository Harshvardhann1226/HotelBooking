using HotelBooking.Repository.DataContext;
using HotelBooking.Repository.Extension;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// A property naming policy, or null to leave property names unchanged.
builder.Services.AddControllersWithViews()
.AddJsonOptions(options =>
{

    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
//AddDbContext
builder.Services.AddDbContext<ApplicationdbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn"));
});

//Add UnitofWorkService
builder.Services.AddRepositoryServices();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
