using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PruebaAspNet.Data;
using PruebaAspNet.Interfaces;
using PruebaAspNet.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

void AddCustomDbContext<TContext>(string connectionString) where TContext : DbContext
{
    // El contexto está configurado para utilizar MySQL como proveedor de base de datos.
    builder.Services.AddDbContext<TContext>(options =>
        options.UseMySql(
            connectionString,
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
        )
    );
}

AddCustomDbContext<BaseContext>(builder.Configuration.GetConnectionString("MySqlConnection"));
// Registrar servicios.
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<TeacherService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<EnrollmentService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();

// Configurar controladores y opciones JSON.
builder.Services.AddControllers().AddJsonOptions(options =>
{

    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Configurar Swagger para la documentación de la API.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    // En el entorno de desarrollo, usar Swagger para la documentación de la API.
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestion Escuala API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
