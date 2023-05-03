using api.businesslayer;
using api.common.Interface;
using api.common.model;
using api.dataaccess;
using api.dataaccess.entityframework.data;
using api.dataaccess.entityframework.model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;
using Org.BouncyCastle.Crypto.Utilities;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;


// Add services to the container.
builder.Services
    .AddScoped<IUserBusinessLayer, UserBusinessLayer>()
    .AddScoped<IUserDataAccess, UserDataAccess>()
    .AddScoped<IAttendanceBusinessLayer, AttendanceBusinessLayer>()
    .AddScoped<IAttendanceDataAccess, AttendanceDataAccess>()
    .AddScoped<IScheduleBusinessLayer, ScheduleBusinessLayer>()
    .AddScoped<IScheduleDataAccess, ScheduleDataAccess>()
    .AddScoped<ISubjectBusinessLayer, SubjectBusinessLayer>()
    .AddScoped<ISubjectDataAccess, SubjectDataAccess>()

    .AddSingleton<HttpClient>();



//Add Automapper
builder.Services.AddSingleton(new MapperConfiguration(cfg =>
{
    cfg.CreateMap<TblUser, User>().ReverseMap();
    cfg.CreateMap<TblAttendance, Attendance>().ReverseMap();
    cfg.CreateMap<TblSchedule, Schedule>().ReverseMap();
    cfg.CreateMap<TblSubject, Subject>().ReverseMap();
    cfg.CreateMap<TblUserOtp, UserOtp>().ReverseMap();

}).CreateMapper());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configuration
var configurationBuilder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json");

var configuration = configurationBuilder.Build();

// Services

var dbConnection = configuration["MySqlConnection"];

builder.Services.AddDbContext<FaceAttendanceDbContext>(options =>
    options.UseMySQL(dbConnection), ServiceLifetime.Scoped);

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

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseCors(corsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
