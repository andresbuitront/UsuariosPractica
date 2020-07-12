using System;
using System.Collections.Generic;

namespace Datos.Entities
{
    public partial class TIPO_CONTACTO
    {
        public TIPO_CONTACTO()
        {
            CONTACTO = new HashSet<CONTACTO>();
        }

        public int TIP_CON_ID { get; set; }
        public string TIP_CON_NOMBRE { get; set; }
        public string TIP_CON_DESCRIPCION { get; set; }

        public virtual ICollection<CONTACTO> CONTACTO { get; set; }
    }
}
