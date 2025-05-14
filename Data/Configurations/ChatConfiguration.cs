using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessangerServerApp.Data.Configurations
{
    public class ChatConfiguration : IEntityTypeConfiguration<ChatEntity>
    {
        public void Configure(EntityTypeBuilder<ChatEntity> builder)
        {
            builder.HasMany(c => c.Messages)
                .WithOne(m => m.Chat);

            builder.HasMany(c => c.ChatUsers)
                .WithOne(cu => cu.Chat);
        }
    }
}
