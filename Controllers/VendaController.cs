using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BocaDeDrogasAPI.Models;
using BocaDeDrogasAPI.Data;

namespace BocaDeDrogasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendaController : ControllerBase
{
    private readonly AppDbContext _AppDbContext;
    public VendaController(AppDbContext appDbContext)
    {
        _AppDbContext = appDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> AddVenda([FromBody] Venda venda)
    {
        var droga = await _AppDbContext.DRUGS.FindAsync(venda.DrogaId);
        if (droga == null)
        {
            return NotFound("Droga não encontrada!");
        }
        var consumidor = await _AppDbContext.CUSTOMERS.FindAsync(venda.ConsumidorId);
        if (consumidor == null)
        {
            return NotFound("Consumidor não encontrado!");
        }
        if (droga.Quantidade < venda.Quantidade)
        {
            return BadRequest("Quantidade insuficiente em estoque! Disponível: " + droga.Quantidade);
        }
            venda.ValorTotal = droga.Preco * venda.Quantidade;
            droga.Quantidade -= venda.Quantidade;
            Consumidor.Divida += venda.ValorTotal;

            _context.SELLS.Add(venda);
            await _context.SaveChangesAsync();
        
        return Ok("Venda realizada com sucesso!");
    }
}