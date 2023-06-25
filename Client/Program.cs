/*using Client.Repository.Data;
*/
using Client.Repository.Interface;
using Client.Repository;

var builder = WebApplication.CreateBuilder(args);
//Add Scope
/*builder.Services.AddScoped<HomeRepository>();
*/
// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddScoped(typeof(IRepository<,>), typeof(GeneralRepository<,>));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
