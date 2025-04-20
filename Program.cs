using Lab05RQuispe.Models;
using Lab05RQuispe.Services;
using Lab05RQuispe.UnitOfWork;
using Lab05RQuispe.UnitOfWork.IUnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register services
builder.Services.AddScoped<IAsistenciaService, AsistenciaService>();
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IEvaluacioneService, EvaluacioneService>();
builder.Services.AddScoped<IMateriaService, MateriaService>();
builder.Services.AddScoped<IProfesoreService, ProfesoreService>();
builder.Services.AddScoped<IMatriculaService, MatriculaService>();

// Register the Swagger generator, defining one or more Swagger documents
builder.Services.AddSwaggerGen();

// Add DbContext with connection string from appsettings.json
builder.Services.AddDbContext<Lab05Context>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 41))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
});

app.Run();