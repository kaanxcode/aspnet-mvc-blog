using Microsoft.EntityFrameworkCore;
using Blog.Data.Entity;
using System;


namespace Blog.Data
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
		public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
		{
		}
		///////////////seed kısmı, metodun kendisi Dbseeder.cs içerisinde 
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Post>().HasMany(p => p.Categories ).WithMany(p=>p.Posts);
			base.OnModelCreating(modelBuilder);
		}
	}
}
