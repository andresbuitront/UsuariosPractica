using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace UsuariosPractica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly LogicaPersona logica;

        public PersonaController(LogicaPersona logica)
        {
            this.logica = logica;
        }

        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] JObject objeto)
        {
            try
            {
                return await logica.InsertarPersonaDireccion(objeto);
            }
            catch (Exception ex)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError, ex);
                return result;
            }
        }
    }
}
