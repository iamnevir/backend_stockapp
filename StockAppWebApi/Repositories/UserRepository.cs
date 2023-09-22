using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockAppWebApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly StockAppDbContext _context;
    private readonly IConfiguration _configuration;

    public UserRepository(StockAppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<User?> Register(User user)
    {
        var parameters = new[]
        {
            new SqlParameter("@username", user.Username),
            new SqlParameter("@password", user.HashedPassword),
            new SqlParameter("@email", user.Email),
            new SqlParameter("@phone", user.Phone),
            new SqlParameter("@full_name", user.FullName),
            new SqlParameter("@date_of_birth", user.DateOfBirth ?? (object)DBNull.Value),
            new SqlParameter("@country", user.Country ?? (object)DBNull.Value),
        };
        IEnumerable<User> result = await _context.Users.FromSqlRaw(
            "EXECUTE dbo.RegisterUser " +
            "@username, " +
            "@password, " +
            "@email, " +
            "@phone, " +
            "@full_name, " +
            "@date_of_birth, " +
            "@country",
            parameters).ToListAsync();
        return result.FirstOrDefault();

    }
    public async Task<string> Login(LoginViewModel loginViewModel)
    {
        var parameters = new[]
        {
            new SqlParameter("@email", loginViewModel.Email),
            new SqlParameter("@password", loginViewModel.Password),
        };
        IEnumerable<User> result = await _context.Users.FromSqlRaw(
            "EXECUTE dbo.CheckLogin @email, @password",
            parameters).ToListAsync();
        User? user = result.FirstOrDefault();
        if (user is not null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"] ?? "");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.HomePhone, user.Phone),

                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }
        else
        {
            throw new Exception("Wrong infomation!");
        }

    }
    public async Task<User?> GetUserById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetUserByName(string name)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == name);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
