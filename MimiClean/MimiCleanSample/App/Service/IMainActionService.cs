using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Domain;
using StudioIdGames.MimiCleanSample.Domain.Type;

namespace StudioIdGames.MimiCleanSample.App.Service
{
    internal interface IMainActionService : IService
    {
        public CleanResult<CleanResult.Void> Invoke(MainActions mainActions, bool dummyMode);
    }
}