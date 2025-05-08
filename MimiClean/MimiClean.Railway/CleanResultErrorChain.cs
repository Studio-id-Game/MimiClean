using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace StudioIdGames.MimiClean.Railway
{
    /// <summary>
    /// <see cref="CleanResult{TResult}"/>から新しい<see cref="CleanResult{TResult}"/>を作成するための機能を提供します。
    /// エラーリストの読み取りと変更、最新の状態へのアクセス、新しいResultの生成機能を提供します。
    /// </summary>
    public readonly struct CleanResultErrorChain : ICleanResultErrorList, IEquatable<CleanResultErrorChain>
    {
        private readonly CleanResultErrorToken errorToken;

        /// <summary>
        ///
        /// </summary>
        /// <param name="errorToken"></param>
        public CleanResultErrorChain(CleanResultErrorToken errorToken)
        {
            this.errorToken = errorToken;
        }

        /// <inheritdoc/>
        public CleanResultState LastState => errorToken.LastState;

        /// <inheritdoc/>
        public int Count => errorToken.Count;

        /// <inheritdoc/>
        public void AddCancel(CancellationToken cancellationToken)
        {
            errorToken.AddCancel(cancellationToken);
        }

        /// <inheritdoc/>
        public void AddError(CleanResultError error)
        {
            errorToken.AddError(error);
        }

        /// <inheritdoc/>
        public void FixError(Predicate<CleanResultError> errorCheck)
        {
            errorToken.FixError(errorCheck);
        }

        /// <inheritdoc/>
        public IEnumerator<CleanResultError> GetEnumerator()
        {
            return errorToken.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return errorToken.GetEnumerator();
        }

        /// <summary>
        /// この<see cref="CleanResultErrorChain"/>に、他の<see cref="CleanResultErrorChain"/>を統合します。<paramref name="other"/>のリソースは破棄されます。
        /// </summary>
        /// <param name="other"></param>
        public void Join(CleanResultErrorChain other)
        {
            var otherToken = other.errorToken;
            if (errorToken == other.errorToken) return;

            foreach (var error in otherToken)
            {
                errorToken.AddError(error);
            }

            otherToken.Dispose();
        }

        /// <summary>
        /// 現在の状態とエラーリストと新しい値を含めた<see cref="CleanResult{TResult}"/>を作成します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public CleanResult<T> With<T>(T newValue)
        {
            return new CleanResult<T>(newValue, errorToken.LastState, errorToken);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is CleanResultErrorChain chain && Equals(chain);
        }

        /// <inheritdoc/>
        public bool Equals(CleanResultErrorChain other)
        {
            return errorToken.Equals(other.errorToken);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return -1979387722 + errorToken.GetHashCode();
        }

        /// <inheritdoc/>
        public static bool operator ==(CleanResultErrorChain left, CleanResultErrorChain right)
        {
            return left.Equals(right);
        }

        /// <inheritdoc/>
        public static bool operator !=(CleanResultErrorChain left, CleanResultErrorChain right)
        {
            return !(left == right);
        }
    }
}
