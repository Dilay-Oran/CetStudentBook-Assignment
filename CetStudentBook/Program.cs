using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CetStudentBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<CetStudentBook.Data.ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<CetStudentBook.Data.ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<CetStudentBook.Data.ApplicationDbContext>();

                if (!context.Categories.Any())
                {
                    context.Categories.Add(new CetStudentBook.Models.Category { Name = "Book" });
                    context.Categories.Add(new CetStudentBook.Models.Category { Name = "Computer" });
                    context.Categories.Add(new CetStudentBook.Models.Category { Name = "Novel" });
                    context.SaveChanges();
                }
            }

            app.Run();
        }
    }
}