using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.Db;

public class ShoppingCartDb:DbContext
{
    
    string DbPath= "";

    public DbSet<Product> Products{get;set;}
    public DbSet<Cart> Carts{get;set;}
    public DbSet<CartItem> CartItems{get;set;}
    
    public DbSet<User> Users{get;set;}
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source=Db\\ShoppingCart.db");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(SeedingData.SeedProducts());
        modelBuilder.Entity<User>().HasData(SeedingData.SeedUser());


    }
    
    public void AddToDb(Product product)
    {
        try
        {
            this.Products.Add(product);
            this.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

 
    
}

