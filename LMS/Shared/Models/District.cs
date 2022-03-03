using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Shared.Models
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }
        [Required]
        public string? Name { get; set; }







    }
}
