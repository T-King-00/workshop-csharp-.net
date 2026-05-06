using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShoppingCart.Db;
using ShoppingCart.Models;

namespace ShoppingCart;
using ShoppingCart.Models;

public class SeedingData
{
    public static IEnumerable<Product> SeedProducts()
    {
        List < Product > products= new List<Product>();
        
        Product p1 = new Product("Product1", 100,new Guid("2fefe38a-a237-40cb-a7d9-888cd52bbffa"));
        Product p2 = new Product("Product2", 200,new Guid("5c91f906-b10e-4686-9c9b-cb39fd520de8"));
        Product p3 = new Product("Product3", 300,new Guid("aeafbc3a-6b55-4bf6-ba5a-8350e20db908"));
        Product p4 = new Product("Product4", 400,new Guid("df36e4d1-dd05-4363-a28d-8adf42790ab6"));
        Product p5 = new Product("Product5", 500,new Guid("f2ebeef4-6c76-46bb-8036-816bb5890d34"));
        Product p6 = new Product("Product6", 600,new Guid("f34747f7-3d6d-4484-8c58-55e8ac69f7ab"));
        
        products.Add(p1);
        products.Add(p2);
        products.Add(p3);
        products.Add(p4);
        products.Add(p5);
        products.Add(p6);
        
        return products.AsEnumerable();
        
    }
    
    public static User SeedUser()
    {
        User user = new User();
        user.Id = new Guid("AFEFE389-A237-40CB-A7D9-888CD52BBFFA");
        
        return user;
    }
}