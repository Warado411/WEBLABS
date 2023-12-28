using LAB_1.Data;
using Microsoft.AspNetCore.Identity;
using WEB.Models;

namespace WEB.Data
{
    public static class DbInitializer
    {
        public static async Task Seed(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            //await context.Database.EnsureDeletedAsync();
            // создать БД, если она еще не создана
            await context.Database.EnsureCreatedAsync();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            if (!context.Sections.Any())
            {
                await context.Sections.AddRangeAsync(
                    new Section { Name = "Одежда" },
                    new Section { Name = "Мебель" },
                    new Section { Name = "Компьютеры" });
                await context.SaveChangesAsync();
            }

            if (!context.Goods.Any())
            {
                await context.Goods.AddRangeAsync(
                    new Good { Name = "Жилет", Description = "Синий", Count = 5, SectionId = 1, Image = "Shirt.jpg" },
                    new Good { Name = "Кофта", Description = "Шерстяная", Count = 6, SectionId = 1, Image = "Jacket.jpg" },
                    new Good { Name = "Моноблок", Description = "Apple, 27 дюймов", Count = 3, SectionId = 3, Image = "Screen.jpg" },
                    new Good { Name = "Стул", Description = "Деревянный, жёсткий", Count = 2, SectionId = 2, Image = "Chair.jpg" },
                    new Good { Name = "Кресло", Description = "Мягкое, кожаное", Count = 7, SectionId = 2, Image = "Armchair.jpg" });
                await context.SaveChangesAsync();
            }            

        }
    }
}
