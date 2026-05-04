using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShoppingCart.Models;

namespace ShoppingCart;
using ShoppingCart.Models;

public class Helper
{
    public static void SeedProducts()
    {
        List < Product > products= new List<Product>();
        
        Product p1 = new Product("Product1", 100);
        Product p2 = new Product("Product2", 200);
        Product p3 = new Product("Product3", 300);
        Product p4 = new Product("Product4", 400);
        Product p5 = new Product("Product5", 500);
        Product p6 = new Product("Product6", 600);
        
        products.Add(p1);
        products.Add(p2);
        products.Add(p3);
        products.Add(p4);
        products.Add(p5);
        products.Add(p6);
        
    }
    
}