namespace StudioIdGames.MimiClean.App
{
    public static class Repository<TInterface>
        where TInterface : class, IRepository
    {
        /// <summary>
        /// 現在利用されているRepository。nullの場合エラーをスローします。
        /// </summary>
        public static TInterface I => SingletonMap<TInterface>.Instance;
    }

    public abstract class Repository<TInterface, TSelf, TValue> : Singleton<TInterface, TSelf>
        where TInterface : class, IRepository
        where TSelf : Repository<TInterface, TSelf, TValue>, TInterface, new()
    {

    }
}