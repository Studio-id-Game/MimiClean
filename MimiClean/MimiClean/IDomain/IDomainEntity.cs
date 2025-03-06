namespace StudioIdGames.MimiClean.IDomain
{
    using MimiCleanContainer;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 概念レベルの設計に登場するオブジェクトを表すインターフェースです<br/>
    /// Domain層をinterface化するのは Bad Pattern なので非推奨になりました。
    /// </summary>
    [Obsolete("Use StudioIdGames.MimiClean.Domain.DomainEntity")]
    public interface IDomainEntity : ITransientService
    {
        /// <summary>
        /// このオブジェクトが利用している<see cref="DomainModule{TDomainEntity}"/>を列挙します。
        /// <see cref="DomainModule{TDomainEntity}"/>や<see cref="DomainModuleSet{TDomainEntity}"/>を利用する場合、必ずオーバーライドして正しく実装してください。
        /// </summary>
        /// <typeparam name="T">列挙するモジュールの型フィルター</typeparam>
        /// <returns></returns>
        IEnumerable<T> M<T>() where T : class, IDomainModule;
    }
}
