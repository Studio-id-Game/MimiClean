using System.Collections.Generic;

namespace StudioIdGames.MimiClean.Domain
{
    /// <summary>
    /// 概念層の設計に登場するオブジェクトを表す抽象クラスです
    /// </summary>
    public abstract class DomainEntity : IDomainEntity
    {
        /// <inheritdoc/>
        public virtual IEnumerable<T> M<T>() where T : class, IDomainModule
        {
            yield break;
        }
    }
}
