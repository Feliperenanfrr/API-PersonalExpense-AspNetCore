using API_PersonalExpense_AspNetCore.Data;
using API_PersonalExpense_AspNetCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_PersonalExpense_AspNetCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuarioController(AppDbContext context)
    {
        _context = context;
    }

    //GET: api/usuario
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
        return await _context.Usuarios.ToListAsync();
    }

    //GET: api/usuario/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null)
        {
            return NotFound();
        }
        return usuario;
    }
    
    [HttpPost]
    public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, Usuario usuario)
    {
        if (id != usuario.Id)
        {
            return BadRequest("ID fornecido na requisição é diferente do ID do usuário");
        }
        
        _context.Entry(usuario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioExists(id))
            {
                return NotFound("Usuario no encontrado");
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }
    
    // Método auxiliar para verificar se um usuário existe no banco de dados
    private bool UsuarioExists(int id)
    {
        return _context.Usuarios.Any(e => e.Id == id);
    }
}