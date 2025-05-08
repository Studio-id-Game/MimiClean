using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace StudioIdGames.MimiClean.Railway
{
    /// <summary>
    /// 特定の <see cref="CleanResult{TResult}"/> と紐づいた <see cref="CleanResultErrorList"/> を管理する識別子
    /// </summary>
    public readonly struct CleanResultErrorToken : ICleanResultErrorList, IDisposable, IEquatable<CleanResultErrorToken>
    {
        private static class Stock
        {
            private static readonly Dictionary<ushort, CleanResultErrorList> stock = new Dictionary<ushort, CleanResultErrorList>()
            {
                [0] = null,
            };

            private static ushort nextIndex = 1;
            private static readonly object stockLock = new object();

            public static ushort CreateId()
            {
                ushort id;

                lock (stockLock)
                {
                    id = nextIndex;

                    if (nextIndex == ushort.MaxValue)
                    {
                        nextIndex = 1;
                    }
                    else
                    {
                        nextIndex++;
                    }

                    if (stock.ContainsKey(nextIndex))
                    {
                        throw new NotSupportedException("Duplicate or overflow index.");
                    }

                    stock.Add(id, null);
                }

                return id;
            }

            public static bool TryPeakErrorList(ushort id, out CleanResultErrorList errorList)
            {
                if (id == 0)
                {
                    errorList = null;
                    return false;
                }

                lock (stockLock)
                {
                    return stock.TryGetValue(id, out errorList);
                }
            }

            /*
            public static CleanResultErrorList PeakError(ushort id)
            {
                if (id == 0) return null;

                CleanResultErrorList error;
                bool found;
                lock (stockLock)
                {
                    found = stock.TryGetValue(id, out error);
                }

                if (found)
                {
                    return error;
                }
                else
                {
                    throw new InvalidOperationException("id not found, PeakError() Can only call before Release().");
                }
            }
            */

            public static CleanResultErrorList GetErrorList(ushort id)
            {
                if (id == 0) return null;

                if (TryPeakErrorList(id, out var errorList))
                {
                    if (errorList == null)
                    {
                        errorList = new CleanResultErrorList();
                        lock (stockLock)
                        {
                            stock[id] = errorList;
                        }
                    }

                    return errorList;
                }
                else
                {
                    throw new InvalidOperationException("id not found, GetError() Can only call before Release().");
                }
            }

            public static void Release(ushort id)
            {
                if (id == 0) return;

                lock (stockLock)
                {
                    if (stock.TryGetValue(id, out var errorList))
                    {
                        errorList?.Dispose();
                        stock.Remove(id);
                        //Console.WriteLine($"Remove : {id}, Stocks : {stock.Count - 1}");
                    }
                }
            }
        }

        internal static CleanResultErrorToken Create()
        {
            return new CleanResultErrorToken(Stock.CreateId());
        }

        private CleanResultErrorToken(ushort id)
        {
            Id = id;
        }

        private ushort Id { get; }

        /// <inheritdoc/>
        public CleanResultState LastState
        {
            get
            {
                if (!Stock.TryPeakErrorList(Id, out var errorList))
                {
                    return CleanResultState.Used;
                }
                else if (errorList == null)
                {
                    return CleanResultState.Success;
                }
                else
                {
                    return errorList.LastState;
                }
            }
        }

        /// <inheritdoc/>
        public int Count
        {
            get
            {
                if (Stock.TryPeakErrorList(Id, out var errorList) && errorList != null)
                {
                    return errorList.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <inheritdoc/>
        public void AddError(CleanResultError error)
        {
            if (error == null) return;

            Stock.GetErrorList(Id).AddError(error);
        }

        /// <inheritdoc/>
        public void FixError(Predicate<CleanResultError> errorCheck)
        {
            if (errorCheck == null) return;
            if (!Stock.TryPeakErrorList(Id, out var errorList)) return;
            if (errorList == null) return;

            errorList.FixError(errorCheck);
        }

        /// <inheritdoc/>
        public void AddCancel(CancellationToken cancellationToken)
        {
            Stock.GetErrorList(Id).AddCancel(cancellationToken);
        }

        /// <summary>
        /// Box化を回避して列挙体を取得します。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CleanResultError> GetEnumerable()
        {
            if (Stock.TryPeakErrorList(Id, out var errorList) && errorList != null)
            {
                return errorList;
            }
            else
            {
                return Enumerable.Empty<CleanResultError>();
            }
        }

        /// <inheritdoc/>
        public IEnumerator<CleanResultError> GetEnumerator()
        {
            return GetEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerable().GetEnumerator();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Stock.Release(Id);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is CleanResultErrorToken token && Equals(token);
        }

        /// <inheritdoc/>
        public bool Equals(CleanResultErrorToken other)
        {
            return Id == other.Id;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        /// <inheritdoc/>
        public static bool operator ==(CleanResultErrorToken left, CleanResultErrorToken right)
        {
            return left.Equals(right);
        }

        /// <inheritdoc/>
        public static bool operator !=(CleanResultErrorToken left, CleanResultErrorToken right)
        {
            return !(left == right);
        }
    }
}
