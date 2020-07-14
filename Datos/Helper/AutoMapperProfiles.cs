using AutoMapper;
using Datos.DTO;
using Datos.DTO.Direccion;
using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Helper
{
    class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<InsertarPersonaDTO, PERSONA>().ReverseMap();
            CreateMap<PERSONA, MostrarPersonaDTO>().ReverseMap();
            CreateMap<InsertarDireccionDTO, DIRECCION>().ReverseMap();
            CreateMap<DIRECCION, MostrarDireccionDTO>().ReverseMap();
        }
    }
}
