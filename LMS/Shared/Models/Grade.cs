using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        [Required]
       [ForeignKey("SchoolLevelId")]
        public int SchoolLevelId { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? ImagePath { get; set; }
        public virtual SchoolLevel? SchoolLevel { get; set; }
    }
}
