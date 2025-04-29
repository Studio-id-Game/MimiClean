namespace StudioIdGames.MimiClean.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// 概念層の設計に登場するオブジェクトを表す抽象クラスです
    /// </summary>

    public abstract class DomainEntity
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        public DomainEntity()
        {
        }

        /// <summary>
        /// このオブジェクトが利用している<see cref="DomainModule"/>を列挙します。
        /// <see cref="DomainModule"/>や<see cref="DomainModuleSet"/>を利用する場合、必ずオーバーライドして正しく実装してください。<br/>
        /// IDomainModule が完全に廃止された時の<see cref="M{T}"/>の動作です。
        /// </summary>
        /// <typeparam name="T">列挙するモジュールの型フィルター</typeparam>
        /// <returns></returns>

        public virtual IEnumerable<T> M<T>() where T : DomainModule
        {
            yield break;
        }
    }
}
