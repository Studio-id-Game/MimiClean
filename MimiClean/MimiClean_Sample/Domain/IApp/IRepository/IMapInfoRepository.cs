namespace StudioIdGames.MimiClean_Sample.Domain.IApp.IRepository
{
    using MimiClean.Domain.IApp;
    using MimiCleanContainer;
    using Entity;

    /// <summary>
    /// 全てのマップ情報リポジトリを抽象化します。
    /// </summary>
    [MimiServiceType(MimiServiceType.Static)]
    public interface IMapInfoRepository : IAppRepositoryMono<MapInfoEntity>
    {
    }
}
