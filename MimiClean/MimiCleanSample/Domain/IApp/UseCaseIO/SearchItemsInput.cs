namespace StudioIdGames.MimiCleanSample.Domain.IApp.UseCaseIO
{
    public readonly struct SearchItemsInput(string name)
    {
        public readonly string name = name;
    }
}
