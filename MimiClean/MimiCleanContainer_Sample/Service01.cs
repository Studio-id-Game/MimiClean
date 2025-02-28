using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiCleanContainer_Sample
{
    /// <summary>
    /// <see cref="IService01"/>の実装
    /// </summary>
    public class Service01_Default : IService01
    {
        private string text = "DEFAULT-Default";

        public string Text { get => "[01_Default]" + text; set => text = value; }
    }

    /// <summary>
    /// <see cref="IService01"/>の実装（<see cref="MimiServiceType.Static"/> で上書き）
    /// </summary>
    [MimiServiceType(MimiServiceType.Static)]
    public class Service01_Static : IService01
    {
        private string text = "DEFAULT-Static";

        public string Text { get => "[01_Static]" + text; set => text = value; }
    }

    /// <summary>
    /// <see cref="IService01"/>の実装（<see cref="MimiServiceType.Singleton"/> で上書き）
    /// </summary>
    [MimiServiceType(MimiServiceType.Singleton)]
    public class Service01_Singleton : IService01
    {
        private string text = "DEFAULT-Singleton";

        public string Text { get => "[01_Singleton]" + text; set => text = value; }
    }

    /// <summary>
    /// <see cref="IService01"/>の実装（<see cref="MimiServiceType.Scoped"/> で上書き）
    /// </summary>
    [MimiServiceType(MimiServiceType.Scoped)]
    public class Service01_Scoped : IService01
    {
        private string text = "DEFAULT-Scoped";

        public string Text { get => "[01_Scoped]" + text; set => text = value; }
    }

    /// <summary>
    /// <see cref="IService01"/>の実装（<see cref="MimiServiceType.Transient"/> で上書き）
    /// </summary>
    [MimiServiceType(MimiServiceType.Transient)]
    public class Service01_Transient : IService01
    {
        private string text = "DEFAULT-Transient";

        public string Text { get => "[01_Transient]" + text; set => text = value; }
    }
}
