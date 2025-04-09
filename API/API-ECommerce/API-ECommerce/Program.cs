var builder = WebApplication.CreateBuilder(args); //nunca apagar esta linhas, pois ela controe a aplicacao
var app = builder.Build();//nunca apagar esta linhas, pois ela controe a aplicacao

app.MapGet("/", () => "Hello World!"); 

app.Run(); //Nunca apagar esta linha, pois ela que exexuta a aplicacao
