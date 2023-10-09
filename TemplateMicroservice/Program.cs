using FluentValidation;
using MediatR;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TemplateMicroservice.BLL;
using TemplateMicroservice.Core.Filters;
using TemplateMicroservice.Core.Infrastructure.MediatR;
using TemplateMicroservice.DAL;

var builder = WebApplication.CreateBuilder(args);

var applicationAssembly = Assembly.Load("TemplateMicroservice.BLL");

//Add MVC with filter 
builder.Services.AddControllers(options => 
    options.Filters.Add(typeof(CustomExceptionFilterAttribute))
).AddNewtonsoftJson();

//Validators registration
builder.Services.AddValidatorsFromAssembly(applicationAssembly);

// Add AutoMapper
builder.Services.AddAutoMapper(new Assembly[] { 
    applicationAssembly, 
});

// Add MediatR
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(applicationAssembly);
});
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

// Add DbContext ()
builder.Services.AddAppDbContextService(builder.Configuration.GetConnectionString("MainConnection"));

// Add HttpAccessor
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

//Add Swagger/OpenAPI
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Person API",
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddBusinessLogicServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
