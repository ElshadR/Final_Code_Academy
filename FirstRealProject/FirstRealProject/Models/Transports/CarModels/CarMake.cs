using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Transports.CarModels
{
	[Table("CarMakes", Schema = "transport")]
    public class CarMake
	{
        public CarMake()
        {
            CarModels = new HashSet<CarModel>();
        }

        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<CarModel> CarModels { get; set; }
    }
}
