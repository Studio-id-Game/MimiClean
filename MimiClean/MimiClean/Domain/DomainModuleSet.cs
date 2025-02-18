using System.Collections;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Domain
{
    public class DomainModuleSet<TDomainEntity> : DomainModule<TDomainEntity>, IDomainModuleSet, IEnumerable<IDomainModule>
        where TDomainEntity : IDomainEntity
    {
        private readonly List<IDomainModule> customModules = new List<IDomainModule>();

        public DomainModuleSet(TDomainEntity entity, string moduleName = null) : base(entity, moduleName)
        {
        }

        protected IEnumerable<IDomainModule> CustomModules => customModules;

        public virtual int Count => customModules.Count;

        public virtual IEnumerable<T> Get<T>()
            where T : class, IDomainModule
        {
            foreach (var module in customModules)
            {
                if (module is T moduleT) yield return moduleT;
            }
        }

        public bool Add<T>()
            where T : class, IDomainModule, new()
        {
            return Add(new T());
        }

        public bool Add<T>(T value)
            where T : class, IDomainModule
        {
            foreach (var module in customModules)
            {
                if (module is T) return false;
            }

            customModules.Add(value);

            return true;
        }

        public bool Remove<T>(T value) where T : class, IDomainModule
        {
            if (customModules.Remove(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual IEnumerator<IDomainModule> GetEnumerator()
        {
            // yield return UniqueModule01; 
            // yield return UniqueModule02; 

            foreach (var module in customModules)
            {
                yield return module;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IDomainModule>)this).GetEnumerator();
        }
    }
}
