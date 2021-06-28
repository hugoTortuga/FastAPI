using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAPI
{
    public class GenericAttribute
    {

        public Type Type { get; set; }
        public string Name { get; set; }

        public GenericAttribute(Type type, string name)
        {
            Type = type;
            Name = name;
        }

    }
}
