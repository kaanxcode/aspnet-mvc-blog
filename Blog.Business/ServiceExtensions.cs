using Blog.Business.Services;
using Blog.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Blog.Business.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business
{
    public static class ServiceExtensions
	{
		public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<BlogDbContext>()/*(o =>
            {
                string connectionString = configuration.GetConnectionString("Default");
                o.UseSqlServer(connectionString);
            })*/;
			services.AddTransient<PostService>();
			services.AddTransient<CategoryService>();
			services.AddTransient<PageService>();
			services.AddTransient<SettingService>();
			services.AddTransient<UserService>();
			return services;
		}
		public static void EnsureDeletedAndCreated(IServiceScope scope)
		{
			// Veritabanı servisine erişim sağlar.
			var context = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
			// Veritabanını sil
			context.Database.EnsureDeleted();
			// Veritabanını oluşturur
			context.Database.EnsureCreated();

			Dbseeder.Seed(context);
		}


	}
}