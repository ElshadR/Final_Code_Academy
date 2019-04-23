using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.Commons
{
    [Table(name:"Comments",Schema ="common")]
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(225, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        public DateTime SendDate { get; set; }

        public DateTime? CheckInDate { get; set; }

        public bool CheckIn { get; set; }
    }
}
