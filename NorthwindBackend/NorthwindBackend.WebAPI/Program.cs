using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TokenOptions = Core.Utilities.Security.JWT.TokenOptions;
using Core.Utilities.Security.Encyption;
using Autofac;
using NorthwindBackend.Business.DependencyResolvers.Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Utilities.IoC;
using Core.Extensions;
using Core.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

var containerBuilder = new ContainerBuilder();
var provider = builder.Services.BuildServiceProvider();
var factory = provider.GetService<IServiceProviderFactory<ContainerBuilder>>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(
    options =>{
        options.AddPolicy("AllowOrign", builder =>{
            builder.WithOrigins("https://localhost:7061");
        });
    });


// builder.Services.AddAuthentication();//jwtBearerDefaults
TokenOptions tokenOptions = new TokenOptions();
ConfigurationManager configurationManager = new ConfigurationManager();
configurationManager.SetBasePath(Directory.GetCurrentDirectory());
configurationManager.AddJsonFile("appsettings.json");
tokenOptions.Audience = configurationManager.GetConnectionString("Audience");
tokenOptions.Issuer = configurationManager.GetConnectionString("Issuer");
tokenOptions.AccessTokenExpiration = Convert.ToInt32(configurationManager.GetConnectionString("AccessTokenExpiration"));
tokenOptions.SecurityKey = configurationManager.GetConnectionString("SecurityKey");

//Console.WriteLine(configurationManager.GetConnectionString("Audience"));


builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

var app = builder.Build();

//AdoNetUserOperationClaimDal s = new AdoNetUserOperationClaimDal();
//List<UserOperationClaim> operationClaims = (List<UserOperationClaim>)s.GetAll();
//foreach (UserOperationClaim operationClaim in operationClaims)
//{
//    Console.WriteLine(operationClaim.Id + "Id");
//}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseCors(
    builder =>{
        builder.WithOrigins("https://localhost:7061").AllowAnyHeader();
    });

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
