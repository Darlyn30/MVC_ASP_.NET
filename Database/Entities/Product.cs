using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Common;

namespace Database.Entities
{
    public class Product : BaseBasicEntity 
    {
        public decimal Price {  get; set; }
        public string ImagePath { get; set; }
        public int CategoryId {  get; set; }//make references to FK from Category Entity

        //Navigation property like we would using joins
        public Category? Category { get; set; }

    }
}
