
using BusinessLogic.Services;
//using BusinessLogic.Interfaces;
//using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
//using TravelTimeDatabasses.Models;
using System.Reflection;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.OpenApi.Models;
using Domain.Models;
using Domain.Interfaces;
using Domain.Interfaces.Service;
//using Domain.Wrapper;

namespace BackendApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //1
            //builder.Services.AddDbContext<TravelTimeContext>(option => option.UseSqlServer(builder.Configuration["ConnectionStrings"]));
            //2 
            builder.Services.AddDbContext<TravelTimeContext>(option => option.UseSqlServer("Server=DESKTOP-KROHT5G;Database=TravelTime;User Id=sa;Password=12345;TrustServerCertificate=True"));
            // Add services to the container.
            
            builder.Services.AddScoped<IRepositoryWrapper,RepositoryWrapper>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IContactListPmService, ContactListPmService>();
            builder.Services.AddScoped<IGroupService, GroupService>();
            builder.Services.AddScoped<IMessageGroupService, MessageGroupService>();
            builder.Services.AddScoped<INewsService, NewsService>();
            builder.Services.AddScoped<IPointService, PointService>();
            builder.Services.AddScoped<IPreferencesUserService, PreferencesUserService>();
            builder.Services.AddScoped<IRatingNewsUserService, RatingNewsUserService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IStoryVisitUserService, StoryVisitUserService>();
            builder.Services.AddScoped<ITravelService, TravelService>();
            builder.Services.AddScoped<ITypePointService, TypePointService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUsersGroupService, UsersGroupService>();
            builder.Services.AddScoped<IWayService, WayService>();
            

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
