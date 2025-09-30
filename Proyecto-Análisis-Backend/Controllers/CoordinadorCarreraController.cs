using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Análisis_Backend.Models;

namespace Proyecto_Análisis_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordinadorCarreraController : ControllerBase
    {
        private readonly PHAtlanticoContext _context;

        public CoordinadorCarreraController(IConfiguration configuration)
        {
            _context = new PHAtlanticoContext(configuration);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> Authenticate(string usuario, string contraseña)
        {
            //verificar que existe el usuario
            var usuarioRevisado = await _context.CoordinadorCarreras.AnyAsync(c => c.Usuario == usuario);
            
            if (!usuarioRevisado)
            {
                return NotFound();
            }

            //validar coincidencia
            var coincidencia = await _context.CoordinadorCarreras
                .Where(c => c.Usuario == usuario && c.Contraseña == contraseña).
                Select(c => new { c.Usuario, c.Contraseña })
                .FirstOrDefaultAsync();

            if (coincidencia != null)
            {

                return Ok(); //se autentificó exitosamente
            }

            return BadRequest(); //contraseña incorrecta

        }
    }
}
