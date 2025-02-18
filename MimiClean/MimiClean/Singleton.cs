using System;

namespace StudioIdGames.MimiClean
{
    /// <summary>
    /// 代替可能でシングルトン（static）な機能を抽象化する事が出来ます。
    /// <see cref="SingletonMap{TInterface}"/> を用いて Static Type Caching を行います。
    /// </summary>
    public abstract class Singleton<TInterface, TSelf>
        where TInterface : class
        where TSelf : Singleton<TInterface, TSelf>, TInterface, new()
    {
        /// <summary>
        /// 現在利用されているinstance。nullの場合エラーをスローします。
        /// </summary>
        public static TInterface Instance => SingletonMap<TInterface>.Instance;

        /// <summary>
        /// 現在instanceが利用可能でない場合、trueを返します。
        /// </summary>
        public static bool IsEmpty => SingletonMap<TInterface>.IsEmpty;

        /// <summary>
        /// このインスタンスがinstanceとして利用されている場合、trueを返します。
        /// </summary>
        public static bool IsUsed => SingletonMap<TInterface>.Instance is TSelf;

        /// <summary>
        /// 現在利用されているinstanceを解放します。実際に解放した場合はtrueを返します。
        /// </summary>
        /// <returns></returns>
        public static bool Unset() => SingletonMap<TInterface>.Unset();

        /// <summary>
        /// 派生クラスをinstanceとして利用します。
        /// </summary>
        public static bool Use(bool overwrite = false)
        {
            return SingletonMap<TInterface>.SetOrOverWrite<TSelf>(overwrite);
        }

        /// <summary>
        /// 現在、他instanceが利用中でない場合、このインスタンスをinstanceとして利用して、自身を返します。
        /// 現在、他instanceが利用中の場合、エラーをスローします。
        /// </summary>
        public static bool UseOrError()
        {
            if (SingletonMap<TInterface>.Set<TSelf>()) return true;
            throw new InvalidOperationException("Any service is alrady used.");
        }
    }
}
