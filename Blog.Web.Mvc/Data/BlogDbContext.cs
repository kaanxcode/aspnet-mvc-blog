using Microsoft.EntityFrameworkCore;
using Blog.Data.Entity;


namespace Blog.Web.Mvc.Data
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<User> Users { get; set; }

        //2.VeriTabanının Konfigrasyonu
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=DB1;";
            builder.UseSqlServer(connectionString);
            base.OnConfiguring(builder);
        }
		///////////////seed kısmı, metodun kendisi Dbseeder.cs içerisinde 
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Post>().HasMany(p => p.Categories ).WithMany(p=>p.Posts);
			base.OnModelCreating(modelBuilder);
		}
	}
}
