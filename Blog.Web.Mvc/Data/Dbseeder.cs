using Microsoft.EntityFrameworkCore;
using Blog.Web.Mvc.Data.Entity;
using System;


namespace Blog.Web.Mvc.Data
{
    public class Dbseeder
    {
        public static void Seed(BlogDbContext context)
        {
            if (!context.Categories.Any())
            {
                // Kategorileri oluşturma
                var categories = new Category[]
                {
                    new Category { Name = "Deneme1", Description = "dadsadas" },
                    new Category { Name = "Deneme 2", Description = "dasd" },
                    new Category { Name = "Deneme3", Description = "asdada" },
                    new Category { Name = "Deneme 4", Description = "muadszik" }
                };

                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.Add(new User { Name = "Admin" });
                //context.SaveChanges();
            }
            if (!context.Posts.Any())
            {
                // Yazıları oluşturma
                var posts = new Post[]
                {
                    new Post { Title = "Post deneme", Content = "Cras ut metus a risus iaculis scelerisque eu ac ante fusce non varius purus aenean nec magna felis fusce vestibulum velit mollis odio sollicitudin lacinia aliquam posuere, sapien elementum lobortis tincidunt, turpis dui ornare nisl, sollicitudin interdum turpis nunc eget sem nulla eu ultricies orci praesent id augue nec lorem pretium congue sit amet ac nunc fusce iaculis lorem eu diam hendrerit at mattis purus dignissim vivamus mauris tellus, fringilla vel dapibus a, blandit quis erat vivamus elementum aliquam luctus.", Id=1,UserId=1},
                    new Post { Title = "Spor Haberleri", Content = "Yerli ve yabancı spor haberleri...", Id=2,UserId=1},
                    new Post { Title = "sakbfkuahs", Content = "Yeni tedavi yöntemleri...", Id=3,UserId=1},
                    new Post { Title = "Müzik Dünyasından Haberler", Content = "Yeni albümler ve konserler hakkında güncel bilgiler...",Id=4,UserId=1}
                };

                context.Posts.AddRange(posts);
                //context.SaveChanges();
            }
            if (!context.Pages.Any())
            {
                // Yazıları oluşturma
                var pages = new Page[]
                {
                    new Page { Title = "Sayfa adı"}

                };

                context.Pages.AddRange(pages);
                //context.SaveChanges();
            }

        }

        


    }
}

