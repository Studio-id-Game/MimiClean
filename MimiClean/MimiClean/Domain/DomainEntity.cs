using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Domain
{
    public abstract class DomainEntity : IDomainEntity
    {
        public virtual IEnumerable<T> M<T>() where T : class, IDomainModule
        {
            yield break;
        }
    }
}
