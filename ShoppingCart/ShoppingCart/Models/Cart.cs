namespace ShoppingCart.Models;

public class Cart
{
    public Guid Id { get; }=Guid.NewGuid();
    public DateTime DateCreated { get; set; }
    public List<CartItem>? Items { get; set; }
    public Guid UserId { get; set; }
}

public class CartItem
{
    public int Quantity { get; set; }
    
    //ref property
    public Product? Product { get; set; }
    public Guid UserId { get; set; }
    
}