using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.EntityConfig
{
    /// <summary>
    /// <see cref="IMimiService"/> を初期化する為に必要な情報をサービスとして提供します。
    /// </summary>
    public class MapInfoConfig : IScopedService
    {
        /// <summary>
        /// Mapの高さ
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// マップの幅
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Mapの高さをセットします。このメソッドはチェーン可能です。
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public MapInfoConfig SetHeight(int height)
        {
            Height = height;
            return this;
        }

        /// <summary>
        /// Mapの幅をセットします。このメソッドはチェーン可能です。
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public MapInfoConfig SetWidth(int width)
        {
            Width = width;
            return this;
        }
    }
}
