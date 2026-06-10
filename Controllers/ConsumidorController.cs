using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BocaDeDrogasAPI.Models;
using BocaDeDrogasAPI.Data;

namespace BocaDeDrogasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsumidorController : ControllerBase
{
    private readonly AppDbContext _AppDbContext;

    public ConsumidorController(AppDbContext appDbContext)
    {
        _AppDbContext = appDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> AddConsumidor(Consumidor consumidor)
    {
        _AppDbContext.CUSTOMERS.Add(consumidor);
        await _AppDbContext.SaveChangesAsync();
        return Ok(consumidor);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Consumidor>>> GetConsumidores()
    {
        var consumidores = await _AppDbContext.CUSTOMERS.ToListAsync();
        return Ok(consumidores);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Consumidor>> GetConsumidorById(int id)
    {
        var consumidor = await _AppDbContext.CUSTOMERS.FindAsync(id);
        if (consumidor == null)
        {
            return NotFound("Consumidor não encontrado!");
        }
        return Ok(consumidor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateConsumidor(int id, [FromBody] Consumidor ConsumidorAtualizado)
    {
        var consumidorExistente = await _AppDbContext.CUSTOMERS.FindAsync(id);
        if (consumidorExistente == null)
        {
            return NotFound("Consumidor não encontrado!");
        }

        _AppDbContext.Entry(consumidorExistente).CurrentValues.SetValues(ConsumidorAtualizado);
        await _AppDbContext.SaveChangesAsync();
        return StatusCode(201, consumidorExistente);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConsumidor(int id)
    {
        var consumidor = await _AppDbContext.CUSTOMERS.FindAsync(id);
        if (consumidor == null)
        {
            return NotFound("Consumidor não encontrado!");
        }

        _AppDbContext.CUSTOMERS.Remove(consumidor);

        await _AppDbContext.SaveChangesAsync();

        return Ok("personagem deletado com sucesso!");
    }
}
