using FighterApi.Models;

namespace FighterApi.Core;

public interface IUnitOfWork
{
    IFighterRepository Fighters{ get; }
    Task CompleteAsync();
}
