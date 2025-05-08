using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace StudioIdGames.MimiClean.Railway
{
    /// <summary>
    /// レールウェイ指向プログラミング（Railway-Oriented Programming, ROP）に基づいたエラーハンドリングを扱うためのオブジェクトです。
    /// 合計メモリ数が16バイト以上 (<typeparamref name="TResult"/>が13バイト以上) の構造体の場合はパフォーマンスが著しく低下する可能性があります。
    /// </summary>　
    public readonly struct CleanResult<TResult> : ICleanResult<TResult>
    {
        private readonly CleanResultErrorToken errorToken;
        private readonly TResult result;
        private readonly CleanResultState state;

        /// <summary>
        /// <see cref="CleanResult{TResult}"/>のコンストラクタ
        /// </summary>
        /// <param name="result">操作に失敗していない場合、操作の結果の戻り値を表します</param>
        public CleanResult(TResult result)
        {
            this.result = result;
            errorToken = CleanResultErrorToken.Create();
            state = CleanResultState.Success;
        }

        /// <summary>
        /// <see cref="CleanResult{TResult}"/>のコンストラクタ
        /// </summary>
        /// <param name="result">操作に失敗していない場合、操作の結果の戻り値を表します</param>
        /// <param name="cancellationToken">存在する場合、この操作の<see cref="CancellationToken"/>を表します</param>
        public CleanResult(TResult result, CancellationToken cancellationToken)
        {
            this.result = result;
            errorToken = CleanResultErrorToken.Create();
            errorToken.AddCancel(cancellationToken);
            state = CleanResultState.Canceled;
        }

        /// <summary>
        /// <see cref="CleanResult{TResult}"/>のコンストラクタ
        /// </summary>
        /// <param name="result">操作に失敗していない場合、操作の結果の戻り値を表します</param>
        /// <param name="errors">操作に失敗した場合、エラーの内容を表します</param>
        public CleanResult(TResult result, IEnumerable<CleanResultError> errors)
        {
            if (errors is null || !errors.Any())
            {
                throw new ArgumentNullException(nameof(errors));
            }

            this.result = result;
            errorToken = CleanResultErrorToken.Create();
            foreach (var error in errors)
            {
                errorToken.AddError(error);
            }
            state = errorToken.LastState;
        }

        /// <summary>
        /// <see cref="CleanResult{TResult}"/>のコンストラクタ
        /// </summary>
        /// <param name="result">操作に失敗していない場合、操作の結果の戻り値を表します</param>
        /// <param name="errors">操作に失敗した場合、エラーの内容を表します</param>
        public CleanResult(TResult result, params CleanResultError[] errors) : this(result, (IEnumerable<CleanResultError>)errors)
        {
        }

        internal CleanResult(TResult result, CleanResultState state, CleanResultErrorToken errorToken)
        {
            this.state = state;
            this.result = result;
            this.errorToken = errorToken;
        }

        /// <inheritdoc/>
        public CleanResultErrorClose Close(out TResult result, out CleanResultState state)
        {
            result = this.result;
            state = this.state;
            return new CleanResultErrorClose(errorToken);
        }

        /// <inheritdoc/>
        public void Close(CleanResultCloser<TResult> closeFunc)
        {
            if (closeFunc is null)
            {
                throw new ArgumentNullException(nameof(closeFunc));
            }

            using (var close = new CleanResultErrorClose(errorToken))
            {
                closeFunc.Invoke(result, state, close);
            }
        }

        /// <inheritdoc/>
        public T Close<T>(CleanResultCloser<TResult, T> closeFunc)
        {
            if (closeFunc is null)
            {
                throw new ArgumentNullException(nameof(closeFunc));
            }

            using (var close = new CleanResultErrorClose(errorToken))
            {
                return closeFunc.Invoke(result, state, close);
            }
        }

        /// <inheritdoc/>
        public CleanResultErrorChain Chain(out TResult result, out CleanResultState state)
        {
            result = this.result;
            state = this.state;
            return new CleanResultErrorChain(errorToken);
        }

        /// <inheritdoc/>
        public CleanResult<T> Chain<T>(CleanResultChainer<TResult, T> chainFunc)
        {
            return CleanResultUtility.Chain(result, state, errorToken, chainFunc);
        }

        /// <inheritdoc/>
        public CleanResult<NoResult> Chain(CleanResultChainer<TResult> chainFunc)
        {
            return CleanResultUtility.Chain(result, state, errorToken, chainFunc);
        }

        /// <inheritdoc cref="CleanResultUtility.ToString{TResult}(TResult, CleanResultState, CleanResultErrorToken)"/>
        public override string ToString()
        {
            return CleanResultUtility.ToString(result, state, errorToken);
        }

        /// <inheritdoc/>
        public void ChainTo<T>(ref CleanResult<T> newResult, CleanResultChainer<TResult, T> chainFunc)
        {
            CleanResultUtility.ChainTo(ref newResult, result, state, errorToken, chainFunc);
        }

        /// <inheritdoc/>
        public void ChainTo(ref CleanResult<NoResult> newResult, CleanResultChainer<TResult> chainFunc)
        {
            CleanResultUtility.ChainTo(ref newResult, result, state, errorToken, chainFunc);
        }
    }
}
