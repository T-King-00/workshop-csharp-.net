using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Db;
using ShoppingCart.Models;
using ShoppingCart.Repo;

namespace ShoppingCart.Controllers;


[ApiController]
[Route("/[controller]")]
public class CartController (ShoppingCartDb db) :ControllerBase 
{
    CartRepo _cartRepo=new(db);
    
    [HttpPost("/newCart")]
    public async Task<IActionResult> InitiateEmptyCart(  [FromBody] Guid userId)
    {
        
        Cart newCart = new();
        newCart.DateCreated=DateTime.Now;
        newCart.UserId=userId;
        
        
        //add cart to db
       await _cartRepo.AddNewCart(newCart);
        
        return CreatedAtAction(
            nameof(GetUserCart), //needs id for route uri 
            new{cartId=newCart.Id},
            newCart
        );
    }
    
    [HttpGet("/{cartId}")]
    public async Task<IActionResult> GetUserCart([FromRoute]Guid cartId)
    {
     
        var cart =  await _cartRepo.GetCart(cartId);
        if (cart is null)
            return NotFound();
        
        return Ok(cart);
    }

    
    [HttpPut("/{cartId}")]
    public async Task<IActionResult> UpdateCart([FromRoute] Guid cartId, [FromBody] List<CartItem> updatedItems)
    {
        Cart? cart =await _cartRepo.UpdateCart(updatedItems,cartId) ;
        if (cart is null)
        {
            return  NotFound();
        }
        
        return Ok();
    }   
    
    [HttpDelete("/{cartId}")]
    public async Task<IActionResult> DeleteCart([FromRoute] Guid cartId)
    {
        Console.WriteLine("DeleteCart called : cartid = "+cartId+"");
        await _cartRepo.DeleteCart(cartId);
        
        return NoContent();

        
            
    }
    
    
    
}