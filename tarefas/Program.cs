using Microsoft.EntityFrameworkCore;
using Services.Models.AppSettings;
using Services.Models.ExternalApisSettings;
using Services.Services;
using Services.Services.Interfaces;
using tarefas.Corp.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddOptions<ExternalApisSettings>()
    .Bind(builder.Configuration.GetSection("ExternalApiSettings"));

builder.Services.AddOptions<SigningSettings>()
    .Bind(builder.Configuration.GetSection("SigningConfigurations"));

builder.Services.AddScoped<IChoreService, ChoreService>();
builder.Services.AddScoped<ISessionService, SessionService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MyPolicy", policy =>
    {
        policy.RequireAssertion(context => true);
    });
});

builder.Services.AddDbContext<CorpContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Corp")!));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder
           .WithOrigins("http://localhost:3000")
           .SetIsOriginAllowedToAllowWildcardSubdomains()
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials());
});

var app = builder.Build();

app.UseCors();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
