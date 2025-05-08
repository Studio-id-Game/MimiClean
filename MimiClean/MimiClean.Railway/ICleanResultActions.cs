namespace StudioIdGames.MimiClean.Railway
{
    /// <summary>
    /// レールウェイ指向プログラミング（Railway-Oriented Programming, ROP）に基づいたエラーハンドリングの為の操作を表すインターフェース
    /// </summary>
    public interface ICleanResultActions
    {
    }

    /// <summary>
    /// レールウェイ指向プログラミング（Railway-Oriented Programming, ROP）に基づいたエラーハンドリングの為の操作を表すインターフェース
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface ICleanResultActions<TResult> : ICleanResultActions
    {
        /// <summary>
        /// このResultから新しい<see cref="CleanResult{TResult}"/>を作成するために、<see cref="CleanResultErrorChain"/>と現在の値と状態を取得します。
        /// </summary>
        /// <param name="result">現在の値</param>
        /// <param name="state">現在の状態</param>
        /// <returns>新しい<see cref="CleanResult{TResult}"/>を作成するための<see cref="CleanResultErrorChain"/></returns>
        CleanResultErrorChain Chain(out TResult result, out CleanResultState state);

        /// <summary>
        /// このResultから新しい<see cref="CleanResult{TResult}"/>を作成するために、<see cref="CleanResultErrorChain"/>と現在の値と状態を取得します。
        /// </summary>
        /// <param name="chainFunc">値を更新する関数</param>
        /// <returns>新しい<see cref="CleanResult{TResult}"/></returns>
        CleanResult<T> Chain<T>(CleanResultChainer<TResult, T> chainFunc);

        /// <summary>
        /// このResultから新しい<see cref="CleanResult{TResult}"/>を作成するために、<see cref="CleanResultErrorChain"/>と現在の値と状態を取得します。
        /// </summary>
        /// <param name="chainFunc">値を更新する関数</param>
        /// <returns>新しい<see cref="CleanResult{TResult}"/></returns>
        CleanResult<NoResult> Chain(CleanResultChainer<TResult> chainFunc);

        /// <summary>
        /// このResultから他の<see cref="CleanResult{TResult}"/>を更新するために、<see cref="CleanResultErrorChain"/>と現在の値と状態を取得します。
        /// </summary>
        /// <param name="newResult">代入先</param>
        /// <param name="chainFunc">値を更新する関数</param>
        void ChainTo<T>(ref CleanResult<T> newResult, CleanResultChainer<TResult, T> chainFunc);

        /// <summary>
        /// このResultから他の<see cref="CleanResult{TResult}"/>を更新するために、<see cref="CleanResultErrorChain"/>と現在の値と状態を取得します。
        /// </summary>
        /// <param name="newResult">代入先</param>
        /// <param name="chainFunc">値を更新する関数</param>
        void ChainTo(ref CleanResult<NoResult> newResult, CleanResultChainer<TResult> chainFunc);

        /// <summary>
        /// このResultを利用するために、<see cref="CleanResultErrorClose"/>と現在の値と状態を取得します。
        /// </summary>
        /// <param name="result">現在の値</param>
        /// <param name="state">現在の状態</param>
        /// <returns>破棄する必要のあるリソース</returns>
        CleanResultErrorClose Close(out TResult result, out CleanResultState state);

        /// <summary>
        /// このResultを利用するために、<see cref="CleanResultErrorClose"/>と現在の値と状態を取得します。
        /// </summary>
        /// <param name="chainAction">値を利用する関数</param>
        void Close(CleanResultCloser<TResult> chainAction);

        /// <summary>
        /// このResultを利用するために、<see cref="CleanResultErrorClose"/>と現在の値と状態を取得します。
        /// </summary>
        /// <param name="chainFunc">値を利用する関数</param>
        /// <returns></returns>
        T Close<T>(CleanResultCloser<TResult, T> chainFunc);
    }
}
