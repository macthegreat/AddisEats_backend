using AddisEats.Api.Services.MenuItemServices;
using AddisEats.Api.Services.OrderServices;
using AddisEats.Api.Services.RestaurantServices;
using AddisEats.Api.Configurations;
using AddisEats.Api.Services.UserServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async(context,next) =>
{
   Console.WriteLine("the request is coming in");

   next(context);

   Console.WriteLine("requst is going out"); 
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("Frontend");

app.MapControllers();


app.Run();


