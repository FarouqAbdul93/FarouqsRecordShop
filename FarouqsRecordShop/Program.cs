
using FarouqsRecordShop.Models;
using FarouqsRecordShop.Repository;
using FarouqsRecordShop.Services;
using Microsoft.EntityFrameworkCore;

namespace FarouqsRecordShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
            builder.Services.AddScoped<IAlbumService, AlbumService>();

            
            var isDevelopment = builder.Environment.IsDevelopment();

            if (isDevelopment)
            {
                builder.Services.AddDbContext<RecordShopContext>(options =>
                    options.UseInMemoryDatabase("RecordShopDb"));
            }
            else
            {
                builder.Services.AddDbContext<RecordShopContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("RecordShopDb")));
            }

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<RecordShopContext>();
                context.Database.EnsureCreated();

                if (!context.Albums.Any())
                {
                    context.Albums.AddRange(
                        new Album { Title = "The Documentary", Artist = "The Game", Genre = "Hip-Hop", ReleaseYear = 2005, Stock = 5 },
                        new Album { Title = "Thriller", Artist = "Michael Jackson", Genre = "Pop", ReleaseYear = 1982, Stock = 3 },
                        new Album { Title = "Konvicted", Artist = "Akon", Genre = "R&B", ReleaseYear = 2006, Stock = 8 }
                    );
                    context.SaveChanges();
                }
            }

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
