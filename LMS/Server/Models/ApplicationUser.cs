using LMS.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace LMS.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int DistrictId { get; set; }
        public virtual District? District { get; set; }
    }
}