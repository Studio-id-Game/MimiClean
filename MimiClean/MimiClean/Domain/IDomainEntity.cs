using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Domain
{
    public interface IDomainEntity
    {
        IEnumerable<T> M<T>() where T : class, IDomainModule;
    }
}
