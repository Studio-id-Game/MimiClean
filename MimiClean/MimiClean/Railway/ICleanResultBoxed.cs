namespace StudioIdGames.MimiClean.Railway
{
    using System;

    /// <summary>
    /// <see cref="CleanResultBoxed{TResult}"/>を戻り値型に依存せずに扱うためのインターフェース
    /// </summary>
    [Obsolete("Use ICleanResult")]
    public interface ICleanResultBoxed : ICleanResult
    {
    }
}
