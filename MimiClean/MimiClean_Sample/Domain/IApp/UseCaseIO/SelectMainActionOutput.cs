namespace StudioIdGames.MimiClean_Sample.Domain.IApp.UseCaseIO
{
    using Domain.DomainType;

    public readonly struct SelectMainActionOutput(MainActions mainAction)
    {
        public readonly MainActions mainAction = mainAction;
    }
}
