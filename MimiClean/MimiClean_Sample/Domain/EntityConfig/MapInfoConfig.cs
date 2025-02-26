using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiClean_Sample.Domain.EntityConfig
{
    public class MapInfoConfig : IScopedService
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public MapInfoConfig SetHeight(int height)
        {
            Height = height;
            return this;
        }

        public MapInfoConfig SetWidth(int width)
        {
            Width = width;
            return this;
        }
    }
}
