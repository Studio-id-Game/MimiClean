using System;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean
{
    /// <summary>
    /// v2.0で利用予定。せっかく書いたので置いておく
    /// </summary>
    internal readonly struct CleanResultErrorToken
    {
        private static readonly Dictionary<ushort, CleanResultError> stock = new Dictionary<ushort, CleanResultError>()
        {
            [0] = null,
        };

        private static int nextIndex = 1;
        private static readonly object stockLock = new object();

        public static CleanResultErrorToken Create(CleanResultError exception)
        {
            if (exception == null)
            {
                return new CleanResultErrorToken(0);
            }

            ushort id;

            lock (stockLock)
            {
                id = (ushort)nextIndex;

                if (nextIndex == ushort.MaxValue)
                {
                    for (ushort i = 1; i <= ushort.MaxValue; i++)
                    {
                        if (stock.ContainsKey(i))
                        {
                            continue;
                        }
                        else
                        {
                            nextIndex = i;
                        }
                    }
                }
                else
                {
                    nextIndex++;
                }

                stock.Add(id, exception);
            }

            return new CleanResultErrorToken(id);
        }

        private CleanResultErrorToken(ushort id)
        {
            Id = id;
        }

        public ushort Id { get; }

        /// <summary>
        /// 一度目の呼び出しのみの結果を保証し、二度目以降の呼び出しの結果は未定義です。
        /// </summary>
        /// <returns></returns>
        public CleanResultError PopError()
        {
            if (Id == 0) return null;

            lock (stockLock)
            {
                if (stock.TryGetValue(Id, out var error))
                {
                    stock.Remove(Id);
                    return error;
                }
                else
                {
                    throw new InvalidOperationException("PopError() Can only call once. Please cache and use the first value you get.");
                }
            }
        }
    }
}
