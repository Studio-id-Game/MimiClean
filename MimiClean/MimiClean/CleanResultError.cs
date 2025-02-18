namespace StudioIdGames.MimiClean
{
    public abstract class CleanResultError
    {
        public abstract string Message { get; }

        public override string ToString()
        {
            return Message;
        }
    }
}

