using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PotifolioASB.API.Token;
using PotifolioASB.Domain.Entities;
using PotifolioASB.Infra.Interfaces;
using PotifolioASB.Infra.Repository;
using PotifolioASB.Repository.Context;
using PotifolioASB.Service.Interfaces;
using PotifolioASB.Service.Services;
using PotifolioASB.Service.ViewModels.Fluxo;
using PotifolioASB.Service.ViewModels.Ocorrencia;
using PotifolioASB.Service.ViewModels.Responsavel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Inserindo Autenticação
#region Jwt 
//var secretKey = builder.Configuration["Jwt:key"];

//builder.Services.AddAuthentication(x =>
//{

//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

//}).AddJwtBearer(x =>
//{
//    x.RequireHttpsMetadata = false;
//    x.SaveToken = true;
//    x.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
//        ValidateIssuer = false,
//        ValidateAudience = false
//    };
//});
#endregion

#region AutoMapper
var automapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<CreateFluxoViewModel, Fluxo>().ReverseMap();
    cfg.CreateMap<UpdateFluxoViewModel, Fluxo>().ReverseMap();

    cfg.CreateMap<CreateOcorrenciaViewModel, Ocorrencia>().ReverseMap();
    cfg.CreateMap<UpdateOcorrenciaViewModel, Ocorrencia>().ReverseMap();

    cfg.CreateMap<CreateResponsavelViewModel, Responsavel>().ReverseMap();
    cfg.CreateMap<UpdateResponsavelViewModel, Responsavel>().ReverseMap();
});

builder.Services.AddSingleton(automapperConfig.CreateMapper());
#endregion


builder.Services.AddDbContext<ManagerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ManagerAPISqlServer"));
});

#region InjecaoDependencia
    //Injeção de Dependencias
    builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();

    builder.Services.AddScoped<IFluxoService, FluxoService>();
    builder.Services.AddScoped<IFluxoRepository, FluxoRepository>();

    builder.Services.AddScoped<IOcorrenciaService, OcorrenciaService>();
    builder.Services.AddScoped<IOcorrenciaRepository, OcorrenciaRepository>();

    builder.Services.AddScoped<IResponsavelService, ResponsavelService>();
    builder.Services.AddScoped<IResponsavelRepository, ResponsavelRepository>();

#endregion



builder.Services.AddEndpointsApiExplorer();

#region Swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Manager API",
        Version = "v1",
        Description = "API construída por Anderson Barbosa.",
        Contact = new OpenApiContact
        {
            Name = "Anderson Barbosa",
            Email = "andersonbarbosadeveloper@gmail.com",
            Url = new Uri("https://github.com/AndersonSBarbosa")
        },
    });

    //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    In = ParameterLocation.Header,
    //    Description = "Por favor utilize Bearer <TOKEN>",
    //    Name = "Authorization",
    //    Type = SecuritySchemeType.ApiKey
    //});
    //c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    //            {
    //                new OpenApiSecurityScheme
    //                {
    //                    Reference = new OpenApiReference
    //                    {
    //                        Type = ReferenceType.SecurityScheme,
    //                        Id = "Bearer"
    //                    }
    //                },
    //                new string[] { }
    //            }
    //            });
});

#endregion

#region Hash

//var config = new Argon2Config
//{
//    Type = Argon2Type.DataIndependentAddressing,
//    Version = Argon2Version.Nineteen,
//    TimeCost = int.Parse(builder.Configuration["Hash:TimeCost"]),
//    MemoryCost = int.Parse(builder.Configuration["Hash:MemoryCost"]),
//    Lanes = int.Parse(builder.Configuration["Hash:Lanes"]),
//    Threads = Environment.ProcessorCount,
//    Salt = Encoding.UTF8.GetBytes(builder.Configuration["Hash:Salt"]),
//    HashLength = int.Parse(builder.Configuration["Hash:HashLength"])
//};

//builder.Services.AddArgon2IdHasher(config);

#endregion

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
