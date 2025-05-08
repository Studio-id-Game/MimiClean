using StudioIdGames.MimiClean.Railway.CleanResultErrors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace StudioIdGames.MimiClean.Railway
{
    /// <summary>
    /// <see cref="CleanResult{TResult}"/>のためのエラーリストを表現するクラス
    /// </summary>
    internal sealed class CleanResultErrorList : ICleanResultErrorList, IDisposable
    {
        private List<CleanResultError> cleanResultErrors = new List<CleanResultError>();

        /// <inheritdoc/>
        public CleanResultState LastState { get; private set; } = CleanResultState.Success;

        /// <inheritdoc/>
        public int Count => cleanResultErrors.Count;

        /// <inheritdoc/>
        public void AddError(CleanResultError error)
        {
            if (LastState == CleanResultState.Used)
            {
                throw new InvalidOperationException("This CleanResultErrorList is Disposed.");
            }

            if (error == null) return;

            switch (LastState)
            {
                case CleanResultState.Canceled:
                    if (!(error is CancellationByUserError))
                    {
                        cleanResultErrors.Add(error);
                    }
                    break;

                case CleanResultState.Success:
                    cleanResultErrors.Add(error);
                    if (error is CancellationByUserError)
                    {
                        LastState = CleanResultState.Canceled;
                    }
                    else
                    {
                        LastState = CleanResultState.Failed;
                    }
                    break;

                case CleanResultState.Failed:
                    cleanResultErrors.Add(error);
                    if (error is CancellationByUserError)
                    {
                        LastState = CleanResultState.Canceled;
                    }
                    break;

                default:
                    throw new NotSupportedException("予期しない値");
            }
        }

        /// <inheritdoc/>
        public void FixError(Predicate<CleanResultError> errorCheck)
        {
            if (LastState == CleanResultState.Used)
            {
                throw new InvalidOperationException("This CleanResultErrorList is Disposed.");
            }

            if (errorCheck == null) return;
            switch (LastState)
            {
                case CleanResultState.Success:
                    break;

                case CleanResultState.Failed:
                case CleanResultState.Canceled:
                    var count = cleanResultErrors.Count;
                    var removed = cleanResultErrors.RemoveAll(e =>
                    {
                        if (!errorCheck(e))
                        {
                            return false;
                        }
                        else if (e is CancellationByUserError)
                        {
                            throw new ArgumentException("ユーザーによるCancel操作を解決する事は許可されません");
                        }
                        else
                        {
                            return true;
                        }
                    });

                    if (removed == count)
                    {
                        LastState = CleanResultState.Success;
                    }
                    break;

                default:
                    throw new NotSupportedException("予期しない値");
            }
        }

        /// <inheritdoc/>
        /// <inheritdoc/>
        public void AddCancel(CancellationToken cancellationToken)
        {
            if (LastState == CleanResultState.Used)
            {
                throw new InvalidOperationException("This CleanResultErrorList is Disposed.");
            }

            switch (LastState)
            {
                case CleanResultState.Canceled:
                case CleanResultState.Success:
                case CleanResultState.Failed:
                    AddError(new CancellationByUserError(cancellationToken));
                    break;

                default:
                    throw new NotSupportedException("予期しない値");
            }
        }

        /// <inheritdoc/>
        public IEnumerator<CleanResultError> GetEnumerator()
        {
            if (LastState == CleanResultState.Used)
            {
                throw new InvalidOperationException("This CleanResultErrorList is Disposed.");
            }
            return cleanResultErrors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            LastState = CleanResultState.Used;
            cleanResultErrors = null;
        }
    }
}
