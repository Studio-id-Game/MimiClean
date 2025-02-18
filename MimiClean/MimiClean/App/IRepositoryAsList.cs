using System.Collections.Generic;

namespace StudioIdGames.MimiClean.App
{
    public interface IRepositoryAsList<TValue> : IRepository, IList<TValue>
    {
    }
}