using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Must have Name")]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage ="must have Price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Must Have Price")]
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }//make references to FK from Category Entity
    }
}
