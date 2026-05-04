using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.Db;

public class ShoppingCartDb:DbContext
{
    
    string DbPath="C:\\Users\\tony_\\OneDrive - BTH Student\\lexicon .NET\\exercises\\ExcercisesCode" +
                  "\\ShoppingCart\\ShoppingCart";

    public DbSet<Product> Products{get;set;}
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}\\ShoppingCart.db");
}