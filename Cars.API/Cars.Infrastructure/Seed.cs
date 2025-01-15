using Cars.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            // sprawdzamy, czy są już jacyś użytkownicy
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{DisplayName = "franek", UserName = "Franco123", Email = "franek@test.com"},
                    new AppUser{DisplayName = "asia", UserName = "Asiula123", Email = "asia@test.com"},
                    new AppUser{DisplayName = "darek", UserName = "Dario123", Email = "darek@test.com"},
                    new AppUser{DisplayName = "michal", UserName = "Szef123", Email = "michal@test.com"}
                };

                foreach (var user in users)
                {
                    // tworzy i jednocześnie zapisuje użytkowników do bazy danych
                    await userManager.CreateAsync(user, "Hase!l0123");
                }
            }

            // jeśli baza ma jakieś rekordy to nic nie rób
            if (context.Cars.Any()) return;
        }
        }
}
