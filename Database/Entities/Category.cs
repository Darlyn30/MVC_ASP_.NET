using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Common;

namespace Database.Entities
{
    public class Category : BaseBasicEntity
    {
        //Nav Prop
        public ICollection<Product>? Products { get; set; }
    }
}
