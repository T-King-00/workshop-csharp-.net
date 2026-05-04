using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Controllers;


[ApiController]
[Route("/[controller]")]
public class Cart
{
    [HttpGet("cart")]
    public string GetCart()
    {
        return "new empty Cart";
    }
    
    [HttpGet("cart/{id}")]
    public string GetUserCart(Guid id)
    {
        return $"User{id}  Cart";
    }
    
    [HttpPut("cart/{id}")]
    public string UpdateCart(Guid id)
    {
        return $"User{id}  Cart";
    }
    
    
}