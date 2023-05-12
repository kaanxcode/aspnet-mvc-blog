using Microsoft.EntityFrameworkCore;
using VeriTaabani1.Data.Entity;

namespace VeriTaabani1.Data
{
    public class Dbseeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new List<Category>
        {
            new Category{ Id = 1, Name="deneme"},
            new Category{ Id = 2, Name="deneme 2"},
            new Category{ Id = 3, Name="deneme 3"}
        });
            modelBuilder.Entity<Post>().HasData(new List<Post>
        {
            new Post{ Id = 1, Title="post1"},
            new Post{ Id = 2,Title="post2"},
            new Post{ Id = 3,Title="post3"},
        });
        }
    }
}

