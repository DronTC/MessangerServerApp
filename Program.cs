using Data.Interfaces;
using MessangerServerApp.Data;
using MessangerServerApp.Data.Repositories;
using MessangerServerApp.Services.Data;
using MessangerServerApp.Services.Interfaces;
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
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();
            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddScoped<IChatRepository, ChatRepository>();
            builder.Services.AddScoped<IChatService, ChatService>();

            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            var app = builder.Build();

            app.MapControllers();
            app.Run();
        }
    }
}
