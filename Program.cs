using Microsoft.EntityFrameworkCore;
using StudentDetail;
using StudentDetail.Models;
using StudentDetail.Repository;
using StudentDetail.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//enabled the CORS
builder.Services.AddCors(option =>
{
    option.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
}
);

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDbContext<AngularAssignmentDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDB"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);//update the values in tables
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
