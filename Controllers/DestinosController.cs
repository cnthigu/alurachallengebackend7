using DepoimentosApi.Data;
using DepoimentosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepoimentosApi.Controllers;


[ApiController]
[Route("[controller]")]
public class DestinosController : ControllerBase
{

    private readonly AppDbContext _context;

    public DestinosController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public ActionResult<IEnumerable<object>> Get([FromQuery] string? nome)
    {
        if (!string.IsNullOrEmpty(nome))
        {
            var destinosFiltrados = _context.Destinos
                .Where(d => d.Nome.Contains(nome))
                .Select(d => new
                {
                    d.Foto1,
                    d.Nome,
                    d.Preco
                })
                .ToList();

            if (destinosFiltrados.Count == 0)
            {
                return NotFound(new { mensagem = "Nenhum destino foi encontrado" });
            }

            return Ok(destinosFiltrados);
        }

        var todosOsDestinos = _context.Destinos
            .Select(d => new
            {
                d.Foto1,
                d.Nome,
                d.Preco
            })
            .ToList();

        return Ok(todosOsDestinos);
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
        var destino = _context.Destinos
            .Where(d => d.Id == id)
            .Select(d => new
            {
                d.Foto1,
                d.Foto2,
                d.Nome,
                d.Meta,
                d.TextoDescritivo
            })
            .FirstOrDefault();

        if (destino == null)
        {
            return NotFound(new { mensagem = "Nenhum destino foi encontrado" });
        }

        return Ok(destino);
    }

    [HttpPost]
    public ActionResult<Destinos> Post([FromBody] Destinos novoDestino)
    {
        if (string.IsNullOrWhiteSpace(novoDestino.TextoDescritivo))
        {
            novoDestino.TextoDescritivo = GerarResumoIA(novoDestino.Nome);
        }

        _context.Destinos.Add(novoDestino);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = novoDestino.Id }, novoDestino);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Destinos atualizado)
    {
        var destinos = _context.Destinos.Find(id);
        if (destinos == null) return NotFound();

        destinos.Foto1 = atualizado.Foto1;
        destinos.Foto2 = atualizado.Foto2;
        destinos.Nome = atualizado.Nome;
        destinos.Meta = atualizado.Meta;
        destinos.Preco = atualizado.Preco;
        destinos.TextoDescritivo = atualizado.TextoDescritivo;

        destinos.TextoDescritivo = string.IsNullOrWhiteSpace(atualizado.TextoDescritivo) 
            ? GerarResumoIA(atualizado.Nome) : atualizado.TextoDescritivo;


        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var destinos = _context.Destinos.Find(id);
        if (destinos == null) return NotFound();

        _context.Destinos.Remove(destinos);
        _context.SaveChanges();
        return NoContent();
    }

    private string GerarResumoIA(string nomeDestino)
    {
        return $"Resumo sobre {nomeDestino}: lugar incrível, cheio de cultura e diversão. Vale a pena conhecer!";
    }

}
