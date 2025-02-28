using StudioIdGames.MimiCleanContainer;
using System;
using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Domain
{
    using IApp;
    using IDomain;

    /// <summary>
    /// 概念層の設計に登場するオブジェクトを表す抽象クラスです
    /// </summary>
    public abstract class DomainEntity : IDomainEntity
    {
        protected readonly ref struct CreateEntityScope : IDisposable
        {
            private readonly ICurrentEntityService service;
            public readonly IDomainEntity prevEntity;

            public CreateEntityScope(MimiServiceProvider mimiServiceProvider, IDomainEntity newEntiry)
            {
                service = mimiServiceProvider.GetMimiService<ICurrentEntityService>();
                prevEntity = service.CurrentEntity;

                service.CurrentEntity = newEntiry;
            }

            public void Dispose()
            {
                service.CurrentEntity = prevEntity;
            }
        }

        public DomainEntity(MimiServiceProvider _)
        {
            /*
            using(new CreateEntityScope(mimiServiceProvider, this))
            {
            }
            */
        }

        /// <inheritdoc/>
        public virtual IEnumerable<T> M<T>() where T : class, IDomainModule
        {
            yield break;
        }
    }
}
