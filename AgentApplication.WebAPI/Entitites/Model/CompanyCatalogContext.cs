using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgentApplication.WebAPI.Entitites.Model
{
    public class CompanyCatalogContext : IdentityUserContext<User>
    {
        public CompanyCatalogContext(DbContextOptions<CompanyCatalogContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<InterviewProccessReview> InterviewProccessReviews { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<JobPostPrerequisite> JobPostPrerequisites { get; set; }
        public DbSet<SalaryReview> SalaryReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.Owner)
                .WithMany(x => x.OwnedCompanies)
                .HasForeignKey(x => x.OwnerId);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.Company)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.CompanyId);
            });

            modelBuilder.Entity<InterviewProccessReview>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.Company)
                .WithMany(x => x.InterviewProccessReviews)
                .HasForeignKey(x => x.CompanyId);
            });

            modelBuilder.Entity<JobPost>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.Company)
                .WithMany(x => x.JobPosts)
                .HasForeignKey(x => x.CompanyId);
            });

            modelBuilder.Entity<JobPostPrerequisite>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.JobPost)
                .WithMany(x => x.JobPostPrerequisites)
                .HasForeignKey(x => x.JobPostId);
            });

            modelBuilder.Entity<SalaryReview>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.Company)
                .WithMany(x => x.SalaryReviews)
                .HasForeignKey(x => x.CompanyId);
            });


        }
    }
}
