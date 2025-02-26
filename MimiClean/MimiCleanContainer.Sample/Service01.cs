using StudioIdGames.MimiCleanContainer;

namespace StudioIdGames.MimiCleanContainerSample
{
    public class Service01_1 : IService01
    {
        private string text = "DEFAULT-1";

        public string Text { get => "[01_1]" + text; set => text = value; }
    }

    public class Service01_2 : IService01
    {
        private string text = "DEFAULT-2";

        public string Text { get => "[01_2]" + text; set => text = value; }
    }

    [MimiServiceType(MimiServiceType.Singleton)]
    public class Service01_Singleton : IService01
    {
        private string text = "DEFAULT-Singleton";

        public string Text { get => "[01_Singleton]" + text; set => text = value; }
    }

    [MimiServiceType(MimiServiceType.Scoped)]
    public class Service01_Scoped : IService01
    {
        private string text = "DEFAULT-Scoped";

        public string Text { get => "[01_Scoped]" + text; set => text = value; }
    }

    [MimiServiceType(MimiServiceType.Transient)]
    public class Service01_Transient : IService01
    {
        private string text = "DEFAULT-Transient";

        public string Text { get => "[01_Transient]" + text; set => text = value; }
    }
}
