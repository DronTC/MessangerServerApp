using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerServerApp.Data.Configurations
{
    public class UserConfigutation : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .HasMany(u => u.Messages)
                .WithOne(m => m.User);

            builder
                .HasMany(u => u.ChatUsers)
                .WithOne(cu => cu.User);
        }
    }
}
