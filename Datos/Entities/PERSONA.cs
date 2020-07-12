using System;
using System.Collections.Generic;

namespace Datos.Entities
{
    public partial class PERSONA
    {
        public PERSONA()
        {
            CONTACTO = new HashSet<CONTACTO>();
            DIRECCION = new HashSet<DIRECCION>();
        }

        public string PER_NOMBRE1 { get; set; }
        public string PER_NOMBRE2 { get; set; }
        public string PER_NOMBRE3 { get; set; }
        public string PER_APELLODO1 { get; set; }
        public string PER_APELLIDO2 { get; set; }
        public int PER_ID { get; set; }
        public int? TIP_ID { get; set; }

        public virtual TIPO_PERSONA TIP_ { get; set; }
        public virtual ICollection<CONTACTO> CONTACTO { get; set; }
        public virtual ICollection<DIRECCION> DIRECCION { get; set; }
    }
}
