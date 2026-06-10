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

        if (droga.Estoque < venda.Quantidade)
        {
            return BadRequest("Quantidade insuficiente em estoque! Disponível: " + droga.Estoque);
        }

        venda.ValorTotal = droga.Preco * venda.Quantidade;
        droga.Estoque -= venda.Quantidade;
        consumidor.Divida += venda.ValorTotal;

        _AppDbContext.SELLS.Add(venda);
        await _AppDbContext.SaveChangesAsync();

        return Ok("Venda realizada com sucesso!");
    }

    [HttpGet]
    public IActionResult Getall()
    {
        var vendas = _AppDbContext.SELLS
            .Include(v => v.Consumidor)
            .Include(v => v.Droga)
            .ToList();

        return Ok(vendas);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var venda = _AppDbContext.SELLS
            .Include(v => v.Droga)
            .Include(v => v.Consumidor)
            .FirstOrDefault(v => v.Id == id);

        if (venda == null)
        {
            return NotFound("Registro não encontrado!");
        }

        return Ok(venda);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVenda(int id, [FromBody] Venda vendaAtualizada)
    {
        var vendaExistente = await _AppDbContext.SELLS.FindAsync(id);
        if (vendaExistente == null)
        {
            return NotFound("Venda não encontrada!");
        }

        _AppDbContext.Entry(vendaExistente).CurrentValues.SetValues(vendaAtualizada);
        await _AppDbContext.SaveChangesAsync();
        return StatusCode(201, vendaExistente);

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        var venda = _AppDbContext.SELLS.Find(id);

        if (venda == null)
        {
            return NotFound("Venda não encontrada!");
        }

        _AppDbContext.SELLS.Remove(venda);
        _AppDbContext.SaveChanges();
        return NoContent();
    }
}
