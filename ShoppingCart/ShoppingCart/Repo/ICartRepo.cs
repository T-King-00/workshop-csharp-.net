using ShoppingCart.Models;

namespace ShoppingCart.Repo;

public interface ICartRepo
{
    public Task AddNewCart(Cart cart);
    
    public Task<Cart?> GetCart(Guid cartId);
    public Task<Cart?> UpdateCart(List<CartItem> updatedItems, Guid cart);
    public Task DeleteCart(Guid cartId);
    public Task SaveChangesAsync();
    
}