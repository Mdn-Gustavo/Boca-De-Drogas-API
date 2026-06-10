using BocaDeDrogasAPI.Data;
using BocaDeDrogasAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BocaDeDrogasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrogaController : ControllerBase  
{
     private readonly AppDbContext _AppDbContext;

     public DrogaController(AppDbContext appdbContext)
     {
          _AppDbContext = appdbContext;
     }

     [HttpPost]
     public async Task<IActionResult> AddDroga(Droga drugs )
     {
          _AppDbContext.Drogas.Add(drugs);
          await  _AppDbContext.SaveChangesAsync();
          return Ok(drugs);
     }

     [HttpGet]
     public async Task<ActionResult<IEnumerable<Droga>>> GetDrogas()
     {
          var drugs = await _AppDbContext.Drogas.ToListAsync();
          return Ok(drugs);
     }

     [HttpGet("{id}")]
     public async Task<ActionResult<Droga>> GetDrogaById(int id)
     {
          var drugs = await _AppDbContext.Drogas.FindAsync(id);
          if (drugs == null)
          {
               return NotFound("Droga não encontrada!");
          }
          return Ok(drugs);
     }

     [HttpPut("{id}")]
     public async Task<IActionResult> UpdateDroga(int id, [FromBody] Droga drugsatualizada)
     {
          var drugsExistente = await _AppDbContext.Drogas.FindAsync(id);
          if (drugsExistente == null)
          {
               return NotFound("Droga não encontrada!");
          }
          
          _AppDbContext.Entry(drugsExistente).CurrentValues.SetValues(drugsatualizada);
          await _AppDbContext.SaveChangesAsync();
          return StatusCode(201, drugsExistente);
     }

     [HttpDelete("{id}")]
     public IActionResult DeleteDroga(int id)
     {
          var droga = _AppDbContext.Drogas.Find(id);

          if (droga == null)
          {
               return NotFound("Droga não encontrada!");
          }

          _AppDbContext.Drogas.Remove(droga);
          _AppDbContext.SaveChanges();
          return NoContent();
     }
}