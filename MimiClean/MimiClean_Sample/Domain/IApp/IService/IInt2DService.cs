using StudioIdGames.MimiClean.Domain.IApp;
using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.IApp.IService
{
    /// <summary>
    /// <typeparamref name="TInt2D"/> で表される二次元整数座標の演算をserviceとして抽象化します。
    /// </summary>
    /// <typeparam name="TInt2D"></typeparam>
    [MimiServiceType(MimiServiceType.Static)]
    public interface IInt2DService<TInt2D> : IAppService
    {
        /// <summary>
        /// 座標の加算を表します。
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public TInt2D Add(in TInt2D a, in TInt2D b);

        /// <summary>
        /// x座標を取り出します。
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int GetX(in TInt2D pos);

        /// <summary>
        /// y座標を取り出します。
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int GetY(in TInt2D pos);

        /// <summary>
        /// 新しい座標を作成します。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public TInt2D New(int x, int y);
    }
}
