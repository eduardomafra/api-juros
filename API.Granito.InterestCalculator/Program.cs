using API.Granito.Utilities.Calculator;
using API.Granito.Utilities.Helper;
using API.Granito.Utilities.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Granito - Calculador de juros",
        Description = "API desenvolvida para o processo seletivo da Granito Pagamentos.",
        Contact = new OpenApiContact
        {
            Name = "Eduardo Mafra",
            Url = new Uri("https://github.com/eduardomafra/")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddScoped<IInterestRateService, InterestRateService>();
builder.Services.AddScoped<IInterestCalculator, InterestCalculator>();

builder.Services.Configure<APISettingsModel>(builder.Configuration.GetSection("APISettings"));

builder.Services.AddOptions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
