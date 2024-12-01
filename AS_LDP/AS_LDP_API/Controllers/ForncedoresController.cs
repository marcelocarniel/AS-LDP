using Microsoft.AspNetCore.Mvc;
using GerenciamentoAPI.Data;
using GerenciamentoAPI.Models;

namespace GerenciamentoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FornecedoresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Fornecedores.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var fornecedor = _context.Fornecedores.Find(id);
            return fornecedor != null ? Ok(fornecedor) : NotFound();
        }

        [HttpPost]
        public IActionResult Create(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = fornecedor.Id }, fornecedor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Fornecedor fornecedor)
        {
            if (id != fornecedor.Id) return BadRequest();
            _context.Fornecedores.Update(fornecedor);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var fornecedor = _context.Fornecedores.Find(id);
            if (fornecedor == null) return NotFound();
            _context.Fornecedores.Remove(fornecedor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
