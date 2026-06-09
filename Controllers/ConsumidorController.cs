using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BocaDeDrogasAPI.Controllers;
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumidorController : ControllerBase
    {
        private readonly AppDbContext _AppDbContext;

        public ConsumidorController(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        // GET: api/consumidor
        [HttpGet]
        public ActionResult<IEnumerable<Consumidor>> GetConsumidores()
        {
            return _AppDbContext  .Consumidores.ToList();
        }

        // GET: api/consumidor/{id}
        [HttpGet("{id}")]
        public ActionResult<Consumidor> GetConsumidor(int id)
        {
            var consumidor = _AppDbContext.Consumidores.Find(id);
            if (consumidor == null)
            {
                return NotFound();
            }
            return consumidor;
        }

        // POST: api/consumidor
        [HttpPost]
        public ActionResult<Consumidor> CreateConsumidor(Consumidor consumidor)
        {
            _AppDbContext.Consumidores.Add(consumidor);
            _AppDbContext.SaveChanges();
            return CreatedAtAction(nameof(GetConsumidor), new { id = consumidor.Id }, consumidor);
        }
    }
}