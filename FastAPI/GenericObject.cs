using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAPI
{
    public class GenericObject
    {

        public List<GenericAttribute> Attributes { get; set; }

        public string ObjectName { get; set; }

        public string Schema { get; set; }


        public GenericObject(string name, string schema, List<GenericAttribute> attributes)
        {
            ObjectName = name;
            Attributes = attributes;
            Schema = schema;
        }

    }
}
