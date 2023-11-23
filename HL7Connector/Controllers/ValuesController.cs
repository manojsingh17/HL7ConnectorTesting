using HL7CreationFromJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HL7Connector.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        

        [HttpPost]
        public IHttpActionResult Post(JsonHL7Fields HL7OrderData)
        {
            //Get Data in HL7 Format
            var HL7FormatMessage = Hl7Helper.GetHL7Format(HL7OrderData);
            return Ok(HL7FormatMessage);
        }
    }
}
