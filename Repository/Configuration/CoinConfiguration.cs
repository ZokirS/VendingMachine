﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class CoinConfiguration : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.HasData(
                new Coin
                {
                    Id = 1,
                    Value = 1,
                    IsBlocked = false,
                },
                new Coin
                {
                    Id = 2,
                    Value = 2,
                    IsBlocked = false
                },
                new Coin
                {
                    Id = 3,
                    Value = 5,
                    IsBlocked = false
                },
                new Coin
                {
                    Id = 4,
                    Value = 10,
                    IsBlocked = false
                });
        }
    }
}
