namespace StudioIdGames.MimiClean.Domain
{
    public readonly struct DomainModuleUpdateInfo
    {
        public DomainModuleUpdateInfo(IDomainModule module, IDomainEntity entity, string reason, object oldValue, object newValue)
        {
            Module = module;
            Entity = entity;
            Reason = reason;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public IDomainModule Module { get; }
        public IDomainEntity Entity { get; }
        public string Reason { get; }
        public object OldValue { get; }
        public object NewValue { get; }
    }
}
