
using resto_api.Core;
using resto_api.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.CustomSchemaIds(type => $"{type.Name}_{System.Guid.NewGuid()}");
//});

builder.Services.AddSignalR();

builder.Services.AddSingleton<ILog, Log>();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed(origin => true)
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger(c =>
    //{
    //    c.RouteTemplate = "api/restocentr/{documentname}/swagger.json";
    //});
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/api/restocentr/v1/swagger.json", "My Resto API V1");
    //    c.RoutePrefix = "api/restocentr/v1";
    //});

    app.UseCors();

    //app.UseRouting();

    //signlr
    app.MapHub<MyHub>("/myhub");
    app.MapHub<MyLocalHub>("/mylocalhub");
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
