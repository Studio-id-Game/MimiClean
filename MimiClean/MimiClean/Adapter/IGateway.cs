namespace StudioIdGames.MimiClean.Adapter
{
    public interface IGateway<TInput>
    {
        CleanResult<TInput> MakeInput();
    }
}