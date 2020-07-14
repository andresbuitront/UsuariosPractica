using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.DTO
{
    public class RespuestaGenericaDTO
    {
        public int Estado { get; set; }
        public string Mensaje { get; set; }
        public object Objeto { get; set; }

        public RespuestaGenericaDTO(int estado, string mensaje, object objeto)
        {
            Estado = estado;
            Mensaje = mensaje;
            Objeto = objeto;
        }

        public RespuestaGenericaDTO()
        {
        }
    }
}
