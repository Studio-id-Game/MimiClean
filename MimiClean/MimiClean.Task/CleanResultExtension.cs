namespace StudioIdGames.MimiClean.Task
{
    using System.Threading.Tasks;

    public static class CleanResultExtension
    {
        public static CleanResultTask AsTask(this CleanResult<Task> @this)
        {
            return new CleanResultTask(@this);
        }

        public static CleanResultTask<T> AsTask<T>(this CleanResult<Task<T>> @this)
        {
            return new CleanResultTask<T>(@this);
        }

        public static CleanResultTask AsTask(this CleanResultBoxed<Task> @this)
        {
            return @this.Unbox().AsTask();
        }

        public static CleanResultTask<T> AsTask<T>(this CleanResultBoxed<Task<T>> @this)
        {
            return @this.Unbox().AsTask();
        }

        public static CleanResultTaskAwaiter GetAwaiter(this CleanResult<Task> @this)
        {
            return @this.AsTask().GetAwaiter();
        }

        public static CleanResultTaskAwaiter<T> GetAwaiter<T>(this CleanResult<Task<T>> @this)
        {
            return @this.AsTask().GetAwaiter();
        }

        public static CleanResultTaskAwaiter GetAwaiter(this CleanResultBoxed<Task> @this)
        {
            return @this.Unbox().GetAwaiter();
        }

        public static CleanResultTaskAwaiter<T> GetAwaiter<T>(this CleanResultBoxed<Task<T>> @this)
        {
            return @this.Unbox().GetAwaiter();
        }
    }
}
