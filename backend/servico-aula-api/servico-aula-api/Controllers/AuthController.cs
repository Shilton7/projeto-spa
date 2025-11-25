using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using servico_aula_api.Data;
using servico_aula_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace servico_aula_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // POST api/<AuthController>
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequest dados)
        {
            if (string.IsNullOrWhiteSpace(dados.Email) ||
                string.IsNullOrWhiteSpace(dados.Senha))
                return BadRequest("Email e senha são obrigatórios");

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(
                u => u.Email == dados.Email &&
                u.Senha == dados.Senha &&
                u.Ativo);

            if(usuario == null)
            {
                return Unauthorized("Email ou senha inválidos");
            }

            return Ok(new
            {
                usuario.Id,
                usuario.Nome,
                usuario.Email
            });
        }
    }
}
