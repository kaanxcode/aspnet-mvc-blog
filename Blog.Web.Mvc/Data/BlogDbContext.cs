using Microsoft.EntityFrameworkCore;
using VeriTaabani1.Data;

namespace Blog.Web.Mvc.Data
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryPost> CategoryPosts { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<User> Users { get; set; }

        //2.VeriTabanının Konfigrasyonu
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;DataBase=DB1;";
            builder.UseSqlServer(connectionString);
            base.OnConfiguring(builder);
        }
        ///////////////seed kısmı, metodun kendisi Dbseeder.cs içerisinde 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Dbseeder.SeedData(modelBuilder);
        }
    }
}
