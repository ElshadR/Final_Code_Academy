using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Transports.CarModels
{
	[Table("CarModels", Schema = "transport")]
    public class CarModel
	{
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public virtual CarMake CarMake { get; set; }
        public int CarMakeId { get; set; }
    }
}
