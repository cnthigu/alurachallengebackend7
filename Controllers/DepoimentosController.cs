using DepoimentosApi.Data;
using DepoimentosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepoimentosApi.Controllers;



[ApiController]
[Route("[controller]")]
public class DepoimentosController : ControllerBase
{

    private readonly AppDbContext _context;

    public DepoimentosController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Depoimento>> Get()
    {
        return Ok(_context.Depoimentos.ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<Depoimento> Get(int id)
    {
        var depoimento = _context.Depoimentos.Find(id);
        if (depoimento == null) return NotFound();
        return Ok(depoimento);
    }


    [HttpPost]
    public ActionResult<Depoimento> Post([FromBody] Depoimento novoDepoimento)
    {
        _context.Depoimentos.Add(novoDepoimento);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = novoDepoimento.Id }, novoDepoimento);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Depoimento atualizado)
    {
        var depoimento = _context.Depoimentos.Find(id);
        if (depoimento == null) return NotFound();

        depoimento.Foto = atualizado.Foto;
        depoimento.Texto = atualizado.Texto;
        depoimento.Nome = atualizado.Nome;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var depoimento = _context.Depoimentos.Find(id);
        if (depoimento == null) return NotFound();

        _context.Depoimentos.Remove(depoimento);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet("/depoimentos-home")]
    public ActionResult<IEnumerable<Depoimento>> GetDepoimentosHome()
    {
        var depoimentos = _context.Depoimentos
            .OrderBy(d => Guid.NewGuid()) 
            .Take(3) 
            .ToList();
        return Ok(depoimentos);
    }
}
