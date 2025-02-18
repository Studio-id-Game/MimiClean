using System.Collections.Generic;

namespace StudioIdGames.MimiClean.App
{
    public interface IRepositoryAsDictionary<TKey, TValue> : IRepository, IDictionary<TKey, TValue>
    {
    }
}