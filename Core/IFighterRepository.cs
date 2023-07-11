using FighterApi.Models;

namespace FighterApi.Core;

public interface IFighterRepository: IGenerateInterface<FighterModel>
{
    Task<FighterModel?> GetByNum(int num);
}
