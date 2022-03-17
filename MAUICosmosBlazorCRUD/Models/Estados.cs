using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUICosmosBlazorCRUD.Models
{
    public class Estados
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "partitionKey")]
        public string PartitionKey { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public List<Municipios> Municipios { get; set; }
    }

    public class Municipios
    {
        public string Nombre { get; set; }

    }
}
