using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstRealProject.Models.PagesModels
{
    [Table("Categories", Schema = "page")]
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3)]
        public string Controller { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3)]
        public string Action { get; set; }

        [Required]
        public virtual BasicMenu BasicMenu { get; set; }
        public int BasicMenuId { get; set; }


    }
}