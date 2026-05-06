using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    
    public string? Name { get ; set; }
    public decimal Price { get ; set; }

    public Product()
    {
        
    }
   
    public Product(string name, decimal price,Guid guid=new Guid())
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Product name cannot be empty");
        }
        if (price<0 || price==0)
        {
            throw new ArgumentException("Product price cannot be negative");
        }
        Name=name;
        Price=price;
        Id=guid;
    }

    
}