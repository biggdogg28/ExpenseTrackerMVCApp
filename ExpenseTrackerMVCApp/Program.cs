using ExpenseTrackerMVCApp.DataContext;
using ExpenseTrackerMVCApp.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ExpenseTrackerDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddTransient<ExpenseTrackerDataContext, ExpenseTrackerDataContext>();
builder.Services.AddTransient<ExpenseCategoriesRepository, ExpenseCategoriesRepository>();
builder.Services.AddTransient<IncomeTypesRepository, IncomeTypesRepository>();
builder.Services.AddTransient<IncomeRepository, IncomeRepository>();
builder.Services.AddTransient<ExpensesRepository, ExpensesRepository>();
builder.Services.AddTransient<LocationsRepository, LocationsRepository>();
builder.Services.AddTransient<TotalsRepository, TotalsRepository>();

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
