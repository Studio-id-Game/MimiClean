namespace StudioIdGames.MimiClean_Sample.Domain.IApp.IRepository
{
    using Entity;
    using MimiClean.Domain.IApp;
    using MimiCleanContainer;

    /// <summary>
    /// 全てのマップ情報リポジトリを抽象化します。
    /// </summary>
    [MimiServiceType(MimiServiceType.Static)]
    public interface IMapInfoRepository : IAppRepositoryMono<MapInfoEntity>
    {
    }
}
