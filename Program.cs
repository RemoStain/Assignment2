using Assignment2.Data;
using Assignment2.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services for MVC
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<LmsDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Register repositories for dependency injection
            builder.Services.AddScoped<BookRepository>();
            builder.Services.AddScoped<ReaderRepository>();
            builder.Services.AddScoped<BorrowingRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
