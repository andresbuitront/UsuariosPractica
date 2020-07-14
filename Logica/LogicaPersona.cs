using AutoMapper;
using Datos;
using Datos.DTO;
using Datos.DTO.Direccion;
using Datos.Entities;
using Logica.Util;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaPersona
    {
        private readonly DatosPersona datos;
        private readonly ObjectCaster objectCaster;
        private readonly IMapper mapper;

        public LogicaPersona(DatosPersona datos, ObjectCaster objectCaster, IMapper mapper)
        {
            this.datos = datos;
            this.objectCaster = objectCaster;
            this.mapper = mapper;
        }
        public async Task<object> InsertarPersonaDireccion(JObject objeto)
        {
            InsertarPersonaDTO personadto = objectCaster.ConvertirJson<InsertarPersonaDTO>(objeto);
            InsertarDireccionDTO direcciondto = objectCaster.ConvertirJson<InsertarDireccionDTO>(objeto);
            return await datos.InsertarPersona(mapper.Map<PERSONA>(personadto), mapper.Map<DIRECCION>(direcciondto));
        }
    }
}
