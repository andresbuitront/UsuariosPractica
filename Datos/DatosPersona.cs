using AutoMapper;
using Datos.Data;
using Datos.DTO;
using Datos.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosPersona
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public DatosPersona(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<RespuestaGenericaDTO> InsertarPersona(PERSONA persona, DIRECCION direccion)
        {
            RespuestaGenericaDTO respuesta;

            using (var Transaccion = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.Add(persona);
                    await dbContext.SaveChangesAsync();
                    direccion.PER_ID = persona.PER_ID;
                    dbContext.Add(persona);
                    await dbContext.SaveChangesAsync();
                    await Transaccion.CommitAsync();
                    var personaInsertada = dbContext.PERSONA.Where(x => x.PER_ID == persona.PER_ID).Include(y => y.DIRECCION);
                    respuesta = new RespuestaGenericaDTO(200, "Exitoso", mapper.Map<MostrarPersonaDTO>(personaInsertada));
                }
                catch (Exception ex)
                {
                    await Transaccion.RollbackAsync();
                    respuesta = new RespuestaGenericaDTO(500, "Error Interno del Servidor", ex.Message);
                }
                return respuesta;

            }
        }
    }
}
