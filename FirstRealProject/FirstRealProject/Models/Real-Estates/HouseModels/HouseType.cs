using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstRealProject.Models.Real_Estates.HouseModels
{
	[Table("HouseTypes", Schema = "real_estate")]
	public class HouseType
	{
		public int Id { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[StringLength(225, MinimumLength = 3)]
		public string Name { get; set; }
	}
}