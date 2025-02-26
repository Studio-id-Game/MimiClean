namespace StudioIdGames.MimiClean_Sample.Domain.IApp.UseCaseIO
{
    public readonly struct SearchItemsInput(string name)
    {
        public readonly string name = name;
    }
}
