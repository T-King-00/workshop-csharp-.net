using ShoppingCart.Db;

var builder = WebApplication.CreateBuilder(args);



//services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ShoppingCartDb>();




var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();



app.Run();