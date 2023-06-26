using ObserverPattern;
using ObserverPattern.Models;
using Microsoft.OpenApi.Models;
using ObserverPattern.DataAccess;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://localhost:56660")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
builder.Services.AddScoped<ILunchDataAccess, LunchDataAccess>();
builder.Services.AddScoped<IInternDataAccess, InternDataAccess>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Observer Pattern", Version = "v1" });
});

WebApplication app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider provider = scope.ServiceProvider;
}

app.UseCors();
app.UseRouting();
app.UseSwagger();
app.UseSwagger();
app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();