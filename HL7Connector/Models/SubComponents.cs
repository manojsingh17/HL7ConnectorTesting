using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HL7.Dotnetcore
{
    public class SubComponent : MessageElement
    {
        public SubComponent(string val, HL7Encoding encoding)
        {
            this.Encoding = encoding;
            this.Value = val;
        }

        protected override void ProcessValue()
        {

        }
    }
}