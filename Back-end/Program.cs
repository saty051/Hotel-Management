using AutoMapper;
using HotelManagementApplication.DAL;
using HotelManagementApplication.Mapping;
using HotelManagementApplication.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();
//builder.Logging.AddDebug();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Log/log.txt", retainedFileCountLimit: 10, rollingInterval: RollingInterval.Minute)
    .CreateLogger();

//builder.Host.UseSerilog();
builder.Logging.AddSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HotelDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotelAppDBConnection"));
});

builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
//builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();  
//builder.Services.AddTransient<IHotelRepository, HotelRepository>();
//builder.Services.AddTransient<IReservationRepository, ReservationRepository>();
//builder.Services.AddTransient<IRoomRepository, RoomRepository>();
builder.Services.AddScoped(typeof(IHotelAppRepository<>), typeof(HotelAppRepository<>));


//builder.Services.AddCors(options => options.AddPolicy("MyTestCORS", policy =>
// {
// Allow only few origins
//policy.WithOrigins("http://localhost:4200");
//    // Allow All origins
//    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//}));

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });

    options.AddPolicy("AllowAllOrigin", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });

    options.AddPolicy("AllowOnlyLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
    options.AddPolicy("AllowOnlyGoogle", policy =>
    {
        policy.WithOrigins("http://google.com", "http://gmail.com", "http://drive.google.com").AllowAnyHeader().AllowAnyMethod();
    });
    options.AddPolicy("AllowOnlyMicrosoft", policy =>
    {
        policy.WithOrigins("http://outlook.com", "http://microsoft.com", "http://onedrive.microsoft.com").AllowAnyHeader().AllowAnyMethod();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseCors("AllowAllOrigin");

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("api/testingendpoint",
        context => context.Response.WriteAsync("Test Response"))
        .RequireCors("AllowOnlyLocalhost");

    endpoints.MapControllers()
             .RequireCors("AllowAllOrigin");

    endpoints.MapGet("api/testendpoint2",
        context => context.Response.WriteAsync(builder.Configuration.GetValue<string>("JWTSecret")));
});

app.Run();
