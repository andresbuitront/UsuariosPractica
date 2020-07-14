using Datos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.DTO.Direccion
{
    public class InsertarDireccionDTO
    {
        public int? PER_ID { get; set; }
        public string DIR_CALLE_PRINCIPAL { get; set; }
        public string DIR_NUMERACION { get; set; }
        public string DIR_CALLE_SECUNDARIA { get; set; }
        public string DIR_REFERENCIA { get; set; }

        public virtual PERSONA PER_ { get; set; }
    }
}
