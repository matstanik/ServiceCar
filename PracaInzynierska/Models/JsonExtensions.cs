using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace PracaInzynierska.Models
{
    public class JsonExtensions
    {
        public string ObjectToJson(object model)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };
            return JsonConvert.SerializeObject(model, settings);
        }
        
    }
}
