using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels
{
    [Table("BasicMenus", Schema = "page")]
    public class BasicMenu
    {
        public BasicMenu()
        {
            Categories = new HashSet<Category>();
        }
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
