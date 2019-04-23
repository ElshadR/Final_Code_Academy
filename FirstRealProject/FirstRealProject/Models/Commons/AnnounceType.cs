using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Commons
{
	[Table("AnnounceTypes", Schema = "common")]
    public class AnnounceType
	{
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
