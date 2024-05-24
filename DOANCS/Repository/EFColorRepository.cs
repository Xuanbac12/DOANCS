
using DOANCS.Data;
using DOANCS.Models;
using DOANCS.Repository;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Repository
{
    public class EFColorRepository : IColorRepository
    {
        private readonly ApplicationDbContext _context;

        public EFColorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Tương tự như EFProductRepository, nhưng cho Category
        public async Task<IEnumerable<Color>> GetAllAsync()
        {
            return await _context.Colors.ToListAsync();
        }

        public async Task<Color> GetByIdAsync(int id)
        {
            return await _context.Colors.FindAsync(id);
        }

        public async Task AddAsync(Color color)
        {
            _context.Colors.Add(color);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Color color)
        {
            _context.Colors.Update(color);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var color = await _context.Colors.FindAsync(id);
            _context.Colors.Remove(color);
            await _context.SaveChangesAsync();
        }
    }
}
