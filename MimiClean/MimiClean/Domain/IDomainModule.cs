namespace StudioIdGames.MimiClean.Domain
{
    public interface IDomainModule
    {
        IDomainEntity Entity { get; }

        string ModuleName { get; }
    }
}
