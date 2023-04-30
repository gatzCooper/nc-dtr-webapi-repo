using api.businesslayer;
using api.common.Interface;
using api.common.model;
using api.dataaccess;
using api.dataaccess.entityframework.data;
using api.dataaccess.entityframework.model;
using api.dataaccess.entityframework.profileMapping;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddTransient<IUserBusinessLayer, UserBusinessLayer>()
    .AddTransient<IUserDataAccess, UserDataAccess>()
    .AddTransient<IAttendanceBusinessLayer, AttendanceBusinessLayer>()
    .AddTransient<IAttendanceDataAccess, AttendanceDataAccess>();

//Add Automapper
builder.Services.AddSingleton(new MapperConfiguration(cfg =>
{
    cfg.CreateMap<TblUser, User>();
    cfg.CreateMap<TblAttendance, Attendance>();
  
}).CreateMapper());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

// Services
builder.Services.AddDbContext<FaceAttendanceDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection")));

var corsPolicy = "CorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, builder =>
    {
        builder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials();
    });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
