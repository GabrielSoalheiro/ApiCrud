using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    //Importante para comunicar com o banco.
    private readonly ApplicationDbContext _context;
    public UsuarioController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var model = await _context.Usuarios.ToListAsync();
        return Ok(model);
    }


    [HttpPost]
    public async Task<ActionResult> Create(Usuario model)
    {
        Usuario novo = new Usuario()
        {
            Id = model.Id,
            Nome = model.Nome,
            Senha = model.Senha
        };

        _context.Usuarios.Add(novo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var model = await _context.Usuarios
            .FirstOrDefaultAsync(c => c.Id == id);

        if (model == null) return NotFound();

        return Ok(model);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, Usuario model)
    {
        if (id != model.Id) return BadRequest();

        Usuario novo = new Usuario()
        {
            Id = model.Id,
            Nome = model.Nome,
            Senha = model.Senha
        };

        _context.Usuarios.Update(novo);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var model = await _context.Usuarios.FindAsync(id);

        if (model == null) return NotFound();

        _context.Usuarios.Remove(model);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
