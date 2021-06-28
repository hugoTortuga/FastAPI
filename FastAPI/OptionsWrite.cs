using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAPI
{
    public class OptionsWrite
    {

        public bool Create { get; set; }
        public bool ReadAll { get; set; }
        public bool ReadById { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }

        public OptionsWrite()
        {
            Create = false;
            ReadAll = false;
            ReadById = false;
            Update = false;
            Delete = false;
        }

        public OptionsWrite(bool create, bool readAll, bool readById, bool update, bool delete)
        {
            Create = create;
            ReadAll = readAll;
            ReadById = readById;
            Update = update;
            Delete = delete;
        }
    }
}
