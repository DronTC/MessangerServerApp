using AutoMapper;
using Data.Entities;
using MessangerServerApp.DTOs.Message;
using MessangerServerApp.DTOs.User;

namespace MessangerServerApp.Profiles
{
    public class MessageProfile: Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageEntity, MessageDTO>();
            CreateMap<CreateMessageDTO, MessageEntity>();
        }
    }
}
