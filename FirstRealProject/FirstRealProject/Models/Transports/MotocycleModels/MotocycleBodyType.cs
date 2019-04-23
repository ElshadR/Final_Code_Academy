using System.ComponentModel.DataAnnotations.Schema;

namespace FirstRealProject.Models.Transports.MotocycleModels
{
	[Table("MotocycleBodyTypes", Schema = "transport")]
    public class MotocycleBodyType
	{
        public int Id { get; set; }

        public string Name { get; set; }

    }
}