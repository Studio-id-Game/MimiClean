namespace StudioIdGames.MimiClean.Task
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    /// <summary>
    /// 参考： https://ufcpp.net/study/csharp/sp5_awaitable.html#awaiter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public readonly struct CleanResultTaskAwaiter<T> : ICriticalNotifyCompletion, INotifyCompletion
    {
        private readonly CleanResultState state;
        private readonly CleanResultError error;
        private readonly Task<T> task;
        private readonly TaskAwaiter<T> taskAwaiter;

        public CleanResultTaskAwaiter(in CleanResult<Task<T>> cleanResult)
        {
            state = cleanResult.State;
            error = cleanResult.Error;

            if (cleanResult.Result == null)
            {
                task = Task.FromResult<T>(default);
            }
            else
            {
                task = cleanResult.Result;
            }

            taskAwaiter = task.GetAwaiter();
        }

        public bool IsCompleted => taskAwaiter.IsCompleted;

        public CleanResult<T> GetResult()
        {
            try
            {
                var res = taskAwaiter.GetResult();

                if (state != CleanResultState.Success)
                {
                    return new CleanResult<T>(state, res, error);
                }

                switch (task.Status)
                {
                    case TaskStatus.Canceled:
                        return CleanResult<T>.Canceled();

                    case TaskStatus.Faulted:
                        return CleanResult<T>.Failed(new CleanResultException(task.Exception));

                    case TaskStatus.RanToCompletion:
                        return CleanResult<T>.Success(res);

                    case TaskStatus.Created:
                    case TaskStatus.Running:
                    case TaskStatus.WaitingForActivation:
                    case TaskStatus.WaitingForChildrenToComplete:
                    case TaskStatus.WaitingToRun:
                    default:
                        throw new InvalidOperationException();
                }
            }
            catch (TaskCanceledException)
            {
                return CleanResult<T>.Canceled();
            }
            catch (Exception e)
            {
                return CleanResult<T>.Failed(new CleanResultException(e));
            }
        }

        public void OnCompleted(Action continuation)
        {
            taskAwaiter.OnCompleted(continuation);
        }

        public void UnsafeOnCompleted(Action continuation)
        {
            taskAwaiter.UnsafeOnCompleted(continuation);
        }
    }

    /// <summary>
    /// 参考： https://ufcpp.net/study/csharp/sp5_awaitable.html#awaiter
    /// </summary>
    public readonly struct CleanResultTaskAwaiter : ICriticalNotifyCompletion, INotifyCompletion
    {
        private readonly CleanResultState state;
        private readonly CleanResultError error;
        private readonly Task task;
        private readonly TaskAwaiter taskAwaiter;

        public CleanResultTaskAwaiter(in CleanResult<Task> cleanResult)
        {
            state = cleanResult.State;
            error = cleanResult.Error;

            if (cleanResult.Result == null)
            {
                task = Task.CompletedTask;
            }
            else
            {
                task = cleanResult.Result;
            }

            taskAwaiter = task.GetAwaiter();
        }

        public bool IsCompleted => taskAwaiter.IsCompleted;

        public CleanResult<CleanResult.Void> GetResult()
        {
            try
            {
                taskAwaiter.GetResult();

                if (state != CleanResultState.Success)
                {
                    return new CleanResult<CleanResult.Void>(state, default, error);
                }

                switch (task.Status)
                {
                    case TaskStatus.Canceled:
                        return CleanResult.Canceled();

                    case TaskStatus.Faulted:
                        return CleanResult.Failed(new CleanResultException(task.Exception));

                    case TaskStatus.RanToCompletion:
                        return CleanResult.Success();

                    case TaskStatus.Created:
                    case TaskStatus.Running:
                    case TaskStatus.WaitingForActivation:
                    case TaskStatus.WaitingForChildrenToComplete:
                    case TaskStatus.WaitingToRun:
                    default:
                        throw new InvalidOperationException();
                }
            }
            catch (TaskCanceledException)
            {
                return CleanResult.Canceled();
            }
            catch (Exception e)
            {
                return CleanResult.Failed(new CleanResultException(e));
            }
        }

        public void OnCompleted(Action continuation)
        {
            taskAwaiter.OnCompleted(continuation);
        }

        public void UnsafeOnCompleted(Action continuation)
        {
            taskAwaiter.UnsafeOnCompleted(continuation);
        }
    }
}
