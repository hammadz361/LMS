using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.Models
{
     public class Video
    {
        [Key]
        public int VideoId { get; set; }
        public string? Name { get; set; }
        public string? SerialNo { get; set; }
        public string? ImagePath { get; set; }
        public string? VideoLink { get; set; }
        public DateTime Duration { get; set; }
        [ForeignKey("Chapter")]
        public int ChapterId { get; set; }
        public virtual Chapter? Chapter { get; set; }


    }
}
