namespace StudioIdGames.MimiClean.Domain
{
    using IDomain;
    using MimiCleanContainer;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 概念層の設計に登場するオブジェクトを表す抽象クラスです
    /// </summary>
#pragma warning disable CS0618 // 型またはメンバーが旧型式です

    public abstract class DomainEntity : IDomainEntity
#pragma warning restore CS0618 // 型またはメンバーが旧型式です
    {
        [Obsolete("This feature is no longer useful.")]
        protected readonly ref struct CreateEntityScope
        {
            private readonly IApp.ICurrentEntityService service;
            public readonly IDomainEntity prevEntity;

            public CreateEntityScope(MimiServiceProvider mimiServiceProvider, IDomainEntity newEntiry)
            {
                service = mimiServiceProvider.GetMimiService<IApp.ICurrentEntityService>();
                prevEntity = service.CurrentEntity;

                service.CurrentEntity = newEntiry;
            }

            public void Dispose()
            {
                service.CurrentEntity = prevEntity;
            }
        }

        public DomainEntity()
        {
        }

        [Obsolete("This feature is no longer useful.")]
        public DomainEntity(MimiServiceProvider _)
        {
            /*
            using(new CreateEntityScope(mimiServiceProvider, this))
            {
            }
            */
        }

        /// <summary>
        /// このオブジェクトが利用している<see cref="DomainModule"/>を列挙します。
        /// <see cref="DomainModule"/>や<see cref="DomainModuleSet"/>を利用する場合、必ずオーバーライドして正しく実装してください。<br/>
        /// IDomainModule が完全に廃止された時の<see cref="M{T}"/>の動作です。
        /// </summary>
        /// <typeparam name="T">列挙するモジュールの型フィルター</typeparam>
        /// <returns></returns>
#pragma warning disable IDE1006 // 命名スタイル

        public virtual IEnumerable<T> M_v2<T>() where T : DomainModule
#pragma warning restore IDE1006 // 命名スタイル
        {
            yield break;
        }

        /// <inheritdoc/>
        [Obsolete("IDomainEntity is Obsoleted.")]
        public virtual IEnumerable<T> M<T>() where T : class, IDomainModule
        {
            var items = M_v2<DomainModule>();
            foreach (var item in items)
            {
                if (item is T itemT)
                {
                    yield return itemT;
                }
            }
        }
    }
}
