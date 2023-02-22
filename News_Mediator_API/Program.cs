using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using News_Mediator_API.Authorization;
using News_Mediator_API.Configuration;
using News_Mediator_API.Handlers.NewsHandlers;
using News_Mediator_API.Helpers;
using News_Mediator_API.Repository.Interfaces;
using News_Mediator_API.Repository.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    var services = builder.Services;
    var env = builder.Environment;


    //builder.Services.AddDbContext<NewsApiContext>(opt =>
    //opt.UseSqlServer("News_System"));
    builder.Services.AddDbContext<NewsApiContext>(options =>
                options.UseSqlServer("Server=DESKTOP-NEJRS4J;Database=NewsApiCF;Encrypt=False; Trusted_Connection=True;"));


    builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
    services.AddCors();
    services.AddControllers().AddJsonOptions(x =>
    {
        // serialize enums as strings in api responses (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddSwaggerGen(option =>
    {
        option.SwaggerDoc("v1", new OpenApiInfo { Title = "NEWS API", Version = "PRO" });
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
    });
    builder.Services.AddScoped<INewsRepository, NewsRepository>();
    builder.Services.AddScoped<IJwtUtils, JwtUtils>();
    builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
    builder.Services.AddMediatR(typeof(RegisterRepository));
    builder.Services.AddMediatR(typeof(GetAllHandler).Assembly);
    builder.Services.AddScoped<IBookmarkRepository, BookmarkRepository>();
    builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddScoped(typeof(IIdentityService), typeof(IdentityService));
    builder.Services.AddAutoMapper(typeof(Program).Assembly);

}



var app = builder.Build();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    //app.UseMiddleware<ErrorHandlerMiddleware>();

    //// custom jwt auth middleware
    //app.UseMiddleware<JwtMiddleware>();

    //app.MapControllers();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlerMiddleware>();

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
