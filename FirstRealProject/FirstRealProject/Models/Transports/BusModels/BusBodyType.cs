using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Transports.BusModels
{
	[Table("BusBodyTypes", Schema = "transport")]
    public class BusBodyType
	{
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
