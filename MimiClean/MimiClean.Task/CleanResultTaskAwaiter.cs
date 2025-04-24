namespace StudioIdGames.MimiClean.Task
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    /// <summary>
    /// 参考：<a href="https://ufcpp.net/study/csharp/sp5_awaitable.html#awaiter"/><br/>
    /// <see cref="CleanResult{TResult}"/>(TResult=<see cref="Task{TResult}"/>) を待機するためのAwaiterです。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public readonly struct CleanResultTaskAwaiter<T> : ICriticalNotifyCompletion, INotifyCompletion
    {
        private readonly CleanResultState state;
        private readonly CleanResultError error;
        private readonly Task<T> task;
        private readonly TaskAwaiter<T> taskAwaiter;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="cleanResult"></param>
        public CleanResultTaskAwaiter(CleanResult<Task<T>> cleanResult)
        {
            state = cleanResult.State;
            error = cleanResult.Error;

            if (cleanResult.Result == null)
            {
                task = null;
                taskAwaiter = default;
            }
            else
            {
                task = cleanResult.Result;
                taskAwaiter = task.GetAwaiter();
            }
        }

        /// <inheritdoc cref="TaskAwaiter{TResult}.IsCompleted"/>
        public bool IsCompleted => taskAwaiter.IsCompleted;

        /// <inheritdoc cref="TaskAwaiter{TResult}.GetResult"/>
        public CleanResult<T> GetResult()
        {
            if (state != CleanResultState.Success || task == null)
            {
                return new CleanResult<T>(state, default, error);
            }

            T res = default;
            try
            {
                res = taskAwaiter.GetResult();

                return GetCleanResult(res);
            }
            catch (OperationCanceledException e)
            {
                return CleanResult<T>.Canceled(res, e);
            }
        }

        private CleanResult<T> GetCleanResult(T res)
        {
            switch (task.Status)
            {
                case TaskStatus.Canceled:
                    return CleanResult<T>.Canceled();

                case TaskStatus.Faulted:
                    return CleanResult<T>.Failed(task.Exception);

                case TaskStatus.RanToCompletion:
                    return CleanResult<T>.Success(res);

                // case TaskStatus.Created:
                // case TaskStatus.Running:
                // case TaskStatus.WaitingForActivation:
                // case TaskStatus.WaitingForChildrenToComplete:
                // case TaskStatus.WaitingToRun:
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <inheritdoc cref="TaskAwaiter{TResult}.OnCompleted"/>
        public void OnCompleted(Action continuation)
        {
            taskAwaiter.OnCompleted(continuation);
        }

        /// <inheritdoc cref="TaskAwaiter{TResult}.UnsafeOnCompleted"/>
        public void UnsafeOnCompleted(Action continuation)
        {
            taskAwaiter.UnsafeOnCompleted(continuation);
        }
    }

    /// <summary>
    /// 参考：<a href="https://ufcpp.net/study/csharp/sp5_awaitable.html#awaiter"/><br/>
    /// <see cref="CleanResult{TResult}"/>(TResult=<see cref="Task"/>) を待機するためのAwaiterです。
    /// </summary>
    public readonly struct CleanResultTaskAwaiter : ICriticalNotifyCompletion, INotifyCompletion
    {
        private readonly CleanResultState state;
        private readonly CleanResultError error;
        private readonly Task task;
        private readonly TaskAwaiter taskAwaiter;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="cleanResult"></param>
        public CleanResultTaskAwaiter(CleanResult<Task> cleanResult)
        {
            state = cleanResult.State;
            error = cleanResult.Error;

            if (cleanResult.Result == null)
            {
                task = null;
                taskAwaiter = default;
            }
            else
            {
                task = cleanResult.Result;
                taskAwaiter = task.GetAwaiter();
            }
        }

        /// <inheritdoc cref="TaskAwaiter.IsCompleted"/>
        public bool IsCompleted => taskAwaiter.IsCompleted;

        /// <inheritdoc cref="TaskAwaiter.GetResult"/>
        public CleanResult<CleanResult.Void> GetResult()
        {
            if (state != CleanResultState.Success || task == null)
            {
                return new CleanResult<CleanResult.Void>(state, default, error);
            }

            try
            {
                taskAwaiter.GetResult();

                return GetCleanResult();
            }
            catch (OperationCanceledException e)
            {
                return CleanResult<CleanResult.Void>.Canceled(default, e);
            }
        }

        private CleanResult<CleanResult.Void> GetCleanResult()
        {
            switch (task.Status)
            {
                case TaskStatus.Canceled:
                    return CleanResult.Canceled();

                case TaskStatus.Faulted:
                    return CleanResult.Failed(task.Exception);

                case TaskStatus.RanToCompletion:
                    return CleanResult.Success();

                // case TaskStatus.Created:
                // case TaskStatus.Running:
                // case TaskStatus.WaitingForActivation:
                // case TaskStatus.WaitingForChildrenToComplete:
                // case TaskStatus.WaitingToRun:
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <inheritdoc cref="TaskAwaiter.OnCompleted"/>
        public void OnCompleted(Action continuation)
        {
            taskAwaiter.OnCompleted(continuation);
        }

        /// <inheritdoc cref="TaskAwaiter.UnsafeOnCompleted"/>
        public void UnsafeOnCompleted(Action continuation)
        {
            taskAwaiter.UnsafeOnCompleted(continuation);
        }
    }
}
