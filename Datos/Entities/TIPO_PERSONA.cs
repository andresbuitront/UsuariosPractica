using System;
using System.Collections.Generic;

namespace Datos.Entities
{
    public partial class TIPO_PERSONA
    {
        public TIPO_PERSONA()
        {
            PERSONA = new HashSet<PERSONA>();
        }

        public int TIP_ID { get; set; }
        public string TIP_NOMBRE { get; set; }
        public string TIP_DESCRIPCION { get; set; }

        public virtual ICollection<PERSONA> PERSONA { get; set; }
    }
}
