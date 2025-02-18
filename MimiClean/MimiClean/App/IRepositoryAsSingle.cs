using System.Collections.Generic;

namespace StudioIdGames.MimiClean.App
{
    public interface IRepositoryAsSingle<TValue> : IRepository, IEnumerable<TValue>
    {
        TValue Value { get; }
    }
}