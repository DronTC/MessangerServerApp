using AutoMapper;
using Data.Entities;
using MessangerServerApp.DTOs.Chat;
using MessangerServerApp.DTOs.User;

namespace MessangerServerApp.Profiles
{
    public class ChatProfile: Profile
    {
        public ChatProfile()
        {
            CreateMap<ChatEntity, ChatDTO>();
            CreateMap<CreateChatDTO, ChatEntity>();
        }
    }
}
