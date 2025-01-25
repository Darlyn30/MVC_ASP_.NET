using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Common
{
    public class BaseBasicEntity
    {
        //Common properties sharing between files
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string? Description { get; set; }
    }
}
