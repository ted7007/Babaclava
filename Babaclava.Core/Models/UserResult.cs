namespace Babaclava.Core.Models;

public class UserResult
{
    public Guid UserId { get; set; }

    public Guid BookId { get; set; }

    public int CurrentPosition { get; set; }
}