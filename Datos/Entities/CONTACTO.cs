using System;
using System.Collections.Generic;

namespace Datos.Entities
{
    public partial class CONTACTO
    {
        public int CON_ID { get; set; }
        public int? TIP_CON_ID { get; set; }
        public int? PER_ID { get; set; }
        public string CON_DESCRIPCION { get; set; }

        public virtual PERSONA PER_ { get; set; }
        public virtual TIPO_CONTACTO TIP_CON_ { get; set; }
    }
}
