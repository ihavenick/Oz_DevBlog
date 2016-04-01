using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using Oz_DevBlog.Data.Identity_Entity;
using Oz_DevBlog.Data.Model_Entity;

namespace Oz_DevBlog.DAL.Context
{ 
    public class Oz_DevDBContext : IdentityDbContext<ApplicationUser>
    {
        public Oz_DevDBContext()
            : base("Data Source=188.121.44.217;database=ihavenick_mssql;User ID=iha_sa;Password=i69el8H!;Connect Timeout=15;Packet Size=4096")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<AdminDesc> AdminDesc { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<BlogType> BlogType { get; set; }
        public virtual DbSet<Certification> Certification { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Employment> Employment { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Seminar> Seminar { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<SkillType> SkillType { get; set; }
        public virtual DbSet<SocialMedia> SocialMedia { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasMany(e => e.Tag)
                .WithMany(e => e.Blog)
                .Map(m => m.ToTable("TagBlog"));


            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
