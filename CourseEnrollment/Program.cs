using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Repositories;
using System;

namespace CourseEnrollment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("CrsDb");

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region My Services
            // Register Database Service using EFCore In memory database
            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseInMemoryDatabase(connectionString));

            // Register repositories in the unit of work
            builder.Services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>(); 
            #endregion


            var app = builder.Build();

            #region Ensure Database Creation and seeding
            // force the application go to the OnModelCreating method to 
            // make data seeding on the first application execution
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.EnsureCreated();
            } 
            #endregion


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
