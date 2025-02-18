using System;
using System.Collections.Generic;
using System.Linq;
namespace StudioIdGames.MimiClean.App
{
    public abstract class RepositoryAsEnum<TInterface, TSelf, TValue> : RepositoryAsList<TInterface, TSelf, TValue>
        where TInterface : class, IRepositoryAsList<TValue>
        where TSelf : RepositoryAsEnum<TInterface, TSelf, TValue>, TInterface, new()
        where TValue : Enum
    {
        protected sealed override IList<TValue> List { get; } = Enum.GetValues(typeof(TValue)).Cast<TValue>().ToList();
    }
}