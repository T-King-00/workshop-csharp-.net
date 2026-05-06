using Microsoft.EntityFrameworkCore;
using ShoppingCart.Db;
using ShoppingCart.Models;

namespace ShoppingCart.Repo;

public class CartRepo(ShoppingCartDb cartDb) : ICartRepo
{
    private readonly ShoppingCartDb _cartDb=cartDb ;
    public async Task AddNewCart(Cart newCart)
    {
        //add cart to db
        await _cartDb.Carts.AddAsync(newCart);
        await SaveChangesAsync();
    }
    
    public async Task<Cart?> GetCart(Guid cartId)
    {
         var cart=await _cartDb.Carts.Where(c=>c.Id==cartId).
            Include(c=>c.Items)!.
            ThenInclude(c=>c.Product).FirstOrDefaultAsync();
         //instead of hitting db twice
         /* if (!db.Carts.Any(c=>c.Id==cartId))
          {
             return NotFound();
          }
          var cart = db.Carts.First(c=>c.Id==cartId);*/
           
         //we can use, one hit to db
         return cart;
    }
    
    public async Task<Cart?> UpdateCart(List<CartItem> updatedItems,Guid cartId)
    {
        var cart=await _cartDb.Carts.Where(c=>c.Id==cartId).Include(c=>c.Items)
            .ThenInclude(p=>p.Product).FirstOrDefaultAsync();
        if (cart is not null && cart.Items is not null)
        {
            _cartDb.CartItems.RemoveRange(cart.Items);
            await SaveChangesAsync();
        }
        if (cart is null)
        {
           throw new Exception("Cart not found to update");
        }

        foreach (var updatedItem in updatedItems)
        {
            updatedItem.CartId=cartId;
        }
       
       
        cart.Items =updatedItems ;
      
        _cartDb.CartItems.AddRange(cart.Items);
        await SaveChangesAsync();
        
        return cart;
    }

    public async Task DeleteCart(Guid cartId)
    {
        var result=_cartDb.Carts.Where(c=>c.Id==cartId).
            Include(i=>i.Items)!.
            ThenInclude(p=>p.Product).
            FirstOrDefault();
        
        if (result is null)
        {
            throw new Exception("Cart not found");
        }
        _cartDb.Carts.Remove(result);
        if (result.Items is not null)
        {
            _cartDb.CartItems.RemoveRange(result.Items);

        }
        
        await SaveChangesAsync();
        
    }

    public async Task   SaveChangesAsync()
    {
       await _cartDb.SaveChangesAsync();
    }
}