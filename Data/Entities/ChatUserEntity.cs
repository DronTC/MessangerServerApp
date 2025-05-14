using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ChatUserEntity
    {
        public int ChatId { get; set; }
        public ChatEntity Chat { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
