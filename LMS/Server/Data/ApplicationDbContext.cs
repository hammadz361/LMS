using Duende.IdentityServer.EntityFramework.Options;
using LMS.Server.Models;
using LMS.Shared.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LMS.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<District>? Districts { get; set; }
        public DbSet<Tehsil>? Tehsils { get; set; }
        public DbSet<UnionCouncil>? UnionCouncils { get; set; }
        public DbSet<School>? Schools { get; set; }
        public DbSet<SchoolLevel>? SchoolLevels { get; set; }
        public DbSet<Gender>? Genders { get; set; }
        public DbSet<Grade>? Grades { get; set; }
        public DbSet<Subject>? Subjects { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }
        public DbSet<UploadedFile>? UploadedFile { get; set; }
        public DbSet<Video>? Videos { get; set; }
        public DbSet<Topic>? Topic { get; set; }
    }
}