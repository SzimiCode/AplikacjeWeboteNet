using Cars.Infrastructure;
using Cars.Domain;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Cars.API
{
    public static class IdentityService
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<DataContext>();

            // klucz musi być identyczny jak klucz szyfrujący w TokenService
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hiper tajnehaslo123!!!hasloHiper tajnehaslo123!!!hasloHiper tajnehaslo123!!!hasloHiper tajnehaslo123!!!hasloHiper tajnehaslo123!!!haslo"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                // jak walidować token
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, // Walidacja klucza podpisującego token
                    IssuerSigningKey = key, // Użycie wcześniej zdefiniowanego klucza symetrycznego do weryfikacji tokenu
                    ValidateIssuer = false, // Nie walidujemy wystawcy tokenu (Issuer)
                    ValidateAudience = false // Nie walidujemy odbiorcy tokenu (Audience)
                };
            });

            // dodanie serwisu odpowiedzialnego za tworzenie tokenów
            services.AddScoped<TokenService>();

            return services;
        }
    }
}
