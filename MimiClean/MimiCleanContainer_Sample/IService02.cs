using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiCleanContainer_Sample
{
    /// <summary>
    /// サービス02の定義
    /// </summary>
    public interface IService02 : IStaticService
    {
        public void Set(string t);

        public void Print();
    }
}
