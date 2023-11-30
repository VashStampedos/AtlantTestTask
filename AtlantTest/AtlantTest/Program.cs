using AtlantTest.DB;
using AtlantTest.Domain.Services.Context;
using AtlantTest.Domain.Services.DetailService;
using AtlantTest.Domain.Services.StoreKeeper;
using AtlantTest.Middleware;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All);

}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StoreApplicationContext>(options =>
{
    options.UseSqlServer(connection);
});

builder.Services.AddCors(options => options.AddPolicy("AtlantApi", policy =>
{
    policy.WithOrigins("http://localhost:4202").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
}));


builder.Services.AddTransient<IStoreKeeperService, StoreKeeperService>();
builder.Services.AddTransient<IDetailService, DetailService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseCors("AtlantApi");
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
