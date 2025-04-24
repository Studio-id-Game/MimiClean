using Cysharp.Threading.Tasks;
using StudioIdGames.MimiClean;
using System;
using System.Runtime.CompilerServices;

namespace Assets.StudioIdGames.MimiCleanUnity.Runtime.CleanResultUniTask
{
    /// <summary>
    /// 参考：<a href="https://ufcpp.net/study/csharp/sp5_awaitable.html#awaiter"/><br/>
    /// <see cref="CleanResult{TResult}"/>(TResult=<see cref="UniTask{TResult}"/>) を待機するためのAwaiterです。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public readonly struct CleanResultUniTaskAwaiter<T> : ICriticalNotifyCompletion, INotifyCompletion
    {
        private readonly CleanResultState state;
        private readonly CleanResultError error;
        private readonly UniTask<T> task;
        private readonly UniTask<T>.Awaiter taskAwaiter;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="cleanResult"></param>
        public CleanResultUniTaskAwaiter(CleanResult<UniTask<T>> cleanResult)
        {
            state = cleanResult.State;
            error = cleanResult.Error;
            if (cleanResult.State == CleanResultState.Success)
            {
                task = cleanResult.Result;
                taskAwaiter = task.GetAwaiter();
            }
            else
            {
                task = default;
                taskAwaiter = default;
            }
        }

        /// <inheritdoc cref="UniTask{T}.Awaiter.IsCompleted"/>
        public bool IsCompleted => taskAwaiter.IsCompleted;

        /// <inheritdoc cref="UniTask{T}.Awaiter.GetResult"/>
        public CleanResult<T> GetResult()
        {
            if (state != CleanResultState.Success)
            {
                return new CleanResult<T>(state, default, error);
            }

            T res = default;
            try
            {
                res = taskAwaiter.GetResult();
                return CleanResult<T>.Success(res);
            }
            catch (OperationCanceledException e)
            {
                return CleanResult<T>.Canceled(res, e);
            }
        }

        /// <inheritdoc cref="UniTask{T}.Awaiter.OnCompleted"/>
        public void OnCompleted(Action continuation)
        {
            taskAwaiter.OnCompleted(continuation);
        }

        /// <inheritdoc cref="UniTask{T}.Awaiter.UnsafeOnCompleted"/>
        public void UnsafeOnCompleted(Action continuation)
        {
            taskAwaiter.UnsafeOnCompleted(continuation);
        }
    }

    /// <summary>
    /// 参考：<a href="https://ufcpp.net/study/csharp/sp5_awaitable.html#awaiter"/><br/>
    /// <see cref="CleanResult{TResult}"/>(TResult=<see cref="UniTask"/>) を待機するためのAwaiterです。
    /// </summary>
    public readonly struct CleanResultUniTaskAwaiter : ICriticalNotifyCompletion, INotifyCompletion
    {
        private readonly CleanResultState state;
        private readonly CleanResultError error;
        private readonly UniTask task;
        private readonly UniTask.Awaiter taskAwaiter;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="cleanResult"></param>
        public CleanResultUniTaskAwaiter(CleanResult<UniTask> cleanResult)
        {
            state = cleanResult.State;
            error = cleanResult.Error;

            if (cleanResult.State == CleanResultState.Success)
            {
                task = cleanResult.Result;
                taskAwaiter = task.GetAwaiter();
            }
            else
            {
                task = default;
                taskAwaiter = default;
            }
        }

        /// <inheritdoc cref="UniTask.Awaiter.IsCompleted"/>
        public bool IsCompleted => taskAwaiter.IsCompleted;

        /// <inheritdoc cref="UniTask.Awaiter.GetResult"/>
        public CleanResult<CleanResult.Void> GetResult()
        {
            if (state != CleanResultState.Success)
            {
                return new CleanResult<CleanResult.Void>(state, default, error);
            }

            try
            {
                taskAwaiter.GetResult();
                return CleanResult.Success();
            }
            catch (OperationCanceledException e)
            {
                return CleanResult<CleanResult.Void>.Canceled(default, e);
            }
        }

        /// <inheritdoc cref="UniTask.Awaiter.OnCompleted"/>
        public void OnCompleted(Action continuation)
        {
            taskAwaiter.OnCompleted(continuation);
        }

        /// <inheritdoc cref="UniTask.Awaiter.UnsafeOnCompleted"/>
        public void UnsafeOnCompleted(Action continuation)
        {
            taskAwaiter.UnsafeOnCompleted(continuation);
        }
    }
}
