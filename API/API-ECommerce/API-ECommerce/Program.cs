using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;

var builder = WebApplication.CreateBuilder(args); //nuca mexer nesta linha, ela deve ficar sempre no comeco da program.cs

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

// O.NET vai criar os objetos  (Injecao de dependencia)
//existem 3 opcoes de configurar essas injecao:
//1- AddTransient - O C# cria uma instancia nova, toda vez que um metodo e chamado, esta forma e a mais usual
//2- AddScoped - 0 C# cria uma instancia nova, toda vez que criar um Controller, esta funcao faz em poucos caso, pois pode dar conflito
//3- AddSingleton - O C# cria uma classe generica para a aplicacao inteira, nao usar este
//4- AddDbContext -> e uma versao do AddScoped, essa versao vai fazer com que os comando sql aparecam no console
builder.Services.AddDbContext<EcommerceContext>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();



var app = builder.Build(); // essa linhas constroi a aplicacao, nunca remover ou mexer nela
//App para usar o swagger
app.UseSwagger();
//Para carregar a interface do swagger
app.UseSwaggerUI();

app.MapControllers();

app.Run(); //essa sempre deve ser a ultima linha do program.cs