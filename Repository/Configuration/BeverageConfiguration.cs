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
                    Price = 1.5m
                },
                new Beverage
                {
                    Id = 2,
                    Name = "Pepsi",
                    Price = 1.2m
                });
        }
    }
}
