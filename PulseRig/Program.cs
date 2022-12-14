using Microsoft.EntityFrameworkCore;
using PulseRig.BuissnesLayer;
using PulseRig.BuissnesLayer.Implementations;
using PulseRig.BuissnesLayer.Interfaces;
using PulseRig.DataLayer;
using PulseRig.PresentationLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EFDBContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
    npgsqlOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(5),
            errorCodesToAdd: null);
    }));

builder.Services.AddTransient<IStationRepository, EFStationRepository>();
builder.Services.AddTransient<IGroupRepository, EFGroupRepository>();
builder.Services.AddTransient<IEquipmentRepository, EFEquipmentRepository>();
builder.Services.AddScoped<DataManager>();
builder.Services.AddScoped<ServicesManager>();

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


using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var context = service.GetRequiredService<EFDBContext>();
    SampleData.InitData(context);
}

app.Run();
