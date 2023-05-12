using System.ComponentModel.DataAnnotations;

namespace VeriTaabani1.Data.Entity;

public class Category
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
}


