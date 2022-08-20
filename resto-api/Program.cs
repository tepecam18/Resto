using Microsoft.Extensions.Options;
using Realms;
using resto_api.Hubs;
using RestoWPF.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.CustomSchemaIds(type => $"{type.Name}_{System.Guid.NewGuid()}");
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "api/restocentr/{documentname}/swagger.json";
    });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/api/restocentr/v1/swagger.json", "My Resto API V1");
        c.RoutePrefix = "api/restocentr/v1";
    });

    //signlr
    //app.UseEndpoints(endPoint =>
    //{
    //    endPoint.MapHub<MyHub>("/myhub");
    //});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
