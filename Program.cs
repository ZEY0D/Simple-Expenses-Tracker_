using efinancee.Data;
using efinancee.Data.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
    // connecting to SQLITE server
var connectionstring = builder.Configuration.GetConnectionString("efinance");
builder.Services.AddSqlite<EfinanceeContext>(connectionstring);


// configure the service
        // IExpensesService = IserviceProvider ______ ExpensesService = Iservicollection
    builder.Services.AddScoped<IExpensesService,ExpensesService>();

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


// for user actions handeling
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
