using Details;
using Details.Data;
using Details.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<Populate>();

builder.Services.AddDbContext<PersonManagerDbContext>(opions => opions.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
if (args.Length == 1 && args[0].ToLower() == "populatedb")
    PopulateDb(app);

void PopulateDb(IHost app)
{
    if(app == null)
    {
        Console.WriteLine("App paramater is null");
        return;
    }


    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    if(scopedFactory == null)
    {
        Console.WriteLine("Scope Factory is null");
        return;
    }
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Populate>();
        if(service == null)
        {
            Console.WriteLine("Populate data service is null");
            return;
        }
        service.PopulateData();

    }
}



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
