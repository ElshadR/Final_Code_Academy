using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstRealProject.Models.Jobs.ForJob
{
	[Table("ActivityAreas", Schema ="jobs")]
	public class ActivityArea
	{
		public int Id { get; set; }

		[Required]
		[DataType(DataType.Text)]
		[StringLength(225, MinimumLength = 3)]
		public string Name { get; set; }
	}
}