using StudioIdGames.MimiClean.IDomain;

namespace StudioIdGames.MimiClean_Sample.IDomain.IModule
{
    /// <summary>
    /// 全てのアイテム名モジュールを抽象化します。
    /// </summary>
    public interface INameModule : IDomainModule
    {
        /// <summary>
        /// アイテム名
        /// </summary>
        string ItemName { get; set; }
    }
}
