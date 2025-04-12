using API_ECommerce.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddTransient<EcommerceContext, EcommerceContext>();

var app = builder.Build();
//App para usar o swagger
app.UseSwagger();
//Para carregar a interface do swagger
app.UseSwaggerUI();

app.MapControllers();

app.Run();