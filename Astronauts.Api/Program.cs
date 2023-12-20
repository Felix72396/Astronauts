using Astronauts.Infraestructure.Extensions;
using Astronauts.Infraestructure.Filters;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;

// Add services to the container.

services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Add your frontend URL here
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
})
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddOptions(builder.Configuration);
services.AddDbContexts(builder.Configuration);
services.AddServices();
services.AddJwtAuthentications(builder.Configuration);
//services.AddSwagger($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");


services.AddMvc(options =>
{
    options.Filters.Add<ValidationFilter>();
})
.AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("../swagger/v1/swagger.json", "Astronaut API");

        //options.RoutePrefix = string.Empty;
    });
}

app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();




