using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class BeverageConfiguration : IEntityTypeConfiguration<Beverage>
    {
        public void Configure(EntityTypeBuilder<Beverage> builder)
        {
            builder.HasData(
                new Beverage
                {
                    Id = 1,
                    Name = "Coca-Cola",
                    Price = 10,
                    Count = 10,
                    ImageUrl = 
                    "https://images.unsplash.com/photo-1561758033-48d52648ae8b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1974&q=80.jpg"
                },
                new Beverage
                {
                    Id = 2,
                    Name = "Pepsi",
                    Price = 12,
                    Count = 10,
                    ImageUrl =
                    "https://images.unsplash.com/photo-1531384370597-8590413be50a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1974&q=80.jpg"
                });
        }
    }
}
