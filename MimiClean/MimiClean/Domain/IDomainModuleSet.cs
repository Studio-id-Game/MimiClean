using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Domain
{
    public interface IDomainModuleSet : IDomainModule, IEnumerable<IDomainModule>
    {
        IEnumerable<T> Get<T>() where T : class, IDomainModule;

        bool Add<T>() where T : class, IDomainModule, new();

        bool Add<T>(T value) where T : class, IDomainModule;

        bool Remove<T>(T value) where T : class, IDomainModule;
    }
}
