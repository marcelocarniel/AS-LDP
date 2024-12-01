using Microsoft.AspNetCore.Mvc;
using GerenciamentoAPI.Data;
using GerenciamentoAPI.Models;

namespace GerenciamentoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Pedidos.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            return pedido != null ? Ok(pedido) : NotFound();
        }

        [HttpPost]
        public IActionResult Create(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pedido pedido)
        {
            if (id != pedido.Id) return BadRequest();
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido == null) return NotFound();
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
