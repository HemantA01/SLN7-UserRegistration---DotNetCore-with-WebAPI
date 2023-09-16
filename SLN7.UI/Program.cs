using Microsoft.EntityFrameworkCore;
using SLN7.DATA.DBContext;
using SLN7.UI.Interface;
using SLN7.UI.Service;
var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddRazorPages()
//    .AddRazorRuntimeCompilation();
var mvcbuilder = builder.Services.AddRazorPages();
if (builder.Environment.IsDevelopment())
{
    mvcbuilder.AddRazorRuntimeCompilation();    
}
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));
builder.Services.AddScoped<IUserDetails, UserDetails>();
builder.Services.AddScoped<ILeadSource, LeadSource>();
builder.Services.AddScoped<ICountryMaster, CountryMaster>();
builder.Services.AddScoped<IStateMaster, StateMaster>();
builder.Services.AddScoped<IUserRegistration, UserRegistration>();
builder.Services.AddScoped<IUploadFile, UploadFile>();

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
    //pattern: "{controller=Home}/{action=LoginIndexTest}/{id?}"); 
    pattern: "{controller=UserDetails}/{action=VerifyUser}/{id?}");

app.Run();
