using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica.Util
{
    public class ObjectCaster
    {
        public TEntidad ConvertirJson<TEntidad>(JObject objeto) where TEntidad : class
        {
            try
            {
                TEntidad dto = JsonConvert.DeserializeObject<TEntidad>(objeto.ToString());
                return dto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
