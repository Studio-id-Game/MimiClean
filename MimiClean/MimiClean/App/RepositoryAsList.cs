using System.Collections;
using System.Collections.Generic;
namespace StudioIdGames.MimiClean.App
{
    /// <summary>
    /// List型のデータストアを表現する為の抽象クラスです。
    /// </summary>
    /// <typeparam name="TValue">要素の型</typeparam>
    public abstract class RepositoryAsList<TInterface, TSelf, TValue> : Repository<TInterface, TSelf, TValue>, IList<TValue>, IRepositoryAsList<TValue>
        where TInterface : class, IRepositoryAsList<TValue>
        where TSelf : RepositoryAsList<TInterface, TSelf, TValue>, TInterface, new()
    {
        public TValue this[int index] { get => List[index]; set => List[index] = value; }

        public int Count => List.Count;

        public bool IsReadOnly => List.IsReadOnly;

        protected abstract IList<TValue> List { get; }

        public void Add(TValue item)
        {
            List.Add(item);
        }

        public void Clear()
        {
            List.Clear();
        }

        public bool Contains(TValue item)
        {
            return List.Contains(item);
        }

        public void CopyTo(TValue[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }

        public override IEnumerator<TValue> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        public int IndexOf(TValue item)
        {
            return List.IndexOf(item);
        }

        public void Insert(int index, TValue item)
        {
            List.Insert(index, item);
        }

        public bool Remove(TValue item)
        {
            return List.Remove(item);
        }

        public void RemoveAt(int index)
        {
            List.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)List).GetEnumerator();
        }
    }
}