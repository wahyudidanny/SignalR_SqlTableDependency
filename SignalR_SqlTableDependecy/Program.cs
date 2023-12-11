using SignalR_SqlTableDependecy;
using SignalR_SqlTableDependecy.Hubs;
using SignalR_SqlTableDependecy.SubscribeTableDependecies;
using SignalR_SqlTableDependecy.Repositories;
using SignalR_SqlTableDependecy.MiddlewareExtentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

builder.RegisterDependency();
var app = builder.Build();
var connectionString = app.Configuration.GetConnectionString("DefaultConnection")??"NotConnected";

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

app.MapHub<DashboardHub>("/dashboardHub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.useSqlTableDependency<SubscribeProductTableDependecy>(connectionString);
app.useSqlTableDependency<SubscribeSaleTableDependecy>(connectionString);
app.useSqlTableDependency<SubscribeCustomerTableDependecy>(connectionString);
app.Run();
