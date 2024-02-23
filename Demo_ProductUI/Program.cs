//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
using DataAccessLayer.Concrete;
using Demo_ProductUI.Models;
using EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Servislerin eklenmesi
builder.Services.AddControllersWithViews();

// Entity Framework Core için DbContext'in eklenmesi
builder.Services.AddDbContext<Context>();

// Identity'nin eklenmesi
builder.Services.AddIdentity<AppUser, AppRole>()
        .AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();

var app = builder.Build();

// HTTP istek pipeline'ýnýn yapýlandýrýlmasý
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
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
