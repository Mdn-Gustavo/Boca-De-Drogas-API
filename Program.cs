using BocaDeDrogasAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// isso vai fazer o get das vendas n entrar em loop infinito de EF (consumidor => venda => consumidor => venda .....)
// mudanca mandatoria de refinamento ademais de json GET para Estilo DTO
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=boca.db");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", () => "Boca de Drogas API");
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
