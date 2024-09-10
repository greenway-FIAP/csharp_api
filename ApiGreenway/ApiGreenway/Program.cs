using ApiGreenway.Data;
using ApiGreenway.Repository;
using ApiGreenway.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<dbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IBadgeRepository, BadgeRepository>();
builder.Services.AddScoped<IBadgeLevelRepository, BadgeLevelRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyRepresentativeRepository, CompanyRepresentativeRepository>();
builder.Services.AddScoped<IImprovementMeasurementRepository, ImprovementMeasurementRepository>();
builder.Services.AddScoped<IMeasurementProcessStepRepository, MeasurementProcessStepRepository>();
builder.Services.AddScoped<IMeasurementRepository, MeasurementRepository>();
builder.Services.AddScoped<IMeasurementTypeRepository, MeasurementTypeRepository>();
builder.Services.AddScoped<IProcessBadgeRepository, ProcessBadgeRepository>();
builder.Services.AddScoped<IProcessRepository, ProcessRepository>();
builder.Services.AddScoped<IProcessResourceRepository, ProcessResourceRepository>();
builder.Services.AddScoped<IProcessStepRepository, ProcessStepRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
builder.Services.AddScoped<IResourceTypeRepository, ResourceTypeRepository>();
builder.Services.AddScoped<ISectorRepository, SectorRepository>();
builder.Services.AddScoped<IStepRepository, StepRepository>();
builder.Services.AddScoped<ISustainableGoalRepository, SustainableGoalRepository>();
builder.Services.AddScoped<ISustainableImprovementActionsRepository, SustainableImprovementActionsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api da Plataforma Greenway de Sustentabilidade",
        Version = "v1",
        Description = "Api da Plataforma Greenway de Sustentabilidade",
        Contact = new OpenApiContact
        {
            Name = "Greenway",
            Email = "technosfiap@gmail.com",
            Url = new Uri("https://www.greenway.com.br")
        }
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

app.MapControllers();

app.Run();
