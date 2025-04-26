using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiCleanContainer_Sample
{
    /// <summary>
    /// サービス02の定義
    /// </summary>
    public interface IService02 : IStaticService
    {
        void Set(string t);

        void Print();
    }
}
