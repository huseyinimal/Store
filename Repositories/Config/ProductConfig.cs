using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(p=>p.ProductId);
            builder.Property(p=>p.ProductName).IsRequired();
            builder.Property(p=>p.Price).IsRequired();
           builder.HasData(
             new Product() { ProductId = 2,CategoryId=2,ImageUrl="/images/1.png", ProductName = "Keyboard", Price = 500 ,ShowCase=false},
            new Product() { ProductId = 1,CategoryId=2,ImageUrl="/images/2.png", ProductName = "Computer", Price = 17_000 ,ShowCase=false},
              new Product() { ProductId = 3,CategoryId=2,ImageUrl="/images/3.png", ProductName = "Mouse", Price = 7_000 ,ShowCase=false},
               new Product() { ProductId =4,CategoryId=2,ImageUrl="/images/4.png", ProductName = "Monitor", Price = 1_000 ,ShowCase=false},
               new Product() { ProductId = 5,CategoryId=2,ImageUrl="/images/5.png", ProductName = "Deck", Price = 1_500 ,ShowCase=false},
               new Product() { ProductId = 6,CategoryId=1,ImageUrl="/images/6.png", ProductName = "1984", Price = 50 ,ShowCase=false},
               new Product() { ProductId = 7,CategoryId=1,ImageUrl="/images/7.png", ProductName = "Animal Farm", Price = 30 ,ShowCase=false},
               new Product() { ProductId = 8,CategoryId=2,ImageUrl="/images/8.png", ProductName = "Tablet", Price = 3000 ,ShowCase=true},
               new Product() { ProductId = 9,CategoryId=1,ImageUrl="/images/9.png", ProductName = "Foundation", Price = 130 ,ShowCase=true},
               new Product() { ProductId = 10,CategoryId=2,ImageUrl="/images/10.png", ProductName = "Earphone", Price = 800 ,ShowCase=true}

           );
        }
    }
}