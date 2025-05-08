namespace StudioIdGames.MimiClean.Railway
{
    /// <summary>
    /// レールウェイ指向プログラミング（Railway-Oriented Programming, ROP）に基づいたエラーハンドリングを戻り値型に依存せずに扱うためのインターフェース
    /// </summary>
    public interface ICleanResult : ICleanResultActions
    {
    }

    /// <summary>
    /// レールウェイ指向プログラミング（Railway-Oriented Programming, ROP）に基づいたエラーハンドリングを扱うためのインターフェース
    /// </summary>
    public interface ICleanResult<TResult> : ICleanResult, ICleanResultActions<TResult>
    {
    }
}
