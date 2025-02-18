using System;

namespace StudioIdGames.MimiClean
{
    /// <summary>
    /// Static Type Caching を利用して、<see cref="Singleton{TInterface, TSelf}"/>で実装された機能を管理します。
    /// </summary>
    internal static class SingletonMap<TInterface>
        where TInterface : class
    {
        private static TInterface instance;

        /// <summary>
        /// 現在利用されているinstance。nullの場合エラーをスローします。
        /// </summary>
        public static TInterface Instance
        {
            get
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException($"Need set instance before this operation. ({typeof(TInterface)})");
                }

                return instance;
            }
        }

        /// <summary>
        /// 現在利用されているinstanceを解放します。実際に解放した場合はtrueを返します。
        /// </summary>
        /// <returns></returns>
        public static bool Unset()
        {
            if (IsEmpty)
            {
                return false;
            }
            else
            {
                instance = null;
                return true;
            }
        }

        /// <summary>
        /// TInstanceのinstanceを利用します。設定に成功した場合はtrueを返します。
        /// </summary>
        public static bool Set<TInstance>()
            where TInstance : TInterface, new()
        {
            if (IsEmpty)
            {
                instance = new TInstance();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 利用するinstanceをTInstanceに変更します。実際に変更した場合はtrueを返します。
        /// </summary>
        /// <param name="service"></param>
        public static bool OverWrite<TInstance>()
            where TInstance : TInterface, new()
        {
            if (instance != null && instance is TInstance)
            {
                return false;
            }
            else
            {
                instance = new TInstance();
                return true;
            }
        }

        /// <summary>
        /// Set() か OverWrite() のどちらかを呼び出します。
        /// </summary>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public static bool SetOrOverWrite<TInstance>(bool overwrite)
            where TInstance : TInterface, new()
        {
            if (overwrite) { return OverWrite<TInstance>(); }
            return Set<TInstance>();
        }

        /// <summary>
        /// 現在instanceが利用可能でない場合、trueを返します。
        /// </summary>
        public static bool IsEmpty => instance is null;
    }
}
