
using DOANCS.Data;
using DOANCS.Models;
using DOANCS.Repository;
using Microsoft.EntityFrameworkCore;

namespace Do_An.Repository
{
    public class EFSizeRepository : ISizeRepository
    {
        private readonly ApplicationDbContext _context;

        public EFSizeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Tương tự như EFProductRepository, nhưng cho Category
        public async Task<IEnumerable<Size>> GetAllAsync()
        {
            return await _context.Sizes.ToListAsync();
        }

        public async Task<Size> GetByIdAsync(int id)
        {
            return await _context.Sizes.FindAsync(id);
        }

        public async Task AddAsync(Size Size)
        {
            _context.Sizes.Add(Size);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Size Size)
        {
            _context.Sizes.Update(Size);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var size = await _context.Sizes.FindAsync(id);
            _context.Sizes.Remove(size);
            await _context.SaveChangesAsync();
        }
    }
}
