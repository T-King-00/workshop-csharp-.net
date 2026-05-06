using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }

    public User()
    {
        Id=Guid.NewGuid();
    }
}