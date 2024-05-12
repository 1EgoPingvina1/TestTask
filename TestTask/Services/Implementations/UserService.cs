using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        public readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context) => _context = context;

        public async Task<User> GetUser()
            => await _context.Users.Where(o => o.Orders.Any(d => d.CreatedAt.Year == 2003)).OrderByDescending(p => p.Orders.Sum(p => p.Price)).FirstOrDefaultAsync();



        public async Task<List<User>> GetUsers()
            => await _context.Users.Where(o => o.Orders.Any(date => date.CreatedAt.Year == 2004 && date.Status == Enums.OrderStatus.Paid)).ToListAsync();
        
    }
}
