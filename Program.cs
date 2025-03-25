using EventManagementAPI.Data;
using System.Text.Json.Serialization;
using EventManagementAPI.Repositories;
using EventManagementAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();


builder.Services.AddDbContext<EventManagementContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://localhost:7239")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IOrganizerRepository, OrganizerRepository>();
builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddScoped<ISponsorRepository, SponsorRepository>();

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IOrganizerService, OrganizerService>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<ISponsorService, SponsorService>();



var app = builder.Build();

app.UseCors("AllowFrontend");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
