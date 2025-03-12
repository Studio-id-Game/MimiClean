namespace StudioIdGames.MimiClean
{
    /// <summary>
    /// レールウェイ指向プログラミング（Railway-Oriented Programming, ROP）に基づいたエラーハンドリングを戻り値型に依存せずに扱うためのインターフェース
    /// </summary>
    public interface ICleanResult
    {
        /// <summary>
        /// 操作の状態を表します
        /// </summary>
        CleanResultState State { get; }

        /// <summary>
        /// 操作に失敗している場合、エラーの内容を表します
        /// </summary>
        CleanResultError Error { get; }

        /// <summary>
        /// 操作に失敗していない場合、操作の結果の戻り値を表します
        /// </summary>
        object Result { get; }

        /// <summary>
        /// 操作が成功した場合のみtrueです。
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// 操作が中断した場合のみtrueです。
        /// </summary>
        bool IsCanceled { get; }

        /// <summary>
        /// 操作が失敗した場合のみtrueです。
        /// </summary>
        bool IsFailed { get; }
    }

    /// <summary>
    /// レールウェイ指向プログラミング（Railway-Oriented Programming, ROP）に基づいたエラーハンドリングを扱うためのインターフェース
    /// </summary>
    public interface ICleanResult<TResult> : ICleanResult
    {
        /// <summary>
        /// 操作に失敗していない場合、操作の結果の戻り値を表します
        /// </summary>
        new TResult Result { get; }

        /// <summary>
        /// 状態をチェックしながら操作の戻り値を取り出します。
        /// </summary>
        /// <param name="result">操作の戻り値が代入されます</param>
        /// <returns>操作の状態を表します</returns>
        CleanResultState TryGetValue(out TResult result);
    }
}
