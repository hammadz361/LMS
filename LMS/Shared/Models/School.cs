using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.Models
{
    public class School
    {
        [Key]
        public int SchoolId { get; set; }
        public string? Name { get; set; }
        [Required]
        [ForeignKey("SchoolLevel")]
        public int SchoolLevelId { get; set; }
        [Required]
        [ForeignKey("Gender")]
        public int GenderId { get; set; }
        public virtual Gender? Gender { get; set; }
        public string? BEMIS { get; set; }
        [Required]
        [ForeignKey("UnionCouncil")]
        public int UnionCouncilId { get; set; }
        public virtual UnionCouncil? UnionCouncil { get; set; }
        public virtual SchoolLevel? SchoolLevel { get; set; }
    }

}
