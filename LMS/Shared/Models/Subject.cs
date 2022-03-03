using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? ImagePath { get; set; }
     
        [ForeignKey("Grade")]
        public int GradeId { get; set; }
        public virtual Grade? Grade { get; set; }




    }
}
