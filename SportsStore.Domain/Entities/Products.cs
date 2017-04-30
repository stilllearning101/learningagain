using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Products
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int? ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }
    }
}
//TODO chapter 22
/* The products class does not know about the html.editorformodel helper. There are three ways we can
 * deal with editorformodel helper knowing the products class which are as follows:
 * 1. <textarea class="text-box-multi-line" id="Description" name="Description">
 * The html element is assigned with a bootstrap class. "MultilineText" on descritpion and 
 * bootstrap class having "multilinetext" allows for the match of the helper and properties.
 * 2. The second approach is to provide the helper with templates that it can use to generate the 
 * elements, including the the style. Chapter 22 has better explanation. 
 * 3. To create the elements needed directly, without using the model level helper method.
 */
