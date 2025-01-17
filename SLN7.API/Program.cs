using Microsoft.EntityFrameworkCore;
using Serilog;
using SLN7.DATA.DBContext;
using SLN7.SERVICE.IService;
using SLN7.SERVICE.Service;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

//private readonly IConfiguration _configuration { get; set; }
//DI for DbContext
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout= TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly= true;
    options.Cookie.IsEssential= true;
});

//builder.Services.AddDbContext<ApplicationContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
//});
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File($"Logs/{Assembly.GetExecutingAssembly().GetName().Name}.log")
    //.WriteTo.Console()
    .CreateLogger();
builder.Logging.ClearProviders();
//builder.Logging.AddSerilog();
builder.Services.AddCors();

builder.Services.AddScoped<IUserDetails, UserDetails>();
builder.Services.AddScoped<ILeadSource, LeadSource>();
builder.Services.AddScoped<ICountryMaster, CountryMaster>();
builder.Services.AddScoped<IStateMaster, StateMaster>();
builder.Services.AddScoped<IUserRegistration, UserRegistration>();
builder.Services.AddScoped<IOtherValues, OtherValues>();
builder.Services.AddScoped<IUploadFile, UploadFile>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
// Add services to the container.
var app = builder.Build();

app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());
app.UseHttpsRedirection();
//

// Add services to the container.
string currentDate = DateTime.Now.AddDays(1).ToShortDateString().Replace('/', '-');
Console.WriteLine("Hello, World!");







//
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwaggerUI(); 
}
app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SLN7.API v1");
    });



// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseStaticFiles();
//
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

/*app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return forecast;
});*/

app.Run();

/*internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}*/
