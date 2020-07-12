using System;
using System.Collections.Generic;

namespace Datos.Entities
{
    public partial class LOG_GENERAL
    {
        public int LG_ID { get; set; }
        public string LG_DESCRIPCION { get; set; }
        public string LG_USUARIO { get; set; }
        public DateTime LG_FECHA { get; set; }
    }
}
