namespace StudioIdGames.MimiClean.Task
{
    using System.Threading.Tasks;

    /// <summary>
    /// 参考：https://ufcpp.net/study/csharp/sp5_awaitable.html#awaiter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public readonly ref struct CleanResultTask<T>
    {
        public CleanResult<Task<T>> CleanResult { get; }

        public CleanResultTask(in CleanResult<Task<T>> cleanResult)
        {
            CleanResult = cleanResult;
        }

        public CleanResultTaskAwaiter<T> GetAwaiter()
        {
            return new CleanResultTaskAwaiter<T>(CleanResult);
        }
    }

    /// <summary>
    /// 参考：https://ufcpp.net/study/csharp/sp5_awaitable.html#awaiter
    /// </summary>
    public readonly ref struct CleanResultTask
    {
        public CleanResult<Task> CleanResult { get; }

        public CleanResultTask(in CleanResult<Task> cleanResult)
        {
            CleanResult = cleanResult;
        }

        public CleanResultTaskAwaiter GetAwaiter()
        {
            return new CleanResultTaskAwaiter(CleanResult);
        }
    }
}
