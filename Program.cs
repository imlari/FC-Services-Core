using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(options => options
    .AllowAnyOrigin() // Adicione aqui o endereço do seu aplicativo
    .AllowAnyHeader()
    .AllowAnyMethod()
);

//Endpoint Criação do Chamado
app.MapPost("/savechamado", (Chamado chamado) =>{
   ChamadoRepository.Add(product); 
});


app.MapGet("/getchamado/{code}", ([FromRoute] string code) => {
    var chamado = ChamadoRepository.GetBy(code);
    return chamado;
});


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

public class AberturaChamado {

    public static List<Chamado> Chamados { get; set; }

    public static void Add(Chamado chamado) {
        if(Chamados == null)
            Chamados == new List<Chamado>();

        Chamados.Add(chamado);
    }

    public AberturaChamado GetBy(string code){
        return Chamados.First(p => p.Code == code);

    }
}

