using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Mvc.Data.Entity;

public class Category
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
}


