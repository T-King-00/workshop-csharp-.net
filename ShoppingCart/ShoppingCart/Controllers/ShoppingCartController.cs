using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Db;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers;


[ApiController]
[Route("/[controller]")]
public class CartController (ShoppingCartDb db) :ControllerBase 
{
    
    [HttpPost]
    public IActionResult InitiateEmptyCart(  [FromBody] Guid userId)
    {
        
        Cart newCart = new();
        newCart.DateCreated=DateTime.Now;
        newCart.UserId=userId;
        
        //add cart to db
        db.Carts.Add(newCart);
        db.SaveChanges();
        
        return CreatedAtAction(
            nameof(GetUserCart), //needs id for route uri 
            new{cartId=newCart.Id},
            newCart
        );
    }
    
    [HttpGet("/{cartId}")]
    public IActionResult GetUserCart([FromRoute]Guid cartId)
    {
        //instead of hitting db twice
        /* if (!db.Carts.Any(c=>c.Id==cartId))
         {
            return NotFound();
         }
         var cart = db.Carts.First(c=>c.Id==cartId);*/
           
        //we can use, one hit to db
        var cart=db.Carts.Where(c=>c.Id==cartId).
            Include(c=>c.Items)!.
            ThenInclude(c=>c.Product).FirstOrDefault();
        
        if (cart==null)
            return NotFound();
        
        
        
        return Ok(cart);
    }

    
    [HttpPut("/{cartId}")]
    public IActionResult UpdateCart([FromRoute] Guid cartId, [FromBody] List<CartItem> updatedItems)
    {
        
        
        Cart cart=db.Carts.Where(c=>c.Id==cartId).Include(c=>c.Items)
            .ThenInclude(p=>p.Product).FirstOrDefault();
        if (cart is null)
        {
           return NotFound();
        }

        db.CartItems.RemoveRange(cart.Items);
        cart.Items =updatedItems ;
        db.CartItems.AddRange(cart.Items);
        
        db.SaveChanges();
        
        return Ok(cart);
    }   
    
    [HttpDelete("/{cartId}")]
    public IActionResult DeleteCart([FromRoute] Guid cartId)
    {
        Console.WriteLine("DeleteCart called : cartid = "+cartId+"");
     
        var result=db.Carts.Where(c=>c.Id==cartId).
            Include(i=>i.Items)!.
            ThenInclude(p=>p.Product).
            FirstOrDefault();
        if (result is null)
        {
            return NotFound();
        }
        
        db.Carts.Remove(result);
        db.SaveChanges();
        return NoContent();

        
            
    }
    
    
    
}