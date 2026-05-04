using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; }=Guid.NewGuid();
    
    public string Name { get ; set; }
    public decimal Price { get ; set; }

    //nav property
    public Product()
    {
        
    }
    public Product(string name, decimal price)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Product name cannot be empty");
        }
        if (price<0)
        {
            throw new ArgumentException("Product price cannot be negative");
        }
        Name=name;
        Price=price;
    }

    
}