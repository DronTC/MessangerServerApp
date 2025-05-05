using Data.Interfaces;
using MessangerServerApp.Data;
using MessangerServerApp.Data.Repositories;
using MessangerServerApp.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace MessangerServerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
            
            
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();
            //builder.Services.AddScoped<MessageService>();
            builder.Services.AddScoped<IChatRepository, ChatRepository>();
            //builder.Services.AddScoped<ChatService>();
            builder.Services.AddScoped<IChatUserRepository, ChatUserRepository>();
            //builder.Services.AddScoped<ChatUserService>();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            var app = builder.Build();

            app.Run();
        }
    }
}
