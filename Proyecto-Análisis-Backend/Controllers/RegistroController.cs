using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Análisis_Backend.Models;

namespace Proyecto_Análisis_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly PHAtlanticoContext _context;
       
        public RegistroController(IConfiguration configuration)
        {
            _context = new PHAtlanticoContext(configuration);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> Authenticate(string usuario, string contraseña)
        {
            //verificar que existe el usuario
            var usuarioRevisado = await _context.Registros.AnyAsync(u => u.Usuario == usuario);
            if (!usuarioRevisado)
            {
                return NotFound();
            }

            //validar coincidencia
            var coincidencia = await _context.Registros
                .Where(u => u.Usuario == usuario && u.Contraseña == contraseña).
                Select(u => new { u.Usuario, u.Contraseña })
                .FirstOrDefaultAsync();

            if (coincidencia != null)
            {
                
                return Ok(); //se autentificó exitosamente
            }

            return BadRequest(); //contraseña incorrecta

        }
    }
}
