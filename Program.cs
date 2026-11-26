using AddisEats.Api.Services.MenuItemServices;
using AddisEats.Api.Services.OrderServices;
using AddisEats.Api.Services.RestaurantServices;
using AddisEats.Api.Configurations;
using AddisEats.Api.Services.UserServices;
using AddisEats.Api.Services.AuthService;
using Microsoft.AspNetCore.Identity;
using AddisEats.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authorization;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    Options =>
    {
        Options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name ="Authorization",
            Type =SecuritySchemeType.Http,
            Scheme ="Bearer",
            BearerFormat="JWT",
            In=ParameterLocation.Header,
            Description =" enter your jwt token only with out Bearer prefix"
        });
        Options.AddSecurityRequirement(Document => new OpenApiSecurityRequirement
        {
            [new OpenApiSecuritySchemeReference("Bearer" ,Document )]= []
        });
    }
);

//


builder.Services.AddScoped<IMenuItemService, MenuitemService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();


//adding CORS policy configuration to allow requests from the frontend application
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
//jwt configuration
builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("Jwt")
);

builder.Services.AddAuthorization(Options =>
{
    Options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
});

//register my AuthService
builder.Services.AddScoped<AuthService>();
builder.Services.AddSingleton<IPasswordHasher<User> , PasswordHasher<User>>();
builder.Services.AddSingleton<DemoUserService>();

var jwt = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(Options =>
{
    Options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwt.Issuer,

        ValidateAudience = true,
        ValidAudience = jwt.Audience,

        ValidateLifetime = true,

        ClockSkew = TimeSpan.FromSeconds(30),

        ValidateIssuerSigningKey = true,

        IssuerSigningKey =new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(jwt.SigningKey)
        ) 
    };
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.Use(async(context,next) =>
// {
//    Console.WriteLine("the request is coming in");

//    next(context);

//    Console.WriteLine("requst is going out"); 
// });

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("Frontend");

app.MapControllers();


app.Run();


