namespace StudioIdGames.MimiClean_Sample.IApp.IRepository
{
    using MimiCleanContainer;
    using StudioIdGames.MimiClean.IApp;
    using StudioIdGames.MimiClean_Sample.Domain.Entity;

    /// <summary>
    /// 全てのマップ情報リポジトリを抽象化します。
    /// </summary>
    [MimiServiceType(MimiServiceType.Static)]
    public interface IMapInfoRepository : IAppRepositoryMono<MapInfoEntity>
    {
    }
}
