using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ApplicationExtension{
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app){
            RepositoryContext context = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<RepositoryContext>();

            if(context.Database.GetPendingMigrations().Any()){
                context.Database.Migrate();
            }
        }

        public static void ConfigureLocalization(this WebApplication app){

            app.UseRequestLocalization(options=>{
                options.AddSupportedUICultures("tr-TR")
                .AddSupportedUICultures("tr-TR")
                .SetDefaultCulture("tr-TR");
            });
        }

        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app){
            const string adminUser = "Admin";
            const string adminPassword = "passord+123";

            //UserManager
            UserManager<IdentityUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            //RoleManager
            RoleManager<IdentityRole> roleManager = app
                .ApplicationServices
                .CreateAsyncScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            IdentityUser user  = await userManager.FindByNameAsync(adminUser);
            if(user is null){
                user = new IdentityUser(){
                    Email = "huseyinimal@hotmail.com",
                    PhoneNumber = "5043334455",
                    UserName = adminUser,
                    
                };

                var result = await userManager.CreateAsync(user, adminPassword);
                if(!result.Succeeded)
                    throw new Exception("Admin user couldn't not created");

                var roleResult = await userManager.AddToRolesAsync(user, 
                roleManager
                    .Roles
                    .Select(r=>r.Name)
                    .ToList()
               );

               if(!roleResult.Succeeded)
                    throw new Exception("error");
                

            }

        }

    }
}