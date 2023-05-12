namespace Blog.Web.Mvc.Data.Entity;

public class PostComment
{
    public int Id { get; set; }
    public int? PostId { get; set; }
    public int? UserId { get; set; }
    public string Comment { get; set; }
    public bool IsActive { get; set; }
}


