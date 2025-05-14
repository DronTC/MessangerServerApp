using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessangerServerApp.Data.Configurations
{
    public class ChatUserConfiguration : IEntityTypeConfiguration<ChatUserEntity>
    {
        public void Configure(EntityTypeBuilder<ChatUserEntity> builder)
        {
            builder.HasKey(cu => new {cu.ChatId, cu.UserId});

            builder.HasOne(cu => cu.User)
                .WithMany(u => u.ChatUsers)
                .HasForeignKey(cu => cu.UserId);

            builder.HasOne(cu => cu.Chat)
                .WithMany(c => c.ChatUsers)
                .HasForeignKey(cu => cu.ChatId);

        }
    }
}
