using FighterApi.Data;
using FighterApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FighterApi.Core.Repositories;

public class FighterRepository : GenericRepository<FighterModel>, IFighterRepository
{
    public FighterRepository(ApiDbContext context, ILogger logger) : base(context, logger)
    {
    }

    public override async Task<IEnumerable<FighterModel>> All()
    {
        try
        {
            return await _context.Fighters.Where(x => x.Id < 100).ToListAsync();
        }
        catch (Exception ex)
        {
            
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public override async Task<FighterModel?> GetById(int id)
    {
        try
        {
            return await _context.Fighters.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            
            throw;
        }
    }
    public async Task<FighterModel?> GetByNum(int num)
    {
       try
       {
        return await _context.Fighters.FirstOrDefaultAsync(x => x.Number == num);
       }
       catch (Exception ex)
       {
        Console.WriteLine(ex.Message);
        throw;
       }
    }
}

