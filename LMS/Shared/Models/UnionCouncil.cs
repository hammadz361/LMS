using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LMS.Shared.Models
{
    public class UnionCouncil
    {
        [Key]
        public int UnionCouncilId { get; set; }
        public string? Name { get; set; }
        [Required]
        [ForeignKey("Tehsil")]
        public int TehsilId { get; set; }
        public virtual Tehsil? Tehsil { get; set; }    
    }
}