﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using News_Mediator_API.Models;

namespace News_Mediator_API.Data
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // builder.HasMany(user => user.favouriteNews).WithOne(favouriteNews => favouriteNews.User).OnDelete(DeleteBehavior.Cascade);
        }
    }
}