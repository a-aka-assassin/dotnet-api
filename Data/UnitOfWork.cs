using FighterApi.Core;
using FighterApi.Core.Repositories;
using FighterApi.Models;
using Microsoft.EntityFrameworkCore;
namespace FighterApi.Data;

public class UnitOfWork : IUnitOfWork, IDisposable

{
    private readonly ApiDbContext _context;

    public IFighterRepository Fighters {get; private set;}

    public UnitOfWork(ApiDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        var _logger = loggerFactory.CreateLogger(categoryName:"logs");
        Fighters = new FighterRepository(_context, _logger);
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}