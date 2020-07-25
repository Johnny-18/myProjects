using DAL_.Entyties;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL_.Context
{
    public class BlogContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }
      
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Comment>().HasKey(s => s.Id);

            builder.Entity<Comment>()
                .HasOne(s => s.Post)
                .WithMany(s => s.Comments)
                .HasForeignKey(s => s.Post_Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(s => s.User)
                .WithMany(s => s.Comments)
                .HasForeignKey(s => s.User_Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Image>().HasKey(s => s.Id);

            builder.Entity<Image>()
                .HasOne(s => s.Post)
                .WithMany(s => s.Images)
                .HasForeignKey(s => s.Post_Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Image>()
                .HasOne(s => s.User)
                .WithMany(s => s.Images)
                .HasForeignKey(s => s.User_Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Like>().HasKey(s => s.Id);

            builder.Entity<Like>()
                .HasOne(s => s.Post)
                .WithMany(s => s.Likes)
                .HasForeignKey(s => s.Post_Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Like>()
                .HasOne(s => s.User)
                .WithMany(s => s.Likes)
                .HasForeignKey(s => s.User_Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasMany(s => s.Comments)
                .WithOne(s => s.User)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                            .HasMany(s => s.Images)
                            .WithOne(s => s.User)
                            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                            .HasMany(s => s.Likes)
                            .WithOne(s => s.User)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
