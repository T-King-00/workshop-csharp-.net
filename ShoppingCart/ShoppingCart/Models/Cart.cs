using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models;

public class Cart
{
    [Key]
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; }
    public List<CartItem>? Items { get; set; }
    
    //ref property
    public Guid UserId { get; set; }

    public Cart()
    {
        Id=Guid.NewGuid();
        DateCreated=DateTime.Now;
    }

   
}

public class CartItem
{
    [Key]
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    
    //ref property : ForeignKey property
    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }
    
    public Guid CartId { get; set; }

 



    public CartItem()
    {
        Id=Guid.NewGuid();
    }
    
}