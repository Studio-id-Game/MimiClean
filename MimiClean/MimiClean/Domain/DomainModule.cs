namespace StudioIdGames.MimiClean.Domain
{
    public abstract class DomainModule<TDomainEntity> : IDomainModule
        where TDomainEntity : IDomainEntity
    {
        protected DomainModule(TDomainEntity entity, string moduleName = null)
        {
            Entity = entity;
            ModuleName = moduleName ?? GetType().Name;
        }

        public TDomainEntity Entity { get; }

        public string ModuleName { get; }

        IDomainEntity IDomainModule.Entity => Entity;
    }
}
