using ChatAll.Application.Interfaces;
using ChatAll.Domain.Entities;
using ChatAll.Infraestructure.DbData;
using ChatAll.Infraestructure.Services;
using ChatAll.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);


// Cors configuration
builder.Services.AddCors(options =>
{

    options.AddPolicy(name: MyAllowSpecificOrigins,
                        policy =>
                        {

                            policy.WithOrigins("http://localhost:5173", "http://localhost:5173/auth/register");
                            policy.AllowAnyMethod();
                            policy.AllowAnyHeader();
                            policy.AllowCredentials();


                        });

});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure entity framework with Sql Server
builder.Services.AddDbContext<ChatDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();

// Configure email service
builder.Services.Configure<Email>(
    builder.Configuration.GetSection("Email"));

builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();
    
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
