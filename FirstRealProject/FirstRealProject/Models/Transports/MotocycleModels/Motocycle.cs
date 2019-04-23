using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Transports.MotocycleModels
{
	[Table("Motocycle", Schema = "transport")]
    public class Motocycle: Announce
	{
        public Motocycle()
        {
            MotocyclePhotos = new HashSet<MotocyclePhoto>();
        }

        public Motocycle(MotocycleBodyType bodyType, MotocycleMake make, int year)
        {
            MotocyclePhotos = new HashSet<MotocyclePhoto>();
            this.AnnounceName = bodyType.Name + " " + make.Name + ", " + year;
            this.MotocycleBodyTypeId = bodyType.Id;
            this.MotocycleYear = year;
            MotocycleMakeId = make.Id;
        }

        [Required]
        public string MotocycleModel { get; set; }

        [Required]
        public virtual MotocycleBodyType MotocycleBodyType { get; set; }
        public int MotocycleBodyTypeId { get; set; }

        [Required]
        public virtual MotocycleMake MotocycleMake { get; set; }
        public int MotocycleMakeId { get; set; }

        [Required]
        public int MotocycleMotor { get; set; }

        [Required]
        public int MotocycleYear { get; set; }

        [Required]
        public int MotocycleKilometer { get; set; }

        [Required]
        public bool Condition { get; set; }
        [Required]
        public bool ConditionCredit { get; set; }
        [Required]
        public bool ConditionBarter { get; set; }

        public virtual ICollection<MotocyclePhoto> MotocyclePhotos { get; set; }

    }
}
